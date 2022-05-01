using System;
using UnityEngine;

// Token: 0x02000241 RID: 577
public class CheerScript : MonoBehaviour
{
	// Token: 0x06001247 RID: 4679 RVA: 0x0008CDB0 File Offset: 0x0008AFB0
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

	// Token: 0x0400171A RID: 5914
	public AudioSource MyAudio;

	// Token: 0x0400171B RID: 5915
	public AudioClip[] Cheers;

	// Token: 0x0400171C RID: 5916
	public float Timer;
}
