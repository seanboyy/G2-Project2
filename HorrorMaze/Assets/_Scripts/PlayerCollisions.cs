using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public MazeLocation mazeLoc;
    private Stack<GameObject> pathToSpawn;
    private List<GameObject> visited;

    private bool hasBeenTaught;

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
        if (otherGO.tag == "Key")
        {
            Debug.Log("Player Collected " + otherGO.GetComponent<Key>().keyName);
            Constants.instance.items.Add(otherGO.GetComponent<Key>().keyName);
            Destroy(otherGO);
        }
        if(otherGO.tag == "Lock")
        {
            Debug.Log("Player opened Lock");
            Destroy(otherGO);
        }
        if(otherGO.tag == "EOLTrophy")
        {
            Constants.instance.items.Add(otherGO.GetComponent<Trophy>().trophyName);
            Destroy(otherGO);
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<WytriamSTD.Scene_Manager>().DoEndOfLevel();
        }
        if (!hasBeenTaught && otherGO.name.Contains("Twist"))
        {
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<WytriamSTD.Scene_Manager>().Announce("Click on and or around\nareas with darker blue walls.\nThis causes them to rotate");
            hasBeenTaught = true;
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
