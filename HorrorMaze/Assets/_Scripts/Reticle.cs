﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    public KeyCode reticleToggle = KeyCode.Escape;
    public bool turnReticleOnAtStart = false;
    private Image reticle;

	// Use this for initialization
	void Start ()
    {
        reticle = GetComponentInChildren<Image>();
        if (reticle == null)
            Debug.Log("Dialogue::Start() - Could not find Dialogue Text");
        reticle.enabled = turnReticleOnAtStart;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(reticleToggle))
            ToggleReticle();
	}

    void ToggleReticle()
    {
        reticle.enabled = !reticle.enabled;          
    }
}
