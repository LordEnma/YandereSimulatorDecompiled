using System;
using UnityEngine;

// Token: 0x020003CC RID: 972
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B5E RID: 7006 RVA: 0x00133C94 File Offset: 0x00131E94
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002ECA RID: 11978
	public AudioClip[] Clips;
}
