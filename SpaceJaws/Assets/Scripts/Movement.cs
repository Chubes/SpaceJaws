using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    //designer variabbles
    //speed
    public Vector2 speed = new Vector2(10, 10);
    protected float speed_x = 0;
    protected float speed_y = 0;
  
   
    //Moving Direction
    public Vector2 direction = new Vector2(-1, 0);

    //boundary y translation
    public float yTrans = 0;
    protected Vector2 movement;

  
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
            movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
       
        //kill object if out of bounds
        if (transform.position.y >= 18.7f)
        {
            Destroy(gameObject);
        }

        
	}
    void FixedUpdate(){
        GetComponent<Rigidbody2D>().velocity = movement;

    }

    public void Stop()
    {
        speed_x = speed.x;
        speed_y = speed.y;
        speed.x = 0;
        speed.y = 0;
    }

    public void Go()
    {
        speed.x = speed_x;
        speed.y = speed_y;
    }
    
    void OnCollisionEnter2D(Collision2D otherCollider)
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
      
    }
}
