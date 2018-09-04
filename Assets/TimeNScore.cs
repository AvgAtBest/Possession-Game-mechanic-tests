using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class TimeNScore : MonoBehaviour
{
    public float time = 0f;
    public int timeMultiplier = 100;
    public Text timer;
    public Text highScore;


    public List<float> scoreArray;

    private string timeToShow;

    // Use this for initialization
    void Start()
    {
        ReadHighScore();

        float scoreToDisplay = scoreArray[0] * 100;
        highScore.text = scoreToDisplay.ToString("##:##");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * timeMultiplier;
        //time = Mathf.Round(time * 100f) / 100f;
        timeToShow = time.ToString("##:##");
        timer.text = timeToShow;
    }

    public void SaveScore()
    {
        string path = "Assets/test.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        string timeToSave = time.ToString("##.##");
        float timeToStore = float.Parse(timeToSave);
        timeToStore /= 100;
        //timeToSave = timeToStore.ToString("##.##");
        
        writer.WriteLine(timeToStore);
        writer.Close();
        
        Debug.Log("Saved " + timeToStore);
    }

    void ReadHighScore()
    {
        string path = "Assets/test.txt";

        string[] reader = File.ReadAllLines(path);
        for (int i = 0; i < reader.Length; i++)
        {
            Debug.Log("Primary key is " + i + ". The data is " + reader[i] + "\n");
            reader[i] = reader[i].Replace(':', '.');

            scoreArray.Add(float.Parse(reader[i]));
        }

        scoreArray.Sort();
        scoreArray.Reverse();
    }
}
