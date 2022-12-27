using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBuild : MonoBehaviour
{
    public bool canBuild;
    [SerializeField] private float checkRange;
    [SerializeField] private LayerMask checkLayer;
    private void Update()
    {
        CheckBuild();
    }
    public void CheckBuild()
    {
        Vector3 checkPoint = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
        Collider[] hitColliders = Physics.OverlapSphere(checkPoint, checkRange, checkLayer);

        if(hitColliders.Length > 0)
        {
            canBuild = false;
        }
        else
        {
            canBuild = true;
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 checkPoint = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkPoint, checkRange);
    }
}
