using System;
using UnityEngine;
using Object = UnityEngine.Object;

public interface ILoader
{
	//接口的抽象方法
	GameObject LoadPrefab(string path);
	GameObject LoadPrefabAndInstantiate(string path, Transform parent = null);

	void LoadConfig(string path, Action<object> complete);
	T Load<T>(string path) where T : Object;
	T[] LoadAll<T>(string path) where T : Object;
}
