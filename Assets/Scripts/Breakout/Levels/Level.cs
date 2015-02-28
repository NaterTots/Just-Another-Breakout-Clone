using UnityEngine;
using System.Collections;

public class Level 
{
    public const int Width = 11;
    public const int Height = 13;

    private int _levelnum;
    public int LevelNum
    {
        get
        {
            return _levelnum;
        }
    }
	
    Brick.BrickType[,] _brickArray;
    public Brick.BrickType[,] BrickArray
    {
        get
        {
            return _brickArray;
        }
    }

    public Brick.BrickType this[int i, int j]
    {
        get { return _brickArray[i, j]; }
        set { _brickArray[i, j] = value; }
    }

    public void Initialize(int levelnum)
    {
        _levelnum = levelnum;
        _brickArray = new Brick.BrickType[Height, Width];

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                _brickArray[i,j] = Brick.BrickType.None;
            }
        }
    }


}
