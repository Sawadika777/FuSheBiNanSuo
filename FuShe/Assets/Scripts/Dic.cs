using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dic
{
    public static class PropertyDic 
    {
        // 定义字典：键为字符，值为属性数值
        public static readonly Dictionary<char, string> PropertyDictionary = new Dictionary<char, string>();

        static PropertyDic()
        {
            // 初始化映射关系（字母 -> 属性名称）
            PropertyDictionary.Add('S', "力量");
            PropertyDictionary.Add('P', "观察力");
            PropertyDictionary.Add('E', "耐力");
            PropertyDictionary.Add('C', "魅力");
            PropertyDictionary.Add('I', "智力");
            PropertyDictionary.Add('A', "敏捷");
            PropertyDictionary.Add('L', "运气");
        }
    }


}


