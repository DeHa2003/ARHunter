using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VersionGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    void Start()
    {
        text.text = "Версия: " + Application.version;
    }
}
