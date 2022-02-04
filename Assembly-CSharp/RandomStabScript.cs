using System;
using UnityEngine;

// Token: 0x020003CB RID: 971
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B4D RID: 6989 RVA: 0x0013289C File Offset: 0x00130A9C
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

	// Token: 0x04002E9C RID: 11932
	public AudioClip[] Stabs;

	// Token: 0x04002E9D RID: 11933
	public AudioClip Bite;

	// Token: 0x04002E9E RID: 11934
	public bool Biting;
}
