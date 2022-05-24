using System;
using UnityEngine;

// Token: 0x020003D2 RID: 978
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B8A RID: 7050 RVA: 0x001370FC File Offset: 0x001352FC
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002F4C RID: 12108
	public AudioClip[] Clips;
}
