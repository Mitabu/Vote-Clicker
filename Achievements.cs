using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class Achievements : MonoBehaviour
{
    public void OpenAchievementPanel()
    {
        Social.ShowAchievementsUI();
    }

    public static void UnlockAchievementEdward()
    {
        Social.ReportProgress(GPGSIds.achievement_edward_snowden, 100f, null);
        //You have just upgraded your hacker to the max level!
    }

    public static void UnlockAchievementHackerGod()
    {
        Social.ReportProgress(GPGSIds.achievement_hacker_god, 100f, null);
        //You have just upgraded all hackers to the max level!
    }

    public static void UnlockAchievementHackerman()
    {
        Social.ReportProgress(GPGSIds.achievement_hackerman, 100f, null);
        //Good job! You bought all hackers!
    }

    public static void UnlockAchievementAmericaGreatAgain()
    {
        Social.ReportProgress(GPGSIds.achievement_america_great_again, 100f, null);
        //Congrats on your first 1000 votes!
    }
}
