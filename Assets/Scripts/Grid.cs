using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int _width;
    private int _height;
    private float _cellSize;

    private int[,] _gridArray;

    /// <summary>
    /// Constructor for a new grid object
    /// </summary>
    /// <param name="width">The width of the grid</param>
    /// <param name="height">The height of the grid</param>
    /// <param name="cellSize">The size of each cell</param>
    public Grid(int width, int height, float cellSize)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _gridArray = new int[_width, _height];
        // Debug.Log($"\n_width: {_width}\n_height: {_height}");
        for (int x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gridArray.GetLength(1); y++)
            {
                Debug.Log($"{x}, {y}");
            }
        }
    }
}