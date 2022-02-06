using System;
using UnityEngine;

// Token: 0x020002E1 RID: 737
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x060014EC RID: 5356 RVA: 0x000D6C00 File Offset: 0x000D4E00
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

	// Token: 0x0400217C RID: 8572
	public YandereScript Yandere;

	// Token: 0x0400217D RID: 8573
	public AudioClip[] Clips;
}
