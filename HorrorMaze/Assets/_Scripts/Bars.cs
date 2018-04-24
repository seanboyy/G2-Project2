using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States { MOVING_LEFT, STOPPED_LEFT, MOVING_MIDDLE, STOPPED_MIDDLE, MOVING_RIGHT, STOPPED_RIGHT }

public class Bars : MonoBehaviour
{
    public float speed = 1;
    public States state = States.STOPPED_MIDDLE;

    public IEnumerator MoveToCenter()
    {
        Debug.Log("Moving to center");
        state = States.MOVING_MIDDLE;
        while (transform.position.x < -0.5)
        {
            transform.position += new Vector3(0.2F * speed * Time.deltaTime, 0, 0);
            yield return new WaitForEndOfFrame();
        }
        while(transform.position.x > 0.5)
        {
            transform.position -= new Vector3(0.2F * speed * Time.deltaTime, 0, 0);
            yield return new WaitForEndOfFrame();
        }
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
        transform.localScale = new Vector3(1, 1, 1);
        state = States.STOPPED_MIDDLE;
        yield return null;
    }

    public IEnumerator MoveLeft()
    {
        Debug.Log("Moving left");
        transform.localScale = new Vector3(1, 1, 1);
        state = States.MOVING_LEFT;
        while(transform.position.x > -9.5)
        {
            transform.position -= new Vector3(0.2F * speed * Time.deltaTime, 0, 0);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(0.9F, 1, 1);
        transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        state = States.STOPPED_LEFT;
        yield return null;
    }

    public IEnumerator MoveRight()
    {
        Debug.Log("Moving right");
        transform.localScale = new Vector3(1, 1, 1);
        state = States.MOVING_RIGHT;
        while (transform.position.x < 9.5)
        {
            transform.position += new Vector3(0.2F * speed * Time.deltaTime, 0, 0);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(0.9F, 1, 1);
        transform.position = new Vector3(10, transform.position.y, transform.position.z);
        state = States.STOPPED_RIGHT;
        yield return null;
    }
}
