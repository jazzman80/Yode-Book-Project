using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using TMPro;

[Serializable]
public class Book
{
    public string Author;
    public string Genre;
    public string Name;
    public string PublicationDate;
}

public class Loader : MonoBehaviour
{
    [SerializeField] private BooksList booksList;
    [SerializeField] private Library library;
    [SerializeField] private GameObject errorScreen;
    [SerializeField] private TextMeshProUGUI errorText;
  
    private void Start()
    {
        StartCoroutine(LoadFromServer());
    }

    private IEnumerator LoadFromServer()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://raw.githubusercontent.com/AkimZay/CollectionJSON/master/Books.json");
        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            //Debug.Log(www.error);
            errorScreen.SetActive(true);
            errorText.text = www.error;
        }
        else
        {
            JsonUtility.FromJsonOverwrite("{ \"books\": " + www.downloadHandler.text + "}", library);
            booksList.BuildBooksList();
        }
    }

}
