using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public int rotationMultiplier = 10;
    public float concentration = 0.4f;

    private bool grounded = false;
    private float fuel = 30.0f;
    private float maxSpeed;
    private float airresistance;
    private float acceleration;
    private float starttime = 0;
    private List<int> attentionvalues = new List<int>();
    private int nextAttentionValue;
    private int previousAttentionValue;
    private bool hasEnded = false;
    public AudioClip audioClip;
    AudioManager audioManager;
    private ParticleSystem particleSys;
    // Start is called before the first frame update
    void Start()
    {
        //4 testing only
        PlayerPrefs.SetFloat("AirResistance", 0.1f);
        PlayerPrefs.SetFloat("Acceleration", 0.12f);
        PlayerPrefs.SetInt("MaxSpeed", 50);
        PlayerPrefs.SetInt("TankCapacity", 20);
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        nextAttentionValue = 0;
        // TODO: add Error handling
        EEGData.instance.Connect();
        EEGData.instance.startAutoRead();
        fuel = PlayerPrefs.GetInt("TankCapacity");
        maxSpeed = PlayerPrefs.GetInt("MaxSpeed");
        airresistance = PlayerPrefs.GetFloat("AirResistance");
        acceleration = PlayerPrefs.GetFloat("Acceleration");
        starttime = Time.time;
    }

    private void Update()
    {
        previousAttentionValue = nextAttentionValue;
        new Thread(() =>
        {
            nextAttentionValue = EEGData.instance.nextAttentionValue();
        }).Start();
        if (nextAttentionValue == 0)
        {
            UIOverlay.instance.pauseGame(true, true);
        }
        else
        {
            UIOverlay.instance.pauseGame(false);
            if (nextAttentionValue != previousAttentionValue)
            {
                GameObject.Find("SaveManager").GetComponent<SaveData>().updateSaveSlotdataMap(nextAttentionValue);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (nextAttentionValue > 0)
        {
            concentration = acceleration * nextAttentionValue;
            fuel -= Time.deltaTime;
            UIOverlay.instance.updatefuel(fuel);
            UIOverlay.instance.updateAttention(nextAttentionValue);
            attentionvalues.Add(nextAttentionValue);
        }
        if (grounded)
        {
            ParticleSystem.EmissionModule eM = GameObject.Find("Exhaust").GetComponent<ParticleSystem>().emission;
            if (fuel > 0.0f && gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < maxSpeed)
            {
                gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(concentration, 0));
                eM.rateOverTime = (5.0f * concentration);
            }
            if (fuel < 0.0f)
            {
                eM.rateOverTime = 0.0f;
                GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().StopEngine();
            }
        }
        else
        {
            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                gameObject.transform.Rotate(0.0f, 0.0f, 0.1f * rotationMultiplier, Space.Self);
            }
            else if (Input.GetKey("d") || Input.GetKey("right"))
            {
                gameObject.transform.Rotate(0.0f, 0.0f, -0.1f * rotationMultiplier, Space.Self);
            }
        }

        if (gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-(gameObject.GetComponent<Rigidbody2D>().velocity.x * airresistance), 0));
        }

        //EndConditions

        if (fuel <= -5.0f && !hasEnded) //-5 to have 5 seconds spare
        {
            GameObject.Find("GameManager").GetComponent<Stats>().setConcentrationPoints((int)((attentionvalues.Sum() / attentionvalues.Count) * (Time.time - starttime) * 0.001));
            GameObject.Find("GameManager").GetComponent<Stats>().save();
            int averageA = attentionvalues.Sum() / attentionvalues.Count;
            int peakA = 0;
            int lowA = 100;
            float time = Time.time - starttime;
            int points = (int)((attentionvalues.Sum() / attentionvalues.Count) * (Time.time - starttime) * 0.001);
            int coins = GameObject.Find("GameManager").GetComponent<Stats>().getCurrCoins();
            foreach (int i in attentionvalues)
            {
                if (peakA < i)
                {
                    peakA = i;
                }
                if (lowA > i)
                {
                    lowA = i;
                }
            }
            EEGData.instance.stopAutoRead();
            UIOverlay.instance.showEndScreen(averageA, peakA, lowA, time, points, coins);
            hasEnded = true;
        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            grounded = true;
        }
        if (collision.gameObject.layer == 8)
        {
            audioManager.PlaySFX(audioClip);
            Destroy(collision.gameObject.transform.parent.gameObject);
            fuel = PlayerPrefs.GetInt("TankCapacity");
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().PlayEngine();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            grounded = false;
            gameObject.GetComponent<Rigidbody2D>().totalForce.Set(0f, 0f);
        }
    }
}
