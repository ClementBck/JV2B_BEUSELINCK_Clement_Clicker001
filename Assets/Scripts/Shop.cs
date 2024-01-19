using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject levelUpMessage;

    public TextMeshProUGUI smolSoldier;
    public TextMeshProUGUI bigSoldier;

    public TextMeshProUGUI smolSoldierPrice;
    public TextMeshProUGUI bigSoldierPrice;

    public TextMeshProUGUI levelUpSmolSoldierButton;
    public TextMeshProUGUI levelUpBigSoldierButton;

    public Money playerMoney;
    // Start is called before the first frame update
    void Start()
    {
        shopMenu.gameObject.SetActive(false);

        levelUpSmolSoldierButton.SetText("Level Up !");
    }

    // Update is called once per frame
    void Update()
    {
        smolSoldier.SetText("Smol Soldier Level : " + sceneData.smolSoldierLevel);
        bigSoldier.SetText("Big Soldier Level : " + sceneData.bigSoldierLevel);

        smolSoldierPrice.SetText("Price : " + sceneData.smolSoldierPrice);

        bigSoldierPrice.SetText("Price : " + sceneData.bigSoldierPrice);

        if (sceneData.bigSoldierBought == false)
        {
            levelUpBigSoldierButton.SetText("Buy !");
        }
        else
        {
            levelUpBigSoldierButton.SetText("Level Up !");
        }

        if (sceneData.money < 0)
        {
            sceneData.money = 0;
        }
    }

    public void openShop()
    {
        shopMenu.gameObject.SetActive(true);
    }

    public void closeShop()
    {
        shopMenu.gameObject.SetActive(false);
    }

    public void levelUpSmolSoldier()
    {
        if (sceneData.money >= sceneData.smolSoldierPrice)
        {
            sceneData.smolSoldierLevel++;
            sceneData.smolSoldierDamage += 2;

            sceneData.money -= sceneData.smolSoldierPrice;

            sceneData.smolSoldierPrice += 2;

            Instantiate(levelUpMessage);
        }
        else
        {
            print("Not Enough Money !");
        }
    }

    public void levelUpBigSoldier()
    {
        if (sceneData.money >= sceneData.bigSoldierPrice)
        {
            if (sceneData.bigSoldierBought == true)
            {
                sceneData.money -= sceneData.bigSoldierPrice;
                
                sceneData.bigSoldierLevel++;
                sceneData.bigSoldierDamage += 4;
                sceneData.bigSoldierPrice += 5;

                Instantiate(levelUpMessage);
            }
            else
            {
                sceneData.money -= sceneData.bigSoldierPrice;
               
                sceneData.bigSoldierBought = true;
                sceneData.bigSoldierLevel++;
                sceneData.bigSoldierPrice = 10;


                GameObject levelUpPopUp = Instantiate(levelUpMessage);
                levelUpPopUp.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("Big Soldier Aquired !");
            }
        }
        else
        {
            print("Not Enough Money !");
        }
    }
}
