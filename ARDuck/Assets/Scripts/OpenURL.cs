using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    [SerializeField] private string path;

    public void URLOpen()
    {
        Application.OpenURL(path);
    }
}
