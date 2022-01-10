using UnityEngine;
using UnityEngine.UI;

public class PrestigeMechanics : MonoBehaviour
{	
	public Button bbb1;
	public Button bbb2;
	public Button bbb3;
	public Button bub;
	
	public Image russianBotBar;
	public Image chineseBotBar;
	public Image northKoreanBotBar;
	
	public GameObject BotEarnings1;
	public GameObject BotEarnings2;
	public GameObject BotEarnings3;
	public GameObject TotalBotEarnings;
	public GameObject UpgradePriceBot1;
	public GameObject UpgradePriceBot2;
	public GameObject UpgradePriceBot3;
	public GameObject UpgradePriceDisplay;
	public GameObject ClickUpgradeDisplay;
	
	public void PrestigeUpgrade() {
		if(GlobalVotes.VoteCount >= (ulong)Storage.PrestigePrice) {
			GlobalVotes.VoteCount -= (ulong)Storage.PrestigePrice;
			Debug.Log(GlobalVotes.VoteCount);
			Storage.PrestigeLvl += 1;
			Storage.PrestigePrice = ((int)(100000 * ((float)Storage.PrestigeLvl + (float)Storage.PrestigeLvl * (float)0.2)));
			ResetProgress();
			GlobalPremium.PremiumCount += 100;
		}else {
			Debug.Log((Storage.PrestigePrice));
		}
	}
	
	private void ResetProgress() {
		//Stop Bots
		GameObject MechanicsObject = GameObject.Find("MechanicsObject");
		MechanicsObject.SendMessage("BotStop");
		MechanicsObject.SendMessage("UpdatePrices");
		GameObject GlobalCurrencyObject = GameObject.Find("GlobalCurrencyObject");

		BotEarnings1.GetComponent<Text>().text = "Russian Hacker Doesn't Work For You Yet";
		BotEarnings2.GetComponent<Text>().text = "4CHAN Hacker Doesn't Work For You Yet";
		BotEarnings3.GetComponent<Text>().text = "North Korean Hacker Doesn't Work For You Yet";
		TotalBotEarnings.GetComponent<Text>().text = "Total 0 Votes/Second";
		UpgradePriceBot1.GetComponent<Text>().text = (Storage.Bot1Price * Storage.PrestigeLvl).ToString("N0") + " " + Storage.CashCurrencyName;
		UpgradePriceBot2.GetComponent<Text>().text = (Storage.Bot2Price * Storage.PrestigeLvl).ToString("N0") + " " + Storage.CashCurrencyName;
		UpgradePriceBot3.GetComponent<Text>().text = (Storage.Bot3Price * Storage.PrestigeLvl).ToString("N0") + " " + Storage.CashCurrencyName;
		UpgradePriceDisplay.GetComponent<Text>().text = "Upgrade your vote per click for " + (Storage.ClickUpgradePrice * Storage.PrestigeLvl).ToString("N0") + " " + Storage.CashCurrencyName;
		ClickUpgradeDisplay.GetComponent<Text>().text = (Storage.VotesPerClick = 5 * Storage.PrestigeLvl).ToString("N0") + " Votes/Click";

		//Turn the upgrade buttons back on
		bbb1.interactable = true;
		bbb2.interactable = true;
		bbb3.interactable = true;
		bub.interactable = true;
		
		//Reset bots' bought status
		Storage.Bot1 = 0;
		Storage.Bot2 = 0;
		Storage.Bot3 = 0;
		
		//Reset bots' bought status fill bars
		russianBotBar.fillAmount = (float)Storage.Bot1 / (float)5;
		chineseBotBar.fillAmount = (float)Storage.Bot2 / (float)5;
		northKoreanBotBar.fillAmount = (float)Storage.Bot3 / (float)5;
		
		//Reset vote per click upgrade
		Storage.UpgradeNumber = 0;
		Storage.VotesPerClick = 5 * Storage.PrestigeLvl;
	}
}
