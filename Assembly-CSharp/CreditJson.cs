using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class CreditJson : JsonData
{
	[SerializeField]
	private string name;

	[SerializeField]
	private int size;

	public static string FilePath => Path.Combine(JsonData.FolderPath, "Credits.json");

	public string Name => name;

	public int Size => size;

	public static CreditJson[] LoadFromJson(string path)
	{
		List<CreditJson> list = new List<CreditJson>();
		Dictionary<string, object>[] array = JsonData.Deserialize(path);
		foreach (Dictionary<string, object> dictionary in array)
		{
			CreditJson creditJson = new CreditJson();
			creditJson.name = TFUtils.LoadString(dictionary, "Name");
			creditJson.size = TFUtils.LoadInt(dictionary, "Size");
			list.Add(creditJson);
		}
		return list.ToArray();
	}
}
