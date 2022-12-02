using System.Collections.Generic;
using UnityEngine;

public class DebugConsole : MonoBehaviour
{
	private List<DebugMessage> logs = new List<DebugMessage>();

	private Texture2D BackgroundTex;

	private void OnEnable()
	{
		Application.logMessageReceived += captureLog;
	}

	private void OnDisable()
	{
		Application.logMessageReceived += captureLog;
	}

	private void Start()
	{
		BackgroundTex = Texture2D.blackTexture;
		Texture2D backgroundTex = BackgroundTex;
		for (int i = 0; i < backgroundTex.width; i++)
		{
			for (int j = 0; j < backgroundTex.height; j++)
			{
				Color pixel = backgroundTex.GetPixel(i, j);
				pixel.a = 0.5f;
				backgroundTex.SetPixel(i, j, pixel);
			}
		}
		backgroundTex.Apply();
		BackgroundTex = backgroundTex;
	}

	private void captureLog(string condition, string stackTrace, LogType type)
	{
		logs.Add(new DebugMessage
		{
			messageType = type,
			content = condition
		});
		if (logs.Count > 30)
		{
			logs.RemoveAt(0);
		}
	}

	private void OnGUI()
	{
		GUIStyle gUIStyle = new GUIStyle();
		gUIStyle.normal.background = BackgroundTex;
		GUI.Label(new Rect(10f, 0f, (float)Screen.width / 3f, 15 * logs.Count), string.Empty, gUIStyle);
		for (int i = 0; i < logs.Count; i++)
		{
			GUIStyle gUIStyle2 = new GUIStyle();
			switch (logs[i].messageType)
			{
			case LogType.Error:
				gUIStyle2.normal.textColor = Color.red;
				break;
			case LogType.Exception:
				gUIStyle2.normal.textColor = Color.red;
				break;
			case LogType.Warning:
				gUIStyle2.normal.textColor = Color.yellow;
				break;
			default:
				gUIStyle2.normal.textColor = Color.white;
				break;
			}
			GUI.Label(new Rect(10f, 15 * i, (float)Screen.width / 3f, 25f), logs[i].content, gUIStyle2);
		}
	}
}
