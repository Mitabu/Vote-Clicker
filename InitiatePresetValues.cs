using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiatePresetValues : MonoBehaviour
{
    void Start()
    {
		PlayerPrefs.SetInt("bot1Price", 50); //Price of bots
		PlayerPrefs.SetInt("bot2Price", 500);
		PlayerPrefs.SetInt("bot3Price", 1000);
		
		PlayerPrefs.SetInt("price2Multiplier", 3); //Price multiplier sets the number by which the standard price is multiplied after each bot upgrade
		PlayerPrefs.SetInt("price3Multiplier", 5);
		PlayerPrefs.SetInt("price4Multiplier", 10);
		PlayerPrefs.SetInt("price5Multiplier", 20);
		
		PlayerPrefs.SetInt("bot1Efficiency", 5); //Bot's efficiency (votes per second)
		PlayerPrefs.SetInt("bot2Efficiency", 15);
		PlayerPrefs.SetInt("bot3Efficiency", 30);
		
		PlayerPrefs.GetInt("upgradeNumber"); //Number of upgrades on the vote click
		
		PlayerPrefs.SetInt("clickUpgradePrice", 100); //Sets standard click upgrade price
		PlayerPrefs.SetInt("clickUpgradeModifier1", 1); //The number by whitch the click price is multiplied after upgrade
		PlayerPrefs.SetInt("clickUpgradeModifier2", 2);
		PlayerPrefs.SetInt("clickUpgradeModifier3", 5);
		PlayerPrefs.SetInt("clickUpgradeModifier4", 10);
		
		if(PlayerPrefs.GetInt("votesPerClick") == 0) {PlayerPrefs.SetInt("votesPerClick", 1);} //the number of the votes per click
		PlayerPrefs.SetInt("upgradeCoefficient", 10); //the coefficient of the upgrade price
		
		PlayerPrefs.SetInt("minAwayInterval", 10); //Minimum amount of time (in seconds) a user needs to spend away in order to get a while away bonus
		PlayerPrefs.SetInt("maxAwayInterval", 3600); //Maximum interval of time (in seconds) user can get rewarded for after returning to the app
		
		if(PlayerPrefs.GetFloat("prestigeLvl") == 0) {PlayerPrefs.SetFloat("prestigeLvl", 1);} //Create Prestige variable (standard value is 0)
		PlayerPrefs.SetInt("prestigePrice", 100000); //Standard prestige price that gets multiplied on each new prestige level
		PlayerPrefs.SetFloat("targetVoteGoalMultiplier", PlayerPrefs.GetFloat("prestigeLvl") + (float)0.2); //Value by which the target score (number of votes) for the next prestige level is calculated
    }
}
