using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LogText : MonoBehaviour
{
    private string path;

    // Start is called before the first frame update
    void Start()
    {
        string title = "/Log_" + DateTime.Now.ToFileTime() + ".txt";
        path = Application.dataPath + title;
        CreateFile();
    }

    public void CreateFile()
    {
        File.WriteAllText(path, "Overview of choices \n \n");
    }

    public void AddChoiceToFile(int round, string title, string hint)
    {
        string content = $"Round: {round} \nChoice made: {title} \nHint: {hint} \n \n";
        File.AppendAllText(path, content);
    }

    public void AddScoreToFile(string score, string rank)
    {
        string content = $"Your final score is: {score} \nYour rank is: {rank}";
        File.AppendAllText(path, content);
    }


    //in de gamestatemanager moet ervoor gezorgd worden dat alleen de eerste klik naar de file geschreven wordt
}
