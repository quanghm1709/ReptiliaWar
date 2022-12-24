using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform maxRightPoint;
    [SerializeField] private Transform maxLeftPoint;

    private void Update()
    {
        float posx = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float posy = CrossPlatformInputManager.GetAxisRaw("Vertical");

        Vector3 pos = transform.position;
        pos.x += speed * posx * Time.deltaTime;
        pos.y += speed * posy * Time.deltaTime;
        transform.position = pos;

        if(transform.position.x >= maxRightPoint.position.x) {
            transform.position = new Vector3(maxRightPoint.position.x, transform.position.y, transform.position.z);
        }

        if(transform.position.x <= maxLeftPoint.position.x)
        {
            transform.position = new Vector3(maxLeftPoint.position.x, transform.position.y, transform.position.z);
        }
    }

}
