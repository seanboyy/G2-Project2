using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MazeLocation
{
    none,
    twist, 
    pipChange
}

public class MazeSection : MonoBehaviour
{
    public bool revealed = false;
    public MazeLocation mazeLoc;

    public GameObject[] linkedSections;

    public bool rotRight = false;

    public Vector3 pipPos = new Vector3();

    public void Reveal()
    {
        if (revealed) return;
        revealed = true;
        // OnlyPIP = 8, NotPIP = 9, Default = 0
        Util.ChangeChildLayers(this.gameObject, 0);
    }
}
