using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSoldier : MonoBehaviour
{
    public int damage = sceneData.bigSoldierDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-0.02f, 0f, 0f);

        if (transform.position.x < -8)
        {
            Destroy(gameObject);
        }
        damage = sceneData.bigSoldierDamage;
    }
}
