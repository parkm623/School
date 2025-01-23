using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardManager : MonoBehaviour
{
    public GameObject leaderBoardPan;
    private int[] bestScore = new int[5];
    private string[] bestName = new string[5];
    public Text[] bestRank = new Text[5];

    public static LeaderBoardManager Instance;
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    public void LeaderBoardUpdate(int score)
    {
        leaderBoardPan.SetActive(true);
        string name = PlayerPrefs.GetString("CurrentPlayerName");

        for (int i = 0; i < 5; i++)
        {
            bestScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");
        }


        if (score != 0 && (bestScore[4] == 0 || score < bestScore[4]))
        {
            for (int i = 0; i < 5; i++)
            {
                if (bestScore[i] == 0 || score < bestScore[i])
                {
                    for (int j = 4; j > i; j--)
                    {
                        bestScore[j] = bestScore[j - 1];
                        bestName[j] = bestName[j - 1];
                    }
                    bestScore[i] = score;
                    bestName[i] = name;
                    break;
                }
            }
        }

        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(i + "BestScore", bestScore[i]);
            PlayerPrefs.SetString(i + "BestName", bestName[i]);
            if (PlayerPrefs.GetInt(i + "BestScore") != 0)
            {
                bestRank[i].text = bestName[i] + " " + bestScore[i].ToString();
            }
        }

    }
}
