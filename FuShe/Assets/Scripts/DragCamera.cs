using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DragCamera : MonoBehaviour, IDragHandler,IPointerDownHandler,IPointerUpHandler
{

    private Image image;
    private Vector3 dragOrigin;
    private Vector3 difference;
    private bool canDrag;
    [Header("边界限制")]
    public float minX = -0.5f; // 最小 X 坐标
    public float maxX = 1f;  // 最大 X 坐标
    public float minY = -0.2f;  // 最小 Y 坐标（2D 视角）
    public float maxY = 1.8f;   // 最大 Y 坐标（2D 视角）
    public void Start()
    {
        image = this.GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!canDrag) return;
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - dragOrigin;

        // 计算目标位置
        Vector3 targetPos = Camera.main.transform.position - difference;

        // 限制目标位置在边界内
        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        // 移动摄像机到目标位置
        Camera.main.transform.position = targetPos;
    }

    public void OnPointerDown(PointerEventData eventData)//注意IsRaycastLocationValid==false后，不响应OnPointerDown事件了
    {
        //if (eventData.pointerCurrentRaycast.gameObject != gameObject) return;//点击到角色，并不移动摄像机
        if (IsDwellerHit())
        {
            canDrag = false;
        }
        else {       
            canDrag = true;
            dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        canDrag = false;
    }


    // 判断射线是否命中场景中的可交互物体（如角色）
    private bool IsHitAnyDweller(PointerEventData eventData)
    {
        // 创建射线检测结果列表
        var results = new List<RaycastResult>();
        // 使用Physics2DRaycaster检测场景中的物体
        EventSystem.current.RaycastAll(eventData, results);

        foreach (var result in results)
        {
            // 判断是否命中了场景中的角色（假设角色标签为"Player"）
            if (result.gameObject.CompareTag("person"))
            {
                return true;
            }
        }
        return false;
    }

    private bool IsDwellerHit()
    {
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction);
        if (hit)
        {
            image.raycastTarget = false;
            Debug.LogFormat("命中了角色{0},关闭raycastTarget,也无法自动打开了", hit.transform.gameObject.name);
        }
        else {
            image.raycastTarget = true;
            Debug.LogFormat("打开了raycastTarget");
        }
        return hit;
    }
/*    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)//每帧调用
    {
        Debug.Log("IsRaycastLocationValid被调用了！");
        return false;
    }*/
}
