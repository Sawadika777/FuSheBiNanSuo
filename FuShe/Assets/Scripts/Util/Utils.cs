using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Utils
{
    public static TextMesh CreatWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 10, Color color = default(Color)) {
        GameObject gameObject = new GameObject("WorldText", typeof(TextMesh));
        var transform = gameObject.GetComponent<Transform>();
        transform.localPosition = localPosition;
        var textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.anchor = TextAnchor.MiddleCenter;        
        textMesh.color = color;
        gameObject.transform.SetParent(parent, false);
        return textMesh;
    }
/*    public static Sprite CreatWorldImage(Sprite sprite, Vector3 localPosition = default(Vector3))
    {
        GameObject gameObject = new GameObject("WorldImage", typeof(SpriteRenderer));
        var spr = gameObject.GetComponent<SpriteRenderer>();

        spr.sprite = sprite;
        var transform = gameObject.GetComponent<Transform>();
        transform.privot = gameObject.GetComponent<Transform>();
        transform.localPosition = localPosition;
        return img;
    }*/

    //只适用与摄像机为正交模式的时候，透视模式并不能正确获取鼠标点击处的世界坐标
    public static Vector3 GetMouseWorldPosition(){
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0;
        return vec;
    }

}
