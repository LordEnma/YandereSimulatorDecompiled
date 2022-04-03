using System;
using UnityEngine;

// Token: 0x02000241 RID: 577
public class CheerScript : MonoBehaviour
{
	// Token: 0x06001247 RID: 4679 RVA: 0x0008CB40 File Offset: 0x0008AD40
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

	// Token: 0x04001717 RID: 5911
	public AudioSource MyAudio;

	// Token: 0x04001718 RID: 5912
	public AudioClip[] Cheers;

	// Token: 0x04001719 RID: 5913
	public float Timer;
}
