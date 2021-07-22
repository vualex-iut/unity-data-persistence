using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] Text bestScoreText;
    [SerializeField] InputField nameInput;
    // Start is called before the first frame update
    private void Start()
    {
        nameInput.text = MainDataManager.instance.bestScorePlayerName;

        if (!string.IsNullOrEmpty(MainDataManager.instance.bestScorePlayerName))
        {
            bestScoreText.text = $"Best Score : {MainDataManager.instance.bestScore} ({MainDataManager.instance.bestScorePlayerName})";
        }
        else
        {
            bestScoreText.text = "No Best Score Available";
        }
    }

    public void OnStartClicked()
    {
        MainDataManager.instance.currentPlayerName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void OnQuitClicked()
    {
        MainDataManager.instance.SaveGameData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
