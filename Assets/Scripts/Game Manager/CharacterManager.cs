using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    [Header("Character List")] public List<GameObject> characterList;

    private void Awake()
    {
        instance = this;
    }
}
