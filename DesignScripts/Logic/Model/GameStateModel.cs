using System;
using UnityEngine;

public class GameStateModel : NormalSingleton<GameStateModel>
{
	public GameStateModel()
	{
		HandMode = (HandMode)DataMgr.Single.Get<int>(DataKeys.HAND_MODE);
		GameState = GameState.NULL;
	}

	public HandMode HandMode { get; set; }
	private GameState _gameState;

	//判斷是否在遊戲中
	public GameState GameState
	{
		get { return _gameState; }
		set
		{
			if (_gameState == value)
				return;

			_gameState = value;
			switch (value)
			{
				case GameState.START:
					MessageMgr.Single.DispatchMsg(MsgEvent.EVENT_START_GAME);
					break;
				case GameState.PAUSE:
					MessageMgr.Single.DispatchMsg(MsgEvent.EVENT_GAME_PAUSE);
					break;
				case GameState.CONTINUE:
					MessageMgr.Single.DispatchMsg(MsgEvent.EVENT_GAME_CONTINUE);
					break;
				case GameState.END:
					MessageMgr.Single.DispatchMsg(MsgEvent.EVENT_END_GAME);
					break;
			}
		}
	}

	public SceneName CurrentScene { get; set; }
	public SceneName TargetScene { get; set; }
	public Hero SelectedHero { get; set; }
	public int SelectedPlaneId { get; set; }

	//取得飛機等級
	public int PlaneLevel
	{
		get
		{
			var key = KeysUtil.GetPropertyKeys(DataKeys.LEVEL);
			return DataMgr.Single.Get<int>(key);
		}
	}

	public int PlaneLevelMax
	{
		get
		{
			var key = KeysUtil.GetPropertyKeys(DataKeys.LEVEL_MAX);
			return DataMgr.Single.Get<int>(key);
		}
	}

	//取得金錢
	public int GetMoney(string key)
	{
		var money = 0;
		switch (key)
		{
			case DataKeys.STAR:
				money = DataMgr.Single.Get<int>(DataKeys.STAR);
				break;
			case DataKeys.DIAMOND:
				money = DataMgr.Single.Get<int>(DataKeys.DIAMOND);
				break;
			default:
				Debug.LogError("當前輸入的key無法識別，key: " + key);
				break;
		}
		return money;
	}

	//花費金錢
	public void SetMoney(string key, int money)
	{
		switch (key)
		{
			case DataKeys.STAR:
				DataMgr.Single.Set(DataKeys.STAR, money);
				break;
			case DataKeys.DIAMOND:
				DataMgr.Single.Set(DataKeys.DIAMOND, money);
				break;
			default:
				Debug.LogError("當前輸入的key無法識別，key: " + key);
				break;
		}
	}
}
