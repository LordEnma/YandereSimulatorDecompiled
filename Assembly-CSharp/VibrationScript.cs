using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004B4 RID: 1204
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001F95 RID: 8085 RVA: 0x001BB207 File Offset: 0x001B9407
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001F96 RID: 8086 RVA: 0x001BB21B File Offset: 0x001B941B
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x040041B5 RID: 16821
	public float Strength1;

	// Token: 0x040041B6 RID: 16822
	public float Strength2;

	// Token: 0x040041B7 RID: 16823
	public float TimeLimit;

	// Token: 0x040041B8 RID: 16824
	public float Timer;
}
