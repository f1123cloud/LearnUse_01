using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoCamera : MonoBehaviour
{
   
    void Start()
    {
		Camera camera = GetComponent<Camera>();

		//改變寬高
		camera.DOAspect(1f, 2);

		//改變背景顏色
		camera.DOColor(Color.black, 2);

		//改變視域遠近 fov
		camera.DOFieldOfView(100, 5);

		//改變 正焦尺寸
		camera.DOOrthoSize(1,10);

		//改變 位置 , 分辨率
		camera.DOPixelRect(new Rect(0, 0, 360, 540), 2);

		//鏡頭晃動
		camera.DOShakePosition(2,10,20);
    }
}
