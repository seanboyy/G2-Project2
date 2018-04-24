using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Displaying Dialogue");
            if (Dialogue.GetInstance() == null)
                Debug.Log("Instance is broken.");
            Dialogue.GetInstance().Display("H pressed");
        }
	}
}
