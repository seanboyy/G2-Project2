using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MazeLocation
{
    none,
    pit,
    boss_room,
    grand_hall,
    player_spawn,
    puzzle_room,
    trap,
    collectible_room,
    mystery_room,
    loop1,
    loop2,
    loop3,
    loop4,
    loop5,
    loop6,
    loop7,
    loop8,
    loop9,
    loop10,
    loop11,
    loop12,
    loop13,
    loop14,
    end1,
    end2,
    end3,
    end4,
    GOO
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
