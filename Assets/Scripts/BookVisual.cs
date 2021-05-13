using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BookVisual : MonoBehaviour
{
    public BooksList booksList;
    [SerializeField] private Library library;
    public int bookIndex;
    public bool isStarred;
    [SerializeField] Toggle starToggle;
    public TextMeshProUGUI shortInfoAuthor;
    public TextMeshProUGUI shortInfoName;
    public FullInfoList fullInfoList;
    public GameObject fullInfo;

    public void ShowFullInfo()
    {
        fullInfoList.fullInfoAuthor.text = library.books[bookIndex].Author;
        fullInfoList.fullInfoName.text = library.books[bookIndex].Name;
        fullInfoList.fullInfoGenre.text = library.books[bookIndex].Genre;
        fullInfoList.fullInfoPublishingDate.text = library.books[bookIndex].PublicationDate;
        fullInfo.SetActive(true);
    }

    public void OnStarChange()
    {
        if (!starToggle.isOn)
        {
            isStarred = false;
            PlayerPrefs.DeleteKey(library.books[bookIndex].Name);
            PlayerPrefs.Save();
            booksList.favoritesCount--;
        }
        else
        {
            isStarred = true;
            PlayerPrefs.SetString(library.books[bookIndex].Name, "");
            PlayerPrefs.Save();
            booksList.favoritesCount++;
        }
    }

}
