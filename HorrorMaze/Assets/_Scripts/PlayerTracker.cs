using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public MazeLocation mazeLoc;

    void OnTriggerEnter(Collider coll)
    {
        GameObject otherGO = coll.gameObject;
        if (otherGO.tag == "Maze")
        {
            MazeSection otherMS = otherGO.GetComponent<MazeSection>();
            if (otherMS != null)
            {
                mazeLoc = otherMS.mazeLoc;
                Debug.Log("Player entered " + mazeLoc);
                otherMS.Reveal();
            }
        }
    }
}
