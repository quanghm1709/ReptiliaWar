using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Update()
    {
        float posx = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float posy = CrossPlatformInputManager.GetAxisRaw("Vertical");

        Vector3 pos = transform.position;
        pos.x += speed * posx * Time.deltaTime;
        pos.y += speed * posy * Time.deltaTime;
        transform.position = pos;
    }

}
