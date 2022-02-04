using System;
using UnityEngine;

// Token: 0x02000258 RID: 600
public class ConsoleLogScript : MonoBehaviour
{
	// Token: 0x060012AB RID: 4779 RVA: 0x00099007 File Offset: 0x00097207
	private void OnEnable()
	{
		Application.logMessageReceived += this.Log;
	}

	// Token: 0x060012AC RID: 4780 RVA: 0x0009901A File Offset: 0x0009721A
	private void OnDisable()
	{
		Application.logMessageReceived -= this.Log;
	}

	// Token: 0x060012AD RID: 4781 RVA: 0x00099030 File Offset: 0x00097230
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

	// Token: 0x060012AE RID: 4782 RVA: 0x000990C0 File Offset: 0x000972C0
	public void Log(string logString, string stackTrace, LogType type)
	{
		this.myLog = this.myLog + "\n" + logString;
		if (this.myLog.Length > this.kChars)
		{
			this.myLog = this.myLog.Substring(this.myLog.Length - this.kChars);
		}
	}

	// Token: 0x060012AF RID: 4783 RVA: 0x0009911C File Offset: 0x0009731C
	private void OnGUI()
	{
		if (!this.doShow)
		{
			return;
		}
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / 1280f, (float)(Screen.height / 720), 1f));
		GUI.TextArea(new Rect(0f, 479.9952f, 426.6624f, 239.9976f), this.myLog);
	}

	// Token: 0x040018BD RID: 6333
	public DebugEnablerScript debug;

	// Token: 0x040018BE RID: 6334
	private string myLog = "Debug Console Output:";

	// Token: 0x040018BF RID: 6335
	private bool doShow;

	// Token: 0x040018C0 RID: 6336
	private int kChars = 700;

	// Token: 0x040018C1 RID: 6337
	private int enters;

	// Token: 0x040018C2 RID: 6338
	private int id;

	// Token: 0x040018C3 RID: 6339
	public string[] code;
}
