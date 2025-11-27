using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Camera cam;
    private Grids<bool> grids;
    private Vector3 worldPos;
    
    void Start()
    {
        cam = Camera.main;
        //grids = new Grids<bool>(4, 7, false);
        //ViewController.Instance.CreateView(ViewConst.MainView);
    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
            grids.SetGridValue(true);
        //ViewController.Instance.HideView(ViewConst.SelectRoomView);
        if (Input.GetMouseButtonDown(0))
            Room.RoomInstance.CreateRoom("Models/DianTi/DianTi");*/
    }
    void OnGUI()
    {
        worldPos = cam.ScreenToWorldPoint(Input.mousePosition);

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Input.Mouseposition: " + Input.mousePosition);
        GUILayout.Label("World position: " + worldPos.ToString("F3"));
        GUILayout.Label("摄像机移动向量 " + Camera.main.transform.position.ToString("F3"));
        GUILayout.EndArea();
    }
}
