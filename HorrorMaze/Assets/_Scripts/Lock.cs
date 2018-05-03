using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {

    public Sprite unlockSprite;

    public void Unlock()
    {
        GetComponent<Collider>().isTrigger = true;
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer renderer in renderers)
        {
            renderer.sprite = unlockSprite;
        }
        Messenger.Broadcast(Messages.TUTORIAL_UNLOCK);
    }
}
