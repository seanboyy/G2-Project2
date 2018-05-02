using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MazeLocation
{
    none,
    twist
}

public class MazeSection : MonoBehaviour
{
    public bool revealed = false;
    public MazeLocation mazeLoc;

    public void Reveal()
    {
        if (revealed) return;
        revealed = true;
        // OnlyPIP = 8, NotPIP = 9, Default = 0
        Util.ChangeChildLayers(this.gameObject, 0);
    }
}
