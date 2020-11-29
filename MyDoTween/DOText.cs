using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DOText : MonoBehaviour
{
    void Start()
    {
		Text text = GetComponent<Text>();
		text.DOText("123456789", 3).SetEase(Ease.Linear);
    }
}
