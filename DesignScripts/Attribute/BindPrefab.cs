using System;

//指定特性應用於哪種對象
[AttributeUsage(AttributeTargets.Class)]
public class BindPrefab : Attribute
{
	public string Path { get; }
	public int Priority { get; }

	public BindPrefab(string path, int priority = 100)
	{
		Path = path;
		Priority = priority;
	}
}
