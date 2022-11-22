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
}
