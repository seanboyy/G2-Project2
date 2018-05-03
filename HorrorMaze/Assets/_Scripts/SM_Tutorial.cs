using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM_Tutorial : WytriamSTD.Scene_Manager {

    public Camera PIPcam;

    private void Awake()
    {
        Messenger.AddListener(Messages.TUTORIAL_LOCK_UN, DoUnlock);
    }

    void DoUnlock()
    {
        PIPcam.orthographicSize = 40;
        PIPcam.transform.position += new Vector3(0, 0, 20);
    }

    public override void DoEndOfLevel()
    {
        //do something
    }
}
