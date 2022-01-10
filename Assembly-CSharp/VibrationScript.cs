using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004B1 RID: 1201
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001F79 RID: 8057 RVA: 0x001B83A3 File Offset: 0x001B65A3
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001F7A RID: 8058 RVA: 0x001B83B7 File Offset: 0x001B65B7
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x0400416D RID: 16749
	public float Strength1;

	// Token: 0x0400416E RID: 16750
	public float Strength2;

	// Token: 0x0400416F RID: 16751
	public float TimeLimit;

	// Token: 0x04004170 RID: 16752
	public float Timer;
}
