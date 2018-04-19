using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AchievementsEnum
{
    cartographer,
    slow_learner,
    maze_runner,
    something_weird, 
    GOO
}

/// <summary>
/// This class is for scoring (sepearte from game state)
/// </summary>
public class Achievements : WytriamSTD.Scene_Manager
{
    public List<AchievementsEnum> achievements;

    void Awake()
    {
        achievements = new List<AchievementsEnum>();
        Messenger.AddListener(Messages.MAZE_EXPLORED, Cartographer);
        Messenger.AddListener(Messages.BOSS_DEFEATED, MazeRunner);
        Messenger.AddListener(Messages.RESPAWN, SomethingWeird);
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
        if (achievements.Count == 0 || !achievements.Contains(AchievementsEnum.cartographer))
        {
            announce("ACHEIVEMENT GET: CARTOGRAPHER\nFully Explore the Maze");
            achievements.Add(AchievementsEnum.cartographer);
        }
    }

    void SlowLearner()
    {
        if (achievements.Count == 0 || !achievements.Contains(AchievementsEnum.slow_learner))
        {
            announce("ACHEIVEMENT GET: SLOW LEARNER\nDie five times to the Monster");
            achievements.Add(AchievementsEnum.slow_learner);
        }
    }

    void MazeRunner()
    {
        if (achievements.Count == 0 || !achievements.Contains(AchievementsEnum.maze_runner))
        {
            announce("ACHEIVEMENT GET: MAZE RUNNER\nComplete the Maze");
            achievements.Add(AchievementsEnum.maze_runner);

        }
    }

    void SomethingWeird()
    {
        if (achievements.Count == 0 || !achievements.Contains(AchievementsEnum.something_weird))
        {
            announce("ACHEIVEMENT GET: SOMETHING WEIRD\nRespawn for the first time");
            achievements.Add(AchievementsEnum.something_weird);

        }
        if (Constants.instance.deathCount == 5 && (achievements.Count == 0 || !achievements.Contains(AchievementsEnum.slow_learner)))
        {
            announce("ACHEIVEMENT GET: SLOW LEARNER\nRespawn five times");
            achievements.Add(AchievementsEnum.slow_learner);
        }
    }

    void GOO()
    {
        if (achievements.Count == 0 || !achievements.Contains(AchievementsEnum.GOO))
        {
            announce("ACHEIVEMENT GET: Eye Got an Eye on You\nDiscover the Great Old One");
            achievements.Add(AchievementsEnum.GOO);

        }

    }
}
