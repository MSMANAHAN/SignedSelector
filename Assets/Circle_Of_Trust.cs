using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Circle_Of_Trust : MonoBehaviour
{
    public InputField ICircumference;
    public InputField IDiameter;
    public Text p;
    public Text r;
    float d;
    float c;
    float radius = 0;
    float points = 0;
    float total = 0;

	// Use this for initialization
	void Start ()
    {
        Randomize();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    float CalculateCircumference()
    {
        float ans = 2 * 3.14f * radius;
        return ans;
    }

    float CalculateDiameter()
    {
        return radius * 2;
    }

    void Solve()
    {
        d = CalculateDiameter();
        c = CalculateCircumference();
        Debug.Log("Circumference:\t" + c + "\n");
        Debug.Log("Diameter:\t" + d + "\n");
    }

   public void CheckAns()
    {
        if (IDiameter.text == d.ToString())
        {
            points++;
            total++;
            Debug.Log("Correct Diameter\n");
        }
        else
            total++;

        if (ICircumference.text == c.ToString())
        {
            points++;
            total++;
            Debug.Log("Correct Circumference\n");
        }
        else
            total++;


        Debug.Log("Points\t" + points);
        p.text = "Points:\t" + points + "/" + total + "\nGrade:\t" + (int)((points / total) * 100) + "%";

        Randomize();
    }

   public void Randomize()
    {
        ICircumference.text = "";
        IDiameter.text = "";

        int[] numbers = new int[121];
        for (int i = 0; i < 121; i++)
        {
            numbers[i] = i;
        }

        radius = UnityEngine.Random.Range(1, numbers.Length);
        r.text = radius.ToString() + " m";
        Solve();

    }
}
