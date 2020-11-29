﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PoolMgr : IInit
{
	private static PoolMgr _single;
	private static GameObject _selfGo;
	private Action _initComplete;

	private Dictionary<string, GameObjectPool> _pools;
	public static PoolMgr Single
	{
		get
		{
			if (GameStateModel.Single.CurrentScene == SceneName.Game)
			{
				if (_single == null)
				{
					InitSelf();
				}
				return _single;
			}
			return null;
		}
	}

	private static void InitSelf()
	{
		if (_single == null)
			_single = new PoolMgr();

		if (_selfGo == null)
			_selfGo = new GameObject("PoolMgr");
	}

	public async void Init()
	{
		InitSelf();
		_pools = new Dictionary<string, GameObjectPool>();
		var config = new PoolConfig();
		GameObject temp = null;
		GameObjectPool pool = null;
		foreach (var data in config.Data)
		{
			temp = LoadMgr.Single.LoadPrefab(data.Path);
			pool = new GameObjectPool();
			pool.Init(temp, _selfGo.transform, data.PreloadCount, data.AutoDestroy);
			_pools.Add(data.Path, pool);
			await Task.Delay(100);
		}

		if (_initComplete != null)
			_initComplete();
	}

	public void Init(Action callBack)
	{
		_initComplete = callBack;
		Init();
	}


	public GameObject Spawn(string path)
	{
		if (_pools.ContainsKey(path))
		{
			return _pools[path].Spawn();
		}

		Debug.LogError("當前預製體沒有在池的管理中，預製路徑: " + path);
		return null;
	}

	public bool Despawn(GameObject go)
	{
		//修改名稱
		var goName = go.name.Replace("(Clone)", "");

		foreach (var pair in _pools)
		{
			if (pair.Key.Contains(goName))
			{
				pair.Value.Despawn(go);
				return true;
			}
		}
		return false;
	}

	public int GetActiveNum(string path)
	{
		if (_pools.ContainsKey(path))
		{
			return _pools[path].GetActiveNum();
		}
		else
		{
			Debug.LogError("當前調用內存池並不存在，Path: " + path);
			return 0;
		}
	}
}
