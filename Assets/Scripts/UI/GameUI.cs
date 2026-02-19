using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject goMenu;
    [SerializeField] List<GameObject> goPanels;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Slider overfillSlider;
    [SerializeField] Slider badIngredientsSlider;
    Collector collector;
    void Start()
    {
        collector = GameObject.Find("Pot").GetComponent<Collector>();
        SetSliders();
        UnpauseGame();
        goMenu.SetActive(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    public void ReturnToMenu(string menuName)
    {
        SceneManager.LoadScene(menuName);
    }

    public void GO(int index, int wrongIngredients = -1)
    {
        Time.timeScale = 0f;
        goMenu.SetActive(true);

        switch (index)
        {
            case 1://win
                goPanels[0].SetActive(true);
                goPanels[1].SetActive(false);
                goPanels[2].SetActive(false);
                text.text = $"You made the potion with only {wrongIngredients} wrong ingredients";
                break;
            case 2://overfill
                goPanels[0].SetActive(false);
                goPanels[1].SetActive(true);
                goPanels[2].SetActive(false);
                break;
            case 3://bad
                goPanels[0].SetActive(false);
                goPanels[1].SetActive(false);
                goPanels[2].SetActive(true);
                break;
            default:
            break;
        }
    }

    public void SetSliders()
    {
        overfillSlider.maxValue = collector.maxOverfillIngredients;
        badIngredientsSlider.maxValue = collector.maxBadIngredients;
    }
    public void UpdateOverfillSlider()
    {
        overfillSlider.gameObject.GetComponent<Animation>().Play();
        overfillSlider.value = collector.overFilledIngredients;
    }
    public void UpdateBadSlider()
    {
        badIngredientsSlider.gameObject.GetComponent<Animation>().Play();
        badIngredientsSlider.value = collector.wrongIngredients;
    }


}
