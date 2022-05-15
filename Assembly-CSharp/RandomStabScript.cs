using System;
using UnityEngine;

// Token: 0x020003D3 RID: 979
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B8B RID: 7051 RVA: 0x00136E90 File Offset: 0x00135090
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

	// Token: 0x04002F45 RID: 12101
	public AudioClip[] Stabs;

	// Token: 0x04002F46 RID: 12102
	public AudioClip Bite;

	// Token: 0x04002F47 RID: 12103
	public bool Biting;
}
