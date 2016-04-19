using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    public Transform shotPrefab;
    public float shootingRate = .25f; 
    private float shotCooldown;
    private bool facingRight = true;


    // Use this for initialization
    void Start()
    {
        shotCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shotCooldown > 0)
        {
            shotCooldown -= Time.deltaTime;
        }
        
    }

    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shotCooldown = shootingRate;
            //create new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            //assign poisition
            shotTransform.position = transform.position;

            //enemy property
            Shot bullet = shotTransform.gameObject.GetComponent<Shot>();
            if (bullet != null)
            {
                bullet.isEnemyShot = isEnemy;
            }
           
            if (!facingRight && (shotTransform.transform.localScale.x > 0))
            {
                Vector3 rotate = shotTransform.transform.localScale;
                rotate.x *= -1;
                shotTransform.transform.localScale = rotate;
                print("bullet facing left" + " " + shotTransform.transform.localScale.x);
            } 
            //make weapon shoot to the right
            Movement move = shotTransform.gameObject.GetComponent<Movement>();
            if (move != null)
            {
                move.direction = this.transform.right;
                
            }
        }
    }

    public bool CanAttack
    {
        get
        {
            return shotCooldown <= 0F;
        }
    }
    public bool FacingRight
    {
        get { return facingRight; }
        set { 
  
            facingRight = value; 
        }
    }
}