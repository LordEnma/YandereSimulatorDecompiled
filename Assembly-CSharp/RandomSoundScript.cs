using System;
using UnityEngine;

// Token: 0x020003CA RID: 970
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B4D RID: 6989 RVA: 0x00132A04 File Offset: 0x00130C04
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002E9E RID: 11934
	public AudioClip[] Clips;
}
