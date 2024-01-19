using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDrop : MonoBehaviour
{
    public GameObject rainDrop;

    public float randomPositionX;
    public float randomPositionY;
    // Start is called before the first frame update
    void Start()
    {
        randomPositionX = Random.Range(-7f, -5.13f);
        randomPositionY = Random.Range(0.38f, -0.55f);

        transform.position = new Vector3(randomPositionX, randomPositionY, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
