using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class YourNamePlayFab : MonoBehaviour
{
    [SerializeField] private TMP_Text displayName;
    [SerializeField] private TMP_Text levelXp;
    [SerializeField] private TMP_Text level;

    public void Start()
    {
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), OnGetAccountInfo, OnError);
        PlayFabClientAPI.GetPlayerStatistics(new GetPlayerStatisticsRequest(), OnGetPlayerStatistics, OnError);
    }
    
    public void OnGetAccountInfo(GetAccountInfoResult result)
    {
        displayName.text = result.AccountInfo.TitleInfo.DisplayName;
    }

    public void OnError(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }

    public void OnGetPlayerStatistics(GetPlayerStatisticsResult result)
    {
        float xp = result.Statistics[0].Value;
        float level = result.Statistics[1].Value;
        float toNextLevel = level * 100;

        levelXp.text = xp + "/" + (level * 100);
        this.level.text = level.ToString();
        if(xp >= toNextLevel)
        {
            PlayFabClientAPI.GetPlayerStatistics(new GetPlayerStatisticsRequest(), OnGetPlayerStatistics, OnError);
        }
    }
}
