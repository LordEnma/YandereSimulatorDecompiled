using System;
using UnityEngine;

// Token: 0x020003CC RID: 972
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B56 RID: 6998 RVA: 0x00132D64 File Offset: 0x00130F64
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

	// Token: 0x04002EA5 RID: 11941
	public AudioClip[] Stabs;

	// Token: 0x04002EA6 RID: 11942
	public AudioClip Bite;

	// Token: 0x04002EA7 RID: 11943
	public bool Biting;
}
