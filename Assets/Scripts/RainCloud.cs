using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCloud : MonoBehaviour
{
    public GameObject rainDrop;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Rain()
    {
        while (true)
        {
            for (int i = 0; i < sceneData.rainDropsNumber; i++)
            {
                Instantiate(rainDrop, this.transform.position, this.transform.rotation);
            }
            yield return new WaitForSeconds(.5f);
        }
    }
}
