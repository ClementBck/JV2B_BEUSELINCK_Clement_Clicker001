using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    public int moneyToGain;
    public int kill = 0;
    public int chestAppear;

    public GameObject ennemy;
    public GameObject chest;
    public GameObject newEnnemy;

    public RainCloud rainUpgrade;

    public Slider progressBar;

    public TextMeshProUGUI moneyCounter;
    public TextMeshProUGUI levelCounter;
    // Start is called before the first frame update
    void Start()
    {
        callEnnemy();

        StartCoroutine(rainUpgrade.Rain());
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.value = sceneData.ennemyCounter;

        levelCounter.SetText("Level : " + sceneData.levelCounter.ToString());

    moneyCounter.text =  "Money : " + sceneData.money;

        if(newEnnemy == false)
        {
            callEnnemy();
        }

        if (sceneData.ennemyCounter >= 10)
        {
            sceneData.ennemyCounter = 0;
            sceneData.chestHP *= 1.2f;
            sceneData.classicEnnemyHP *= 1.2f;

            sceneData.minMoneyToGain += 2;
            sceneData.maxMonyToGain += 3;

            sceneData.levelCounter++;
        }
    }

    private void callEnnemy()
    {
        if (sceneData.ennemyCounter < 10)
        {
            chestAppear = Random.Range(0, 100);
            if (chestAppear == 75)
            {
                newEnnemy = Instantiate(chest);
            }
            else
            {
                newEnnemy = Instantiate(ennemy);
            }
        }
    }
}
