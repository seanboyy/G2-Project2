using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Spherecast
            Ray ray = new Ray(gameObject.transform.position, Camera.main.gameObject.transform.forward);
            RaycastHit hitInfo;
            Physics.SphereCast(ray, 2f, out hitInfo);
            if (hitInfo.collider != null)   // we got a hit
            {
                Debug.Log("User clicked on " + hitInfo.collider.gameObject.name);
                GameObject otherGo = hitInfo.collider.gameObject;
                GameObject otherParent = otherGo.transform.parent.gameObject;
                if (otherGo.tag == "Maze")
                {
                    Debug.Log("Using GameObject...");
                    MazeSection otherMS = otherGo.GetComponent<MazeSection>();
                    if (otherMS == null) return;
                    if (otherMS.mazeLoc == MazeLocation.twist)
                    {
                        otherGo.transform.Rotate(0, -90, 0);
                    }
                }
                else if (otherParent.tag == "Maze")
                {
                    Debug.Log("using parent...");
                    MazeSection otherMS = otherParent.GetComponent<MazeSection>();
                    if (otherMS == null) return;
                    if (otherMS.mazeLoc == MazeLocation.twist)
                    {
                        otherParent.transform.Rotate(0, -90, 0);
                    }

                }
            }
        }

    }
}
