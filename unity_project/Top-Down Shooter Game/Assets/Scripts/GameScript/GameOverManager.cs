using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOverManger : MonoBehaviour
{
    public Text flashingText;
    private string textToDisplay = "Click to Exit";
    public float blinkInterval = 0.5f;
    public GameObject gameOverPan;

    private void Start()
    {
        if (flashingText == null)
        {
            flashingText = GetComponent<Text>();
        }

        if (flashingText != null)
        {
            flashingText.text = textToDisplay;
            StartCoroutine(Blink());
        }
        else
        {
            Debug.LogError("Text component is not assigned!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            flashingText.text = textToDisplay;
            yield return new WaitForSecondsRealtime(blinkInterval);
            flashingText.text = string.Empty;
            yield return new WaitForSecondsRealtime(blinkInterval);
        }
    }


}
