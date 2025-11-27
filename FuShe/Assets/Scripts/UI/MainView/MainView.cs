using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : View
{
    public Button BtnPeople;
    public Button BtnBuild;
    public void Start()
    {
        BtnBuild.onClick.AddListener(() =>
        {
            ViewController.Instance.HideView(ViewConst.MainView);
            ViewController.Instance.CreateView(ViewConst.SelectRoomView);
        });
    }
}
