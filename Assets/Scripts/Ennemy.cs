using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ennemy : MonoBehaviour
{
    public Slider hpBar;

    public float hp;
    public int moneyGiven;

    public GameObject textDamage;    

    // Start is called before the first frame update
    void Start()
    {
        moneyGiven = Random.Range(sceneData.minMoneyToGain, sceneData.maxMonyToGain);
        hp = sceneData.classicEnnemyHP;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.maxValue = sceneData.classicEnnemyHP;
        hpBar.value = hp;

        if (hp <= 0)
        {
            Destroy(gameObject);
            sceneData.classicEnnemyHP += 5;
            sceneData.chestHP += 20;
            sceneData.money += moneyGiven;

            sceneData.ennemyCounter++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SmolSoldier")
        {
            hp -= sceneData.smolSoldierDamage;
            Destroy(collision.gameObject);
            GameObject damageText = Instantiate(textDamage);
            damageText.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(sceneData.smolSoldierDamage.ToString());
        }

        if (collision.gameObject.tag == "BigSoldier")
        {
            hp -= sceneData.bigSoldierDamage;
            Destroy(collision.gameObject);
            GameObject damageText = Instantiate(textDamage);
            damageText.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(sceneData.bigSoldierDamage.ToString());
        }

        if (collision.gameObject.tag == "RainDrop")
        {
            hp -= sceneData.rainDropDamage;
            Destroy(collision.gameObject);
            GameObject damageText = Instantiate(textDamage);
            damageText.transform.GetChild(0).GetComponent<TextMeshPro>().color = Color.green;
            damageText.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(sceneData.rainDropDamage.ToString());
        }
    }
}
