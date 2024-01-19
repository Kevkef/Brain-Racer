using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mathmode : MonoBehaviour
{
    public TMP_Text question;
    public TMP_Text[] buttons;
    public Image background;

    private Mathquestion currentquestion;
    // Start is called before the first frame update
    void Start()
    {
        nextQuestion();
    }

    private void nextQuestion()
    {
        currentquestion = getRandomQuestion();
        question.text = currentquestion.question;
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].text = currentquestion.answers[i];
        }
    }

    public void buttonPushed(int index)
    {
        if(index == currentquestion.solution)
        {
            background.color = Color.green;
        } else
        {
            background.color = Color.red;
        }
        StartCoroutine(wait(2));

    }

    private void next()
    {
        nextQuestion();
        background.color = new Color(252f / 255f, 198f / 255f, 0f / 255f, 136f / 255f); //rgba
    }

    private Mathquestion getRandomQuestion()
    {
        int index = (int)Random.Range(0, 10); // change if question added

        switch (index)
        {
            case 0:
                return new Mathquestion("17 + 33", "40", "50", "60", "37", 1);
            case 1:
                return new Mathquestion("sqrt(9) * 6 + 17", "69", "36", "35", "50", 2);
            case 2:
                return new Mathquestion("9^2 * 5 + 15", "395", "435", "825", "420", 3);
            case 3:
                return new Mathquestion("16 / 5", "3,2", "3,1", "3,5", "2,3", 0);
            case 4:
                return new Mathquestion("999 / 15 * 3 * 5", "870", "999", "3333", "1530", 1);
            case 5:
                return new Mathquestion("f(x) = x^2; y = 4", "8", "256", "16", "64", 2);
            case 6:
                return new Mathquestion("f(x) = x^3; y = 4", "8", "256", "16", "64", 3);
            case 7:
                return new Mathquestion("5 + 9 + 45 - 3 + 7 + 1 - 1 - 15", "40", "48", "50", "47", 1);
            case 8:
                return new Mathquestion("9 * 4 / 6 + 17 / 2", "14,5", "14", "13,75", "15,5", 0);
            case 9:
                return new Mathquestion("8 * 7 + 19", "40", "50", "60", "75", 3);
            case 10:
                return new Mathquestion("4! * 2 - 6", "186", "42", "506", "89", 1);
            default:
                return new Mathquestion("Diese Frage sollte nie auftauchen!", "Ja", "Nein", "Vielleicht", "Definitiv", 3);

        }

    }

    IEnumerator wait(int sec)
    {
        yield return new WaitForSeconds(sec);
        next();
    }
}
