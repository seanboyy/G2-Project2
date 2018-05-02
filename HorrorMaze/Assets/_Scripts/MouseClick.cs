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
            Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
            RaycastHit hitInfo;
            Physics.SphereCast(ray, 2f, out hitInfo);
            if (hitInfo.collider != null)   // we got a hit
            {
                Debug.Log("User clicked on " + hitInfo.collider.gameObject.name);
                GameObject go = hitInfo.collider.gameObject;
                if (go.tag == "Lore")
                {
                    Dialogue.GetInstance().Display(go.GetComponent<Lore>().lore);
                }
                if (go.tag == "Button")
                {
                    Debug.Log("Clicked a button");
                    StartCoroutine(go.GetComponent<Puzzle>().Move());
                }
                if (go.transform.root.gameObject.tag == "Twist")
                {
                    go.transform.root.gameObject.transform.Rotate(0, 90, 0);
                }
            }
        }

    }
}
