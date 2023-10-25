using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFinishGame : MonoBehaviour
{
    [SerializeField] private GameObject finishPanel;
    private void OnEnable()
    {
        Timer.OnFinishTimer += ActivateFinishPanel;
    }

    private void OnDisable()
    {
        Timer.OnFinishTimer -= ActivateFinishPanel;
    }

    private void ActivateFinishPanel()
    {
        finishPanel.SetActive(true);
        Destroy(GetComponent<OnFinishGame>());
    }
}
