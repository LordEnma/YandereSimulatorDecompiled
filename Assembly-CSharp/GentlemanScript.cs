using System;
using UnityEngine;

// Token: 0x020002E0 RID: 736
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x060014E7 RID: 5351 RVA: 0x000D6264 File Offset: 0x000D4464
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

	// Token: 0x0400216D RID: 8557
	public YandereScript Yandere;

	// Token: 0x0400216E RID: 8558
	public AudioClip[] Clips;
}
