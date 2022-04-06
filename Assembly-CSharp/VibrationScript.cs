using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004BB RID: 1211
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001FB9 RID: 8121 RVA: 0x001BE41B File Offset: 0x001BC61B
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001FBA RID: 8122 RVA: 0x001BE42F File Offset: 0x001BC62F
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x04004230 RID: 16944
	public float Strength1;

	// Token: 0x04004231 RID: 16945
	public float Strength2;

	// Token: 0x04004232 RID: 16946
	public float TimeLimit;

	// Token: 0x04004233 RID: 16947
	public float Timer;
}
