using System;
using UnityEngine;

// Token: 0x020003D1 RID: 977
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B77 RID: 7031 RVA: 0x001355D8 File Offset: 0x001337D8
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

	// Token: 0x04002F18 RID: 12056
	public AudioClip[] Stabs;

	// Token: 0x04002F19 RID: 12057
	public AudioClip Bite;

	// Token: 0x04002F1A RID: 12058
	public bool Biting;
}
