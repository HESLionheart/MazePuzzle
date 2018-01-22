using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTileScript : TileScript {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            GameManager.instance.Win();
    }
}
