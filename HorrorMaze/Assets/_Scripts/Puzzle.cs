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
        foreach(GameObject bar in bars)
        {
            switch (bar.GetComponent<Bars>().state)
            {
                case States.MOVING_LEFT:
                case States.STOPPED_LEFT:
                case States.MOVING_RIGHT:
                case States.STOPPED_RIGHT:
                    bar.GetComponent<Bars>().StopAllCoroutines();
                    StartCoroutine(bar.GetComponent<Bars>().MoveToCenter());
                    break;
                case States.MOVING_MIDDLE:
                case States.STOPPED_MIDDLE:
                    bar.GetComponent<Bars>().StopAllCoroutines();
                    if (Random.Range(0F, 1F) > 0.5)
                        StartCoroutine(bar.GetComponent<Bars>().MoveRight());
                    else
                        StartCoroutine(bar.GetComponent<Bars>().MoveLeft());
                    break;

            }
        }
        yield return null;
    }
}
