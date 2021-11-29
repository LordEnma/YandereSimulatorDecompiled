using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000272 RID: 626
public class DebugConsole : MonoBehaviour
{
	// Token: 0x06001349 RID: 4937 RVA: 0x000ADD32 File Offset: 0x000ABF32
	private void OnEnable()
	{
		Application.logMessageReceived += this.captureLog;
	}

	// Token: 0x0600134A RID: 4938 RVA: 0x000ADD45 File Offset: 0x000ABF45
	private void OnDisable()
	{
		Application.logMessageReceived += this.captureLog;
	}

	// Token: 0x0600134B RID: 4939 RVA: 0x000ADD58 File Offset: 0x000ABF58
	private void Start()
	{
		this.BackgroundTex = Texture2D.blackTexture;
		Texture2D backgroundTex = this.BackgroundTex;
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
		this.BackgroundTex = backgroundTex;
	}

	// Token: 0x0600134C RID: 4940 RVA: 0x000ADDC4 File Offset: 0x000ABFC4
	private void captureLog(string condition, string stackTrace, LogType type)
	{
		this.logs.Add(new DebugMessage
		{
			messageType = type,
			content = condition
		});
		if (this.logs.Count > 30)
		{
			this.logs.RemoveAt(0);
		}
	}

	// Token: 0x0600134D RID: 4941 RVA: 0x000ADE10 File Offset: 0x000AC010
	private void OnGUI()
	{
		GUIStyle guistyle = new GUIStyle();
		guistyle.normal.background = this.BackgroundTex;
		GUI.Label(new Rect(10f, 0f, (float)(Screen.width / 3), (float)(15 * this.logs.Count)), string.Empty, guistyle);
		int i = 0;
		while (i < this.logs.Count)
		{
			GUIStyle guistyle2 = new GUIStyle();
			switch (this.logs[i].messageType)
			{
			case LogType.Error:
				guistyle2.normal.textColor = Color.red;
				break;
			case LogType.Assert:
			case LogType.Log:
				goto IL_B9;
			case LogType.Warning:
				guistyle2.normal.textColor = Color.yellow;
				break;
			case LogType.Exception:
				guistyle2.normal.textColor = Color.red;
				break;
			default:
				goto IL_B9;
			}
			IL_C9:
			GUI.Label(new Rect(10f, (float)(15 * i), (float)(Screen.width / 3), 25f), this.logs[i].content, guistyle2);
			i++;
			continue;
			IL_B9:
			guistyle2.normal.textColor = Color.white;
			goto IL_C9;
		}
	}

	// Token: 0x04001BDA RID: 7130
	private List<DebugMessage> logs = new List<DebugMessage>();

	// Token: 0x04001BDB RID: 7131
	private Texture2D BackgroundTex;
}
