using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Bot : MonoBehaviour
{
	public GameObject Canvas;
	public GameObject bb1;
	public GameObject bb2;
	public GameObject bb3;
	
	public Text botEarnings1;
	public Text botEarnings2;
	public Text botEarnings3;
	
	public Button buyBot1; //Bot buy buttons
	public Button buyBot2;
	public Button buyBot3;
	public int botNumber; //Number of the bot you want to buy
	public bool activateOnLoad; // set TRUE if you want to check if the bots are bought, and if so then start them
	
	private int voteNum; //Number of votes/clicks
	private int botPrice; //Price of bots
	private float prestigeLvl;
	private int priceMultiplier;
	
	void Start() {
		Canvas = GameObject.Find("Canvas");
		bb1 = GameObject.Find("Button_Buy_Bot1");
		bb2 = GameObject.Find("Button_Buy_Bot2");
		bb3 = GameObject.Find("Button_Buy_Bot3");
		prestigeLvl = PlayerPrefs.GetFloat("prestigeLvl");
		if(activateOnLoad) 
		{
			if(buyBot1.interactable == true) 
			{
				if(PlayerPrefs.GetInt("bot1") == 5) 
				{
					buyBot1.interactable = false;
				}
			}
			if(buyBot2.interactable == true) 
			{
					if(PlayerPrefs.GetInt("bot2") == 5) 
					{
						buyBot2.interactable = false;
					}
			}
			if(buyBot3.interactable == true) 
			{
					if(PlayerPrefs.GetInt("bot3") == 5) 
					{
						buyBot3.interactable = false;
					}
			}
			BotActivate();
		}
	}
	
	public void BuyBot() 
	{
		int currentVoteNum = PlayerPrefs.GetInt("voteNum");
		int botUpgradeValue = PlayerPrefs.GetInt("bot" + botNumber);
		switch (botNumber) 
		{
			case 1:
				botPrice = PlayerPrefs.GetInt("bot1Price");
				break;
			case 2:
				botPrice = PlayerPrefs.GetInt("bot2Price");
				break;
			case 3:
				botPrice = PlayerPrefs.GetInt("bot3Price");
				break;
		}
		switch (PlayerPrefs.GetInt("bot" + botNumber)) 
		{
			case 1:
				priceMultiplier = PlayerPrefs.GetInt("price2Multiplier");
				break;
			case 2:
				priceMultiplier = PlayerPrefs.GetInt("price3Multiplier");
				break;
			case 3:
				priceMultiplier = PlayerPrefs.GetInt("price4Multiplier");
				break;
			case 4:
				priceMultiplier = PlayerPrefs.GetInt("price5Multiplier");
				break;
		}
		if(botUpgradeValue == 0) 
		{
			currentVoteNum = PlayerPrefs.GetInt("voteNum");
			prestigeLvl = PlayerPrefs.GetFloat("prestigeLvl");
			if(currentVoteNum >= botPrice*(int)prestigeLvl) 
			{
				currentVoteNum = PlayerPrefs.GetInt("voteNum");
				CallBotStop();
				currentVoteNum -= botPrice*(int)prestigeLvl;
				PlayerPrefs.SetInt("voteNum", currentVoteNum);
				PlayerPrefs.SetInt("bot" + botNumber.ToString(), 1);
				Debug.Log(PlayerPrefs.GetInt("bot" + botNumber));
				BotActivate();
			}else 
			{
				Debug.Log("Not Enough Votes to Buy This Upgrade!!!");
			}
		}else if(botUpgradeValue >= 1 && botUpgradeValue < 4)
		{
			currentVoteNum = PlayerPrefs.GetInt("voteNum");
			if(currentVoteNum >= botPrice*priceMultiplier*(int)prestigeLvl) 
			{
				CallBotStop();
				currentVoteNum -= botPrice*priceMultiplier*(int)prestigeLvl;
				PlayerPrefs.SetInt("voteNum", currentVoteNum);
				PlayerPrefs.SetInt("bot" + botNumber.ToString(), PlayerPrefs.GetInt("bot" + botNumber.ToString()) + 1);
				Debug.Log(PlayerPrefs.GetInt("bot" + botNumber));
				BotActivate();
			}else {
				Debug.Log("Not Enough Votes to Buy This Upgrade!!!");
			}
			
		}else if (botUpgradeValue == 4)
		{
			currentVoteNum = PlayerPrefs.GetInt("voteNum");
			if(currentVoteNum >= botPrice*priceMultiplier*(int)prestigeLvl)
			{
				priceMultiplier = PlayerPrefs.GetInt("price5Multiplier");
				CallBotStop();
				currentVoteNum -= botPrice*priceMultiplier*(int)prestigeLvl;
				PlayerPrefs.SetInt("voteNum", currentVoteNum);
				PlayerPrefs.SetInt("bot" + botNumber.ToString(), PlayerPrefs.GetInt("bot" + botNumber.ToString()) + 1);
				Debug.Log(PlayerPrefs.GetInt("bot" + botNumber));
				BotActivate();
				DeactivateBuyButton();
			}else 
			{
				Debug.Log("Not Enough Votes to Buy This Upgrade!!!");
			}
		}
	}
	
	private void Bot1Work() {
		int botEfficiency = PlayerPrefs.GetInt("bot1Efficiency");
		voteNum = PlayerPrefs.GetInt("voteNum");
		voteNum += botEfficiency * (int)prestigeLvl * (int)Math.Pow(1.5, PlayerPrefs.GetInt("bot1"));
		botEarnings1.text = "Bot 1 makes " + botEfficiency * (int)prestigeLvl * (int)Math.Pow(1.5, PlayerPrefs.GetInt("bot1")) + " votes a'second";
		PlayerPrefs.SetInt("voteNum", voteNum);
	}
	
	private void Bot2Work() {
		int botEfficiency = PlayerPrefs.GetInt("bot2Efficiency");
		voteNum = PlayerPrefs.GetInt("voteNum");
		voteNum += botEfficiency * (int)prestigeLvl * (int)Math.Pow(1.5, PlayerPrefs.GetInt("bot2"));
		botEarnings2.text = "Bot 2 makes " + botEfficiency * (int)prestigeLvl * (int)Math.Pow(1.5, PlayerPrefs.GetInt("bot2")) + " votes a'second";
		PlayerPrefs.SetInt("voteNum", voteNum);
	}
	private void Bot3Work() {
		int botEfficiency = PlayerPrefs.GetInt("bot3Efficiency");
		voteNum = PlayerPrefs.GetInt("voteNum");
		voteNum += botEfficiency * (int)prestigeLvl * (int)Math.Pow(1.5, PlayerPrefs.GetInt("bot3"));
		botEarnings3.text = "Bot 3 makes " + botEfficiency * (int)prestigeLvl * (int)Math.Pow(1.5, PlayerPrefs.GetInt("bot3")) + " votes a'second";
		PlayerPrefs.SetInt("voteNum", voteNum);
	}
	
	public void BotActivate() {
		if(PlayerPrefs.GetInt("bot1") >= 1) {
			InvokeRepeating("Bot1Work", 0.0f, 1.0f);
		}
		if(PlayerPrefs.GetInt("bot2") >= 1) {
			InvokeRepeating("Bot2Work", 0.0f, 1.0f);
		}
		if(PlayerPrefs.GetInt("bot3") >= 1) {
			InvokeRepeating("Bot3Work", 0.0f, 1.0f);
		}
	}
	
	public void CallBotStop() {
		Canvas.SendMessage("BotStop");
		bb1.SendMessage("BotStop");
		bb2.SendMessage("BotStop");
		bb3.SendMessage("BotStop");
	}
	
	public void CallBotActivate() {
		Canvas.SendMessage("BotActivate");
	}
	
	public void BotStop() {
		CancelInvoke();
	}
	
	private void DeactivateBuyButton() {
		switch (botNumber) {
			case 1:
				buyBot1.interactable = false;
				break;
			case 2:
				buyBot2.interactable = false;
				break;
			case 3:
				buyBot3.interactable = false;
				break;
		}
	}
}
