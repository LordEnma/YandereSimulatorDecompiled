using System;
using UnityEngine;

// Token: 0x020003D1 RID: 977
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B83 RID: 7043 RVA: 0x00136248 File Offset: 0x00134448
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002F2F RID: 12079
	public AudioClip[] Clips;
}
