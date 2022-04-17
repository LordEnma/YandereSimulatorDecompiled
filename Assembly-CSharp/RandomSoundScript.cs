using System;
using UnityEngine;

// Token: 0x020003D1 RID: 977
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B7F RID: 7039 RVA: 0x00135BD0 File Offset: 0x00133DD0
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002F25 RID: 12069
	public AudioClip[] Clips;
}
