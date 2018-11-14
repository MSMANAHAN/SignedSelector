using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class StatsAndProb : MonoBehaviour {

    float points = 0;
    float total = 0;
    public int listCount;
    public Text List;
    public InputField iMean;
    public InputField iMode;
    public InputField iMedian;
    public InputField iRange;
    public InputField iMax;
    public InputField iMin;
    public Text p;
    int[] randList;
    float mean;
    //float mode;
    float median;
    float range;
    float max;
    float min;
    // Use this for initialization
    void Start ()
    {
        randList = CreateList();
        FillList(randList);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

   int[] CreateList()
    {
        int[] numbers = new int[121];
        for (int i = 0; i < 121; i++)
        {
            numbers[i] = i;
        }
        int[] randomNumbers = new int[listCount];
        for (int i = 0; i < randomNumbers.Length; i++)
        {
            int thisNumber = UnityEngine.Random.Range(0, numbers.Length);
            randomNumbers[i] = numbers[thisNumber];
            Debug.Log(randomNumbers[i] + "\n");
        }
        return randomNumbers;
    }

    void FillList(int[] l)
    {
        List.text = "";
        for (int i = 0; i < l.Length; i++)
        {
            List.text += " " +(i+1) + ".\t\t" + l[i] + "\n";
        }
        Solve(l);
    }

    float CalculateMean(int[] l)
    {
        float ans;
        float add = 0;
        for (int i = 0; i < l.Length; i++)
        {
            add += l[i];
        }
        ans = add / l.Length;

        int z = (int)ans;
        if ((ans - z) >= .4999f)
        {
            ans++;
        }
        return (int)ans;
    }

    float CalculateMedian(int[] l)
    {
        float ans;
        float x = 0;
        float y = 0;
        int index = (l.Length / 2);


        int[] rList = l;
        Array.Sort(rList);
        Debug.Log("rList:\n");
        for (int i = 0; i < rList.Length; i++)
        {
            Debug.Log(rList[i] + "\n");
        }
         if (l.Length % 2 == 1)
        {
            ans = rList[index];
        }
         else
        {
            x = rList[index];
            y = rList[index - 1];
            ans = (y + x) / 2;
        }
        int z = (int)ans;
        if ((ans - z) >= .49999f)
        {
            ans++;
        }
        Debug.Log("ans: " + ans + "\n");
        Debug.Log("z: " + z + "\n");
        return (int)ans;
    }

    float CalculateMode(int[] l)
    {
        return 0;
    }

    float CalculateRange(int[] l)
    {
        int smolBoi = l[0];
        int bigBoi = l[0];

        for (int i = 0; i < l.Length; i++)
        {
            if (smolBoi > l[i])
                smolBoi = l[i];
            if (bigBoi < l[i])
                bigBoi = l[i];
        }

        float ans = bigBoi - smolBoi;
        max = bigBoi;
        min = smolBoi;
        return ans;
    }

    void Solve(int[] l)
    {
        mean = CalculateMean(l);
        median = CalculateMedian(l);
       // mode = CalculateMode(l);
        range = CalculateRange(l);
        Debug.Log("Mean:\t" + mean + "\n");
        //Debug.Log("Mode:\t" + mode + "\n");
        Debug.Log("Median:\t" + median + "\n");
        Debug.Log("Range:\t" + range + "\n");
        Debug.Log("Max:\t" + max + "\n");
        Debug.Log("Min:\t" + min + "\n");
    }


    public void CheckAns()
    {
        if (iMean.text == mean.ToString())
        {
            points++;
            total++;
            Debug.Log("Correct Mean\n");
        }
        else
            total++;

        //if (iMode.text == mode.ToString())
        //{
        //    points++;
        //    total++;
        //    Debug.Log("Correct Mode\n");
        //}
        //else
        //    total++;

        if (iMedian.text == median.ToString())
        {
            points++;
            total++;
            Debug.Log("Correct Median\n");
        }
        else
            total++;

        if (iRange.text == range.ToString())
        {
            points++;
            total++;
            Debug.Log("Correct Range\n");
        }
        else
            total++;

        if (iMax.text == max.ToString())
        {
            points++;
            total++;
            Debug.Log("Correct Max\n");
        }
        else
            total++;

        if (iMin.text == min.ToString())
        {
            points++;
            total++;
            Debug.Log("Correct Min\n");
        }
        else
            total++;

        Debug.Log("Points\t" + points);
        p.text = "Points:\t" + points + "/" + total + "\nGrade:\t" + (int)((points / total) * 100) + "%";

        Rand();
    }

    public void Rand()
    {
        iMean.text = "";
        iMode.text = "";
        iMedian.text = "";
        iRange.text = "";
        iMax.text = "";
        iMin.text = "";

        randList = CreateList();
        FillList(randList);
    }
}
