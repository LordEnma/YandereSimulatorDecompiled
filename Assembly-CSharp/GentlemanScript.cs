using System;
using UnityEngine;

// Token: 0x020002E3 RID: 739
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x060014FA RID: 5370 RVA: 0x000D78FC File Offset: 0x000D5AFC
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

	// Token: 0x040021A4 RID: 8612
	public YandereScript Yandere;

	// Token: 0x040021A5 RID: 8613
	public AudioClip[] Clips;
}
