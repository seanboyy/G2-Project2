using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    public KeyCode reticleToggle = KeyCode.Escape;
    public bool turnReticleOnAtStart = false;
    private Image reticle;

    void Awake()
    {
        Messenger.AddListener(Messages.RETICLE_OFF, ReticleOff);
        Messenger.AddListener(Messages.RETICLE_ON, ReticleOn);
    }

    // Use this for initialization
    void Start()
    {
        reticle = GetComponentInChildren<Image>();
        if (reticle == null)
            Debug.Log("Dialogue::Start() - Could not find Dialogue Text");
        reticle.enabled = turnReticleOnAtStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(reticleToggle))
            ToggleReticle();
        if (Dialogue.GetInstance() != null && Dialogue.GetInstance().DialogueOpen() || (Cursor.visible && reticle.enabled))
            ReticleOff();

        else if (!Cursor.visible && !reticle.enabled)
            ReticleOn();
    }

    void ToggleReticle()
    {
        if (reticle != null)
            reticle.enabled = !reticle.enabled;
    }

    void ReticleOn()
    {
        if (reticle != null)
            reticle.enabled = true;
    }

    void ReticleOff()
    {
        if (reticle != null)
            reticle.enabled = false;
    }
}
