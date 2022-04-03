using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004BA RID: 1210
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001FB1 RID: 8113 RVA: 0x001BDF13 File Offset: 0x001BC113
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001FB2 RID: 8114 RVA: 0x001BDF27 File Offset: 0x001BC127
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x0400422D RID: 16941
	public float Strength1;

	// Token: 0x0400422E RID: 16942
	public float Strength2;

	// Token: 0x0400422F RID: 16943
	public float TimeLimit;

	// Token: 0x04004230 RID: 16944
	public float Timer;
}
