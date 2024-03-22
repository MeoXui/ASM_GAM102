using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{
    [SerializeField] private int highScore;
    private int score;
    public TextMeshProUGUI tmpScore;

    public void AddScore(int V)
    {
        score += V;
        SetScoreText();
        if (score > highScore) Save();
    }

    public void SetScoreText()
    {
        tmpScore.text = "Score: " + score.ToString("n0") + "\n"
                      + "High: " + highScore.ToString("n0");
    }

    public void Save()
    {
        string SS = Extension.Encrypt(score.ToString("n0"), "MATKHAUSIEUCAPVUTRU");
        PlayerPrefs.SetString("HighScore", SS);
    }

    public void Load()
    {
        string SS = PlayerPrefs.GetString("HighScore");
        if(!string.IsNullOrEmpty(SS)) highScore = int.Parse(Extension.Decrypt(SS, "MATKHAUSIEUCAPVUTRU"));
        score = 0;
        AddScore(0);
    }
}
