public class SwitchPlayer : ViewBase
{
	protected override void InitChild()
	{

	}

	//介面默認值初始化
	public override void Show()
	{
		base.Show();
		UpdateSprite();
	}

	public override void UpdateFun()
	{
		UpdateSprite();
	}

	//更新完的數據
	private void UpdateSprite()
	{
		var id = GameStateModel.Single.SelectedPlaneId;

		var level = GameStateModel.Single.PlaneLevel;
		Util.Get("Icon").SetSprite(PlaneSpritesModel.Single[id, level]);
	}
}
