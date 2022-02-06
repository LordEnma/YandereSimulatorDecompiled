using System;
using UnityEngine;

// Token: 0x02000258 RID: 600
public class ConsoleLogScript : MonoBehaviour
{
	// Token: 0x060012AB RID: 4779 RVA: 0x000990B3 File Offset: 0x000972B3
	private void OnEnable()
	{
		Application.logMessageReceived += this.Log;
	}

	// Token: 0x060012AC RID: 4780 RVA: 0x000990C6 File Offset: 0x000972C6
	private void OnDisable()
	{
		Application.logMessageReceived -= this.Log;
	}

	// Token: 0x060012AD RID: 4781 RVA: 0x000990DC File Offset: 0x000972DC
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			this.enters++;
			if (this.enters > 9)
			{
				this.doShow = !this.doShow;
			}
		}
		if (this.id < this.code.Length && Input.GetKeyDown(this.code[this.id]))
		{
			this.id++;
			if (this.id == this.code.Length)
			{
				this.debug.EnableDebug();
			}
		}
	}

	// Token: 0x060012AE RID: 4782 RVA: 0x0009916C File Offset: 0x0009736C
	public void Log(string logString, string stackTrace, LogType type)
	{
		this.myLog = this.myLog + "\n" + logString;
		if (this.myLog.Length > this.kChars)
		{
			this.myLog = this.myLog.Substring(this.myLog.Length - this.kChars);
		}
	}

	// Token: 0x060012AF RID: 4783 RVA: 0x000991C8 File Offset: 0x000973C8
	private void OnGUI()
	{
		if (!this.doShow)
		{
			return;
		}
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / 1280f, (float)(Screen.height / 720), 1f));
		GUI.TextArea(new Rect(0f, 479.9952f, 426.6624f, 239.9976f), this.myLog);
	}

	// Token: 0x040018BF RID: 6335
	public DebugEnablerScript debug;

	// Token: 0x040018C0 RID: 6336
	private string myLog = "Debug Console Output:";

	// Token: 0x040018C1 RID: 6337
	private bool doShow;

	// Token: 0x040018C2 RID: 6338
	private int kChars = 700;

	// Token: 0x040018C3 RID: 6339
	private int enters;

	// Token: 0x040018C4 RID: 6340
	private int id;

	// Token: 0x040018C5 RID: 6341
	public string[] code;
}
