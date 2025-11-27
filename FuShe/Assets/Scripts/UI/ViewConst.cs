using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using Running.Collections;
public class ViewConst
{
    public readonly static ViewConst SelectRoomView = new ViewConst("Views/SelectRoomView/SelectRoomView", typeof(SelectRoomView));//选择要建的房间界面
    public readonly static ViewConst MainView = new ViewConst("Views/MainView/MainView", typeof(MainView));//主界面

    public string path;
    public Type viewName;

    public ViewConst(string path, Type type)
    {
        this.path = path;
        this.viewName = type;
    }

}

public class View : MonoBehaviour 
{ 

}