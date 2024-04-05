using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public static int Highscore; //
    public int hightscore = 0;
    public GameObject bangTrai;
    public GameObject bangGiua;
    public TextMeshProUGUI scoreDeathText;
    public TextMeshProUGUI hightscoreDeathText;

    [SerializeField] private int score;

    private void Start()
    {
        LoadGame();
        SetTextScore();
        // Load highscore từ PlayerPrefs
        Highscore = PlayerPrefs.GetInt("Highscore", 0);//

        // Bắt đầu game với điểm số là 0
        score = 0;
    }
    public void SaveGame()
    {
        string maHoa = Extension.Encrypt(hightscore.ToString(), "LapTrinhGame2");
        PlayerPrefs.SetString("coin", maHoa);

    }

    public void LoadGame()
    {
        // score = PlayerPrefs.GetInt("Diem");
        string getDiem = PlayerPrefs.GetString("diem");
        string giaiMa = Extension.Decrypt(getDiem, "LapTrinhGame2");
        hightscore = int.Parse(giaiMa);
    }

    public void SetTextScore()
    {
        scoreText.text = "Score: " + score.ToString("n0");
    }

    public void Checkscore()
    {
        if (score > hightscore)
        {
            hightscore = score;
            SaveGame();
        }

        bangTrai.SetActive(false);
        bangGiua.SetActive(true);

        scoreDeathText.text = "Score:" + " " + score.ToString("n0");
        hightscoreDeathText.text = "HightScore:" + " " + hightscore.ToString("n0");
    }

    public void PlayerAgin()
    {
        SceneManager.LoadScene(0);
    }
    public void Home()
    {
        SceneManager.LoadScene(1);
    }
    public void AddScore()
    {
        score++;
    }
    public int GetScore()
    {
        return score;
    }
    public void TruScore()
    {
        score--;
        scoreDeathText.text = "Score:" + " " + score.ToString("n0");
    }
    public void UpdateScore(int newScore)
    {
        score = newScore;

        // Nếu điểm số mới vượt qua Highscore, cập nhật Highscore và lưu vào PlayerPrefs
        if (score > Highscore)
        {
            Highscore = score;
            PlayerPrefs.SetInt("Highscore", Highscore);
            PlayerPrefs.Save(); // Lưu thay đổi vào bộ nhớ
        }
    }
}