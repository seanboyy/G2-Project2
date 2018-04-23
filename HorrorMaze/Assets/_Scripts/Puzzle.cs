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
            StartCoroutine("MoveButton");
            StartCoroutine("MoveBars");
        }
        yield return null;
    }

    public IEnumerator MoveButton()
    {
        isButtonPressed = true;
        button.transform.position -= new Vector3(0, 0.25F, 0);
        yield return new WaitForSeconds(1);
        button.transform.position += new Vector3(0, 0.25F, 0);
        isButtonPressed = false;
        yield return null;
    }

    public IEnumerator MoveBars()
    {
        yield return null;
    }
}
