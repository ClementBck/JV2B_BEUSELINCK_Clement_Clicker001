using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chest : MonoBehaviour
{
    public Slider hpBar;

    public float hp;
    public int moneyGivenPerHit;
    public int moneyGivenAtDeath;

    public GameObject textDamage;

    // Start is called before the first frame update
    void Start()
    {
        moneyGivenPerHit = Random.Range(5, 15);
        moneyGivenAtDeath = Random.Range(200, 500);
        hp = sceneData.chestHP;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.maxValue = sceneData.chestHP;
        hpBar.value = hp;

        if (hp <= 0)
        {
            Destroy(gameObject);
            sceneData.classicEnnemyHP += 5;
            sceneData.chestHP += 100;
            sceneData.money += moneyGivenAtDeath;

            sceneData.ennemyCounter++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SmolSoldier")
        {
            hp -= sceneData.smolSoldierDamage;
            Destroy(collision.gameObject);
            sceneData.money += moneyGivenPerHit;
            GameObject damageText = Instantiate(textDamage);
            damageText.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(moneyGivenPerHit.ToString());
            moneyGivenPerHit = Random.Range(sceneData.minMoneyToGain, sceneData.maxMonyToGain);
        }

        if (collision.gameObject.tag == "BigSoldier")
        {
            hp -= sceneData.bigSoldierDamage;
            Destroy(collision.gameObject);
            sceneData.money += moneyGivenPerHit;
            GameObject damageText = Instantiate(textDamage);
            damageText.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(moneyGivenPerHit.ToString());
            moneyGivenPerHit = Random.Range(sceneData.minMoneyToGain, sceneData.maxMonyToGain);
        }

        if (collision.gameObject.tag == "RainDrop")
        {
            Destroy(collision.gameObject);
        }
    }
}
