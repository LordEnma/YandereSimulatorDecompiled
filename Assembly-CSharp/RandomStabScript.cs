using System;
using UnityEngine;

// Token: 0x020003C9 RID: 969
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B45 RID: 6981 RVA: 0x00131DE8 File Offset: 0x0012FFE8
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

	// Token: 0x04002E8B RID: 11915
	public AudioClip[] Stabs;

	// Token: 0x04002E8C RID: 11916
	public AudioClip Bite;

	// Token: 0x04002E8D RID: 11917
	public bool Biting;
}
