using UnityEngine;
using UnityEngine.UI;
using System;


public class GlobalVotes : MonoBehaviour
{
    public static ulong VoteCount; //Number of Votes
	public GameObject VoteDisplay;
	private bool UnlockAchievementAmericaGreatAgain = false;

	//public static GameObject ProgressBar;
	public Image Mask;

	private void Start()
	{
		if (PlayerPrefs.GetInt("UnlockAchievementAmericaGreatAgain") == 0)
		{
			UnlockAchievementAmericaGreatAgain = true;
		}
	}
	private void Update()
    {
	    UpdateVoteDisplay();
    }

    private void UpdateVoteDisplay()
    {
	    VoteDisplay.GetComponent<Text>().text = String.Format("Votes : {0:N0} / {1:N0}", VoteCount,
		    Storage.PrestigePrice);
	    UpdateFill();
	    if (UnlockAchievementAmericaGreatAgain)
	    {
		    if (VoteCount >= 1000)
		    {
			    Achievements.UnlockAchievementAmericaGreatAgain();
			    UnlockAchievementAmericaGreatAgain = false;
			    PlayerPrefs.SetInt("UnlockAchievementAmericaGreatAgain", 1);
		    }
	    }
    }

    private void UpdateFill()
    {
        Mask.fillAmount = (float)VoteCount / (float)Storage.PrestigePrice;
    }
}
