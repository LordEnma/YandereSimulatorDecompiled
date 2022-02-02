using System;
using UnityEngine;

// Token: 0x020003CB RID: 971
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B4D RID: 6989 RVA: 0x00132798 File Offset: 0x00130998
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

	// Token: 0x04002E9B RID: 11931
	public AudioClip[] Stabs;

	// Token: 0x04002E9C RID: 11932
	public AudioClip Bite;

	// Token: 0x04002E9D RID: 11933
	public bool Biting;
}
