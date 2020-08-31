using UnityEngine;

[BindPrefab(Paths.PREFAB_SELECTED_HERO_VIEW, Const.BIND_PREFAB_PRIORITY_CONTROLLER)]
public class SelectedHeroController : ControllerBase
{
	protected override void InitChild()
	{
		transform.Find("Heros").gameObject.AddComponent<SelectHeroController>();

		transform.ButtonAction("Btn_OK", () =>
		 {
			 UIManager.Single.Show(Paths.PREFAB_LEVELS_VIEW);
		 });

		transform.ButtonAction("Btn_Exit", () =>
		 {
			 Application.Quit();
		 });

		transform.ButtonAction("Btn_Strengthen", () =>
		 {
			 UIManager.Single.Show(Paths.PREFAB_STRENGTHEN_VIEW);
		 });
	}
}
