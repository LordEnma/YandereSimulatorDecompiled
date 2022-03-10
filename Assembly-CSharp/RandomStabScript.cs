using System;
using UnityEngine;

// Token: 0x020003CD RID: 973
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B60 RID: 7008 RVA: 0x00133CC4 File Offset: 0x00131EC4
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

	// Token: 0x04002ECB RID: 11979
	public AudioClip[] Stabs;

	// Token: 0x04002ECC RID: 11980
	public AudioClip Bite;

	// Token: 0x04002ECD RID: 11981
	public bool Biting;
}
