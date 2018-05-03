using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public GameObject _lock;
    public string keyName;

    private void OnDestroy()
    {
        _lock.GetComponent<Lock>().Unlock();
    }
}
