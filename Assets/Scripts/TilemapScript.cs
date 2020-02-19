using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TilemapScript : MonoBehaviour
{
    TilemapCollider2D tc2d;
    Tilemap tilemap;
    public Tile emptyTile;
    public float explodeRadius;
    void Start()
    {
        tc2d = GetComponent<TilemapCollider2D>();
        tilemap = GetComponent<Tilemap>();
    }

    public void Explode(Vector3 position){

        tc2d.usedByComposite = false;


        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (!tilemap.HasTile(pos))
            {
                continue;
            }


            if (Vector3.Distance(pos, position) < explodeRadius)
            {
                tilemap.SetTile(pos, emptyTile);
            }
        }

        tc2d.usedByComposite = true;

    }
}
