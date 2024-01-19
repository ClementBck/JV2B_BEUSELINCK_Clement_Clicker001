using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierSelection : MonoBehaviour
{
    public Button smolSoldierButton;
    public Button bigSoldierButton;

    public void Update()
    {
        if (sceneData.bigSoldierBought == false)
        {
            bigSoldierButton.gameObject.SetActive(false);
        }
        else
        {
            bigSoldierButton.gameObject.SetActive(true);
        }
    }
    public void SmolSoldierSlected()
    {
        sceneData.smolSoldierSelected = true;
        sceneData.bigSoldierSelected = false;
    }

    public void BigSoldierSlected()
    {
        if (sceneData.bigSoldierBought == true)
        {
            sceneData.smolSoldierSelected = false;
            sceneData.bigSoldierSelected = true;
        }
        else
        {
            print("Big Soldier Not Available");
        }
    }
}
