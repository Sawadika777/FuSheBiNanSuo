using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager RoomInstance;

    void Awake()
    {
        RoomInstance = this;
    }


    public void CreateRoom(string path)
    {
        var prefab = Resources.Load<GameObject>("Models/DianTi/DianTi");
        if (prefab == null) {
            Debug.LogFormat("模型加载失败！请检查路径：{0}", path);
            return;
        }
        var go = Instantiate(prefab, this.transform);go.transform.localPosition = Utils.GetMouseWorldPosition();
    }
    public void CreateRoom<T>(string modelResourcesPath, Transform parent) where T : RoomManager
    {
        StartCoroutine(LoadModelAndAddComponent<T>(modelResourcesPath, parent));
    }

    // 协程：异步加载房间模型（避免卡顿），协程不能是静态的，因为要依赖MonoBehaviour 实例的生命周期
    private IEnumerator LoadModelAndAddComponent<T>(string modelResourcesPath, Transform parent)where T:RoomManager
    {
        // 1. 从 Resources 加载模型（需将模型放在 Assets/Resources 文件夹下）
        ResourceRequest request = Resources.LoadAsync<GameObject>(modelResourcesPath);
        yield return request;

        GameObject modelPrefab = request.asset as GameObject;
        if (modelPrefab == null)
        {
            Debug.LogError("模型加载失败！请检查路径：" + modelResourcesPath);
            yield break;
        }

        // 2. 实例化模型到场景
        var spawnedInstance = Object.Instantiate(modelPrefab, parent);
        spawnedInstance.name = "ModelWithCanting"; // 重命名实例

        // 3. 为实例添加 Canting 组件
        T com = spawnedInstance.AddComponent<T>();
        if (com == null)
        {
            Debug.LogError("添加 Canting 组件失败！请检查脚本是否存在。");
            Destroy(spawnedInstance);
            yield break;
        }

        Debug.Log("运行时实例创建成功！");
    }
}
