using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Tile1 : MonoBehaviour
{
    public int maxRepeats;
    public TileBase empety_tile;
    public TileBase tile1;
    public TileBase tile2;
    public TileBase tile3;
    public TileBase tile4;
    public Tilemap tilemap;
    public byte avgHeight;
    int Delta;
    public byte maxDelta;
    public byte X;
    public byte Y;
    public int[,] grid;
    void Start()
    {
        generate();
        showGrid();
    }
    
    void generate()
    { 
        int Errors = 0;
        grid = new int[X+1, Y+1];
        System.Random random = new System.Random();
        Start:
        int currentX = 0;
        int currentY = avgHeight;
        grid[0, currentY] = 1;
        try
        {
        while (currentX < X)
        {
            Delta = random.Next(2*maxDelta) - maxDelta;
            
            currentY += Delta;
            grid[currentX,currentY] = 1;
            // for (byte i = 1;currentY - i > 0; i++)
            // {
            //     grid[currentX,(currentY - i)] = 0;
            // }
            for (byte i = 1; i <= 2; i++)
            {
                grid[currentX,currentY + i] = 2;
            }
            for (byte i = 3; currentY + i < Y; i++)
            {
                grid[currentX, (currentY + i)] = random.Next(2) + 2;
            }
            currentX++; 
        }
        }
        catch (System.IndexOutOfRangeException e)
        {
            clearMassive(grid);
            //Debug.Log(e);
            Errors++;
            if (Errors <= maxRepeats) goto Start;
            else Debug.Log(e);

        }
        Debug.Log(Errors);
    }

    void clearMassive(int[,] mas)
    {
        for (int x = 0; x < X; x++)
        {
            for(int y = 0; y < Y; y++)
            {
                mas[x,y] = 0;
            }
        }
    }

    void showGrid()
    {
        for (int currentX = 0; currentX < X; currentX++)
        {
            for (int currentY = Y-1; currentY >= 0; currentY--)
            {
                switch(grid[currentX,currentY])
                {
                    // case 0:

                    //     break;
                    case 1:
                        tilemap.SetTile(new Vector3Int(currentX -X/2 , -currentY ,0), tile1);
                        break;
                    case 2:
                        tilemap.SetTile(new Vector3Int(currentX - X/2, -currentY, 0), tile2);
                        break;
                    case 3:
                        tilemap.SetTile(new Vector3Int(currentX - X/2, -currentY, 0), tile3);
                        break;
                    case 4:
                        tilemap.SetTile(new Vector3Int(currentX - X/2, -currentY, 0), tile4);
                        break;
                }
            }
        }
    }
}
