using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
   
    
    public Vector2 speed = new Vector2(25, 25);
    private float speed_x = 25;
    private float speed_y = 25;
    private Vector2 movement;
    private bool facingRight = true;
    public bool FacingRight
    {
        get { return facingRight; }
    }

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
       
        Health hp = this.GetComponent<Health>();
        if (hp != null)
        {
            hp.Kill();
        
        }
    }
    
    
    
    
    
    // Update is called once per frame
	 
    void Update () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        //turn left
        if (inputX < 0 && facingRight) { 
          
            transform.Rotate(Vector3.forward * 180);
            
            
            facingRight = false;
            GetComponentInChildren<Weapon>().FacingRight = facingRight;
        }
        //turn right
        if (inputX > 0 && !facingRight)
        {
          
            transform.Rotate(Vector3.forward * 180);
            facingRight = true;
            GetComponentInChildren<Weapon>().FacingRight = facingRight;
        }
        movement = new Vector2(speed.x * inputX, speed.y * inputY);

        // 6 - Make sure we are not outside the camera bounds
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder + 0.5f, bottomBorder - 0.5f),
          transform.position.z
        );

        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            Weapon weapon = GetComponentInChildren<Weapon>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
        }
	}

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
    private void Stop()
    {
        speed_x = speed.x;
        speed_y = speed.y;
        speed.x = 0;
        speed.y = 0;
    }
   
}
