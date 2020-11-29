using UnityEngine;

public class SelectHero : ViewBase
{
	//添加腳本
	protected override void InitChild()
	{
		foreach (Transform trans in transform)
			trans.gameObject.AddComponent<HeroItem>();
	}
}
