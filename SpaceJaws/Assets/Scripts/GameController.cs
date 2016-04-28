using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public static GameController master;
	public int xsEnemyCount = 0;
    bool isPaused;
       
    
    
    public bool IsPaused
    {
        get { return isPaused; }
        set
        {
            isPaused = value;
            if (isPaused)
            {
                //pause time
                Time.timeScale = 0f;
            }
            else
            {
                //unpause
                Time.timeScale = 1.0f;

            }

        }
    }
    // Use this for initialization
	void Start () {
        master = this;
	}
	
	void Update()
    {
        
       
    }

}
