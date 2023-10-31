using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;

    private void OnEnable()
    {
        RayPlayer.OnHitBird += AddScore;
    }

    private void OnDisable()
    {
        RayPlayer.OnHitBird -= AddScore;
    }

    private void AddScore()
    {
        int a = int.Parse(textScore.text);
        a += 1;
        textScore.text = a.ToString();
    }

    public string GetScore()
    {
        return textScore.text;
    }
}
