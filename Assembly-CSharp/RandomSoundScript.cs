using System;
using UnityEngine;

// Token: 0x020003CD RID: 973
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B6B RID: 7019 RVA: 0x00134B34 File Offset: 0x00132D34
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002EFE RID: 12030
	public AudioClip[] Clips;
}
