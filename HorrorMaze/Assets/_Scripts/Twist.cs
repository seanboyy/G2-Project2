using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twist : MonoBehaviour
{
    public float twistDuration = 1.0f;
    Vector3 startingRot;
    Vector3 targetRot;
    bool isTwisting = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void TwistLeft()
    {
        if (isTwisting)
            return;
        isTwisting = true;
        startingRot = gameObject.transform.rotation.eulerAngles;
        targetRot = startingRot + new Vector3(0, 90, 0);
        StartCoroutine("Twisting");
    }

    public void TwistRight()
    {
        if (isTwisting)
            return;
        isTwisting = true;
        startingRot = gameObject.transform.rotation.eulerAngles;
        targetRot = startingRot + new Vector3(0, -90, 0);
        StartCoroutine("Twisting");
    }

    IEnumerator Twisting()
    {
        float startTime = Time.time;
        float u;
        do
        {
            u = (Time.time - startTime) / twistDuration;
            // Do a basic lerp on rotation
            gameObject.transform.Rotate(((1 - u) * startingRot) + (u * targetRot));
        } while (u < 1);
        yield return null;
    }


}
