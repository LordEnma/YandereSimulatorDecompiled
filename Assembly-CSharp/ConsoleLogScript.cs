using System;
using UnityEngine;

// Token: 0x02000258 RID: 600
public class ConsoleLogScript : MonoBehaviour
{
	// Token: 0x060012AC RID: 4780 RVA: 0x00099207 File Offset: 0x00097407
	private void OnEnable()
	{
		Application.logMessageReceived += this.Log;
	}

	// Token: 0x060012AD RID: 4781 RVA: 0x0009921A File Offset: 0x0009741A
	private void OnDisable()
	{
		Application.logMessageReceived -= this.Log;
	}

	// Token: 0x060012AE RID: 4782 RVA: 0x00099230 File Offset: 0x00097430
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

	// Token: 0x060012AF RID: 4783 RVA: 0x000992C0 File Offset: 0x000974C0
	public void Log(string logString, string stackTrace, LogType type)
	{
		this.myLog = this.myLog + "\n" + logString;
		if (this.myLog.Length > this.kChars)
		{
			this.myLog = this.myLog.Substring(this.myLog.Length - this.kChars);
		}
	}

	// Token: 0x060012B0 RID: 4784 RVA: 0x0009931C File Offset: 0x0009751C
	private void OnGUI()
	{
		if (!this.doShow)
		{
			return;
		}
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / 1280f, (float)Screen.height / 720f, 1f));
		GUI.TextArea(new Rect(0f, 479.9952f, 426.6624f, 239.9976f), this.myLog);
	}

	// Token: 0x040018CA RID: 6346
	public DebugEnablerScript debug;

	// Token: 0x040018CB RID: 6347
	private string myLog = "Debug Console Output:";

	// Token: 0x040018CC RID: 6348
	private bool doShow;

	// Token: 0x040018CD RID: 6349
	private int kChars = 700;

	// Token: 0x040018CE RID: 6350
	private int enters;

	// Token: 0x040018CF RID: 6351
	private int id;

	// Token: 0x040018D0 RID: 6352
	public string[] code;
}
