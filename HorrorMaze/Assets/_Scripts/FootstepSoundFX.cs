using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FootstepSoundFX : MonoBehaviour
{
    public AudioClip[] footsteps;
    public AudioSource speaker;
    public float speakerDist = 2;
    private Vector3 lastPos;
    private int footstepIdx = 0;
    private CharacterController cc;

    void Awake()
    {
        speaker = GetComponent<AudioSource>();
        if (speaker == null)
        {
            Debug.Log("no speaker attached to player!");
            return;
        }
        speaker.mute = true;
        cc = GetComponent<CharacterController>();
    }

    // Use this for initialization
    void Start()
    {
        if (speaker != null)
            speaker.mute = false;

        if (footsteps.Length == 0)
        { 
            Debug.Log("No footsteps put player");
            return;
        }
        speaker.clip = footsteps[footstepIdx];
        lastPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (cc.isGrounded && Vector3.Distance(lastPos, gameObject.transform.position) >= speakerDist)
        {
            lastPos = gameObject.transform.position;
            PlayFootstep();
        }	
	}

    void PlayFootstep()
    {
        //Debug.Log("playing sound");
        speaker.Play();
        footstepIdx = (footstepIdx + 1) % footsteps.Length;
        //speaker.clip = footsteps[footstepIdx];
        speaker.clip = footsteps[Random.Range(0, footsteps.Length)];
    }
}
