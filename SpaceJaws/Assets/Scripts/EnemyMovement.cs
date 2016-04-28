using UnityEngine;
using System.Collections;

public class EnemyMovement : Movement {
    //stop time after getting shot
    public float shotDelay;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {

        if (otherCollider.gameObject.name.Contains("Boundary"))
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
            float delay = shotDelay; 
            Stop();
            while(delay > 0)
            {
                print(delay);
                delay -= Time.deltaTime;
            }
            Go();

        }

    }
}
