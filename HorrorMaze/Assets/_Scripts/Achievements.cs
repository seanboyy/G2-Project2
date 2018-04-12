using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AchievementsEnum
{
    cartographer
}

public class Achievements : WytriamSTD.Scene_Manager
{
    List<AchievementsEnum> achievements;

    void Awake()
    {
        Messenger.AddListener(Messages.MAZE_EXPLORED, Cartographer);
        achievements = new List<AchievementsEnum>();
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
        if (achievements.Count != 0 && !achievements.Contains(AchievementsEnum.cartographer))
        {
            announce("ACHEIVEMENT GET: CARTOGRAPHER\nFully Explore the Maze");
            achievements.Add(AchievementsEnum.cartographer);
        }
    }
}
