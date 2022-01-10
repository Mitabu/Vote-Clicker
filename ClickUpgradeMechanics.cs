using UnityEngine;
using UnityEngine.UI;
using System;

public class ClickUpgradeMechanics : MonoBehaviour
{
	public GameObject UpgradePriceDisplay;
	public GameObject ClickUpgradeDisplay;
	public Button BuyUpgradeBtn;
	
	private int clickUpgradeModifier;

	void Start() {
		if(BuyUpgradeBtn.interactable == true) 
		{
			if(Storage.UpgradeNumber == 4) 
			{
				BuyUpgradeBtn.interactable = false;
			}
		}
		UpdateUpgradePriceDisplay();
		UpdateClickUpgradeDisplay();
	}

    public void BuyUpgrade() {
        
		if(Storage.UpgradeNumber == 0) 
		{
			SetClickUpgradeModifier();
			
			if(GlobalCash.CashCount >= Storage.ClickUpgradePrice * Storage.PrestigeLvl) 
			{
				GlobalCash.CashCount -= Storage.ClickUpgradePrice * Storage.PrestigeLvl;
				Debug.Log("Bought a click update for " + Storage.ClickUpgradePrice * Storage.PrestigeLvl);
				if(Storage.PrestigeLvl == 1) {
					Storage.VotesPerClick += (clickUpgradeModifier*Storage.UpgradeCoefficient*Storage.PrestigeLvl) - 1;
				} else {
						Storage.VotesPerClick += clickUpgradeModifier*Storage.UpgradeCoefficient*Storage.PrestigeLvl;
				}
				UpdateClickUpgradeDisplay();
				Storage.UpgradeNumber += 1;
				UpdateUpgradePriceDisplay();
				//Debug.Log("VotesPerClick : " + votesPerClick + "     UpgradeNumber : " + upgradeNumber + "     Cost : " + (Storage.ClickUpgradePrice*Storage.PrestigeLvl));
			}else 
			{
				Debug.Log("You do not have enough Money to buy this Upgrade");
			}
		}else if(Storage.UpgradeNumber < 3) 
		{
			if (GlobalCash.CashCount >= (Storage.ClickUpgradePrice*(int)Math.Pow(Storage.UpgradeCoefficient, Storage.UpgradeNumber)*Storage.PrestigeLvl)) {
				GlobalCash.CashCount -= (Storage.ClickUpgradePrice*(int)Math.Pow(Storage.UpgradeCoefficient, Storage.UpgradeNumber)*Storage.PrestigeLvl);
				Debug.Log("Bought a click update for " + (Storage.ClickUpgradePrice*(int)Math.Pow(Storage.UpgradeCoefficient, Storage.UpgradeNumber)*Storage.PrestigeLvl));
				Storage.VotesPerClick += clickUpgradeModifier*Storage.UpgradeCoefficient*Storage.PrestigeLvl;
				UpdateClickUpgradeDisplay();
				Storage.UpgradeNumber += 1;
				UpdateUpgradePriceDisplay();
				//Debug.Log("VotesPerClick : " + votesPerClick + "    UpgradeNumber : " + upgradeNumber + "    Cost : " + (Storage.ClickUpgradePrice*(int)Math.Pow(Storage.UpgradeCoefficient, upgradeNumber)*prestigeLvl));
			}
        }else if(Storage.UpgradeNumber == 3) {
			if (GlobalCash.CashCount >= (Storage.ClickUpgradePrice*(int)Math.Pow(Storage.UpgradeCoefficient, Storage.UpgradeNumber)*Storage.PrestigeLvl)) {
				GlobalCash.CashCount -= (Storage.ClickUpgradePrice*(int)Math.Pow(Storage.UpgradeCoefficient, Storage.UpgradeNumber)*Storage.PrestigeLvl);
				Debug.Log("Bought a click update for " + (Storage.ClickUpgradePrice*(int)Math.Pow(Storage.UpgradeCoefficient, Storage.UpgradeNumber)*Storage.PrestigeLvl));
				Storage.VotesPerClick += clickUpgradeModifier*Storage.UpgradeCoefficient*Storage.PrestigeLvl;
				UpdateClickUpgradeDisplay();
				Storage.UpgradeNumber += 1;
				BuyUpgradeBtn.interactable = false;
				UpdateUpgradePriceDisplay();
				Debug.Log("That was your last upgrade, turning button off ...");
				//Debug.Log("VotesPerClick : " + votesPerClick + "     UpgradeNumber : " + upgradeNumber + "      Cost : " + (Storage.ClickUpgradePrice*(int)Math.Pow(Storage.UpgradeCoefficient, upgradeNumber)*prestigeLvl));
			}
		}
    }
	
	private void SetClickUpgradeModifier() {
		switch (Storage.UpgradeNumber) {  //the upgrade number is used to determine what price and modifier is
            case 0:
                clickUpgradeModifier = Storage.ClickUpgradeModifier1; //in order to add new upgrades, create a new upgrade modifier in player prefs and edit this switch statement
				break;
			case 1:
                clickUpgradeModifier = Storage.ClickUpgradeModifier2;
				break;
			case 2:
                clickUpgradeModifier = Storage.ClickUpgradeModifier3;
				break;
			case 3:
                clickUpgradeModifier = Storage.ClickUpgradeModifier4;
				break;
		}
	}
	
	private void UpdateUpgradePriceDisplay() {
		SetClickUpgradeModifier();
		
		if(Storage.UpgradeNumber == 0) 
		{
			UpgradePriceDisplay.GetComponent<Text>().text = "Upgrade your vote per click for " + (Storage.ClickUpgradePrice * Storage.PrestigeLvl).ToString("N0") + " " + Storage.CashCurrencyName;
		}else if (Storage.UpgradeNumber > 0 && Storage.UpgradeNumber < 4) {
			UpgradePriceDisplay.GetComponent<Text>().text = "Upgrade your vote per click for " + (Storage.ClickUpgradePrice*(int)Math.Pow(Storage.UpgradeCoefficient, Storage.UpgradeNumber)*Storage.PrestigeLvl).ToString("N0") + " " + Storage.CashCurrencyName;
		}else {
			UpgradePriceDisplay.GetComponent<Text>().text = "Fully Upgraded";
		}
	}
	
	private void UpdateClickUpgradeDisplay() {
		ClickUpgradeDisplay.GetComponent<Text>().text = (Storage.VotesPerClick).ToString("N0") + " Votes/Click";
	}
}
