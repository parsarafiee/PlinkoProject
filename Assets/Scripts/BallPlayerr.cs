using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlayerr : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;


    bool ballReleased = false;
    bool winGame = false;
    bool lose = false;

    // Start is called before the first frame update
    void Start()
    {

        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ballReleased)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector3 pos = transform.position;
                pos.x += speed * Time.deltaTime;
                transform.position = pos;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Vector3 pos = transform.position;
                pos.x += -speed * Time.deltaTime;
                transform.position = pos;
            }

        }
        if (Input.GetKey(KeyCode.Space))
        {
            ballReleased = true;
            rb.isKinematic = false;
        }

        if (winGame)
        {

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "winZone")
        {
            winGame = true;
        }

        if (collision.collider.tag == "LoseZone")
        {
            lose = true;
        }
        if (collision.collider.tag == "Cylander")
        {

            this.GetComponent<MeshRenderer>().material.color = collision.gameObject.GetComponent<MeshRenderer>().material.color;
        }
    }


}
