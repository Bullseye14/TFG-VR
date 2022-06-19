using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;

public class ChooseQuestion : MonoBehaviour
{
    public TrailMovement movement;

    private List<string> allText;

    public List<string> answers;

    public TextMeshPro question;
    public List<TextMeshPro> answersList;

    private int questionLine;

    public int correctIndex;

    // Start is called before the first frame update
    void Start()
    {
        string readFrom = Application.streamingAssetsPath + "/Documents/QuestionsM3.txt";

        allText = File.ReadAllLines(readFrom).ToList();

        GetNewQuestion();
    }

    public void GetNewQuestion()
    {
        if (allText.Count > 1)
        {
            // Ens diu la línia on està la pregunta escollida random
            questionLine = Random.Range(0, allText.Count) / 4 * 4;

            // Assignem el text de la pregunta al TMP
            question.text = allText[questionLine];

            // Afegim les 3 possibles respostes a una llista "answers"
            answers.Add(allText[questionLine + 1]);
            answers.Add(allText[questionLine + 2]);
            answers.Add(allText[questionLine + 3]);

            // Decidim en quina de les 3 preguntes anirà la resposta correcta
            correctIndex = Random.Range(0, 3);

            // Assignem la resposta correcta a una de les tres preguntes
            answersList[correctIndex].text = answers[2];

            FillQuestions(correctIndex);

            // Esborrem les 3 respostes i la pregunta de la llista principal, així no tornaran a apareixer
            allText.RemoveAt(questionLine + 3);
            allText.RemoveAt(questionLine + 2);
            allText.RemoveAt(questionLine + 1);
            allText.RemoveAt(questionLine);

            // Buidem la llista helper de answers, per quan la tornem a fer servir
            answers.Clear();
        }

        else movement.moving = false;
    }

    private void FillQuestions(int firstRandom)
    {
        // Falten assignar respostes 1 i 2
        // Triem un altre random que ens dirà en quin ordre les posarem
        int secondRandom = Random.Range(0, 2);

        switch (firstRandom)
        {
            // Falten de la answersList i = 1-2
            case 0:
                if (secondRandom == 0)
                {
                    answersList[1].text = answers[0];
                    answersList[2].text = answers[1];
                }
                else
                {
                    answersList[1].text = answers[1];
                    answersList[2].text = answers[0];
                }
                break;

            // Falten de la answersList i = 0-2
            case 1:
                if (secondRandom == 0)
                {
                    answersList[0].text = answers[0];
                    answersList[2].text = answers[1];
                }
                else
                {
                    answersList[0].text = answers[1];
                    answersList[2].text = answers[0];
                }
                break;

            // Falten de la answersList i = 0-1
            case 2:
                if (secondRandom == 0)
                {
                    answersList[0].text = answers[0];
                    answersList[1].text = answers[1];
                }
                else
                {
                    answersList[0].text = answers[1];
                    answersList[1].text = answers[0];
                }
                break;
        }
    }
}
