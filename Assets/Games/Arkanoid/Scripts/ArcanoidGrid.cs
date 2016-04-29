using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArcanoidGrid : MonoBehaviour
{
    public ArkCell cell;
    public List<ArkCell> cells;

    public bool isGridReady = false;

    int curRow = 0;
    int curPos = 0;

    void Start()
    {
        cells = new List<ArkCell>();

        for (int y = 0; y <= 7; y++)
        {
            for (int x = -14; x <= 14; x += 2)
            {
                cell = new ArkCell(x, y);
                cell.row = curRow;
                cell.rowPos = curPos;
                cells.Add(cell);

                curPos++;
                if (curPos > 14)
                {
                    curRow++;
                    curPos = 0;
                }
            }
        }

        isGridReady = true;
    }


    void Update()
    {

    }
}

[System.Serializable]
public class ArkCell
{
    public Vector2 pos;

    int Xpos;
    int Ypos;

    public int row;
    public int rowPos;

    public ArkCell(int x, int y)
    {
        Xpos = x;
        Ypos = y;

        pos = new Vector2(Xpos, Ypos);
    }
}