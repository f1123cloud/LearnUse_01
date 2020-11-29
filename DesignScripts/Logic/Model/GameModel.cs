public class GameModel : NormalSingleton<GameModel>
{
	public void InitData()
	{
		CurrentLevel = SelectedLevel;
		Life = LifeMax;
		MessageMgr.Single.DispatchMsg(MsgEvent.EVENT_HP);
	}

	public int Life { get; set; }
	public int Score { get; set; }
	public int Stars { get; set; }
	public int ShieldCount { get; set; }
	public int PowerCount { get; set; }

	//選中的關卡
	public int SelectedLevel { get; set; }

	//當前的關卡
	public int CurrentLevel { get; set; }

	private int _tempLevel;

	//遊戲中臨時等級
	public int TempLevel
	{
		get { return _tempLevel; }
		set
		{
			if (value < GameStateModel.Single.PlaneLevelMax)
				_tempLevel = value;
		}
	}

	public bool IsFinishOneLevel { get; set; }

	public int LifeMax
	{
		get
		{
			var key = KeysUtil.GetNewKey(PropertyItem.ItemKey.value, PlaneProperty.Property.life.ToString());
			return DataMgr.Single.Get<int>(key);
		}
	}

	//恢復默認值
	public void Clear()
	{
		_single = new GameModel();
	}
}
