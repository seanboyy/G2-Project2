﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public MazeLocation mazeLoc;
    private Stack<GameObject> pathToSpawn;
    private List<GameObject> visited;

    void Awake()
    {
        pathToSpawn = new Stack<GameObject>();
        visited = new List<GameObject>();
    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject otherGO = coll.gameObject;
        if (otherGO.tag == "Maze")
        {
            if (pathToSpawn == null || visited == null)
            {
                Debug.Log("ERROR - CONTAINERS NOT INITIALIZED.");
                return;
            }
            MazeSection otherMS = otherGO.GetComponent<MazeSection>();
            if (otherMS != null)
            {
                mazeLoc = otherMS.mazeLoc;
                otherMS.Reveal();
                // keep track of where the player has been.
                if (pathToSpawn.Count != 0 && pathToSpawn.Contains(otherGO))
                {
                    while (pathToSpawn.Peek() != otherGO)
                        pathToSpawn.Pop();
                }
                else
                {
                    pathToSpawn.Push(otherGO);
                }
                if (visited.Count != 238 && !visited.Contains(otherGO))
                {
                    visited.Add(otherGO);
                }
            }
        }
        if (otherGO.tag == "Collectible")
        {
            Debug.Log("Player Collected Brass Key");
            Constants.instance.items.Add("Brass Key");
            Destroy(otherGO);
        }
    }

    void DoReturnToSpawn()
    {
        StartCoroutine("ReturnToSpawn");
    }

    IEnumerator ReturnToSpawn()
    {
        while (pathToSpawn.Count != 0)
        {
            GameObject tempGO = pathToSpawn.Pop();
            this.gameObject.transform.position = tempGO.transform.position;
            yield return new WaitForSeconds(0.1f);
        }
        Messenger.Broadcast(Messages.RESPAWN);
        yield return null;
    }
}
