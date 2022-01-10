using System;
using UnityEngine;

// Token: 0x020003CB RID: 971
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B4C RID: 6988 RVA: 0x00132184 File Offset: 0x00130384
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

	// Token: 0x04002E91 RID: 11921
	public AudioClip[] Stabs;

	// Token: 0x04002E92 RID: 11922
	public AudioClip Bite;

	// Token: 0x04002E93 RID: 11923
	public bool Biting;
}
