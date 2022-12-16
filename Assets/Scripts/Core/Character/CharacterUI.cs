using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    [Header("Character")]
    public GameObject character;
    [SerializeField] public float characterBuyCD;
    [SerializeField] public bool canBuy;
    [SerializeField] public float characterBuyTime;
}
