using System;
using UnityEngine;

// Token: 0x02000259 RID: 601
public class ConsoleLogScript : MonoBehaviour
{
	// Token: 0x060012B1 RID: 4785 RVA: 0x00099CAF File Offset: 0x00097EAF
	private void OnEnable()
	{
		Application.logMessageReceived += this.Log;
	}

	// Token: 0x060012B2 RID: 4786 RVA: 0x00099CC2 File Offset: 0x00097EC2
	private void OnDisable()
	{
		Application.logMessageReceived -= this.Log;
	}

	// Token: 0x060012B3 RID: 4787 RVA: 0x00099CD8 File Offset: 0x00097ED8
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

	// Token: 0x060012B4 RID: 4788 RVA: 0x00099D68 File Offset: 0x00097F68
	public void Log(string logString, string stackTrace, LogType type)
	{
		this.myLog = this.myLog + "\n" + logString;
		if (this.myLog.Length > this.kChars)
		{
			this.myLog = this.myLog.Substring(this.myLog.Length - this.kChars);
		}
	}

	// Token: 0x060012B5 RID: 4789 RVA: 0x00099DC4 File Offset: 0x00097FC4
	private void OnGUI()
	{
		if (!this.doShow)
		{
			return;
		}
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / 1280f, (float)Screen.height / 720f, 1f));
		GUI.TextArea(new Rect(0f, 479.9952f, 426.6624f, 239.9976f), this.myLog);
	}

	// Token: 0x040018DC RID: 6364
	public DebugEnablerScript debug;

	// Token: 0x040018DD RID: 6365
	private string myLog = "Debug Console Output:";

	// Token: 0x040018DE RID: 6366
	private bool doShow;

	// Token: 0x040018DF RID: 6367
	private int kChars = 700;

	// Token: 0x040018E0 RID: 6368
	private int enters;

	// Token: 0x040018E1 RID: 6369
	private int id;

	// Token: 0x040018E2 RID: 6370
	public string[] code;
}
