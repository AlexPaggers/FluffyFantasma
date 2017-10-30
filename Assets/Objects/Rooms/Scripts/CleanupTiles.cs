using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanupTiles : MonoBehaviour
{
    private List<string> tiles = new List<string>(new string[] 
    {
        "Wall Tile",
        "Floor Tile",
        "Roof Tile"
    });


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(tiles.Contains(other.gameObject.tag))
        {
            other.gameObject.SetActive(false);
        }
    }
}
