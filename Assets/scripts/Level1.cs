using System.Collections.Generic;
using UnityEngine;

public class Level1 : BaseBehaviour
{
    public GameObject TilePrefab;
    public int Columns = 8;
    public int Rows = 8;
    public float PlaceScale = 1;
    public float Offset = 1;
    public int TileH = 100;
    public int TileW = 100;

    void Start()
    {
        CreateGrid();
    }

    void Update()
    {

    }

    protected void CreateGrid()
    {
        var startVector = Camera.main.ScreenToWorldPoint(new Vector3(TileW / 2, Screen.height - TileH / 2, 20));
        var startX = startVector.x;

        for (var i = 0; i < Rows; i++)
        {
            var innerList = new List<TileBehaviour>();

            for (var j = 0; j < Columns; j++)
            {
                var obj = Inst(TilePrefab, startVector, TilePrefab.transform.rotation);
                var tile = obj.GetComponent<TileBehaviour>();

                tile.Model.SetPlace(i, j);

                innerList.Add(tile);
                startVector.x += PlaceScale + Offset;
            }

            GridController.Grid.Add(innerList);

            startVector.x = startX;
            startVector.y -= PlaceScale + Offset;
        }
    }
}
