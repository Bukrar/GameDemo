using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayHealthUI : MonoBehaviour
{
    public Slider slider;
    public GameObject target;

    void Update()
    {
        Vector2 targetPonit = Camera.main.WorldToScreenPoint(target.transform.position);
        slider.GetComponent<RectTransform>().position = targetPonit + Vector2.up * 70;
    }
}
