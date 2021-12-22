using System;
using UnityEngine;

// Token: 0x02000258 RID: 600
public class ConsoleLogScript : MonoBehaviour
{
	// Token: 0x060012AA RID: 4778 RVA: 0x00098E67 File Offset: 0x00097067
	private void OnEnable()
	{
		Application.logMessageReceived += this.Log;
	}

	// Token: 0x060012AB RID: 4779 RVA: 0x00098E7A File Offset: 0x0009707A
	private void OnDisable()
	{
		Application.logMessageReceived -= this.Log;
	}

	// Token: 0x060012AC RID: 4780 RVA: 0x00098E90 File Offset: 0x00097090
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

	// Token: 0x060012AD RID: 4781 RVA: 0x00098F20 File Offset: 0x00097120
	public void Log(string logString, string stackTrace, LogType type)
	{
		this.myLog = this.myLog + "\n" + logString;
		if (this.myLog.Length > this.kChars)
		{
			this.myLog = this.myLog.Substring(this.myLog.Length - this.kChars);
		}
	}

	// Token: 0x060012AE RID: 4782 RVA: 0x00098F7C File Offset: 0x0009717C
	private void OnGUI()
	{
		if (!this.doShow)
		{
			return;
		}
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / 1280f, (float)(Screen.height / 720), 1f));
		GUI.TextArea(new Rect(0f, 479.9952f, 426.6624f, 239.9976f), this.myLog);
	}

	// Token: 0x040018B8 RID: 6328
	public DebugEnablerScript debug;

	// Token: 0x040018B9 RID: 6329
	private string myLog = "Debug Console Output:";

	// Token: 0x040018BA RID: 6330
	private bool doShow;

	// Token: 0x040018BB RID: 6331
	private int kChars = 700;

	// Token: 0x040018BC RID: 6332
	private int enters;

	// Token: 0x040018BD RID: 6333
	private int id;

	// Token: 0x040018BE RID: 6334
	public string[] code;
}
