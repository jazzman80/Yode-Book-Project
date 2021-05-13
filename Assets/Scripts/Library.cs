using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Library", menuName ="Scriptable Assets/Library", order = 1)]
[Serializable]
public class Library : ScriptableObject
{
    public Book[] books;
}
