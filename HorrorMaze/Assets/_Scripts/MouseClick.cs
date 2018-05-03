using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {
    	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // Spherecast
            Ray ray = new Ray(gameObject.transform.position, Camera.main.gameObject.transform.forward);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);
            if (hitInfo.collider != null)   // we got a hit
            {
                Debug.Log("User clicked on " + hitInfo.collider.gameObject.name);
                GameObject otherGo = hitInfo.collider.gameObject;
                GameObject otherParent = otherGo.transform.parent.gameObject;
                if (otherGo.tag == "Maze")
                {
                    Debug.Log("Using GameObject...");
                    MazeSection otherMS = otherGo.GetComponent<MazeSection>();
                    DoMultiRotate(otherGo);
                }
                else if (otherParent.tag == "Maze")
                {
                    Debug.Log("using parent...");
                    MazeSection otherMS = otherParent.GetComponent<MazeSection>();
                    DoMultiRotate(otherParent);
                }
            }
        }

    }

    void DoRotate(MazeSection section, GameObject _object)
    {
        if (section == null) return;
        if (section.mazeLoc == MazeLocation.twist)
        {
            if (!CanRotate(section))
            {
                GameObject.FindGameObjectWithTag("SceneManager").GetComponent<WytriamSTD.Scene_Manager>().Announce("If the section rotates now, you could\nget stuck in a wall!");
                return;
            }
            if (!section.rotRight)
                _object.transform.Rotate(0, -90, 0);
            else
                _object.transform.Rotate(0, 90, 0);
        }
    }

    void DoMultiRotate(GameObject mazeSection)
    {
        MazeSection ms = mazeSection.GetComponent<MazeSection>();
        if (ms == null) return;
        if (ms.linkedSections.Length == 0)
            DoRotate(ms, mazeSection);
        else
        {
            for (int i = 0; i < ms.linkedSections.Length; ++i)
            {
                MazeSection section = ms.linkedSections[i].GetComponent<MazeSection>();
                if (section != null)
                {
                    DoRotate(section, ms.linkedSections[i]);
                }
            }
        }
    }

    bool CanRotate(MazeSection section)
    {
        Vector3 pos = transform.position;
        Vector3 secPos = section.transform.position;
        //you must be in the center of the section, or entirely outside of it
        if ((pos.x > secPos.x - 2 && pos.x < secPos.x + 2) && (pos.z > secPos.z - 2 && pos.z < secPos.z + 2) ||
            ((pos.x > secPos.x + 5 || pos.x < secPos.x - 5) || (pos.z > secPos.z + 5 || pos.z < secPos.z - 5))) return true;
        return false;
    }
}
