using UnityEngine;
using UnityEngine.UI;
using System;

public class BotMechanics : MonoBehaviour
{
	public Text BotEarnings1;
	public Text BotEarnings2;
	public Text BotEarnings3;
	public Text TotalBotEarnings;
	public Text UpgradePriceBot1;
	public Text UpgradePriceBot2;
	public Text UpgradePriceBot3;
	
	public Image russianBotBar;
	public Image chineseBotBar;
	public Image northKoreanBotBar;
	
	public Button BuyBot1; //Bot buy buttons
	public Button BuyBot2;
	public Button BuyBot3;
	
	private int BotPrice;
	private int PriceMultiplier;

	private bool UnlockAchievementEdward = false;
	private bool UnlockAchievementHackerGod = false;
	private bool UnlockAchievementHackerman = false;
	
	void Start() {
		if (PlayerPrefs.GetInt("UnlockAchievementEdward") == 0)
		{
			UnlockAchievementEdward = true;
		}

		if (PlayerPrefs.GetInt("UnlockAchievementHackerGod") == 0)
		{
			UnlockAchievementHackerGod = true;
		}

		if (PlayerPrefs.GetInt("UnlockAchievementHackerman") == 0)
		{
			UnlockAchievementHackerman = true;
		}
		
		if(BuyBot1.interactable == true) 
		{
			if(Storage.Bot1 == 5) 
			{
				UpdateFill(1);
				BuyBot1.interactable = false;
				UpgradePriceBot1.GetComponent<Text>().text = "Fully Upgraded";
			}else {
				UpdateFill(1);
				SetPriceMultiplier(Storage.Bot1);
				UpgradePriceBot1.GetComponent<Text>().text = (Storage.Bot1Price * PriceMultiplier * Storage.PrestigeLvl).ToString("N0") + " " + Storage.CashCurrencyName;
			}
		}
		if(BuyBot2.interactable == true) 
		{
			UpdateFill(2);
			if(Storage.Bot2 == 5) 
			{
				BuyBot2.interactable = false;
				UpgradePriceBot2.GetComponent<Text>().text = "Fully Upgraded";
			}else {
				SetPriceMultiplier(Storage.Bot2);
				UpgradePriceBot2.GetComponent<Text>().text = (Storage.Bot2Price * PriceMultiplier * Storage.PrestigeLvl).ToString("N0") + " " + Storage.CashCurrencyName;
			}
		}
		if(BuyBot3.interactable == true) 
		{
			UpdateFill(3);
			if(Storage.Bot3 == 5) 
			{
				BuyBot3.interactable = false;
				UpgradePriceBot3.GetComponent<Text>().text = "Fully Upgraded";
			}else {
				SetPriceMultiplier(Storage.Bot3);
				UpgradePriceBot3.GetComponent<Text>().text = (Storage.Bot3Price * PriceMultiplier * Storage.PrestigeLvl).ToString("N0") + " " + Storage.CashCurrencyName;
			}
		}
		BotActivate();
	}
	
	public void Bot1() {
		int BotNumber = 1;
		int BotUpgradeValue = Storage.Bot1;
		BuyBot(BotNumber, BotUpgradeValue);
	}
	public void Bot2() {
		int BotNumber = 2;
		int BotUpgradeValue = Storage.Bot2;
		BuyBot(BotNumber, BotUpgradeValue);
	}
	public void Bot3() {
		int BotNumber = 3;
		int BotUpgradeValue = Storage.Bot3;
		BuyBot(BotNumber, BotUpgradeValue);
	}
	
