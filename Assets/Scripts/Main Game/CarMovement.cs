using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    public float concentration = 0.4f;
    public float airresistance = 0.1f;

    private bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
// TODO: add Error handling
        //EEGData.instance.Connect();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (grounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(concentration, 0));
        }

        if (gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-(gameObject.GetComponent<Rigidbody2D>().velocity.x * airresistance), 0));
        }
        //concentration = 0.1f * EEGData.instance.readAttentionValues(1)[0];
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
