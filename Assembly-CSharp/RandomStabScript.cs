using System;
using UnityEngine;

// Token: 0x020003CE RID: 974
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B6D RID: 7021 RVA: 0x00134B64 File Offset: 0x00132D64
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

	// Token: 0x04002EFF RID: 12031
	public AudioClip[] Stabs;

	// Token: 0x04002F00 RID: 12032
	public AudioClip Bite;

	// Token: 0x04002F01 RID: 12033
	public bool Biting;
}
