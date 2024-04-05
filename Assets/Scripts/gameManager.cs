using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{
    private int highScore;
    private int score;

    public Transform player;
    public GameObject scBoard, ryBoard, bomd;
    public TextMeshProUGUI tmpScore, tmpRyBoard;

    public Slider hp;
    public Image fillImage;

    public bool AdminPower;

    void Start()
    {
        Time.timeScale = 1;
        Load();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R) && AdminPower) reSetHight();

        if (Input.GetKeyDown(KeyCode.H) && AdminPower) spawnBomb();
    }

    public void dead()
    {
        if (score > highScore)
        {
            highScore = score;
            SetScoreText();
            Save();
        }
        tmpRyBoard.text = tmpScore.text;
        scBoard.SetActive(false);
        ryBoard.SetActive(true);
        HPColorChanging();
        Time.timeScale = 0;
    }

    public bool AddScore(int V)
    {
        score += V;
        if (score < 0)
        {
            score = 0;
            return false;
        }
        SetScoreText();
        return true;
    }

    public void SetScoreText()
    {
        tmpScore.text = "Score: " + score.ToString("n0") + "\n"
                      + "High: " + highScore.ToString("n0");
    }

    [SerializeField]
    string save;

    public void Save()
    {
        save = Extension.Encrypt(highScore.ToString("n0"), "MATKHAUSIEUCAPVUTRU");
        PlayerPrefs.SetString("HighScore", save);
        Load();
    }

    public void Load()
    {
        save = PlayerPrefs.GetString("HighScore");
        if(!string.IsNullOrEmpty(save)) highScore = int.Parse(Extension.Decrypt(save, "MATKHAUSIEUCAPVUTRU"));
        AddScore(0);
    }

    float r = 0, g = 1;
    public void HPColorChanging()
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

    public void spawnBomb()
    {
        Instantiate(bomd, new Vector3(player.position.x + Random.Range(-1, 2) * 2, 5, 0), Quaternion.identity);
    }

    private void reSetHight()
    {
        highScore = 0;
        Save();
    }
}