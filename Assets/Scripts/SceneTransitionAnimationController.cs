using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class SceneTransitionAnimationController : MonoBehaviour
{
    public static SceneTransitionAnimationController instance;
    public float fadeOpenDuration = 0.25f;

    private Animator anim;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 120;
    }

    private void CloseTransition(Scene scene, LoadSceneMode mode)
    {
        anim.SetTrigger("Close");
    }
    public void OpenTransition()
    {
        SceneManager.sceneLoaded += CloseTransition;
        anim.SetTrigger("Open");
    }
}
