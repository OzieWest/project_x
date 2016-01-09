using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : BaseBehaviour
{
    public Sprite[] possibleTextureTiles;
    
    public static SpriteManager Instance;

    public void Awake()
    {
        Instance = this;
    }
}
