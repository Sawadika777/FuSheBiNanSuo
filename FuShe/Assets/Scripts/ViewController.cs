using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public static ViewController Instance;
    public readonly Dictionary<string, View> CreatedViewDic = new Dictionary<string, View>();
    private Transform safeArea;

    public void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
    }
       
    private void Start()
    {
        //safeArea = GameObject.Find("SafeArea").GetComponent<RectTransform>();整个场景寻找性能消耗更大比transform.find
        safeArea = this.transform.Find("SafeArea");
        ViewController.Instance.CreateView(ViewConst.MainView);
    }
    //public readonly static StringMap<View> ViewMap = new StringMap<View>();
    public void CreateView(ViewConst viewconst)
    {
        var key = viewconst.viewName.ToString();
        var prefab = Resources.Load<GameObject>(viewconst.path);
        if (prefab == null) {
            Debug.LogFormat("{0}路径下不存在预制件",viewconst.path.ToString());
            return;
        } 
        //创建界面实例
        var inst = UnityEngine.Object.Instantiate(prefab, safeArea);
        inst.name = key;
        //inst.transform.SetParent(safeArea);

        Debug.Log(key+"界面已经创建");

        View view = inst.GetComponent<View>();
        if(view==null) Debug.Log(key+"界面没有配置对应的脚本");

        if (!CreatedViewDic.ContainsKey(key)) CreatedViewDic.Add(key, view);
    }

    public void HideView(ViewConst viewconst) 
    {
        var key = viewconst.viewName.Name;
        View view;
        if (CreatedViewDic.TryGetValue(key, out view))
        {
            view.gameObject.SetActive(false); 
        }
        else {
            Debug.Log(key + "未被创建过，无法隐藏"); return;
        }
    }

    public void DestroyView(ViewConst viewconst)
    {
        var key = viewconst.viewName.Name;
        View view;
        if (CreatedViewDic.TryGetValue(key, out view))
        {
            Destroy(view.gameObject);
            CreatedViewDic.Remove(key);
        }
        else
        {
            Debug.Log(key + "未被创建过，无法销毁"); return;
        }
    }
}