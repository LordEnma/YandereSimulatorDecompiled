using System;
using UnityEngine;

// Token: 0x02000240 RID: 576
public class CheerScript : MonoBehaviour
{
	// Token: 0x06001241 RID: 4673 RVA: 0x0008C138 File Offset: 0x0008A338
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

	// Token: 0x040016FF RID: 5887
	public AudioSource MyAudio;

	// Token: 0x04001700 RID: 5888
	public AudioClip[] Cheers;

	// Token: 0x04001701 RID: 5889
	public float Timer;
}
