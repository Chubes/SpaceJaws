using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform myTarget;

	// Update is called once per frame
	void Update () {
	    if(myTarget != null && myTarget.position.y > -15.2 && myTarget.position.y < 13.5)
        {
            Vector3 tarPos = myTarget.position;
            tarPos.z = transform.position.z;
            tarPos.x = transform.position.x;
       
            transform.position = tarPos;
        }
	}
}
