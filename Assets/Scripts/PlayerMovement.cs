using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float speed;
    GameObject ground;

    private void Update()
    {
        float x = Input.acceleration.x * speed * Time.deltaTime;
        float z = Input.acceleration.y * speed * Time.deltaTime;
        transform.Translate(x, 0, z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            ground = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Tile") && ground==collision.gameObject)
        {
            ground = null;
        }
    }

    private void LateUpdate()
    {
        if (ground == null)
            GameManager.instance.Fail();
    }
}
