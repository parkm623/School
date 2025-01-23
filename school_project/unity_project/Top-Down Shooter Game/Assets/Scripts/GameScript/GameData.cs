using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData")]
public class GameData : ScriptableObject
{
    //Game Data
    public int score;
    public int currentStage;
    public bool isFirstStage;
    public bool isPause;
    public bool isPlay;
    public bool isGameClear;
    public bool playerDied;
    public bool isBossStage;

    //Player Data
    public int playerHealth;
    public float playerStamina;
    public int playerPower;
    public float playerShootCooldown;
    public float playerBulletSpeed;
    public float playerMoveSpeed;
    public Vector3 playerPosition;
}
