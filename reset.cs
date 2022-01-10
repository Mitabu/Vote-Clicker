using UnityEngine;

public class reset : MonoBehaviour
{
    public void resetPurchases() {
		/*PlayerPrefs.SetInt("bot1", 0);
		PlayerPrefs.SetInt("bot2", 0);
		PlayerPrefs.SetInt("bot3", 0);
		Canvas.SendMessage("BotStop");*/
		
		Storage.UpgradeNumber = 0;
		Storage.VotesPerClick = 0;
		Storage.PrestigeLvl = 0;
		Storage.PrestigePrice = ((int)(100000 * ((float)Storage.PrestigeLvl + (float)Storage.PrestigeLvl * (float)0.2)));
		GlobalVotes.VoteCount = 0;
		GlobalCash.CashCount = 0;
		GlobalPremium.PremiumCount = 0;
		Storage.Bot1 = 0;
		Storage.Bot2 = 0;
		Storage.Bot3 = 0;
		
		PlayerPrefs.DeleteAll();
		
		//BotMechanics.BotStop();
		/*PlayerPrefs.SetInt("voteNum", 111000);
		PlayerPrefs.SetString("savedDateTime", " ");
		PlayerPrefs.SetInt("upgradeNumber", 0);
		PlayerPrefs.SetInt("votesPerClick", 1);
		PlayerPrefs.SetFloat("prestigeLvl", 1);
		PlayerPrefs.SetFloat("targetVoteGoalMultiplier", PlayerPrefs.GetFloat("prestigeLvl") + (float)0.2);*/
	}
}
