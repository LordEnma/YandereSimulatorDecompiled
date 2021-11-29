using System;
using UnityEngine;

// Token: 0x020003C7 RID: 967
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B39 RID: 6969 RVA: 0x001310FC File Offset: 0x0012F2FC
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002E59 RID: 11865
	public AudioClip[] Clips;
}
