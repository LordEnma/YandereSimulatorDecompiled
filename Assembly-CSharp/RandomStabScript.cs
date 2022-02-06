using System;
using UnityEngine;

// Token: 0x020003CB RID: 971
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B4F RID: 6991 RVA: 0x00132A34 File Offset: 0x00130C34
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

	// Token: 0x04002E9F RID: 11935
	public AudioClip[] Stabs;

	// Token: 0x04002EA0 RID: 11936
	public AudioClip Bite;

	// Token: 0x04002EA1 RID: 11937
	public bool Biting;
}
