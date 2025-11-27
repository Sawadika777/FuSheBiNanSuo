using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    [Header("边界限制")]
    public float minX = -0.5f; // 最小 X 坐标
    public float maxX = 1f;  // 最大 X 坐标
    public float minY = -0.2f;  // 最小 Y 坐标（2D 视角）
    public float maxY = 1.8f;   // 最大 Y 坐标（2D 视角）

    private Vector3 dragOrigin;
    public static Vector3 difference;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return;
        }

        if (Input.GetMouseButton(0))
        {
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - dragOrigin;

            // 计算目标位置
            Vector3 targetPos = Camera.main.transform.position - difference;

            // 限制目标位置在边界内
            targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
            targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

            // 移动摄像机到目标位置
            Camera.main.transform.position = targetPos;
        }
    }

    // 在 Scene 视图中绘制边界 Gizmo，方便调试
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(minX, minY, 0), new Vector3(maxX, minY, 0));
        Gizmos.DrawLine(new Vector3(maxX, minY, 0), new Vector3(maxX, maxY, 0));
        Gizmos.DrawLine(new Vector3(maxX, maxY, 0), new Vector3(minX, maxY, 0));
        Gizmos.DrawLine(new Vector3(minX, maxY, 0), new Vector3(minX, minY, 0));
    }

}
