using UnityEngine;

public static class StreamingAssetsHelper
{
	public static string GetPath(string relativePath)
	{
		string text = Application.streamingAssetsPath + "/" + relativePath;
		if (Application.platform != RuntimePlatform.Android)
		{
			return "file://" + text;
		}
		return "jar:file://" + text;
	}
}
