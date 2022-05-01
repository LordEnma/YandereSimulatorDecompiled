using System;
using UnityEngine;

// Token: 0x02000258 RID: 600
public class ConsoleLogScript : MonoBehaviour
{
	// Token: 0x060012AF RID: 4783 RVA: 0x000999E7 File Offset: 0x00097BE7
	private void OnEnable()
	{
		Application.logMessageReceived += this.Log;
	}

	// Token: 0x060012B0 RID: 4784 RVA: 0x000999FA File Offset: 0x00097BFA
	private void OnDisable()
	{
		Application.logMessageReceived -= this.Log;
	}

	// Token: 0x060012B1 RID: 4785 RVA: 0x00099A10 File Offset: 0x00097C10
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

	// Token: 0x060012B2 RID: 4786 RVA: 0x00099AA0 File Offset: 0x00097CA0
	public void Log(string logString, string stackTrace, LogType type)
	{
		this.myLog = this.myLog + "\n" + logString;
		if (this.myLog.Length > this.kChars)
		{
			this.myLog = this.myLog.Substring(this.myLog.Length - this.kChars);
		}
	}

	// Token: 0x060012B3 RID: 4787 RVA: 0x00099AFC File Offset: 0x00097CFC
	private void OnGUI()
	{
		if (!this.doShow)
		{
			return;
		}
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / 1280f, (float)Screen.height / 720f, 1f));
		GUI.TextArea(new Rect(0f, 479.9952f, 426.6624f, 239.9976f), this.myLog);
	}

	// Token: 0x040018D6 RID: 6358
	public DebugEnablerScript debug;

	// Token: 0x040018D7 RID: 6359
	private string myLog = "Debug Console Output:";

	// Token: 0x040018D8 RID: 6360
	private bool doShow;

	// Token: 0x040018D9 RID: 6361
	private int kChars = 700;

	// Token: 0x040018DA RID: 6362
	private int enters;

	// Token: 0x040018DB RID: 6363
	private int id;

	// Token: 0x040018DC RID: 6364
	public string[] code;
}
