using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public int hp = 1;
    public bool isEnemy = true;


    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void Kill()
    {
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
       
        //check if it is a bullet/shot
        Shot bullet = otherCollider.gameObject.GetComponent<Shot>();
        if (bullet != null)
        {
            
            if (bullet.isEnemyShot != isEnemy)
            {
                Damage(bullet.damage);

                Destroy(bullet.gameObject);
            }
        }
    }

    void OnDestroy()
    {
        if (isEnemy)
        {
            GameController.master.xsEnemyCount -= 1;
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
