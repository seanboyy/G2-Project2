using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOO : MonoBehaviour {
    public GameObject player;
    GameObject[] eyes;
    Quaternion[] startingRotation;
    bool playerIsCloseEnough = false;
	// Use this for initialization
	void Start () {
        eyes = GameObject.FindGameObjectsWithTag("Eye");
        startingRotation = new Quaternion[eyes.Length];
        for(int i = 0; i < startingRotation.Length; ++i)
        {
            startingRotation[i] = eyes[i].transform.rotation;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 10)
        {
            playerIsCloseEnough = true;
        }
        else
        {
            playerIsCloseEnough = false;
        }
        if (playerIsCloseEnough)
        {
            foreach (GameObject eye in eyes) {
                eye.transform.LookAt(player.transform);
                eye.transform.Rotate(new Vector3(0, -90, 0));
            }
        }
        else
        {
            for(int i = 0; i < eyes.Length; ++i)
            {
                eyes[i].transform.rotation = startingRotation[i];
            }
        }
	}
}
