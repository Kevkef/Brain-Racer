using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public int rotationMultiplier = 10;
    public float concentration = 0.4f;
    public float airresistance = 0.1f;

    private bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
// TODO: add Error handling
        EEGData.instance.Connect();
        EEGData.instance.startAutoRead();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int nextAttentionValue = EEGData.instance.nextAttentionValue();
        if (nextAttentionValue >= 0)
        {
            concentration = 0.1f * nextAttentionValue;
        }
        if (grounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(concentration, 0));
        } else
        {
            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                gameObject.transform.Rotate(0.0f, 0.0f, 0.1f * rotationMultiplier, Space.Self);
            } else if (Input.GetKey("d") || Input.GetKey("right"))
            {
                gameObject.transform.Rotate(0.0f, 0.0f, -0.1f * rotationMultiplier, Space.Self);
            }
        }

        if (gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-(gameObject.GetComponent<Rigidbody2D>().velocity.x * airresistance), 0));
        }

        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            grounded = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            grounded = false;
            gameObject.GetComponent<Rigidbody2D>().totalForce.Set(0f, 0f);
        }
    }
}
