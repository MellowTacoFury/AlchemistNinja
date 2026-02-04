using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;
    public void Start()
    {
        creditsPanel.SetActive(false);
    }
    public void StartGame(string levelToGoTo)
    {
        SceneManager.LoadScene(levelToGoTo);
    }
    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }
    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
