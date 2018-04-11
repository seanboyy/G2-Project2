using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public static void ChangeChildLayers(GameObject go, int layer)
    {
        foreach (Transform child in go.transform)
        {
            child.gameObject.layer = layer;
        }
    }
}
