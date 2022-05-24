using System;
using UnityEngine;

// Token: 0x02000242 RID: 578
public class CheerScript : MonoBehaviour
{
	// Token: 0x06001249 RID: 4681 RVA: 0x0008D108 File Offset: 0x0008B308
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

	// Token: 0x04001720 RID: 5920
	public AudioSource MyAudio;

	// Token: 0x04001721 RID: 5921
	public AudioClip[] Cheers;

	// Token: 0x04001722 RID: 5922
	public float Timer;
}
