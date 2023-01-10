using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMeshUI : MonoBehaviour
{
    public static CharacterMeshUI instance;

    [Header("UI")]
    public GameObject changeCharacterScreen;

    [Header("Resource")]
    public MeshFilter[] meshList;
    public Material[] meshRender;
    public Transform[] meshTransform;
    public bool[] onField;
    public GameObject[] changeBtnList;

    [Header("Change Target")]
    public MeshFilter[] t_meshList;
    public MeshRenderer[] t_meshRender;
    public Transform[] t_meshTransform;
    public int targetIndex;

    private void Start()
    {
        instance = this;
    }


    public void ChangeCharacterScreen(int index)
    {
        if (changeCharacterScreen.activeInHierarchy)
        {
            changeCharacterScreen.SetActive(false);
        }
        else
        {
            changeCharacterScreen.SetActive(true);
        }
        ActiveBtn();
        targetIndex = index;
    }

    public void SwapCharacter(int index)
    {
        t_meshList[targetIndex].sharedMesh = meshList[index].sharedMesh;
        t_meshRender[targetIndex].material = meshRender[index];
        //t_meshTransform[targetIndex].position = new Vector3(t_meshTransform[targetIndex].position.x, -70f, t_meshTransform[targetIndex].position.z);
        t_meshTransform[targetIndex].localScale =  new Vector3(meshTransform[index].localScale.x, meshTransform[index].localScale.y, meshTransform[index].localScale.z);
        t_meshTransform[targetIndex].localRotation = meshTransform[index].localRotation;
        onField[index] = true;

        //UsingCharacter.instance.characterUseUIList.Remove(UsingCharacter.instance.characterUseUIList[targetIndex]);
        UsingCharacter.instance.characterUseUIList[targetIndex] = CharacterManager.instance.playerCharacterList[index];
        UsingCharacter.instance.characterUseIndex[targetIndex] = index;
        changeCharacterScreen.SetActive(false);
    }

    public void SetupUI()
    {
        for(int i = 0; i < UsingCharacter.instance.characterUseUIList.Count; i++)
        {
            targetIndex = i;
            SwapCharacter(UsingCharacter.instance.characterUseIndex[i]);
        }
    }

    public void ActiveBtn()
    {
        for(int i = 0; i < onField.Length; i++)
        {
            if (onField[i])
            {
                changeBtnList[i].SetActive(false);
            }
            else
            {
                changeBtnList[i].SetActive(true);
            }
        }
    }
}
