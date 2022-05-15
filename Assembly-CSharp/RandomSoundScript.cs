using System;
using UnityEngine;

// Token: 0x020003D2 RID: 978
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B89 RID: 7049 RVA: 0x00136E60 File Offset: 0x00135060
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002F44 RID: 12100
	public AudioClip[] Clips;
}
