public enum Hero
{
	player_0,
	player_1,
	player_2
}

public enum SceneName
{
	NULL,
	Main,
	Game,
	COUNT
}

public enum BGAudio
{
	Game_BGM,
	Battle_BGM,
	Boss_BGM
}

public enum UIAudio
{
	UI_ClickButton,
	UI_Loading,
	UI_StartGame
}

public enum GameAudio
{
	Null,
	Fire,
	Power,
	Effect_Great,
	Effect_GameOver,
	Effect_Boss_Warning,
	Effect_Missile_Warning,
	Explode_Bullet,
	Explode_Plane,
	Get_Gold,
	Get_Item,
	Get_Shield,
	Lost_Item
}

public enum HandMode
{
	RIGHT,
	LEFT
}

public enum UILayer
{
	BASE_UI,
	MIDDLE_UI,
	TOP_UI,
	COUNT
}

public enum GameLayer
{
	BACKGROUND = 0,
	PLANE = -1,
	EFFECT = -2
}

public enum BulletOwner
{
	PLAYER,
	ENEMY
}

public enum EnemyType
{
	Normal,
	Elites,
	Boss,
	Item
}

//路徑類型
public enum PathType
{
	//直線路徑
	Straight,
	//W型路徑
	W,
	//入場動畫，入場後待在上方不動
	StayOnTop,
	//橢圓路徑
	Ellipse,
	//原地旋轉
	Rotate,
	COUNT
}

public enum BulletType
{
	Player,
	Enemy_Normal_0,
	Enemy_Boss_0,
	Enemy_Boss_1,
	Power
}

public enum PathState
{
	ENTER,
	FORWARD_MOVING,
	BACK_MOVING
}

public enum GameState
{
	NULL,
	START,
	PAUSE,
	CONTINUE,
	END
}

public enum BulletName
{
	Enemy_Normal_0,
	Enemy_Boss_0,
	Enemy_Boss_1,
	COUNT
}

public enum BulletEventType
{
	ChangeSpeed,
	ChangeTrajectory
}

public enum BuffType
{
	NULL,
	LEVEL_UP
}

public enum DebuffType
{
	NULL
}

public enum ItemType
{
	ADD_BULLET,
	ADD_EXP,
	SHIELD,
	POWER
}