	public void BuyBot(int BotNumber, int BotUpgradeValue) 
	{
		switch (BotNumber) 
		{
			case 1:
				this.BotPrice = Storage.Bot1Price;
				break;
			case 2:
				this.BotPrice = Storage.Bot2Price;
				break;
			case 3:
				this.BotPrice = Storage.Bot3Price;
				break;
		}
		SetPriceMultiplier(BotUpgradeValue);
		if(BotUpgradeValue == 0) 
		{
			if(GlobalCash.CashCount >= BotPrice * PriceMultiplier * Storage.PrestigeLvl) 
			{
				BotStop();
				GlobalCash.CashCount -= BotPrice * PriceMultiplier * Storage.PrestigeLvl;
				Debug.Log("Bought a bot for " + BotPrice * PriceMultiplier * Storage.PrestigeLvl);
				UpdateBotUpgradeValue(BotNumber);
				BotActivate();
				UpdateUpgradePriceBot(BotPrice, PriceMultiplier, BotUpgradeValue + 1);
				UpdateFill(BotNumber);
			}else 
			{
				Debug.Log("Not Enough " + Storage.CashCurrencyName + " to Buy This Upgrade!!!");
			}
		}else if(BotUpgradeValue >= 1 && BotUpgradeValue < 4)
		{
			if(GlobalCash.CashCount >= BotPrice * PriceMultiplier * Storage.PrestigeLvl) 
			{
				BotStop();
				GlobalCash.CashCount -= BotPrice * PriceMultiplier * Storage.PrestigeLvl;
				Debug.Log("Bought a bot for " + BotPrice * PriceMultiplier * Storage.PrestigeLvl);
				UpdateBotUpgradeValue(BotNumber);
				BotActivate();
				UpdateUpgradePriceBot(BotPrice, PriceMultiplier, BotUpgradeValue + 1);
				UpdateFill(BotNumber);
			}else {
				Debug.Log("Not Enough " + Storage.CashCurrencyName + " to Buy This Upgrade!!!");
			}
			
		}else if (BotUpgradeValue == 4)
		{
			if(GlobalCash.CashCount >= BotPrice * PriceMultiplier * Storage.PrestigeLvl)
			{
				BotStop();
				GlobalCash.CashCount -= BotPrice * PriceMultiplier * Storage.PrestigeLvl;
				Debug.Log("Bought a bot for " + BotPrice * PriceMultiplier * Storage.PrestigeLvl);
				UpdateBotUpgradeValue(BotNumber);
				BotActivate();
				UpdateUpgradePriceBot(BotPrice, PriceMultiplier, BotUpgradeValue + 1);
				UpdateFill(BotNumber);
				DeactivateBuyButton(BotNumber);
				if (UnlockAchievementEdward)
				{
					Achievements.UnlockAchievementEdward();
					PlayerPrefs.SetInt("UnlockAchievementEdward", 1);
					UnlockAchievementEdward = false;
				}

				if (UnlockAchievementHackerGod)
				{
					if (Storage.Bot1 == 5 && Storage.Bot2 == 5 && Storage.Bot3 == 5)
					{
						Achievements.UnlockAchievementHackerGod();
						PlayerPrefs.SetInt("UnlockAchievementHackerGod", 1);
						UnlockAchievementHackerGod = false;
					}
				}

				if (UnlockAchievementHackerman)
				{
					if (Storage.Bot1 >= 1 && Storage.Bot2 >= 1 && Storage.Bot3 >= 1)
					{
						Achievements.UnlockAchievementHackerman();
						PlayerPrefs.SetInt("UnlockAchievementHackerman", 1);
						UnlockAchievementHackerman = false;
					}
				}
			}else 
			{
				Debug.Log("Not Enough " + Storage.CashCurrencyName + " to Buy This Upgrade!!!");
			}
		}
	}
	
	private void Bot1Work() {
		GlobalVotes.VoteCount += (ulong)(Storage.Bot1Efficiency * Storage.PrestigeLvl * (int)Math.Pow(1.5, Storage.Bot1));
	}
	
	private void Bot2Work() {
		GlobalVotes.VoteCount += (ulong)(Storage.Bot2Efficiency * Storage.PrestigeLvl * (int)Math.Pow(1.5, Storage.Bot2));
	}
	private void Bot3Work() {
		GlobalVotes.VoteCount += (ulong)(Storage.Bot3Efficiency * Storage.PrestigeLvl * (int)Math.Pow(1.5, Storage.Bot3));
	}
	
	public void BotActivate() {
		int TotalBotEarningsCount = 0;
		if(Storage.Bot1 >= 1) {
			InvokeRepeating("Bot1Work", 0.0f, 1.0f);
			BotEarnings1.text = (Storage.Bot1Efficiency * Storage.PrestigeLvl * (int)Math.Pow(1.5, Storage.Bot1)).ToString("N0") + " Votes/Second";
			TotalBotEarningsCount += Storage.Bot1Efficiency * Storage.PrestigeLvl * (int)Math.Pow(1.5, Storage.Bot1);
		}
		if(Storage.Bot2 >= 1) {
			InvokeRepeating("Bot2Work", 0.0f, 1.0f);
			BotEarnings2.text = (Storage.Bot2Efficiency * Storage.PrestigeLvl * (int)Math.Pow(1.5, Storage.Bot2)).ToString("N0") + " Votes/Second";
			TotalBotEarningsCount += Storage.Bot2Efficiency * Storage.PrestigeLvl * (int)Math.Pow(1.5, Storage.Bot2);
		}
		if(Storage.Bot3 >= 1) {
			InvokeRepeating("Bot3Work", 0.0f, 1.0f);
			BotEarnings3.text = (Storage.Bot3Efficiency * Storage.PrestigeLvl * (int)Math.Pow(1.5, Storage.Bot3)).ToString("N0") + " Votes/Second";
			TotalBotEarningsCount += Storage.Bot3Efficiency * Storage.PrestigeLvl * (int)Math.Pow(1.5, Storage.Bot3);
		}
		TotalBotEarnings.text = "Total " + TotalBotEarningsCount.ToString("N0") + " Votes/Second";
	}
	
