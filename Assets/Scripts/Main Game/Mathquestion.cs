using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mathquestion
{
    public string question;
    public string[] answers = new string[4];
    public int solution;
    public Mathquestion(string question, string answer1, string answer2, string answer3, string answer4, int solution)
    {
        this.question = question;
        answers[0] = answer1;
        answers[1] = answer2;
        answers[2] = answer3;
        answers[3] = answer4;
        this.solution = solution;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
