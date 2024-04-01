using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{
    [SerializeField] private int highScore;
    private int score;
    public GameObject scBoard, ryBoard;
    public TextMeshProUGUI tmpScore, tmpRyBoard;

    public Slider hp;
    public Image fillImage;

    void Start()
    {
        Time.timeScale = 1;
        Load();
    }

    void FixedUpdate()
    {
        HPColorChanging();
    }

    public void dead()
    {
        tmpRyBoard.text = tmpScore.text;
        scBoard.SetActive(false);
        ryBoard.SetActive(true);
        HPColorChanging();
        Time.timeScale = 0;
    }

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

    float r = 0, g = 1;
    void HPColorChanging()
    {
        if (r > 1) r = 1;
        if (r < 0) r = 0;
        if (g > 1) g = 1;
        if (g < 0) g = 0;
        fillImage.color = new Color(r, g, 0f);
        r = (hp.maxValue - hp.value) * 2 / hp.maxValue;
        g = hp.value * 2 / hp.maxValue;
    }

    public void RunScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
