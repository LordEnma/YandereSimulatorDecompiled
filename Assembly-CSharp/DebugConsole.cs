using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000274 RID: 628
public class DebugConsole : MonoBehaviour
{
	// Token: 0x06001359 RID: 4953 RVA: 0x000AEFC8 File Offset: 0x000AD1C8
	private void OnEnable()
	{
		Application.logMessageReceived += this.captureLog;
	}

	// Token: 0x0600135A RID: 4954 RVA: 0x000AEFDB File Offset: 0x000AD1DB
	private void OnDisable()
	{
		Application.logMessageReceived += this.captureLog;
	}

	// Token: 0x0600135B RID: 4955 RVA: 0x000AEFF0 File Offset: 0x000AD1F0
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

	// Token: 0x0600135C RID: 4956 RVA: 0x000AF05C File Offset: 0x000AD25C
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

	// Token: 0x0600135D RID: 4957 RVA: 0x000AF0A8 File Offset: 0x000AD2A8
	private void OnGUI()
	{
		GUIStyle guistyle = new GUIStyle();
		guistyle.normal.background = this.BackgroundTex;
		GUI.Label(new Rect(10f, 0f, (float)Screen.width / 3f, (float)(15 * this.logs.Count)), string.Empty, guistyle);
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
				goto IL_BD;
			case LogType.Warning:
				guistyle2.normal.textColor = Color.yellow;
				break;
			case LogType.Exception:
				guistyle2.normal.textColor = Color.red;
				break;
			default:
				goto IL_BD;
			}
			IL_CD:
			GUI.Label(new Rect(10f, (float)(15 * i), (float)Screen.width / 3f, 25f), this.logs[i].content, guistyle2);
			i++;
			continue;
			IL_BD:
			guistyle2.normal.textColor = Color.white;
			goto IL_CD;
		}
	}

	// Token: 0x04001C22 RID: 7202
	private List<DebugMessage> logs = new List<DebugMessage>();

	// Token: 0x04001C23 RID: 7203
	private Texture2D BackgroundTex;
}
