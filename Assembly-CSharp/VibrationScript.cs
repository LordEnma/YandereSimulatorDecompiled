using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004B2 RID: 1202
public class VibrationScript : MonoBehaviour
{
	// Token: 0x06001F82 RID: 8066 RVA: 0x001B9AC7 File Offset: 0x001B7CC7
	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	// Token: 0x06001F83 RID: 8067 RVA: 0x001B9ADB File Offset: 0x001B7CDB
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}

	// Token: 0x04004185 RID: 16773
	public float Strength1;

	// Token: 0x04004186 RID: 16774
	public float Strength2;

	// Token: 0x04004187 RID: 16775
	public float TimeLimit;

	// Token: 0x04004188 RID: 16776
	public float Timer;
}
