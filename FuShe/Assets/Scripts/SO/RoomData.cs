using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dic;

[CreateAssetMenu(menuName = "房间/新房间")]
public class RoomData : ScriptableObject
{
        public int index;
        public string name;
        public Sprite cover;
        public Sprite product;
        public string desc;
        // 用普通 char 类型，约定 ' '（空格）表示“未设置”
        public char property=' ';
        public int money;
        public string modelPath="Model/CanTing/Canting11";

    public string GetPropertyName(char property)
    {
        if (Dic.PropertyDic.PropertyDictionary.TryGetValue(property, out string value))
        {
            return value;
        }
        else 
            return null;
    } 
}
