using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResourceLoader : ILoader
{
	public GameObject LoadPrefab(string path)
	{
		var prefab = Resources.Load<GameObject>(path);
		return prefab;
	}

	public GameObject LoadPrefabAndInstantiate(string path, Transform parent = null)
	{
		var prefab = LoadPrefab(path);
		var temp = Object.Instantiate(prefab, parent);//Object.Instantiate 非Mono類 靜態實例化方法
		return temp;
	}

	public T Load<T>(string path) where T : Object
	{
		var sprite = Resources.Load<T>(path);
		if (sprite == null)
		{
			Debug.LogError("未找到對應資源，路徑: " + path);
			return null;
		}
		return sprite;
	}

	public T[] LoadAll<T>(string path) where T : Object
	{
		var sprites = Resources.LoadAll<T>(path);
		if (sprites == null || sprites.Length == 0)
		{
			Debug.LogError("當前路徑未找到對應資源，路徑 " + path);
			return null;
		}
		return sprites;
	}

	public void LoadConfig(string path, Action<object> complete)
	{
		CoroutineMgr.Single.ExecuteOnce(Config(path, complete));
	}

	private IEnumerator Config(string path, Action<object> complete)
	{
		if (Application.platform != RuntimePlatform.Android)
			path = "file://" + path;

		var www = new WWW(path);
		yield return www;

		if (www.error != null)
		{
			Debug.LogError("加載配置錯誤，路徑為: " + path);
			yield break;
		}
		complete(www.text);
		//Debug.Log("文件加載成功，路徑為: " + path);
	}
}
