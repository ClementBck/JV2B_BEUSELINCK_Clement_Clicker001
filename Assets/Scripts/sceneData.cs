using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneData : MonoBehaviour
{
    public static int money;

    public static int minMoneyToGain = 5;
    public static int maxMonyToGain = 15;

    public static int smolSoldierDamage = 1;
    public static int smolSoldierLevel = 1;
    public static int smolSoldierPrice = 2;

    public static bool bigSoldierBought = false;
    public static int bigSoldierDamage = 5;
    public static int bigSoldierLevel = 0;
    public static int bigSoldierPrice = 6;

    public static int ennemyCounter = 0;
    public static int bossCounter = 0;
    public static float classicEnnemyHP = 10;

    public static int levelCounter;

    public static int doubleDamagePrice = 1000;

    public static float chestHP = 200;

    public static bool smolSoldierSelected = true;
    public static bool bigSoldierSelected = false;

    public static bool acidicRainBought = false;
    public static int acidicRainPrice = 100;
    public static int rainDropsNumber = 0;
    public static float rainDropDamage = 0.2f;
    public static int rainDropUpgradePrice = 10;
}
