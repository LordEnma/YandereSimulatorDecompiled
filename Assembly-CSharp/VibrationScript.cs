using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004B3 RID: 1203
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001F89 RID: 8073 RVA: 0x001B9F1B File Offset: 0x001B811B
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001F8A RID: 8074 RVA: 0x001B9F2F File Offset: 0x001B812F
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x0400418E RID: 16782
	public float Strength1;

	// Token: 0x0400418F RID: 16783
	public float Strength2;

	// Token: 0x04004190 RID: 16784
	public float TimeLimit;

	// Token: 0x04004191 RID: 16785
	public float Timer;
}
