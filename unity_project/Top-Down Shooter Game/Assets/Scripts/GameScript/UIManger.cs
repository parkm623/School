using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManger : MonoBehaviour
{
    public GameObject pausePan;
    public GameObject leaderBoardPan;
    public Player player;

    void Start()
    {
        if (pausePan == null)
        {
            pausePan = GameObject.Find("PausePan");
        }
        if (leaderBoardPan == null)
        {
            leaderBoardPan = GameObject.Find("LeaderBoardPan");
        }
    }

    void Update()
    {
        if (GameManager.Instance.CheckPlay())
        {
            if (GameManager.Instance.CheckPause())
            {
                if (pausePan != null)
                {
                    pausePan.SetActive(true);
                }
            }
            else
            {
                if (pausePan != null)
                {
                    pausePan.SetActive(false);
                }
            }
        }
    }
    public void RespawnPlayer()
    {
        player.respawn();
        pausePan.SetActive(false);
        GameManager.Instance.PauseGame();
    }

    public void ExitPause()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.Instance.EndGame();
        pausePan.SetActive(false);
        GameManager.Instance.PauseGame();
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene("MainMenu");
        leaderBoardPan.SetActive(false);
    }
}
