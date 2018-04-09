using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxTest : MonoBehaviour {
    public Material skybox1;
    public Material skybox2;
    public float timeInterval;
	// Use this for initialization
	void Start () {
        StartCoroutine("SkyboxOne");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SkyboxOne()
    {
        RenderSettings.skybox = skybox1;
        yield return new WaitForSeconds(timeInterval);
        StartCoroutine("SkyboxTwo");
    }

    IEnumerator SkyboxTwo()
    {
        RenderSettings.skybox = skybox2;
        yield return new WaitForSeconds(timeInterval);
        StartCoroutine("SkyboxOne");
    }
}
