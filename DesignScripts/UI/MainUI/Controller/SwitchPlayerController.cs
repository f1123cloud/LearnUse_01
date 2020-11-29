public class SwitchPlayerController : ControllerBase
{
	private int _id;
	protected override void InitChild()
	{
		//id數據初始化
		GameStateModel.Single.SelectedPlaneId = DataMgr.Single.Get<int>(DataKeys.PLANE_ID);
		_id = GameStateModel.Single.SelectedPlaneId;

		transform.ButtonAction("Left", () => Switch(ref _id, -1));
		transform.ButtonAction("Right", () => Switch(ref _id, 1));
	}

	//ref 關鍵字指出以傳參考方式傳遞引數，而不是以傳值方式
	private void Switch(ref int id, int direction)
	{
		UpdateId(ref id, direction);
		GameStateModel.Single.SelectedPlaneId = id;
	}

	private void UpdateId(ref int id, int direction)
	{
		var min = 0;
		var max = PlaneSpritesModel.Single.Count;
		id += direction;
		id = id < 0 ? 0 : id >= max ? id = max - 1 : id;//id 0~3  max=4 所以要-1
	}
}
