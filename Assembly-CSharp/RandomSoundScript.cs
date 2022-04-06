using System;
using UnityEngine;

// Token: 0x020003D1 RID: 977
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B7B RID: 7035 RVA: 0x001357C0 File Offset: 0x001339C0
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002F1A RID: 12058
	public AudioClip[] Clips;
}
