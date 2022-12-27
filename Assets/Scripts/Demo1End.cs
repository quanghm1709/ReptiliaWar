using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1End : MonoBehaviour
{
    public static Demo1End instance;
    [SerializeField] private bool isEnd;

    private void Awake()
    {
        instance = this;
        
    }

    private void Update()
    {
        if (isEnd && HomeUIController.instace != null)
        {
            HomeUIController.instace.endScreen.SetActive(true);
        }
    }

    public void SetEnd()
    {
        isEnd = true;
    }
}