	public void BotStop() {
		CancelInvoke();
	}
	
	private void SetPriceMultiplier(int BotUpgradeValue) {
		switch (BotUpgradeValue) 
		{
			case 0:
				PriceMultiplier = 1;
				break;
			case 1:
				PriceMultiplier = Storage.Price1Multiplier;
				break;
			case 2:
				PriceMultiplier = Storage.Price2Multiplier;
				break;
			case 3:
				PriceMultiplier = Storage.Price3Multiplier;
				break;
			case 4:
				PriceMultiplier = Storage.Price4Multiplier;
				break;
		}
	}
	
	private void UpdateBotUpgradeValue(int BotNumber) {
		switch (BotNumber)
		{
			case 1:
				Storage.Bot1 += 1;
				break;
			case 2:
				Storage.Bot2 += 1;
				break;
			case 3:
				Storage.Bot3 += 1;
				break;
		}
	}
	
	private void DeactivateBuyButton(int BotNumber) {
		switch (BotNumber) {
			case 1:
				BuyBot1.interactable = false;
				break;
			case 2:
				BuyBot2.interactable = false;
				break;
			case 3:
				BuyBot3.interactable = false;
				break;
		}
	}
	
	private void UpdateUpgradePriceBot(int BotPrice, int PriceMultiplier, int BotUpgradeValue) {
		//string BotName;
		switch (PriceMultiplier) 
		{
			case 1:
				PriceMultiplier = Storage.Price1Multiplier;
				break;
			case Storage.Price1Multiplier:
				PriceMultiplier = Storage.Price2Multiplier;
				break;
			case Storage.Price2Multiplier:
				PriceMultiplier = Storage.Price3Multiplier;
				break;
			case Storage.Price3Multiplier:
				PriceMultiplier = Storage.Price4Multiplier;
				break;
			case Storage.Price4Multiplier:
				PriceMultiplier = Storage.Price4Multiplier;
				break;
		}
		if(BotPrice == Storage.Bot1Price) {
			//BotName = "Bot1";
			if(BotUpgradeValue >= 1 && BotUpgradeValue < 5)
			{
				UpgradePriceBot1.GetComponent<Text>().text = /*"Buy " + BotName + " upgrade for "*/ + BotPrice * PriceMultiplier * Storage.PrestigeLvl + " " + Storage.CashCurrencyName;
			}else if (BotUpgradeValue == 5)
			{
				UpgradePriceBot1.GetComponent<Text>().text = "Fully Upgraded";
			}
			//Debug.Log(BotName + "Upgrade was bought. " + BotPrice + "<- BotPrice" + PriceMultiplier + "<- PriceMultiplier");
		}else if(BotPrice == Storage.Bot2Price) {
			//BotName = "Bot2";
			if(BotUpgradeValue >= 1 && BotUpgradeValue < 5)
			{
				UpgradePriceBot2.GetComponent<Text>().text = /*"Buy " + BotName + " upgrade for "*/ + BotPrice * PriceMultiplier * Storage.PrestigeLvl + " " + Storage.CashCurrencyName;
			}else if (BotUpgradeValue == 5)
			{
				UpgradePriceBot2.GetComponent<Text>().text = "Fully Upgraded";
			}
			//Debug.Log(BotName + "Upgrade was bought. " + BotPrice + "<- BotPrice" + PriceMultiplier + "<- PriceMultiplier");
		}else if(BotPrice == Storage.Bot3Price) {
			//BotName = "Bot3";
			if(BotUpgradeValue >= 1 && BotUpgradeValue < 5)
			{
				UpgradePriceBot3.GetComponent<Text>().text = /*"Buy " + BotName + " upgrade for "*/ + BotPrice * PriceMultiplier * Storage.PrestigeLvl + " " + Storage.CashCurrencyName;
			}else if (BotUpgradeValue == 5)
			{
				UpgradePriceBot3.GetComponent<Text>().text = "Fully Upgraded";
			}
			//Debug.Log(BotName + "Upgrade was bought. " + BotPrice + "<- BotPrice" + PriceMultiplier + "<- PriceMultiplier");
		}
		
		
	}
	
	private void UpdateFill(int BotNumber)
    {
		if(BotNumber == 1) {
			russianBotBar.fillAmount = (float)Storage.Bot1 / (float)5;
		}else if(BotNumber == 2) {
			chineseBotBar.fillAmount = (float)Storage.Bot2 / (float)5;
		}else if(BotNumber == 3) {
			northKoreanBotBar.fillAmount = (float)Storage.Bot3 / (float)5;
		}
        
    }
}
