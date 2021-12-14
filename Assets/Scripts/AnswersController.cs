using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void AnswerEventHandler(bool isTrueAnswer);
public class AnswersController : MonoBehaviour
{
    [SerializeField] private Text question;
    [SerializeField] private AnswerButton[] buttons;

    public AnswerEventHandler onAnswered;

    //local
    private string trueAnswer;
    private List<AnswerButton> workingButtons;
    private bool answered = false;

    public void SetQuest(string _question, string[] answers)
    {
        if (answers.Length == 0)
            return;

        ResetQuest();

        question.text = _question;

        List<AnswerButton> _workingButtons = new List<AnswerButton>();

        for (int i = 0; i < answers.Length; i++)
        {
            if (buttons[i] != null)
                _workingButtons.Add(buttons[i]);
        }

        Tools.Shuffle(_workingButtons);

        for (int i = 0; i < _workingButtons.Count; i++)
        {
            _workingButtons[i].gameObject.SetActive(true);
            _workingButtons[i].Answer = answers[i];
        }

        trueAnswer = answers[0];
        workingButtons = _workingButtons;
    }

    public void TryToAnswer(AnswerButton button)
    {
        if (answered)
            return;

        if(button.Answer == trueAnswer)
        {
            button.SetAnswerState(true);
        }
        else
        {
            button.SetAnswerState(false);
            foreach (AnswerButton but in workingButtons)
            {
                if (but.Answer == trueAnswer)
                    but.SetAnswerState(true);
            }
        }

        answered = true;

        onAnswered.Invoke(button.Answer == trueAnswer);
    }
    private void ResetQuest()
    {

        foreach (AnswerButton _but in buttons)
        {
            _but.gameObject.SetActive(false);
        }

        if (workingButtons != null)
        {
            foreach (AnswerButton but in workingButtons)
            {
                but.ResetButton();
            }
        }

        answered = false;
    }
}
