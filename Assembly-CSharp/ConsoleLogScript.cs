using System;
using UnityEngine;

// Token: 0x02000257 RID: 599
public class ConsoleLogScript : MonoBehaviour
{
	// Token: 0x060012A5 RID: 4773 RVA: 0x00098C6F File Offset: 0x00096E6F
	private void OnEnable()
	{
		Application.logMessageReceived += this.Log;
	}

	// Token: 0x060012A6 RID: 4774 RVA: 0x00098C82 File Offset: 0x00096E82
	private void OnDisable()
	{
		Application.logMessageReceived -= this.Log;
	}

	// Token: 0x060012A7 RID: 4775 RVA: 0x00098C98 File Offset: 0x00096E98
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
		if (this.doShow && this.id < this.code.Length && Input.GetKeyDown(this.code[this.id]))
		{
			this.id++;
			if (this.id == this.code.Length)
			{
				this.debug.EnableDebug();
			}
		}
	}

	// Token: 0x060012A8 RID: 4776 RVA: 0x00098D30 File Offset: 0x00096F30
	public void Log(string logString, string stackTrace, LogType type)
	{
		this.myLog = this.myLog + "\n" + logString;
		if (this.myLog.Length > this.kChars)
		{
			this.myLog = this.myLog.Substring(this.myLog.Length - this.kChars);
		}
	}

	// Token: 0x060012A9 RID: 4777 RVA: 0x00098D8C File Offset: 0x00096F8C
	private void OnGUI()
	{
		if (!this.doShow)
		{
			return;
		}
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / 1280f, (float)(Screen.height / 720), 1f));
		GUI.TextArea(new Rect(0f, 479.9952f, 426.6624f, 239.9976f), this.myLog);
	}

	// Token: 0x040018B4 RID: 6324
	public DebugEnablerScript debug;

	// Token: 0x040018B5 RID: 6325
	private string myLog = "Debug Console Output:";

	// Token: 0x040018B6 RID: 6326
	private bool doShow;

	// Token: 0x040018B7 RID: 6327
	private int kChars = 700;

	// Token: 0x040018B8 RID: 6328
	private int enters;

	// Token: 0x040018B9 RID: 6329
	private int id;

	// Token: 0x040018BA RID: 6330
	public string[] code;
}
