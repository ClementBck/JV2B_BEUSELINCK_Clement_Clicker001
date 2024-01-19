using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    public GameObject upgradeMenu;

    public GameObject levelUpMessage;

    public GameObject cloud;

    public RainCloud rainUpgrade;

    public TextMeshProUGUI upgradeRain;
    public TextMeshProUGUI rainPrice;
    public TextMeshProUGUI rainDropCounter;

    public TextMeshProUGUI rainDropUpgradePrice;
    public TextMeshProUGUI rainDropDamage;
    public TextMeshProUGUI rainDropUpgradeTitle;

    public TextMeshProUGUI doubleDamageUpgradeText;

    public Button upgradeRainDropButton;

    public Button closeButton;

    // Start is called before the first frame update
    void Start()
    {
        upgradeMenu.gameObject.SetActive(false);

        upgradeRainDropButton.gameObject.SetActive(false);

        rainDropUpgradePrice.gameObject.SetActive(false);
        rainDropDamage.gameObject.SetActive(false);

        cloud.gameObject.SetActive(false);

        rainDropCounter.gameObject.SetActive(false);

        rainDropUpgradeTitle.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneData.acidicRainBought == false)
        {
            upgradeRain.SetText("Buy !");
        }
        else
        {
            upgradeRain.SetText("Level Up !");

            upgradeRainDropButton.gameObject.SetActive(true);
            rainDropUpgradePrice.gameObject.SetActive(true);
            rainDropDamage.gameObject.SetActive(true);
            rainDropUpgradeTitle.gameObject.SetActive(true);
        }

        rainPrice.SetText("Price : " + sceneData.acidicRainPrice.ToString());
        rainDropCounter.SetText("Raindrops : " + sceneData.rainDropsNumber.ToString());

        rainDropUpgradePrice.SetText("Price : " + sceneData.rainDropUpgradePrice.ToString());
        rainDropDamage.SetText("Raindrops Damage : " + sceneData.rainDropDamage.ToString());

        doubleDamageUpgradeText.SetText("Price : " + sceneData.doubleDamagePrice.ToString());
    }

    public void OpenUpgradeMenu()
    {
        upgradeMenu.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(false);
    }

    public void CloseUpgradeMenu()
    {
        upgradeMenu.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(true);
    }

    public void LevelUpRain()
    {
        if (sceneData.acidicRainBought == false && sceneData.money >= sceneData.acidicRainPrice)
        {
            cloud.gameObject.SetActive(true);
            sceneData.rainDropsNumber = 5;
            sceneData.acidicRainBought = true;
            sceneData.money -= sceneData.acidicRainPrice;
            sceneData.acidicRainPrice = 20;

            rainDropCounter.gameObject.SetActive(true);

            GameObject levelUpPopUp = Instantiate(levelUpMessage);
            levelUpPopUp.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("It's Raining !");
        }
        else
        {
            if (sceneData.rainDropsNumber <= 100 && sceneData.money >= sceneData.acidicRainPrice)
            {
                sceneData.rainDropsNumber += 1;
                sceneData.acidicRainPrice += 5;
                sceneData.money -= sceneData.acidicRainPrice;

                GameObject levelUpPopUp = Instantiate(levelUpMessage);
                levelUpPopUp.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("RainDrop + 1 !");
            }
            else
            {
                print("Level Max !!");
                rainPrice.SetText("Level Max !");
            }
        }
    }

    public void LevelUpRainDrop()
    {
        if (sceneData.money >= sceneData.rainDropUpgradePrice)
        {
            sceneData.rainDropDamage += 0.5f;
            sceneData.rainDropUpgradePrice += 10;
            sceneData.money -= sceneData.rainDropUpgradePrice;

            GameObject levelUpPopUp = Instantiate(levelUpMessage);
            levelUpPopUp.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("RainDrop Damage ++ !!");
        }
    }

    public void DoubleDamageUpgrade()
    {
        if (sceneData.money >= sceneData.doubleDamagePrice)
        {
            sceneData.rainDropDamage *= 2;
            sceneData.smolSoldierDamage *= 2;
            sceneData.bigSoldierDamage *= 2;

            sceneData.doubleDamagePrice += 500;

            sceneData.money -= sceneData.doubleDamagePrice;


            GameObject levelUpPopUp = Instantiate(levelUpMessage);
            levelUpPopUp.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("All damages X2 !!!");
        }
        else
        {
            print("not enough money !!");
        }
    }
}

