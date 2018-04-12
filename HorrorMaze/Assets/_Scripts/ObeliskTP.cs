using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObeliskTP : MonoBehaviour {

    private void Awake()
    {
        Messenger.AddListener(Messages.OBELISK_TOUCHED, EnterMaze);
    }

    private void EnterMaze()
    {
        SceneManager.LoadScene("maze");
    }
}
