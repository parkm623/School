using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.CinemachineCore;


public class GameManager : MonoBehaviour
{
    public Player player;
    public MonsterController monster;
    public static GameManager Instance;

    // Stage
    public GameObject[] stages;
    public GameObject fisrtStage;
    public GameObject bossStage;
    private List<int> availableStages;
    public int currentStage = -1;
    private bool isClear = false;
    private bool isFirst;
    private bool isPause = false;
    private List<GameObject> monsterList = new List<GameObject>();
    private bool isGameClear = false;
    private bool isPlay = false;
    private bool playerDied = false;
    private bool isBossStage = false;


    // Score
    public int score;
    private int[] bestScore = new int[5];
    private string[] bestName = new string[5];
    public Text scoreText;

    public GameObject gameOverPan;


    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip defaultStageBGM;
    [SerializeField] private AudioClip bossStageBGM;
    [SerializeField] public GameData gameData;

    private void Awake()
    {
        if (gameData == null)
        {
            Debug.LogError("GameData is not assigned to GameManager!");
            gameData = ScriptableObject.CreateInstance<GameData>();
        }
    }

    private void SaveGameData()
    {

        gameData.score = score;
        gameData.currentStage = currentStage;
        gameData.isFirstStage = isFirst;
        gameData.isPause = isPause;
        gameData.isPlay = isPlay;
        gameData.isGameClear = isGameClear;
        gameData.playerDied = playerDied;
        gameData.isBossStage = isBossStage;
        if (player != null)
        {
            player.PlayerSaveGameData();
        }
    }

    public void LoadData()
    {
        if (!gameData.isBossStage)
        {
            return;

        }
        else
        {
            score = gameData.score;
            currentStage = gameData.currentStage;
            isFirst = gameData.isFirstStage;
            isPause = gameData.isPause;
            isPlay = gameData.isPlay;
            isGameClear = gameData.isGameClear;
            playerDied = gameData.playerDied;
            isBossStage = gameData.isBossStage;
            if (player != null)
            {
                player.PlayerLoadData();
            }

        }

    }

    IEnumerator CountScore()
    {
        while (!isPause && isPlay)
        {
            if (scoreText != null)
            {
                scoreText.text = score.ToString();
                yield return new WaitForSeconds(1f);
                score++;
            }
            else
            {
                Debug.LogError("ScoreText is null!");
                yield break;
            }
        }
    }

    void Start()
    {
        if (!gameData.isBossStage)
        {
            Debug.Log("Starting normal stage");
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            Initialize();  

            scoreText = GameObject.Find("Score")?.GetComponent<Text>();
            if (scoreText == null)
            {
                Debug.LogError("ScoreText not found");
                return;
            }

            gameOverPan.SetActive(false);
            SetStages();
            StartCoroutine(CountScore());
            PlayBGM(defaultStageBGM);
        }
        else
        {
            Debug.Log("Starting boss stage");
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            SetBossStage();
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void Initialize()
    {
        Time.timeScale = 1;
        isPause = false;
        isPlay = true;
        isGameClear = false;
        playerDied = false;
        isBossStage = false;
        SaveGameData();

    }

    void SetStages()
    {
        availableStages = new List<int>();
        for (int i = 0; i < stages.Length; i++)
        {
            availableStages.Add(i);
        }

        fisrtStage.SetActive(true);
        isFirst = true;
        SetMonster(fisrtStage);
    }

    public void SetNextStage()
    {
        DestroyAllProjectiles();
        if (currentStage != -1)
        {
            stages[currentStage].SetActive(false);
        }

        if (isFirst)
        {
            fisrtStage.SetActive(false);
            isFirst = false;
        }

        if (availableStages.Count == 0)
        {
            isBossStage = true;
            SaveGameData();
            StopCoroutine(CountScore());
            SceneManager.LoadScene("BossEnter");
        }

        else
        {
            int randomStage = UnityEngine.Random.Range(0, availableStages.Count);
            currentStage = availableStages[randomStage];
            stages[currentStage].SetActive(true);
            availableStages.RemoveAt(randomStage);
            SetMonster(stages[currentStage]);
        }
        SetNoClear();
        player.respawn();
    }

    public void SetBossStage()
    {
        LoadData();
        StartCoroutine(CountScore());
        PlayBGM(bossStageBGM);
        bossStage.SetActive(true);
    }

    private void SetMonster(GameObject stage)
    {
        monsterList.Clear();
        MonsterController[] monstersInStage = stage.GetComponentsInChildren<MonsterController>(true);
        foreach (MonsterController monster in monstersInStage)
        {
            monsterList.Add(monster.gameObject);
        }
    }

    public void SetClear()
    {
        isClear = true;
    }
    public void SetNoClear()
    {
        isClear = false;
    }

    public bool CheckClear()
    {
        return isClear;
    }

    public bool CheckPause()
    {
        return isPause;
    }
    public bool CheckPlay()
    {
        return isPlay;
    }
    public void PauseGame()
    {
        if (isPause != true)
        {
            Time.timeScale = 0;
            isPause = true;
        }
        else
        {
            Time.timeScale = 1;
            isPause = false;
        }
    }
    public void EndGame()
    {
        DestroyAllProjectiles();
        isPlay = false;
        Time.timeScale = 0;
        if (playerDied)
        {
            gameOverPan.SetActive(true);
        }
        else if (isGameClear)
        {
            LeaderBoardManager.Instance.LeaderBoardUpdate(score);
        }
    }

    public void KilledMonster(GameObject monster)
    {
        monsterList.Remove(monster);
        if (monsterList.Count == 0)
        {
            Debug.Log("All monsters are dead. Stage Clear!");
            SetClear();
        }
        else
        {
            Debug.Log($"Monsters remaining: {monsterList.Count}");
        }
    }

    public void DestroyAllProjectiles()
    {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("PlayerBullet");
        foreach (GameObject projectile in projectiles)
        {
            Destroy(projectile);
        }
    }

    public void BossStageClear()
    {
        Debug.Log("Boss monster is dead. Stage Clear!");
        isGameClear = true;
        EndGame();
    }

    public void SetPlayerDied()
    {
        playerDied = true;
        EndGame();
    }
    private void PlayBGM(AudioClip clip)
    {
        Debug.Log($"Trying to play BGM: {clip?.name}");
        if (audioSource.clip != clip)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
            Debug.Log($"Playing new BGM: {clip?.name}");
        }
    }
}
