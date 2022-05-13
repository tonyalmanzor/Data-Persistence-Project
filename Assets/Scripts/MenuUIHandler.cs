using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
    using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputName;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int bestScore;
    string bestScoreName;
    string playerName;

    // Start is called before the first frame update
    private void Start()
    {
        bestScore = DataManager.dataManagerInstance.GetBestScore();
        bestScoreName = DataManager.dataManagerInstance.GetBestScoreName();

        scoreText.text = "Best Score: " + bestScoreName + " - " + bestScore;

        DataManager.dataManagerInstance.LoadData();
    }

    // Update is called once per frame
    public void StartGame()
    {
        playerName = inputName.text;
        DataManager.dataManagerInstance.SetPlayerName(playerName);
        
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }
    public void ExitAplication()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void UpdateScore()
    {
        bestScore = DataManager.dataManagerInstance.GetBestScore();
        bestScoreName = DataManager.dataManagerInstance.GetBestScoreName();
        scoreText.text = "Best Score: " + bestScoreName + " - " + bestScore;
    }
}
