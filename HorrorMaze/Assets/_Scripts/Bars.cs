using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States { STOPPED_LEFT, MOVING_LEFT, STOPPED_MIDDLE, MOVING_RIGHT, STOPPED_RIGHT }

public class Bars : MonoBehaviour
{
    public States state = States.STOPPED_MIDDLE;
}
