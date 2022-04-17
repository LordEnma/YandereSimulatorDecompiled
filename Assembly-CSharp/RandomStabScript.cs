using System;
using UnityEngine;

// Token: 0x020003D2 RID: 978
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B81 RID: 7041 RVA: 0x00135C00 File Offset: 0x00133E00
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

	// Token: 0x04002F26 RID: 12070
	public AudioClip[] Stabs;

	// Token: 0x04002F27 RID: 12071
	public AudioClip Bite;

	// Token: 0x04002F28 RID: 12072
	public bool Biting;
}
