using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004AF RID: 1199
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001F6B RID: 8043 RVA: 0x001B754B File Offset: 0x001B574B
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001F6C RID: 8044 RVA: 0x001B755F File Offset: 0x001B575F
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x04004152 RID: 16722
	public float Strength1;

	// Token: 0x04004153 RID: 16723
	public float Strength2;

	// Token: 0x04004154 RID: 16724
	public float TimeLimit;

	// Token: 0x04004155 RID: 16725
	public float Timer;
}
