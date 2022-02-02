using System;
using UnityEngine;

// Token: 0x02000241 RID: 577
public class CheerScript : MonoBehaviour
{
	// Token: 0x06001244 RID: 4676 RVA: 0x0008C31C File Offset: 0x0008A51C
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

	// Token: 0x04001703 RID: 5891
	public AudioSource MyAudio;

	// Token: 0x04001704 RID: 5892
	public AudioClip[] Cheers;

	// Token: 0x04001705 RID: 5893
	public float Timer;
}
