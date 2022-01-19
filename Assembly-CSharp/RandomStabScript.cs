using System;
using UnityEngine;

// Token: 0x020003CB RID: 971
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B4C RID: 6988 RVA: 0x00132354 File Offset: 0x00130554
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

	// Token: 0x04002E95 RID: 11925
	public AudioClip[] Stabs;

	// Token: 0x04002E96 RID: 11926
	public AudioClip Bite;

	// Token: 0x04002E97 RID: 11927
	public bool Biting;
}
