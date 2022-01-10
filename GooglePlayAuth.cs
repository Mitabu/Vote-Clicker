using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using System.Diagnostics;

public class GooglePlayAuth : MonoBehaviour
{
    public static PlayGamesPlatform platform;



    void Start()
    {
        
        if(platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;

            PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate(success =>
        {
            if(success)
            {
               UnityEngine.Debug.Log("Logged In");
            }
            else
            {
                UnityEngine.Debug.Log("Failed to Log In");
            }


        });



    }

}
