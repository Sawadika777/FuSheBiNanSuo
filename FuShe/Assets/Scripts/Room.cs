using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Room : MonoBehaviour,IPointerClickHandler
{
    public GameObject selectedLight;

    public void OnPointerClick(PointerEventData eventData)
    {
        selectedLight.SetActive(true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
