using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004BC RID: 1212
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001FC9 RID: 8137 RVA: 0x001C02AF File Offset: 0x001BE4AF
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001FCA RID: 8138 RVA: 0x001C02C3 File Offset: 0x001BE4C3
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x04004256 RID: 16982
	public float Strength1;

	// Token: 0x04004257 RID: 16983
	public float Strength2;

	// Token: 0x04004258 RID: 16984
	public float TimeLimit;

	// Token: 0x04004259 RID: 16985
	public float Timer;
}
