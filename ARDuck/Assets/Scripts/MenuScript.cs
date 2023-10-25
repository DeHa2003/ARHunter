using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private OpenScene openScene;

    private bool isOpenMainScene = false;

    public void ExitGame()
    {
        Application.Quit();
    }
}
