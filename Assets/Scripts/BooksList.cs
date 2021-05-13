using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BooksList : MonoBehaviour
{
    [SerializeField] Library library;
    private List<GameObject> bookList = new List<GameObject>();
    [SerializeField] GameObject bookPrefab;
    [SerializeField] private FullInfoList fullInfoList;
    [SerializeField] private GameObject fullInfo;
    [SerializeField] private RectTransform scrollViewport;
    public int favoritesCount = 0;

    public void BuildBooksList()
    {
        for(int i = 0; i < library.books.Length; i++)
        {
            GameObject newBook = Instantiate(bookPrefab, this.transform);
            BookVisual newBookVisual = newBook.GetComponent<BookVisual>();
            newBookVisual.bookIndex = i;
            newBookVisual.booksList = this;

            Toggle starred = newBook.GetComponentInChildren<Toggle>();

            if (PlayerPrefs.HasKey(library.books[i].Name))
            {
                newBookVisual.isStarred = true;
                starred.isOn = true;
                //favoritesCount++;
            }
            else newBookVisual.isStarred = false;

            newBookVisual.shortInfoAuthor.text = library.books[i].Author;
            newBookVisual.shortInfoName.text = "\"" + library.books[i].Name + "\"";
            newBookVisual.fullInfo = fullInfo;
            newBookVisual.fullInfoList = fullInfoList;

            bookList.Add(newBook);
        }

        scrollViewport.sizeDelta = new Vector2(1080, library.books.Length * 200);
    }

    public void OnShowAll()
    {
        for (int i = 0; i < bookList.Count; i++) bookList[i].SetActive(true);
        scrollViewport.sizeDelta = new Vector2(1080, library.books.Length * 200);
    }

    public void OnShowFavorites()
    {
        for (int i = 0; i < bookList.Count; i++)
        {
            if (!bookList[i].GetComponent<BookVisual>().isStarred) bookList[i].SetActive(false);
        }

        scrollViewport.sizeDelta = new Vector2(1080, favoritesCount * 200);

    }
}
