using System;
using UnityEngine;

// Token: 0x02000241 RID: 577
public class CheerScript : MonoBehaviour
{
	// Token: 0x06001245 RID: 4677 RVA: 0x0008C480 File Offset: 0x0008A680
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

	// Token: 0x04001707 RID: 5895
	public AudioSource MyAudio;

	// Token: 0x04001708 RID: 5896
	public AudioClip[] Cheers;

	// Token: 0x04001709 RID: 5897
	public float Timer;
}
