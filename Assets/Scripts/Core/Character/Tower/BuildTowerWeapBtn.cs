using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTowerWeapBtn : MonoBehaviour
{
    [SerializeField] private GameObject buildPoint;
    [SerializeField] private TowerCore tower;
    private void Update()
    {
        
    }

    public void Build(int index)
    {
        foreach (Transform child in buildPoint.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        GameObject newWeap = Instantiate(TowerWeaponManager.instance.weapList[index]);
        newWeap.transform.parent = buildPoint.transform;
        newWeap.transform.position = buildPoint.transform.position;
        newWeap.transform.localRotation = Quaternion.Euler(Vector3.zero);
        newWeap.transform.localScale = new Vector3(2, 2, 2);
        tower.weapUI.SetActive(false);
    }
}
