using UnityEngine;
using System.Collections.Generic;

public class TileBehaviour : BaseBehaviour
{
    public static TileBehaviour SelectedTile;

    public TileModel Model;

    protected Sprite _sprite;
    protected SpriteRenderer _spriteRenderer;
    protected Color _color;

    void Awake()
    {
        Model = TileModel.Create(8);
    }

    void Start()
    {
        _sprite = SpriteManager.Instance.possibleTextureTiles[Model.Type];
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _spriteRenderer.sprite = _sprite;
        _color = _spriteRenderer.material.color;
    }

    void Update()
    {

    }

    void OnMouseEnter()
    {
        if (!IsCurrentSelected())
        {
            ChangeColor(Color.gray);
        }
    }

    void OnMouseDown()
    {
        if (IsAnySelected())
        {
            DeselectTile(); // Deselect old one

            if (!IsCurrentSelected())
            {
                SelectTile();
            }
        }
        else
        {
            SelectTile();
        }
    }

    void OnMouseExit()
    {
        if (!IsCurrentSelected())
        {
            RestoreColor();
        }
    }

    void SelectTile()
    {
        SelectedTile = this;
        ChangeColor(Color.green);
    }

    void DeselectTile()
    {
        SelectedTile.RestoreColor();
        SelectedTile = null;
    }

    bool IsCurrentSelected()
    {
        return SelectedTile == this;
    }

    bool IsAnySelected()
    {
        return SelectedTile != null;
    }

    void ChangeColor(Color color)
    {
        _spriteRenderer.material.SetColor("_Color", color);
    }

    void RestoreColor()
    {
        _spriteRenderer.material.color = this._color;
    }
}

