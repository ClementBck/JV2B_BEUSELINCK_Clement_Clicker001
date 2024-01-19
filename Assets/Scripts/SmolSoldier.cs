using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmolSoldier : MonoBehaviour
{
    public float speed = 0.04f;



    public int damage = sceneData.smolSoldierDamage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed, 0f, 0f);

        if (transform.position.x < -8)
        {
            Destroy(gameObject);
        }
        damage = sceneData.smolSoldierDamage;
    }


}
