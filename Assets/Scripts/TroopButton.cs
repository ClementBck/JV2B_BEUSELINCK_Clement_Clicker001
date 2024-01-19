using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TroopButton : MonoBehaviour
{
    public Button troopButton;

    public SmolSoldier soldier;

    public GameObject smolSoldier;
    public GameObject bigSoldier;
    // Start is called before the first frame update
    void Start()
    {
        troopButton.onClick.AddListener(callTroop);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void callTroop()
    {
        if (sceneData.smolSoldierSelected == true)
        {
            Instantiate(smolSoldier);
        }
        else
        {
            print("Smol Soldier Not Selected !");
        }

        if (sceneData.bigSoldierSelected == true)
        {
            Instantiate(bigSoldier);
        }
        else
        {
            print("Big Soldier Not Selected");
        }
    }
}
