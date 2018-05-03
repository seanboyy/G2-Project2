using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM_Tutorial : WytriamSTD.Scene_Manager {

    public Camera PIPcam;

    private void Awake()
    {
        Messenger<Vector3>.AddListener(Messages.MOVE_PIP, DoMovePip);
    }

    public override void DoEndOfLevel()
    {
        SceneManager.LoadScene("Puzzle One");
    }

    public void DoMovePip(Vector3 newPos)
    {
        PIPcam.orthographicSize = 40;
        PIPcam.transform.position = newPos;
    }
}
