using System;
using System.Reflection;

public class InitCustomAttributes : IInit
{
	public void Init()
	{
		InitData<BindPrefab>(BindUtil.Bind);
		InitData<BulletAttribute>(BulletUtil.Add);
	}

	private void InitData<T>(Action<T, Type> callBack) where T : class
	{
		//表示組件 (Assembly)，此組件是可重複使用、可控制版本和自我描述的。
		var assembly = Assembly.GetAssembly(typeof(T));
		//獲取公有類型
		var types = assembly.GetExportedTypes();

		//搜索類型
		foreach (var type in types)
		{
			foreach (var attribute in Attribute.GetCustomAttributes(type, true))
			{
				if (attribute is T)
				{
					T data = attribute as T;
					callBack(data, type);
				}
			}
		}
	}
}
