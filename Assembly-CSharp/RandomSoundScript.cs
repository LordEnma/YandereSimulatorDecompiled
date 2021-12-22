using System;
using UnityEngine;

// Token: 0x020003C8 RID: 968
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B41 RID: 6977 RVA: 0x001319BC File Offset: 0x0012FBBC
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002E83 RID: 11907
	public AudioClip[] Clips;
}
