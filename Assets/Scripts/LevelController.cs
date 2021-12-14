using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum QuestionsType
{
    additionAndSubtraction,
    multiplication,
    erectionAndExtractionOfSquaresEasy,
    erectionAndExtractionOfSquaresHard,
    decimalConvertion
}
public class LevelController : MonoBehaviour
{
    [Header("Default")]
    [SerializeField] protected QuestionsType questionsType;
    [SerializeField] protected AnswersController con;
                       
    [SerializeField] protected int questionsCount = 10;
    [SerializeField] protected Text questionsBar;
    [SerializeField] protected Button nextQuestionButton;
                       
    [SerializeField] protected GameObject endTitle;
    [SerializeField] protected Text endTitleText;

    protected int currentQuestion = 0;
    protected int score = 0;

    private void Start()
    {
        NextQuestion();
        nextQuestionButton.onClick.AddListener(NextQuestion);
    }
    public virtual void NextQuestion()
    {
        StopAllCoroutines();
        if (con == null)
            return;

        if (currentQuestion >= questionsCount && !endTitle.activeSelf)
        {
            endTitle.SetActive(true);
            endTitleText.text = $"Вы набрали {score} из {questionsCount} баллов!";
            return;
        }
        else if (currentQuestion >= questionsCount)
            return;

        currentQuestion++;
        questionsBar.text = $"{currentQuestion}/{questionsCount}";

        QuestionKit kit = GenerateKit(questionsType);

        con.SetQuest(kit.question, kit.answers);

        nextQuestionButton.gameObject.SetActive(false);
    }
    protected QuestionKit GenerateKit(QuestionsType _type)
    {
        switch (_type)
        {
            case QuestionsType.additionAndSubtraction:
                return QuestionsGenerator.GenerateKit_AdditionAndSubtraction();
            case QuestionsType.multiplication:
                return QuestionsGenerator.GenerateKit_Multiplication();
            case QuestionsType.erectionAndExtractionOfSquaresEasy:
                return QuestionsGenerator.Generate_ErectionAndExtractionOfSquaresEasy();
            case QuestionsType.erectionAndExtractionOfSquaresHard:
                return QuestionsGenerator.Generate_ErectionAndExtractionOfSquaresHard();
            case QuestionsType.decimalConvertion:
                return QuestionsGenerator.Generate_DecimalConvertion();
        }

        return null;
    }

    private void CheckLastAnswerAngGoNextQuestion(bool isTrueAnswer)
    {
        if (isTrueAnswer)
            score++;

        nextQuestionButton.gameObject.SetActive(true);
        StartCoroutine(WaitToNext(1f));
    }
    private IEnumerator WaitToNext(float time)
    {
        yield return new WaitForSeconds(time);
        NextQuestion();
    }


    private void OnEnable()
    {
        con.onAnswered += CheckLastAnswerAngGoNextQuestion;
    }
    private void OnDisable()
    {
        
    }
}
