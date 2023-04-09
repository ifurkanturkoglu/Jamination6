using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipPage : MonoBehaviour
{
    public GameObject[] pages;
    int currentPage = 0;
    
    void Start()
    {
        ShowPages(0, 1);
    }
    private void Update()
    {
        print(currentPage);
    }
    public void ShowNextPages()
    {
        if (currentPage == pages.Length - 2)
        {
            return;
        }
        if (currentPage == pages.Length - 1)
        {
            ShowPages(pages.Length, pages.Length + 1);
        }
        else
        {
            ShowPages(currentPage + 2, currentPage + 3);
        }
    }

    public void ShowPreviousPages()
    {
        if (currentPage == 0)
        {
            return;
        }
        else if (currentPage == pages.Length)
        {
            ShowPages(currentPage - 1, currentPage - 2);
        }
        else
        {
            ShowPages(currentPage - 2, currentPage - 1);
        }
    }

    private void ShowPages(int leftPageIndex, int rightPageIndex)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (i == leftPageIndex || i == rightPageIndex)
            {
                pages[i].SetActive(true);
            }
            else
            {
                pages[i].SetActive(false);
            }
        }

        currentPage = leftPageIndex;
    }

}