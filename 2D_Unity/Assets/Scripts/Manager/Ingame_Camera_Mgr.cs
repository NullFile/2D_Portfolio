using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingame_Camera_Mgr : MonoBehaviour
{
    private Camera cam;

    private Vector3 prePos = Vector3.zero;
    //private Vector3 curPos = Vector3.zero;

    //private Vector3 camPos = Vector3.zero;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start() => StartFunc();

    private void StartFunc()
    {
    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        // 마우스 클릭
        if (Input.GetMouseButtonDown(1))
        {
            prePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        // 드래그
        //if (Input.GetMouseButton(1))
        //{
        //    curPos = cam.ScreenToWorldPoint(Input.mousePosition);
        //    camPos = prePos - curPos;
        //    camPos.z = 0.0f;

        //    cam.transform.position += camPos;
        //}
    }
}
