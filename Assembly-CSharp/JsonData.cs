using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;

public abstract class JsonData
{
	protected static string FolderPath => Path.Combine(Application.streamingAssetsPath, "JSON");

	protected static Dictionary<string, object>[] Deserialize(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
	}
}
