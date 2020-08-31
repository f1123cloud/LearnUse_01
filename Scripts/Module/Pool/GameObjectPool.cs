using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameObjectPool
{
	private List<GameObject> _activeList;
	private List<GameObject> _inactiveList;
	private bool _isDestroying;//是否銷毀中

	private int _minNum;
	private GameObject _prefab;//緩存
	private GameObject _selfGo;//自身物件
	private DateTime _spawnTime;//生成時間

	private readonly int _useFrequency = 5;//使用頻率

	public void Init(GameObject prefab, Transform parent, int preloadCount, bool autoDestroy)
	{
		_isDestroying = false;
		_minNum = preloadCount;
		_activeList = new List<GameObject>(preloadCount);
		_inactiveList = new List<GameObject>(preloadCount);
		_prefab = prefab;
		_selfGo = new GameObject(_prefab.name + "Pool");
		_selfGo.transform.SetParent(parent);
		Preload(preloadCount);

		if (autoDestroy)
			AutoDestroy();
	}

	//自動銷毀 (非同步)
	private async void AutoDestroy()
	{
		while (true)
		{
			await Task.Delay(TimeSpan.FromSeconds(1));
			var spendTime = (_spawnTime - DateTime.Now).Seconds;
			if (spendTime >= _useFrequency && !_isDestroying)
			{
				_isDestroying = true;
				StartDestroy();
			}
		}
	}

	//銷毀方法
	private async void StartDestroy()
	{
		GameObject go = null;
		while (_inactiveList.Count > _minNum)
		{
			//等待0.1秒
			await Task.Delay(100);
			go = _inactiveList[0];
			_inactiveList.Remove(go);
			Object.Destroy(go);
		}
		_isDestroying = false;
	}

	//預加載
	private void Preload(int count)
	{
		GameObject temp = null;
		for (var i = 0; i < count; i++)
		{
			temp = SpawnNew();
			_inactiveList.Add(temp);
			temp.SetActive(false);
		}
	}

	//生成
	public GameObject Spawn()
	{
		_spawnTime = DateTime.Now;
		GameObject temp = null;
		if (_inactiveList.Count > 0)
		{
			temp = _inactiveList[0];
			_inactiveList.Remove(temp);
			temp.SetActive(true);
		}
		else
		{
			temp = SpawnNew();
		}

		_activeList.Add(temp);
		return temp;
	}

	//生成物件
	private GameObject SpawnNew()
	{
		return Object.Instantiate(_prefab, _selfGo.transform);
	}

	//回收
	public void Despawn(GameObject go)
	{
		if (_activeList.Contains(go))
		{
			_activeList.Remove(go);
			_inactiveList.Add(go);
			go.SetActive(false);
		}
	}

	public int GetActiveNum()
	{
		return _activeList.Count;
	}
}
