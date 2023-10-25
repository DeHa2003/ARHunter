using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    private Animator animator;
    private int sceneNumber = -1;

    private bool isOpening = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        animator.SetTrigger("Close");
    }

    public void GoToScene(int scene)
    {
        if (!isOpening)
        {
            sceneNumber = scene;
            animator.SetTrigger("Open");
            isOpening = true;
        }
    }

    public void LoadScene()
    {
        if(sceneNumber != -1)
        SceneManager.LoadScene(sceneNumber);
    }
}
