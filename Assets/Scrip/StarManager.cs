using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;

    public GameObject winPanel;
    public GameObject pauseMenu;
    private string[] titleOptions = {"Hello Word", "Mario", "Nguyen Anh Tuan"}; // Danh sách các tên title có thể chọn

    void Start()
    {
        StartCoroutine(ChangeTitleRoutine());
    }

    IEnumerator ChangeTitleRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Đợi 2 giây
            ChangeTitle(); // Gọi hàm để thay đổi title
        }
    }

    void ChangeTitle()
    {
        // Chọn ngẫu nhiên một trong các tên title
        int randomIndex = Random.Range(0, titleOptions.Length);
        title.text = titleOptions[randomIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowWinPanel();
            Time.timeScale = 0;
        }
    }

    private void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void chuyenMan2()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void ReStarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void QuizGame()
    {
        Application.Quit();
        Debug.Log("Ban da bam thoat game");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            title.text = "Hello Wolrd";
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            title.text = "Mario";
        }
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            title.text = "Nguyen Anh Tuan";
        }
        if (Input.GetKeyUp(KeyCode.W)) 
        {
            title.text = "Game Lor";
        }
    }
}
