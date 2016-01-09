using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TileModel
{
    public int Type;
    public int PlaceX;
    public int PlaceY;

    public static TileModel Create(int length)  
    {
        var tileModel = new TileModel();
        tileModel.Type = Generator.rnd.Next(0, length);

        return tileModel;
    }

    public void SetPlace(int x, int y) {
        PlaceX = x;
        PlaceY = y;
    }
}
