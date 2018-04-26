using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public GameObject[] bars;
    public GameObject button;
    public bool isButtonPressed = false;

    public IEnumerator Move()
    {
        if (!isButtonPressed)
        {
            Debug.Log("Doing");
            StartCoroutine("MoveButton");
        }
        yield return null;
    }

    public IEnumerator MoveButton()
    {
        isButtonPressed = true;
        button.transform.position -= new Vector3(0, 0.25F, 0);
        //Audiosource play sound
        StartCoroutine("MoveBars");
        yield return new WaitForSeconds(1);
        button.transform.position += new Vector3(0, 0.25F, 0);
        isButtonPressed = false;
        yield return null;
    }

    public IEnumerator MoveBars()
    {
        foreach (GameObject bar in bars)
        {
            if (bar.name == "Button")
            {
                if (bar.activeInHierarchy)
                {
                    bar.SetActive(false);
                }
                else
                {
                    bar.SetActive(true);
                }
            }
            else
            {
                bar.SetActive(true);
            }
        }
        yield return null;
    }
}
