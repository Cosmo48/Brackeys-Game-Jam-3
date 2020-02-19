using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    TilemapScript exploder;
    GameObject tilemap;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 2f);
        tilemap = GameObject.Find("Tilemap");
        exploder = tilemap.GetComponent<TilemapScript>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }

    void Explode()
    {

        exploder.Explode(transform.position);
        Destroy(gameObject);

    }


}
