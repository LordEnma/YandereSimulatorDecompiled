using System;
using UnityEngine;

// Token: 0x020003CA RID: 970
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B4B RID: 6987 RVA: 0x0013286C File Offset: 0x00130A6C
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002E9B RID: 11931
	public AudioClip[] Clips;
}
