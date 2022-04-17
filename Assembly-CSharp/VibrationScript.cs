using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004BB RID: 1211
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001FBF RID: 8127 RVA: 0x001BEDF7 File Offset: 0x001BCFF7
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001FC0 RID: 8128 RVA: 0x001BEE0B File Offset: 0x001BD00B
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x04004240 RID: 16960
	public float Strength1;

	// Token: 0x04004241 RID: 16961
	public float Strength2;

	// Token: 0x04004242 RID: 16962
	public float TimeLimit;

	// Token: 0x04004243 RID: 16963
	public float Timer;
}
