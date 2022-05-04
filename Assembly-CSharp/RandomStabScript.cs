using System;
using UnityEngine;

// Token: 0x020003D2 RID: 978
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B85 RID: 7045 RVA: 0x00136244 File Offset: 0x00134444
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

	// Token: 0x04002F30 RID: 12080
	public AudioClip[] Stabs;

	// Token: 0x04002F31 RID: 12081
	public AudioClip Bite;

	// Token: 0x04002F32 RID: 12082
	public bool Biting;
}
