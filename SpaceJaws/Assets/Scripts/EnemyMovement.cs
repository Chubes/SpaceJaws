using UnityEngine;
using System.Collections;

public class EnemyMovement : Movement {
    //stop time after getting shot
    public float shotDelay = 0;
    public float delay = 0;
    // Update is called once per frame
    void Update()
    {
        if (delay <= 0)
        {
            movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
        }
        else
        {
            movement = new Vector2(0, 0);
            delay -= Time.deltaTime;
           
        }
        //kill object if out of bounds
        if (transform.position.y >= 18.7f)
        {
            Destroy(gameObject);
        }


    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;

    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {

        if (otherCollider.tag == "Boundary")
        {

            Stop();
            transform.Translate(0, yTrans, 0, Space.World);
            this.direction.x *= -1;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

            Go();
        }
        if (otherCollider.tag == "Shot")
        {
            delay = shotDelay;
          
        }

    }
}
