using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004BD RID: 1213
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001FD3 RID: 8147 RVA: 0x001C18C3 File Offset: 0x001BFAC3
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001FD4 RID: 8148 RVA: 0x001C18D7 File Offset: 0x001BFAD7
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x0400427D RID: 17021
	public float Strength1;

	// Token: 0x0400427E RID: 17022
	public float Strength2;

	// Token: 0x0400427F RID: 17023
	public float TimeLimit;

	// Token: 0x04004280 RID: 17024
	public float Timer;
}
