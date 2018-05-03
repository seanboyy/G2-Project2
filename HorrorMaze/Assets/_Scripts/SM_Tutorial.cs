using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM_Tutorial : WytriamSTD.Scene_Manager {

    public Camera PIPcam;
    public string nextScene = "Puzzle One";

    private void Awake()
    {
        Messenger<Vector3>.AddListener(Messages.MOVE_PIP, DoMovePip);
    }

    public void Start()
    {

    }

    public override void DoEndOfLevel()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void DoMovePip(Vector3 newPos)
    {
        if (PIPcam != null)
        {
            PIPcam.orthographicSize = 40;
            PIPcam.transform.position = newPos;
        }
    }
}
