using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004AE RID: 1198
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001F61 RID: 8033 RVA: 0x001B678F File Offset: 0x001B498F
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001F62 RID: 8034 RVA: 0x001B67A3 File Offset: 0x001B49A3
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x04004122 RID: 16674
	public float Strength1;

	// Token: 0x04004123 RID: 16675
	public float Strength2;

	// Token: 0x04004124 RID: 16676
	public float TimeLimit;

	// Token: 0x04004125 RID: 16677
	public float Timer;
}
