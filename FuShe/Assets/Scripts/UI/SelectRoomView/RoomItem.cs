using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class RoomItem : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public Image coverImage;
    public Image productImage;
    public TextMeshProUGUI descText;
    public TextMeshProUGUI propertyText;
    public TextMeshProUGUI propertyNameText;
    public TextMeshProUGUI moneyText;

    public Button btnAll;
    public Button btnBuild;
    public Button btnCancel;
    
    //设置显影的控件
    public enum State{ NorState,BuildState};
    public State state;
    public GameObject emptyNor;
    public GameObject emptyBuild;
    public GameObject hBoxProperty;

    public static event Action OnBtnAllClicked;

    private RoomData roomData;
    public void Start()
    {  
        btnAll.onClick.AddListener(() => {
            OnBtnAllClicked?.Invoke();
            emptyNor.SetActive(false);
            emptyBuild.SetActive(true);
        });
        btnBuild.onClick.AddListener(() =>
        {
            ViewController.Instance.HideView(ViewConst.SelectRoomView);
            
        });
        btnCancel.onClick.AddListener(()=>{
            emptyNor.SetActive(true);
            emptyBuild.SetActive(false);
        });
    }
    public  void SetData(RoomData roomData)
    {
        this.roomData = roomData;
        emptyNor.SetActive(true);
        emptyBuild.SetActive(false);

        nameText.SetText(roomData.name);
        coverImage.sprite=roomData.cover;
        if (roomData.product)
            productImage.sprite = roomData.product;
        else
            productImage.gameObject.SetActive(false);
        descText.SetText(roomData.desc);
        if (roomData.property == ' ') hBoxProperty.SetActive(false);

        propertyText.SetText(roomData.property.ToString());
        propertyNameText.SetText(roomData.GetPropertyName(roomData.property));
        moneyText.SetText(roomData.money.ToString());
    }

}
