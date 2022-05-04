using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000274 RID: 628
public class DebugConsole : MonoBehaviour
{
	// Token: 0x0600135D RID: 4957 RVA: 0x000AF58C File Offset: 0x000AD78C
	private void OnEnable()
	{
		Application.logMessageReceived += this.captureLog;
	}

	// Token: 0x0600135E RID: 4958 RVA: 0x000AF59F File Offset: 0x000AD79F
	private void OnDisable()
	{
		Application.logMessageReceived += this.captureLog;
	}

	// Token: 0x0600135F RID: 4959 RVA: 0x000AF5B4 File Offset: 0x000AD7B4
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

	// Token: 0x06001360 RID: 4960 RVA: 0x000AF620 File Offset: 0x000AD820
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

	// Token: 0x06001361 RID: 4961 RVA: 0x000AF66C File Offset: 0x000AD86C
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

	// Token: 0x04001C2B RID: 7211
	private List<DebugMessage> logs = new List<DebugMessage>();

	// Token: 0x04001C2C RID: 7212
	private Texture2D BackgroundTex;
}
