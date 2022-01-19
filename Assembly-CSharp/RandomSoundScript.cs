using System;
using UnityEngine;

// Token: 0x020003CA RID: 970
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B4A RID: 6986 RVA: 0x00132324 File Offset: 0x00130524
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002E94 RID: 11924
	public AudioClip[] Clips;
}
