using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FractionQuestionsType
{
    additionAndSubtractionOfFractions,
    multiplicationAndDivisionOfFractions,
    convertingFractionsToDecimal
}
public class FractionLevelController : LevelController
{
    [Header("Fraction")]
    [SerializeField] private FractionQuestionsType fractionQuestionsType = FractionQuestionsType.additionAndSubtractionOfFractions;
    [SerializeField] private Text firstNumerator;
    [SerializeField] private Text firstDenomerator;
    [SerializeField] private Text secondNumerator;
    [SerializeField] private Text secondDenomerator;
    [SerializeField] private Text fractionOperator;

    public override void NextQuestion()
    {
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

        FractionQuestionKit kit = GenerateFractionQuestionKit(fractionQuestionsType);

        if(firstNumerator != null)
            firstNumerator.text = kit.firstNumerator;
        if(firstDenomerator != null)
            firstDenomerator.text = kit.firstDenomerator;
        if(secondDenomerator != null)
            secondDenomerator.text = kit.secondDenomerator;
        if(secondNumerator != null)
            secondNumerator.text = kit.secondNumerator;
        if(fractionOperator != null)
            fractionOperator.text = kit.fractionOperator;

        con.SetQuest("", kit.answers);

        nextQuestionButton.gameObject.SetActive(false);
    }

    private FractionQuestionKit GenerateFractionQuestionKit(FractionQuestionsType type)
    {
        switch (type)
        {
            case FractionQuestionsType.additionAndSubtractionOfFractions:
                return QuestionsGenerator.Generate_AdditionAndSubtractionOfFractions();
            case FractionQuestionsType.multiplicationAndDivisionOfFractions:
                return QuestionsGenerator.Generate_MultiplicationAndDivisionOfFractions();
            case FractionQuestionsType.convertingFractionsToDecimal:
                return QuestionsGenerator.Generate_ConvertingFractionsToDecimal();
        }
        return null;
    }
}
