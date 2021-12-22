using System;
using UnityEngine;

// Token: 0x020003C9 RID: 969
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B43 RID: 6979 RVA: 0x001319EC File Offset: 0x0012FBEC
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

	// Token: 0x04002E84 RID: 11908
	public AudioClip[] Stabs;

	// Token: 0x04002E85 RID: 11909
	public AudioClip Bite;

	// Token: 0x04002E86 RID: 11910
	public bool Biting;
}
