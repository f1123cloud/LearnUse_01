public class Const
{
	//腳本優先級
	public const int BIND_PREFAB_PRIORITY_VIEW = 0;
	public const int BIND_PREFAB_PRIORITY_CONTROLLER = 1;

	//遊戲部分常量數據
	public const int LIFE_ITEM_NUM = 10;
	public const float CD_EFFECT_TIME = 2;

	//開火的基礎時間
	public const float FIRE_BASE_TIME = 1;

	//開火的CD時間
	public const float FIRE_CD_TIME = 0.15f;

	//開火的持續時間
	public const float FIRE_DURATION = 0.3f;

	//護盾持續時間
	public const float SHIELD_TIME = 6;

	//地圖
	public const string MAP_PREFIX = "map_level_";

	//敵人
	public const string ENEMY_PREFIX = "Enemy_{0}_{1}";

	//敵人血量自適應寬度比例
	public const float ENEMY_LIFE_BAR_WIDTH = 0.8f;
	public const float WAIT_BOSS_TIME = 5;

	//關卡之間等待時間
	public const float WAIT_LEVEL_START_TIME = 10;
}
