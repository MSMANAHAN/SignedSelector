using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VariableRand : MonoBehaviour {
   public Text variableOne;
   public Text variableTwo;
   public Text Operator;
   public Text Answer;
   public Text CorrectAnswers;
   public InputField input;

    bool addition = false;

    int intOne = 0;
    int intTwo = 0;
    float correct = 0;
    float total = 0;
    int ans = 0;
    // Use this for initialization
    void Start()
    {
        intOne = 0;
        intTwo = 0;
        Randomize();
        CorrectAnswers.text = "" + correct + "/" + total + "\n" + "0%";

    }
    private void Update()
    {
        if (total != 0)
        {
            CorrectAnswers.text = "" + correct + "/" + total + "\n" + (int)((correct/total) * 100) + "%";
        }
    }

    public void Solve()
    {
        total++;
        if (addition)
        {
            ans= intOne + intTwo;
            Debug.Log(intOne + " + " + intTwo + " = " + ans);
        }
        else
        {
            ans = intOne - intTwo;
            Debug.Log(intOne + " - " + intTwo + " = " + ans);
        }

        Answer.text = ans.ToString();
        if (ans < 0)        
            Answer.color = new Color(255, 0, 0);        
        else
            Answer.color = new Color(0, 255, 0);
        Debug.Log(Answer.text + " " + input.text);
        if (input.text == Answer.text)
        {
            correct += 1;

        }
    }

    public void Randomize()
    {
        Answer.text = "";
        input.text = "";
        if (Random.value >= .5f)
            Operator.text = "+";
        else
            Operator.text = "-";

        if (Random.value >= .5f)
            variableOne.text = "" + Random.Range(1, 99).ToString();
        else
            variableOne.text = "-" + Random.Range(1, 99).ToString();
        if (Random.value >= .5f)
            variableTwo.text = "" + Random.Range(1, 99).ToString();
        else
            variableTwo.text = "-" + Random.Range(1, 99).ToString();
        Debug.Log(variableOne.text + Operator.text + variableTwo.text);

        intOne = 0;
        intTwo = 0;

        addition = false;
        char[] varOne = null;
        char[] varTwo = null;
        varOne = variableOne.text.ToCharArray();
        varTwo = variableTwo.text.ToCharArray();
/*
        for (int i = 0; i < varOne.Length; i++)
        {
            if (varOne[0] == '-')
            {
                negativeVarOne = true;
            }
            else
            {
                if (i == 0)
                {
                    intOne = varOne[0];
                }
                if (i == 1)
                {
                    if (negativeVarOne)
                        intOne = varOne[1];
                    else
                        intOne *= 10 + varOne[1];
                }
                if (i == 2)
                {
                    intOne *= 10 + varOne[2];
                }
            }
        }
        
        for (int i = 0; i < varTwo.Length; i++)
        {
            if (varTwo[0] == '-')
            {
                negativeVarTwo = true;
            }
            else
            {
                if (i == 0)
                {
                    intTwo = varTwo[0];
                }
                if (i == 1)
                {
                    if (negativeVarTwo)
                        intTwo = varTwo[1];
                    else
                        intTwo *= 10 + varTwo[1];
                }
                if (i == 2)
                {
                    intTwo *= 10 + varTwo[2];
                }
            }
        }
 */


        int.TryParse(variableOne.text, out intOne);
        int.TryParse(variableTwo.text, out intTwo);

        if (intOne < 0 )
        {
            //intOne *= -1;
            variableOne.color = new Color(255, 0, 0);
        }
        else
            variableOne.color = new Color(0, 255, 0);

        if (intTwo < 0)
        {
            //intTwo *= -1;
            variableTwo.color = new Color(255, 0, 0);
        }
        else
            variableTwo.color = new Color(0, 255, 0);


        if (Operator.text.StartsWith("+"))
            addition = true;
    }
}
