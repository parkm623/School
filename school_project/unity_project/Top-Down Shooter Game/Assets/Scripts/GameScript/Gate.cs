using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject closedDoorObject;
    public GameObject openedDoorObject;
    public Player player;

    private void Update()
    {
        if (GameManager.Instance.CheckClear()) 
        {
            closedDoorObject.SetActive(false);
            openedDoorObject.SetActive(true);
        }
        else
        {
            closedDoorObject.SetActive(true);
            openedDoorObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null && gameObject.tag == "Gate")
        {
            Debug.Log("Clear");
            GameManager.Instance.SetNextStage();
            Debug.Log(GameManager.Instance.currentStage); 
        }
    }

}
