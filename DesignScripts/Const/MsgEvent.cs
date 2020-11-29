public class MsgEvent
{
	public const int EVENT_HP = 0;
	public const int EVENT_SCORE = 1;
	public const int EVENT_SHIELD = 2;
	public const int EVENT_POWER = 3;
	public const int EVENT_USE_SHIELD = 4;
	public const int EVENT_USE_BOMB = 5;
	public const int EVENT_CHANGE_HAND = 6;

	public const int EVENT_GAME_PAUSE = 7;
	public const int EVENT_GAME_CONTINUE = 8;
	public const int EVENT_START_GAME = 9;
	public const int EVENT_END_GAME = 10;

	//遊戲過程中升級
	public const int EVENT_GAME_UPDATE_LEVEL = 11;
	//通過加經驗方式提升臨時等級
	public const int EVENT_GAME_EXP_LEVEL_UP = 12;

	public const int EVENT_BUFF = 13;
	public const int EVENT_DEBUFF = 14;

	//結束了一關
	public const int EVENT_END_ONCE = 15;
	//開始新的一關
	public const int EVENT_START_ONCE = 16;
}
