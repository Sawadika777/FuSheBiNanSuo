using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;


public class SelectRoomView : View
{
    public Transform scrollContent;
    private List<RoomData> roomDatas;
    private List<RoomItem> roomItems;
    public RoomItem roomPrefab;
    public Button btnClose;


    private void Awake()
    {
        RoomItem.OnBtnAllClicked += RefreshData;
    }
    void Start()
    {
        CreateRoomItem();
        btnClose.onClick.AddListener(()=> {
            ViewController.Instance.HideView(ViewConst.SelectRoomView); }
        );
        
    }


    private void CreateRoomItem()
    {
        roomDatas = new List<RoomData>();
        roomDatas = Resources.LoadAll<RoomData>("Rooms").ToList();
        roomDatas = roomDatas.OrderBy(r => r.index).ToList();
        roomItems = roomDatas.Select(roomData =>
        {
            var instance = Instantiate(roomPrefab, Vector3.zero, Quaternion.identity, scrollContent);
            instance.SetData(roomData);
            return instance;
        }).ToList();
    }

    private void RefreshData() 
    {
        for (int i = 0; i < roomDatas.Count; i++)
        {
            roomItems[i].SetData(roomDatas[i]);
        }

    }
}
