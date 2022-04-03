using System;
using UnityEngine;

// Token: 0x020003D0 RID: 976
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B75 RID: 7029 RVA: 0x001355A8 File Offset: 0x001337A8
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002F17 RID: 12055
	public AudioClip[] Clips;
}
