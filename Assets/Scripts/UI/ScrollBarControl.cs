using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarControl : MonoBehaviour {
    private Scrollbar scrollbar;
    public float ScrollSpeed = 50f;
    void Start()
    {
        scrollbar = GetComponent<Scrollbar>();
    }
    void Update()
    {
        scrollbar.value -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed * Time.deltaTime;
    }
    public void ListScroll(RectTransform list)
    {
        list.localPosition = new Vector3(list.localPosition.x, scrollbar.value * 907.52f + 0.250061f, list.localPosition.z);////(1)
    }
}
