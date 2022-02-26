using System;
using UnityEngine;

// Token: 0x020002E3 RID: 739
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x060014FA RID: 5370 RVA: 0x000D75D8 File Offset: 0x000D57D8
	private void Update()
	{
		if (Input.GetButtonDown("RB"))
		{
			AudioSource component = base.GetComponent<AudioSource>();
			if (!component.isPlaying)
			{
				component.clip = this.Clips[UnityEngine.Random.Range(0, this.Clips.Length - 1)];
				component.Play();
				this.Yandere.Sanity += 10f;
			}
		}
	}

	// Token: 0x04002190 RID: 8592
	public YandereScript Yandere;

	// Token: 0x04002191 RID: 8593
	public AudioClip[] Clips;
}
