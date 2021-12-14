using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Animator))]
public class AnswerButton : MonoBehaviour
{
    [SerializeField] private Text buttonText;

    private string answer = string.Empty;

    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public string Answer
    {
        get => answer;
        set
        {
            answer = value;

            if (buttonText != null)
                buttonText.text = answer;
        }
    }

    public void SetAnswerState(bool isTrueAnswer)
    {
        if (isTrueAnswer)
        {
            anim.SetTrigger("True");
        }
        else
        {
            anim.SetTrigger("False");
        }
    }

    public void ResetButton()
    {
        anim.SetTrigger("Return");
    }
}
