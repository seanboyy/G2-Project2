using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is for keeping track of game state (seperate from scoring)
/// </summary>
public class Constants : MonoBehaviour
{
    public static Constants instance;
    public List<string> items;

    public int deathCount = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        items = new List<string>();
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
