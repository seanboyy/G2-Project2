using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : WytriamSTD.Scene_Manager
{
    void Awake()
    {
        Messenger.AddListener(Messages.MAZE_EXPLORED, Cartographer);
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Cartographer()
    {
        announce("ACHEIVEMENT GET: CARTOGRAPHER\nFully Explore the Maze");
    }
}
