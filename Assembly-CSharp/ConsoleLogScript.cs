using System;
using UnityEngine;

// Token: 0x02000258 RID: 600
public class ConsoleLogScript : MonoBehaviour
{
	// Token: 0x060012AF RID: 4783 RVA: 0x0009980F File Offset: 0x00097A0F
	private void OnEnable()
	{
		Application.logMessageReceived += this.Log;
	}

	// Token: 0x060012B0 RID: 4784 RVA: 0x00099822 File Offset: 0x00097A22
	private void OnDisable()
	{
		Application.logMessageReceived -= this.Log;
	}

	// Token: 0x060012B1 RID: 4785 RVA: 0x00099838 File Offset: 0x00097A38
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

	// Token: 0x060012B2 RID: 4786 RVA: 0x000998C8 File Offset: 0x00097AC8
	public void Log(string logString, string stackTrace, LogType type)
	{
		this.myLog = this.myLog + "\n" + logString;
		if (this.myLog.Length > this.kChars)
		{
			this.myLog = this.myLog.Substring(this.myLog.Length - this.kChars);
		}
	}

	// Token: 0x060012B3 RID: 4787 RVA: 0x00099924 File Offset: 0x00097B24
	private void OnGUI()
	{
		if (!this.doShow)
		{
			return;
		}
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / 1280f, (float)Screen.height / 720f, 1f));
		GUI.TextArea(new Rect(0f, 479.9952f, 426.6624f, 239.9976f), this.myLog);
	}

	// Token: 0x040018D2 RID: 6354
	public DebugEnablerScript debug;

	// Token: 0x040018D3 RID: 6355
	private string myLog = "Debug Console Output:";

	// Token: 0x040018D4 RID: 6356
	private bool doShow;

	// Token: 0x040018D5 RID: 6357
	private int kChars = 700;

	// Token: 0x040018D6 RID: 6358
	private int enters;

	// Token: 0x040018D7 RID: 6359
	private int id;

	// Token: 0x040018D8 RID: 6360
	public string[] code;
}
