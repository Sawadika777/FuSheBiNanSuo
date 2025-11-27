using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{
    public Slider sliderNeed;
    public float k;//电力消耗系数
    private int houseCount { get; }
    void Start()
    {
        //sliderNeed.value = houseCount * k /CanStore;//需要的电力/可储存的电力
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
