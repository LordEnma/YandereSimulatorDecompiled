using System;
using UnityEngine;

// Token: 0x020002E3 RID: 739
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x060014FD RID: 5373 RVA: 0x000D7D6C File Offset: 0x000D5F6C
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

	// Token: 0x040021B4 RID: 8628
	public YandereScript Yandere;

	// Token: 0x040021B5 RID: 8629
	public AudioClip[] Clips;
}
