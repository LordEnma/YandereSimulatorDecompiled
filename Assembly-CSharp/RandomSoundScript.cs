using System;
using UnityEngine;

// Token: 0x020003CB RID: 971
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B54 RID: 6996 RVA: 0x00132D34 File Offset: 0x00130F34
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002EA4 RID: 11940
	public AudioClip[] Clips;
}
