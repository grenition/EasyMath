using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UITitleOpener : MonoBehaviour
{
    public bool startState = false;
    [SerializeField] private float closeAnimationDuration = 0.2333f;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        if (startState)
            Open();
        else
            gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        anim.SetTrigger("Close");
        StartCoroutine(TimeCloser(closeAnimationDuration));
    }
    private IEnumerator TimeCloser(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
