using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004B2 RID: 1202
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001F7F RID: 8063 RVA: 0x001B98A7 File Offset: 0x001B7AA7
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001F80 RID: 8064 RVA: 0x001B98BB File Offset: 0x001B7ABB
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x04004182 RID: 16770
	public float Strength1;

	// Token: 0x04004183 RID: 16771
	public float Strength2;

	// Token: 0x04004184 RID: 16772
	public float TimeLimit;

	// Token: 0x04004185 RID: 16773
	public float Timer;
}
