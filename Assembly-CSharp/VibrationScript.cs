using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004B2 RID: 1202
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001F7B RID: 8059 RVA: 0x001B9073 File Offset: 0x001B7273
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001F7C RID: 8060 RVA: 0x001B9087 File Offset: 0x001B7287
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x04004174 RID: 16756
	public float Strength1;

	// Token: 0x04004175 RID: 16757
	public float Strength2;

	// Token: 0x04004176 RID: 16758
	public float TimeLimit;

	// Token: 0x04004177 RID: 16759
	public float Timer;
}
