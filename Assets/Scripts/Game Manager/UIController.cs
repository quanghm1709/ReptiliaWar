using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] public Camera cam;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnCharacter(int index)
    {
        Transform spwanpoint = GameObject.Find("Tower").GetComponent<TowerCore>().spawnPoint;

        Instantiate(CharacterManager.instance.characterList[index], spwanpoint.position, spwanpoint.rotation);
    }
}
