using UnityEngine;
                              //約束:必須是class,能構造函數new();								
public class NormalSingleton<T> where T : class, new()
{
	protected static T _single;

	public static T Single
	{
		get
		{
			if (_single == null)
			{
				//創造公有，默認構造
				var t = new T();
				if (t is MonoBehaviour)
				{
					Debug.LogError("Mono類請使用MonoSingleton");
					return null;
				}
				_single = t;
			}
			return _single;
		}
	}
}
