using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004BD RID: 1213
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001FD2 RID: 8146 RVA: 0x001C1447 File Offset: 0x001BF647
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001FD3 RID: 8147 RVA: 0x001C145B File Offset: 0x001BF65B
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x04004274 RID: 17012
	public float Strength1;

	// Token: 0x04004275 RID: 17013
	public float Strength2;

	// Token: 0x04004276 RID: 17014
	public float TimeLimit;

	// Token: 0x04004277 RID: 17015
	public float Timer;
}
