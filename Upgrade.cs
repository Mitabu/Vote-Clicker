using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Upgrade : MonoBehaviour
{
	public Button buyUpgradeBtn;
	public bool activateOnLoad;
    //declaring useful variables
    private int voteNum;
    private int votesPerClick;
    private int clickUpgradePrice;
    private int clickUpgradeModifier;
    private int upgradeNumber;
	private float prestigeLvl;
    private float upgradeCoefficient;

	void Start() {
		if(activateOnLoad) 
		{
			if(buyUpgradeBtn.interactable == true) 
			{
				if(PlayerPrefs.GetInt("upgradeNumber") == 4) 
				{
					buyUpgradeBtn.interactable = false;
				}
			}
		}
	}

    public void BuyUpgrade() {
		prestigeLvl = PlayerPrefs.GetFloat("prestigeLvl");
        voteNum = PlayerPrefs.GetInt("voteNum");
        votesPerClick = PlayerPrefs.GetInt("votesPerClick");
		clickUpgradePrice = PlayerPrefs.GetInt("clickUpgradePrice");
		upgradeCoefficient = PlayerPrefs.GetInt("upgradeCoefficient");
		upgradeNumber = PlayerPrefs.GetInt("upgradeNumber");

        switch (upgradeNumber) {  //the upgrade number is used to determine what price and modifier is
            case 0:
                clickUpgradeModifier = PlayerPrefs.GetInt("clickUpgradeModifier1"); //in order to add new upgrades, create a new upgrade modifier in player prefs and edit this switch statement
            break;
			case 1:
                clickUpgradeModifier = PlayerPrefs.GetInt("clickUpgradeModifier2"); //in order to add new upgrades, create a new upgrade modifier in player prefs and edit this switch statement
            break;
			case 2:
                clickUpgradeModifier = PlayerPrefs.GetInt("clickUpgradeModifier3"); //in order to add new upgrades, create a new upgrade modifier in player prefs and edit this switch statement
            break;
			case 3:
                clickUpgradeModifier = PlayerPrefs.GetInt("clickUpgradeModifier4"); //in order to add new upgrades, create a new upgrade modifier in player prefs and edit this switch statement
            break;
		}
		if(upgradeNumber == 0) 
		{
			voteNum = PlayerPrefs.GetInt("voteNum");
			if(voteNum >= clickUpgradePrice) 
			{
				voteNum = voteNum - clickUpgradePrice*(int)prestigeLvl;
				PlayerPrefs.SetInt("voteNum", voteNum);
				votesPerClick = (int)(clickUpgradeModifier*upgradeCoefficient*prestigeLvl);
				PlayerPrefs.SetInt("votesPerClick", votesPerClick);
				upgradeNumber += 1;
				PlayerPrefs.SetInt("upgradeNumber", upgradeNumber);
				//Debug.Log("VotesPerClick : " + votesPerClick + "     UpgradeNumber : " + upgradeNumber + "     Cost : " + (clickUpgradePrice*(int)prestigeLvl));
			}else 
			{
				Debug.Log("You do not have enough Money to buy this Upgrade");
			}
		}else if(upgradeNumber < 3) 
		{
			if (voteNum >= (int)(clickUpgradePrice*(int)Math.Pow(upgradeCoefficient, upgradeNumber)*prestigeLvl)) {
				voteNum = PlayerPrefs.GetInt("voteNum");
				voteNum = voteNum - (int)(clickUpgradePrice*(int)Math.Pow(upgradeCoefficient, upgradeNumber)*prestigeLvl);
				PlayerPrefs.SetInt("voteNum", voteNum);
				votesPerClick = (int)(clickUpgradeModifier*upgradeCoefficient*prestigeLvl);
				PlayerPrefs.SetInt("votesPerClick", votesPerClick);
				upgradeNumber += 1;
				PlayerPrefs.SetInt("upgradeNumber", upgradeNumber);
				//Debug.Log("VotesPerClick : " + votesPerClick + "    UpgradeNumber : " + upgradeNumber + "    Cost : " + (clickUpgradePrice*(int)Math.Pow(upgradeCoefficient, upgradeNumber)*prestigeLvl));
			}
        }else if(upgradeNumber == 3) {
			if (voteNum >= (int)(clickUpgradePrice*(int)Math.Pow(upgradeCoefficient, upgradeNumber)*prestigeLvl)) {
				voteNum = PlayerPrefs.GetInt("voteNum");
				voteNum = voteNum - (int)(clickUpgradePrice*(int)Math.Pow(upgradeCoefficient, upgradeNumber)*prestigeLvl);
				PlayerPrefs.SetInt("voteNum", voteNum);
				votesPerClick = (int)(clickUpgradeModifier*upgradeCoefficient*prestigeLvl);
				PlayerPrefs.SetInt("votesPerClick", votesPerClick);
				upgradeNumber += 1;
				PlayerPrefs.SetInt("upgradeNumber", upgradeNumber);
				buyUpgradeBtn.interactable = false;
				Debug.Log("That was your last upgrade, turning button off ...");
				//Debug.Log("VotesPerClick : " + votesPerClick + "     UpgradeNumber : " + upgradeNumber + "      Cost : " + (clickUpgradePrice*(int)Math.Pow(upgradeCoefficient, upgradeNumber)*prestigeLvl));
			}
		}
    }
}
