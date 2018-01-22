using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;

[Serializable]
public class Board
{
    [SerializeField]
    Vector2 start_pos, end_pos,size;
    [SerializeField]
    Vector2[] traps;

    public Vector2 StartPos
    {
        get { return start_pos; }
    }

    public Vector2 EndPos
    {
        get { return end_pos; }
    }

    public Vector2 Size
    {
        get { return size; }
    }

    public bool isTrap(Vector2 tile)
    {
        return traps.Contains(tile);
    }

    public Board(Vector2 start_pos,Vector2 end_pos,Vector2 size,Vector2[] traps)
    {
        this.start_pos = start_pos;
        this.end_pos = end_pos;
        this.size = size;
        this.traps = traps;
    }
}

