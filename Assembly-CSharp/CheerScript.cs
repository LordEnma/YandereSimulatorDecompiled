using System;
using UnityEngine;

// Token: 0x02000241 RID: 577
public class CheerScript : MonoBehaviour
{
	// Token: 0x06001245 RID: 4677 RVA: 0x0008C6DC File Offset: 0x0008A8DC
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.MyAudio.clip = this.Cheers[UnityEngine.Random.Range(1, this.Cheers.Length)];
			this.MyAudio.Play();
			this.Timer = 0f;
		}
	}

	// Token: 0x04001710 RID: 5904
	public AudioSource MyAudio;

	// Token: 0x04001711 RID: 5905
	public AudioClip[] Cheers;

	// Token: 0x04001712 RID: 5906
	public float Timer;
}
