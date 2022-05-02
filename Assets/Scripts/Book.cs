using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    public GameObject book;
    public int currentPage;
    public GameObject[] pages;

    public GameObject canvas;



    public void NextPage()
    {
        currentPage += 1;
        GameObject newPage = Instantiate(pages[currentPage], canvas.transform);
        newPage.transform.position = book.transform.position;
        Destroy(book);
        book = newPage;
    }
    public void LastPage()
    {
        currentPage -= 1;
        GameObject newPage = Instantiate(pages[currentPage], canvas.transform);
        newPage.transform.position = book.transform.position;
        Destroy(book);
        book = newPage;
    }
}
