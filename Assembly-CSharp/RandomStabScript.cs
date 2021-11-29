using System;
using UnityEngine;

// Token: 0x020003C8 RID: 968
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B3B RID: 6971 RVA: 0x0013112C File Offset: 0x0012F32C
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

	// Token: 0x04002E5A RID: 11866
	public AudioClip[] Stabs;

	// Token: 0x04002E5B RID: 11867
	public AudioClip Bite;

	// Token: 0x04002E5C RID: 11868
	public bool Biting;
}
