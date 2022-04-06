using System;
using UnityEngine;

// Token: 0x020002E5 RID: 741
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x06001509 RID: 5385 RVA: 0x000D837C File Offset: 0x000D657C
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

	// Token: 0x040021C4 RID: 8644
	public YandereScript Yandere;

	// Token: 0x040021C5 RID: 8645
	public AudioClip[] Clips;
}
