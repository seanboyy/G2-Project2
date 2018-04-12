using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obelisk : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Obelisk")
        {
            Messenger.Broadcast(Messages.OBELISK_TOUCHED);
        }
    }
}
