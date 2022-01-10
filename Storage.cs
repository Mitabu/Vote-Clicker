using System;
using UnityEngine;

public class Storage : MonoBehaviour
{
	/*private void LoadGameSequence()
	{
		InitiatePrestige();
		InitiateClickUpgrades();
		LoadGame();
		InitiatePrestige();
		InitiateClickUpgrades();
	}*/

	private void Awake()
	{
		LoadGame();
		if (PlayerPrefs.GetInt("FirstLoad") == 0)
		{
			Storage.PrestigeLvl = 1;
			Storage.TargetVoteGoalMultiplier = (float)PrestigeLvl + (float)PrestigeLvl * (float)0.2;
			Storage.PrestigePrice = (int)(100000 * TargetVoteGoalMultiplier);
			Storage.VotesPerClick = 1;
			PlayerPrefs.SetInt("FirstLoad", 1);
		}
	}

	private void OnApplicationQuit() {
		SaveGame();
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus)
		{
			SaveGame();
		}
	}

	public static int PrestigeLvl; //Presitge level number. Used for upgrading prices after reset
	public const string CashCurrencyName = "$";
	public const string PremiumCurrencyName = "Premium";
	
	private void InitiatePrestige() 
	{
		if(PrestigeLvl == 0) 
		{
			PrestigeLvl += 1;
			PrestigePrice += 1;
			TargetVoteGoalMultiplier = (float)PrestigeLvl + (float)PrestigeLvl * (float)0.2;
			PrestigePrice = (int)(100000 * TargetVoteGoalMultiplier);
		}
	}
	
	public static float TargetVoteGoalMultiplier;// = (float)PrestigeLvl + (float)PrestigeLvl * (float)0.2; //Price modifier
	public static int PrestigePrice; //= (int)(100000 * TargetVoteGoalMultiplier); //Standard prestige price
	
	public static int VotesPerClick; //Number of votes user does per click
	public static int UpgradeNumber; //Number of upgrades that the VoteClickButton has
	public const int UpgradeCoefficient = 10; //Number by which the upgrade price of the click button is multiply after bought
	
	private void InitiateClickUpgrades() 
	{
		if(VotesPerClick == 0) {
			VotesPerClick += 1;
		}
	}
	
	public const int ClickUpgradePrice = 100; //Standard click upgrade price
	
	public const int ClickUpgradeModifier1 = 1; //The number by whitch the click price is multiplied after upgrade #n
	public const int ClickUpgradeModifier2 = 2;
	public const int ClickUpgradeModifier3 = 5;
	public const int ClickUpgradeModifier4 = 10;
	
	public static int Bot1;
	public static int Bot2;
	public static int Bot3;
	
	public const int Bot1Price = 50; //Price of bots
	public const int Bot2Price = 500;
	public const int Bot3Price = 1000;
	
	public const int Price1Multiplier = 5; //Price multiplier sets the number by which the standard bot price is multiplied after each bot upgrade
	public const int Price2Multiplier = 10;
	public const int Price3Multiplier = 25;
	public const int Price4Multiplier = 40;
	
	public const int Bot1Efficiency = 5; //Bot's efficiency (votes per second)
	public const int Bot2Efficiency = 15;
	public const int Bot3Efficiency = 30;
	
	public const int MinAwayInterval = 30; //Minimum amount of time (in seconds) a user needs to spend away in order to get a while away bonus
	public const int MaxAwayInterval = 3600; //Maximum interval of time (in seconds) user can get rewarded for after returning to the app
	
	public static double ExchangeRate = 0.5; //Rate of exchange (votes * exchangeRate = cash)
	public const double ExchangeRateBonus1 = 0.05;
	public const double ExchangeRateBonus2 = 0.07;
	public const double ExchangeRateBonus3 = 0.1;
	public const double ExchangeRateBonus4 = 0.12;
	
	public const double Exchange1Amount = 100; //Exchange amount per button click
	public const double Exchange2Amount = 500;
	public const double Exchange3Amount = 1000;
	public const double Exchange4Amount = 10000;
	public const double Exchange5Amount = 100000;

	private static void SaveGame() 
	{
		PlayerPrefs.SetInt("UpgradeNumber", Storage.UpgradeNumber);
		PlayerPrefs.SetInt("VotesPerClick", Storage.VotesPerClick);
		PlayerPrefs.SetInt("PrestigeLvl", Storage.PrestigeLvl);
		PlayerPrefs.SetInt("PrestigePrice", ((int)(100000 * ((float)PrestigeLvl + (float)PrestigeLvl * (float)0.2))));
		PlayerPrefs.SetString("VoteCount", GlobalVotes.VoteCount.ToString());
		PlayerPrefs.SetInt("CashCount", GlobalCash.CashCount);
		PlayerPrefs.SetInt("PremiumCount", GlobalPremium.PremiumCount);
		PlayerPrefs.SetInt("Bot1", Storage.Bot1);
		PlayerPrefs.SetInt("Bot2", Storage.Bot2);
		PlayerPrefs.SetInt("Bot3", Storage.Bot3);
		PlayerPrefs.SetInt("AudioSetting", AudioMechanics.AudioSetting);
	}
	
	private static void LoadGame()
	{
		if (PlayerPrefs.GetInt("PrestigeLvl") == 0)
		{
			Storage.PrestigeLvl = 1;
			Storage.TargetVoteGoalMultiplier = (float)PrestigeLvl + (float)PrestigeLvl * (float)0.2;
			Storage.PrestigePrice = (int)(100000 * TargetVoteGoalMultiplier);
			Storage.VotesPerClick = 1;
		}
		else
		{
			Storage.UpgradeNumber = PlayerPrefs.GetInt("UpgradeNumber");
			Storage.VotesPerClick = PlayerPrefs.GetInt("VotesPerClick");
			Storage.PrestigeLvl = PlayerPrefs.GetInt("PrestigeLvl");
			Storage.PrestigePrice = PlayerPrefs.GetInt("PrestigePrice");
			GlobalVotes.VoteCount = UInt64.Parse(PlayerPrefs.GetString("VoteCount"));
			GlobalCash.CashCount = PlayerPrefs.GetInt("CashCount");
			GlobalPremium.PremiumCount = PlayerPrefs.GetInt("PremiumCount");
			Storage.Bot1 = PlayerPrefs.GetInt("Bot1");
			Storage.Bot2 = PlayerPrefs.GetInt("Bot2");
			Storage.Bot3 = PlayerPrefs.GetInt("Bot3");
			AudioMechanics.AudioSetting = PlayerPrefs.GetInt("AudioSetting");
		}
	}
}
