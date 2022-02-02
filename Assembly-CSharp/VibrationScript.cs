using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004B2 RID: 1202
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001F7D RID: 8061 RVA: 0x001B959B File Offset: 0x001B779B
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001F7E RID: 8062 RVA: 0x001B95AF File Offset: 0x001B77AF
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x0400417C RID: 16764
	public float Strength1;

	// Token: 0x0400417D RID: 16765
	public float Strength2;

	// Token: 0x0400417E RID: 16766
	public float TimeLimit;

	// Token: 0x0400417F RID: 16767
	public float Timer;
}
