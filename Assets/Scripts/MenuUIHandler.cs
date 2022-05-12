using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
    using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score;

    // Start is called before the first frame update
    

    // Update is called once per frame
    public void StartGame()
    {
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
}
