using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParchmentBook : MonoBehaviour
{
    [SerializeField] GameObject parchmentBook;
    [SerializeField] List<GameObject> pages;
    [SerializeField] int currentPage = 0;
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;
    void Start()
    {
        Close();
    }
    public void Open()
    {
        pages[currentPage].SetActive(true);
        parchmentBook.gameObject.SetActive(true);
    }
    public void Close()
    {
        parchmentBook.gameObject.SetActive(false);
        foreach (var page in pages)
        {
            page.SetActive(false);
        }
    }
    public void NextPage()
    {
        pages[currentPage].SetActive(false);
        if(currentPage == pages.Count-1)
        {
            currentPage = 0;
        }
        else
        {
            currentPage++;
        }
        pages[currentPage].SetActive(true);
    }
    public void LastPage()
    {
        pages[currentPage].SetActive(false);
        if(currentPage == 0)
        {
            currentPage = pages.Count-1;
        }
        else
        {
            currentPage--;
        }
        pages[currentPage].SetActive(true);
    }
}
