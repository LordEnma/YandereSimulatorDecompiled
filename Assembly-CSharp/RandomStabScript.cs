using System;
using UnityEngine;

// Token: 0x020003D3 RID: 979
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B8C RID: 7052 RVA: 0x0013712C File Offset: 0x0013532C
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (!this.Biting)
		{
			component.clip = this.Stabs[UnityEngine.Random.Range(0, this.Stabs.Length)];
			component.Play();
			return;
		}
		component.clip = this.Bite;
		component.pitch = UnityEngine.Random.Range(0.5f, 1f);
		component.Play();
	}

	// Token: 0x04002F4D RID: 12109
	public AudioClip[] Stabs;

	// Token: 0x04002F4E RID: 12110
	public AudioClip Bite;

	// Token: 0x04002F4F RID: 12111
	public bool Biting;
}
