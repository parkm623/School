using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuManager : MonoBehaviour
{
    public GameObject leaderBoardPan;
    public GameObject inputNamePan;
    public Text rank;
    private int[] bestScore = new int[5];
    private string[] bestName = new string[5];
    private string playerName;
    [SerializeField] public GameData gameData;

    public void StartName()
    {
        inputNamePan.SetActive(true);
    }
    public void StartGame()
    {
        InputName();
        inputNamePan.SetActive(false);
        gameData.isBossStage = false;
        SceneManager.LoadScene("Game");
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ExitLeaderBoard()
    {
        leaderBoardPan.SetActive(false);
    }
    public void LeaderBoard()
    {
        leaderBoardPan.SetActive(true);
        rank.text = "";

        for (int i = 0; i < 5; i++)
        {
            bestScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");

        }
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.GetInt(i + "BestScore") != 0)
            {
                rank.text = rank.text + bestName[i] + " " + bestScore[i].ToString() + "\n";
            }
        }
    }
    public void InputName()
    {
        GameObject inputField = GameObject.Find("NameBox");
        InputField playerNameInput = inputField.GetComponent<InputField>();
        playerName = playerNameInput.GetComponent<InputField>().text;

        if (playerName == "")
        {
            playerName = "NoName";
        }

        PlayerPrefs.SetString("CurrentPlayerName", playerName);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("CurrentPlayerName"));
    }

}
