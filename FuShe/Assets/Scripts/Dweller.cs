using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Dweller : MonoBehaviour,IPointerClickHandler,IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    // Start is called before the first frame update
    private Vector3 mouseDragOrigin;
    private bool isdrag;
    private bool ishit;
    private Vector3 personOriPostion;
    private Vector3 targetPos;
    public event Action onHitPerson;
    private RaycastHit2D hit;
    public GameObject selectedOutline;

    private Vector3 dragOrigin;
    private  Vector3 difference;

    public void OnPointerClick(PointerEventData eventData)
    {
        selectedOutline.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
    //Vector3 move = difference * dragSpeed * Time.deltaTime;
/*    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            switch (hit.collider.tag)
            {
                case "person":
                    onHitPerson.Invoke();
                    break;
                    ScreenToWorldPoint   }
            if (hit.collider)
            {
                ishit = true;
            }

            else
            {
                ishit = false;
            }

        }
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider.CompareTag("person"))
            {
                ishit = true;
                personOriPostion = hit.transform.position;
                mouseDragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (hit.collider)
            {
                difference = Camera.main.(Input.mousePosition) - mouseDragOrigin;
                if (difference.magnitude > 0.001)
                {

                }
                targetPos = personOriPostion + difference;
                hit.transform.position = targetPos;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            hit.transform.position = personOriPostion;
            ishit = false;
        }

    }*/

    public void OnDrag(PointerEventData eventData)
    {
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - dragOrigin;
        // 计算目标位置
        Vector3 targetPos = transform.position + difference;
        transform.position = targetPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.LogWarning("没有点击到人物，但同样触发了OnPointerDown");
        dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
