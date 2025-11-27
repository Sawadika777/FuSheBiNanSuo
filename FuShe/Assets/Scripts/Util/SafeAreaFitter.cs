using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(RectTransform))]
public class SafeAreaFitter : MonoBehaviour
{
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform =this.GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            // 输出当前对象名称，确认脚本挂载是否正确
            Debug.LogError($"【{gameObject.name}】上没有找到 RectTransform 组件！", this);
        }
        
    }
    private void Start()
    {
        UpdateSafeArea();
    }

    // 屏幕尺寸变化时（如旋转、分辨率改变）重新适配
    void OnRectTransformDimensionsChange()
    {
        UpdateSafeArea();
    }

    private void UpdateSafeArea()
    {
        // 获取设备的安全区数据（Unity 内置 API，所有版本通用）
        Rect safeArea = Screen.safeArea;

        // 将安全区坐标转换为 RectTransform 的本地坐标（适配不同 Canvas 模式）
        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;

        // 转换为 0~1 的比例（相对于屏幕尺寸）
        anchorMin.x /= Screen.width;//132/2436=0.1
        anchorMin.y /= Screen.height;//63/1125=0.1
        anchorMax.x /= Screen.width;//2304/2436=0.9
        anchorMax.y /= Screen.height;//1125/1125=1

        // 应用到当前 UI 元素的 RectTransform
        rectTransform.anchorMin = anchorMin;
        rectTransform.anchorMax = anchorMax;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
    }
}