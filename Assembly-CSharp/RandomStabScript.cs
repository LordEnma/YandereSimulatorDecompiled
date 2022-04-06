using System;
using UnityEngine;

// Token: 0x020003D2 RID: 978
public class RandomStabScript : MonoBehaviour
{
	// Token: 0x06001B7D RID: 7037 RVA: 0x001357F0 File Offset: 0x001339F0
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

	// Token: 0x04002F1B RID: 12059
	public AudioClip[] Stabs;

	// Token: 0x04002F1C RID: 12060
	public AudioClip Bite;

	// Token: 0x04002F1D RID: 12061
	public bool Biting;
}
