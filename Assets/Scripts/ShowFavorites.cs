using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFavorites : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private GameEvent showFavorites;
    [SerializeField] private GameEvent showAll;

    public void OnChange()
    {
        if (toggle.isOn) showFavorites.Raise();
        else showAll.Raise();
    }
}
