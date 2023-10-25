using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] private RayPlayer player;
    [SerializeField] private PlayAnimationMainScene animationScene;
    [SerializeField] private Score score;

    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textHitRate;

    private float a;
    private void OnEnable()
    {
        animationScene.PlayAnimations(true);

        textScore.text = score.GetScore();
        a = (float)player.GetCountGoodFire() / player.GetAllCountFire() * 100f;
        textHitRate.text = Mathf.Round(a).ToString();
    }
}
