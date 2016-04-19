using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float spawnRate = 1.0f;
    public Transform playPos;
    public float spawnDiff;
    private int spawnCount;

    
    public bool spawn = false;

    private float cooldown;
    // Use this for initialization
    void Start()
    {
        cooldown = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        if (GameController.master.xsEnemyCount < 6)
        {
            cooldown = spawnRate;
            var enemyTransform = Instantiate(enemyPrefab) as Transform;
            GameController.master.xsEnemyCount += 1;

            Vector3 tarPos = new Vector3(transform.position.x, Random.Range(playPos.position.y - spawnDiff, playPos.position.y + spawnDiff), 0);
            //make sure enemies don't spawn off screen
            if (tarPos.y < -20.0f)
                tarPos.y = -20.0f;
            if (tarPos.y > 20.0f)
                tarPos.y = 20.0f;
            //randomly spawn on left or right side of screen
            if (Random.Range(0.0f, 1.0f) < 0.51f)
            {
                tarPos.x = -5.0f;
            }

            enemyTransform.position = tarPos;
            
        }
        
    }
}
