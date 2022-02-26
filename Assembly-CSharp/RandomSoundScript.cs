using System;
using UnityEngine;

// Token: 0x020003CC RID: 972
public class RandomSoundScript : MonoBehaviour
{
	// Token: 0x06001B5D RID: 7005 RVA: 0x0013377C File Offset: 0x0013197C
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
		component.Play();
	}

	// Token: 0x04002EB4 RID: 11956
	public AudioClip[] Clips;
}
