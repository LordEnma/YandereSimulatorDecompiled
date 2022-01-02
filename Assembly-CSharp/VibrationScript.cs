using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004AF RID: 1199
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001F6E RID: 8046 RVA: 0x001B7A23 File Offset: 0x001B5C23
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001F6F RID: 8047 RVA: 0x001B7A37 File Offset: 0x001B5C37
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x04004159 RID: 16729
	public float Strength1;

	// Token: 0x0400415A RID: 16730
	public float Strength2;

	// Token: 0x0400415B RID: 16731
	public float TimeLimit;

	// Token: 0x0400415C RID: 16732
	public float Timer;
}
