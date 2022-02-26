using System;
using UnityEngine;

// Token: 0x020003CD RID: 973
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B5F RID: 7007 RVA: 0x001337AC File Offset: 0x001319AC
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

	// Token: 0x04002EB5 RID: 11957
	public AudioClip[] Stabs;

	// Token: 0x04002EB6 RID: 11958
	public AudioClip Bite;

	// Token: 0x04002EB7 RID: 11959
	public bool Biting;
}
