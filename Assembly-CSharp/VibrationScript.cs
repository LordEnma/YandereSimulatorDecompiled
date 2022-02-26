using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004B4 RID: 1204
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001F92 RID: 8082 RVA: 0x001BAA67 File Offset: 0x001B8C67
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001F93 RID: 8083 RVA: 0x001BAA7B File Offset: 0x001B8C7B
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x0400419E RID: 16798
	public float Strength1;

	// Token: 0x0400419F RID: 16799
	public float Strength2;

	// Token: 0x040041A0 RID: 16800
	public float TimeLimit;

	// Token: 0x040041A1 RID: 16801
	public float Timer;
}
