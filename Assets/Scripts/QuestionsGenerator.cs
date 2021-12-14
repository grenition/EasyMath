using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionKit
{
    public string question;
    public string[] answers;

    public QuestionKit(string _question, string[] _answers)
    {
        question = _question;
        answers = _answers;
    }
}
public class FractionQuestionKit
{
    public string firstNumerator;
    public string firstDenomerator;
    public string secondNumerator;
    public string secondDenomerator;
    public string fractionOperator;
    public string[] answers;

    public FractionQuestionKit(string _firstNumerator, string _firstDenomerator, string _secondNumerator, string _secondDenomirator, string _fractionOperator, string[] _answers)
    {
        firstNumerator = _firstNumerator;
        firstDenomerator = _firstDenomerator;
        secondNumerator = _secondNumerator;
        secondDenomerator = _secondDenomirator;
        fractionOperator = _fractionOperator;
        answers = _answers;
    }
}
public class QuestionsGenerator
{
    public static QuestionKit GenerateKit_AdditionAndSubtraction()
    {
        int op = Random.Range(0, 2);
        int firstValue = Random.Range(0, 101);
        int secondValue = Random.Range(0, 101);

        int result = 0;
        string opImage = "";

        switch (op)
        {
            case 0:
                result = firstValue + secondValue;
                opImage = "+";
                break;
            case 1:
                result = firstValue - secondValue;
                opImage = "-";
                break;
        }

        List<string> _answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
                _answers.Add(result.ToString());
            else
            {
                int rnd = 0;

                for (; ; )
                {
                    rnd = Random.Range(result - 10, result + 10);
                    bool stop = true;
                    foreach (string ans in _answers)
                    {
                        if (rnd.ToString() == ans)
                            stop = false;
                    }
                    if (stop)
                        break;
                }

                _answers.Add(rnd.ToString());
            }
        }
        string question = $"{firstValue} {opImage} {secondValue}";
        return new QuestionKit(question, _answers.ToArray());
    }
    public static QuestionKit GenerateKit_Multiplication()
    {
        int firstValue = Random.Range(0, 11);
        int secondValue = Random.Range(0, 11);
        int result = firstValue * secondValue;

        List<string> _answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
                _answers.Add(result.ToString());
            else
            {
                int rnd = 0;
                for (; ; )
                {
                    rnd = Random.Range(0, 101);
                    if (rnd != result)
                        break;
                }
                _answers.Add(rnd.ToString());
            }
        }
        string question = $"{firstValue} * {secondValue}";
        return new QuestionKit(question, _answers.ToArray());
    }

    public static FractionQuestionKit Generate_AdditionAndSubtractionOfFractions()
    {
        int parametr = Random.Range(1, 4);
        int fd = Random.Range(1, 4) * parametr;
        int fn = Random.Range(1, 11) * fd;
        int sd = Random.Range(1, 4) * parametr;
        int sn = Random.Range(1, 11) * sd;

        int op = Random.Range(0, 2);
        int result = 0;

        string fo = "+";
        if (op == 1)
            fo = "-";

        if(op == 0)
        {
            result = (fn / fd) + (sn / sd);
        }
        else
        {
            result = (fn / fd) - (sn / sd);
        }

        List<string> answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
                answers.Add(result.ToString());
            else
            {
                for (; ; )
                {
                    int rnd = Random.Range(result - 11, result + 11);
                    bool stop = true;
                    foreach(string ans in answers)
                    {
                        if (ans == rnd.ToString())
                            stop = false;
                    }
                    if (stop)
                    {
                        answers.Add(rnd.ToString());
                        break;
                    }
                }
            }
        }

        FractionQuestionKit kit = new FractionQuestionKit(fn.ToString(), fd.ToString(), sn.ToString(), sd.ToString(), fo, answers.ToArray());
        return kit;
    }
    public static FractionQuestionKit Generate_MultiplicationAndDivisionOfFractions()
    {
        int parametr = Random.Range(1, 4);
        int op = Random.Range(0, 2);

        int sd = Random.Range(1, 4) * parametr;
        int sn = Random.Range(1, 11) * sd;


        int fn = 0;
        int fd = Random.Range(1, 4) * parametr;
        if (op == 0)
            fn = Random.Range(1, 11) * fd;
        else
            fn = Random.Range(1, 11) * fd * (sn / sd);

        int result = 0;

        string fo = "*";
        if (op == 1)
            fo = ":";

        if (op == 0)
        {
            result = (fn / fd) * (sn / sd);
        }
        else
        {
            result = (fn / fd) / (sn / sd);
        }

        List<string> answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
                answers.Add(result.ToString());
            else
            {
                for (; ; )
                {
                    int rnd = Random.Range(result - 11, result + 11);
                    bool stop = true;
                    foreach (string ans in answers)
                    {
                        if (ans == rnd.ToString())
                            stop = false;
                    }
                    if (stop)
                    {
                        answers.Add(rnd.ToString());
                        break;
                    }
                }
            }
        }

        FractionQuestionKit kit = new FractionQuestionKit(fn.ToString(), fd.ToString(), sn.ToString(), sd.ToString(), fo, answers.ToArray());
        return kit;
    }
    public static FractionQuestionKit Generate_ConvertingFractionsToDecimal ()
    {
        int parametr = Random.Range(1, 4);

        int[] denumerators = { 2, 4, 5, 8 };
        int fd = denumerators[Random.Range(0, denumerators.Length)];
        int fn = Random.Range(0, 17);

        float result = (float)fn / (float)fd;

        List<string> answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
                answers.Add(result.ToString());
            else
            {
                for (; ; )
                {
                    float rnd = (float)fn / (float)denumerators[Random.Range(0, denumerators.Length)];
                    bool stop = true;
                    foreach (string ans in answers)
                    {
                        if (ans == rnd.ToString())
                            stop = false;
                    }
                    if (stop)
                    {
                        answers.Add(rnd.ToString());
                        break;
                    }
                }
            }
        }
        

        FractionQuestionKit kit = new FractionQuestionKit(fn.ToString(), fd.ToString(), "", "", "", answers.ToArray());
        return kit;
    }

    public static QuestionKit Generate_ErectionAndExtractionOfSquaresEasy()
    {
        int op = Random.Range(0, 2);
        int parametr = Random.Range(1, 21);
        string question = "";
        if (op == 0)
            question = $"{parametr}" + '\u00B2';
        else if (op == 1)
            question = '\u221A' + $"{parametr * parametr}";

        List<string> answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                if (op == 0)
                    answers.Add((parametr * parametr).ToString());
                else
                    answers.Add(parametr.ToString());
            }
            else
            {
                for (; ; )
                {
                    int rnd = Random.Range(parametr - 4, parametr + 4);
                    if (op == 0)
                        rnd *= rnd;

                        bool stop = true;
                    foreach (string ans in answers)
                    {
                        if (ans == rnd.ToString())
                            stop = false;
                    }
                    if (stop)
                    {
                        answers.Add(rnd.ToString());
                        break;
                    }
                }
            }
        }
        QuestionKit kit = new QuestionKit(question, answers.ToArray());
        return kit;
    }
    public static QuestionKit Generate_ErectionAndExtractionOfSquaresHard()
    {
        int op = Random.Range(0, 2);
        int parametr = Random.Range(19, 101);
        string question = "";
        if (op == 0)
            question = $"{parametr}" + '\u00B2';
        else if (op == 1)
            question = '\u221A' + $"{parametr * parametr}";

        List<string> answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                if (op == 0)
                    answers.Add((parametr * parametr).ToString());
                else
                    answers.Add(parametr.ToString());
            }
            else
            {
                for (; ; )
                {
                    int rnd = Random.Range(parametr - 10, parametr + 10);
                    if (op == 0)
                        rnd *= rnd;

                    bool stop = true;
                    foreach (string ans in answers)
                    {
                        if (ans == rnd.ToString())
                            stop = false;
                    }
                    if (stop)
                    {
                        answers.Add(rnd.ToString());
                        break;
                    }
                }
            }
        }
        QuestionKit kit = new QuestionKit(question, answers.ToArray());
        return kit;
    }
    public static string GetDegreeSymbol(int value)
    {
        string valueOut = string.Empty;
        switch (value)
        {
            case 0:
                valueOut = "⁰";
                break;
            case 1:
                valueOut = "¹";
                break;
            case 2:
                valueOut = "²";
                break;
            case 3:
                valueOut = "³";
                break;
            case 4:
                valueOut = "⁴";
                break;
            case 5:
                valueOut = "⁵";
                break;
            case 6:
                valueOut = "⁶";
                break;
            case 7:
                valueOut = "⁷";
                break;
            case 8:
                valueOut = "⁸";
                break;
            case 9:
                valueOut = "⁹";
                break;
            case 10:
                valueOut = "⁻";
                break;
            case 11:
                valueOut = "√";
                break;
        }
        return valueOut;
    }
}
