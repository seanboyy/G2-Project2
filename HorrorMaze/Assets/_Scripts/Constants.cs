using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is for keeping track of game state (seperate from scoring)
/// </summary>
public class Constants : WytriamSTD.Scene_Manager
{
    public static Constants instance;

    // The collectible to let the player survive the boss encounter
    public bool hasCollectible = false;

    public int deathCount = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        Messenger.AddListener(Messages.BOSS_ROOM, EnterBossRoom);
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void EnterBossRoom()
    {
        if (hasCollectible)
        {
            Messenger.Broadcast(Messages.BOSS_DEFEATED);
        }
        else
        {
            Messenger.Broadcast(Messages.PLAYER_DIED);
            deathCount++;
            Debug.Log("Death Count: " + deathCount);
        }
    }
}
