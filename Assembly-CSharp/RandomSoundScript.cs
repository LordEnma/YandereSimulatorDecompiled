using System;
using UnityEngine;

// Token: 0x020003C8 RID: 968
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B43 RID: 6979 RVA: 0x00131DB8 File Offset: 0x0012FFB8
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002E8A RID: 11914
	public AudioClip[] Clips;
}
