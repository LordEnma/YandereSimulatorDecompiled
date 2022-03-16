using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004B7 RID: 1207
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001FA7 RID: 8103 RVA: 0x001BC987 File Offset: 0x001BAB87
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001FA8 RID: 8104 RVA: 0x001BC99B File Offset: 0x001BAB9B
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x04004200 RID: 16896
	public float Strength1;

	// Token: 0x04004201 RID: 16897
	public float Strength2;

	// Token: 0x04004202 RID: 16898
	public float TimeLimit;

	// Token: 0x04004203 RID: 16899
	public float Timer;
}
