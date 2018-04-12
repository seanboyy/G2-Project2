using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
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
                Debug.Log("Player entered " + mazeLoc);
                otherMS.Reveal();
                // keep track of where the player has been.
                if (pathToSpawn.Count != 0 && pathToSpawn.Peek() == otherGO)
                {
                    Debug.Log("Maze Location Popped from pathToSpawn");
                    pathToSpawn.Pop();
                }
                else
                {
                    Debug.Log("Maze Location Pushed to pathToSpawn");
                    pathToSpawn.Push(otherGO);
                }
                if (!visited.Contains(otherGO))
                {
                    Debug.Log("Maze Location Pushed to visited");
                    Debug.Log(visited.Count.ToString() + " Locations visited");
                    visited.Add(otherGO);
                    if (visited.Count == 238)
                        Messenger.Broadcast(Messages.MAZE_EXPLORED);
                }
            }
        }
    }

    IEnumerator ReturnToSpawn()
    {
        while(pathToSpawn.Count != 0)
        {
            GameObject tempGO = pathToSpawn.Pop();
            this.gameObject.transform.position = tempGO.transform.position;
        }
        yield return null;
    }
}
