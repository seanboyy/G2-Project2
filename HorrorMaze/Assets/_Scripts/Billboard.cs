using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

    public GameObject playerCapsule;
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.LookAt(playerCapsule.transform);
        gameObject.transform.rotation = Quaternion.Euler(0, gameObject.transform.rotation.eulerAngles.y, 0);
	}
}
