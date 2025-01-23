using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BossEnterManager : MonoBehaviour
{
    public GameData gameData;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameData = GameManager.Instance.gameData;
            SceneManager.LoadScene("Game");
        }
    }
}