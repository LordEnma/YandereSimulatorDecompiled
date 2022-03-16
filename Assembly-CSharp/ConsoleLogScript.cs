using System;
using UnityEngine;

// Token: 0x02000258 RID: 600
public class ConsoleLogScript : MonoBehaviour
{
	// Token: 0x060012AE RID: 4782 RVA: 0x000995EB File Offset: 0x000977EB
	private void OnEnable()
	{
		Application.logMessageReceived += this.Log;
	}

	// Token: 0x060012AF RID: 4783 RVA: 0x000995FE File Offset: 0x000977FE
	private void OnDisable()
	{
		Application.logMessageReceived -= this.Log;
	}

	// Token: 0x060012B0 RID: 4784 RVA: 0x00099614 File Offset: 0x00097814
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

	// Token: 0x060012B1 RID: 4785 RVA: 0x000996A4 File Offset: 0x000978A4
	public void Log(string logString, string stackTrace, LogType type)
	{
		this.myLog = this.myLog + "\n" + logString;
		if (this.myLog.Length > this.kChars)
		{
			this.myLog = this.myLog.Substring(this.myLog.Length - this.kChars);
		}
	}

	// Token: 0x060012B2 RID: 4786 RVA: 0x00099700 File Offset: 0x00097900
	private void OnGUI()
	{
		if (!this.doShow)
		{
			return;
		}
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / 1280f, (float)Screen.height / 720f, 1f));
		GUI.TextArea(new Rect(0f, 479.9952f, 426.6624f, 239.9976f), this.myLog);
	}

	// Token: 0x040018D0 RID: 6352
	public DebugEnablerScript debug;

	// Token: 0x040018D1 RID: 6353
	private string myLog = "Debug Console Output:";

	// Token: 0x040018D2 RID: 6354
	private bool doShow;

	// Token: 0x040018D3 RID: 6355
	private int kChars = 700;

	// Token: 0x040018D4 RID: 6356
	private int enters;

	// Token: 0x040018D5 RID: 6357
	private int id;

	// Token: 0x040018D6 RID: 6358
	public string[] code;
}
