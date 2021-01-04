using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        GameManager.OnCubeSpawnerd += GameManager_OnCubeSpawnerd;
    }

    private void OnDestroy()
    {
        GameManager.OnCubeSpawnerd -= GameManager_OnCubeSpawnerd;
    }

    private void GameManager_OnCubeSpawnerd()
    {
        score++;
        text.text = "Pontuação: " + score;

    }
}
