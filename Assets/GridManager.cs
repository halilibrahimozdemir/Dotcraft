using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{   
    [SerializeField]
    public int rows = 7;
    [SerializeField]
    public int cols = 6;
    [SerializeField]
    public float tileSize = 1;

    //The scaleLevel order is as follows 0(max Circle scale) 1,2,3(min Circle scale)
    private int scaleLevel=0;

    private float scaleFactor=0.1f;

    public GameObject referenceTile;



    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        Scaling();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);

                float posX = col * tileSize;
                float posY = row * -tileSize;

                //Debug.Log(posX + " " +posY);

                var pos = transform.position;
                pos.x = posX;
                pos.y = posY;
                tile.transform.localPosition = pos;

                var circleScale = tile.transform.localScale;
                circleScale.x = 1 - scaleLevel * scaleFactor;
                circleScale.y = 1 - scaleLevel * scaleFactor;
                tile.transform.localScale = circleScale;


            }
        }
        float gridW = cols * tileSize;
        float gridH = rows * tileSize;
        transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseCols()
    {
        DestroyOldGrid();
        if (cols < 6)
        {
            cols = cols + 1;
        }
        else
        {
            cols = 6;
        }
   
        GenerateGrid();
        
    }
    public void DecreaseCols()
    {
        DestroyOldGrid();
        if (cols > 3)
        {
            cols = cols - 1;
        }
        else
        {
            cols = 3;
        }
        GenerateGrid();

    }
    public void IncreaseRows()
    {
        DestroyOldGrid();
        if (rows < 7)
        {
            rows = rows + 1;
        }
        else
        {
            rows = 7;
        }
        
        GenerateGrid();

    }
    public void DecreaseRows()
    {
        DestroyOldGrid();

        if (rows > 3)
        {
            rows = rows - 1;
        }
        else
        {
            rows = 3;
        }
        
        GenerateGrid();

    }

    public void DestroyOldGrid()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

    }

    public void Test()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.transform.position = new Vector2(0, 0);
        }
    }

    void Scaling()
    {
        if (cols-3 > rows - 4)
        {
            scaleLevel = cols - 3;
        }
        else
        {
            scaleLevel = rows - 4;
        }
    }
}
