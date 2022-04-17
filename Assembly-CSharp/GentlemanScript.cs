using System;
using UnityEngine;

// Token: 0x020002E5 RID: 741
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x0600150B RID: 5387 RVA: 0x000D8564 File Offset: 0x000D6764
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

	// Token: 0x040021C6 RID: 8646
	public YandereScript Yandere;

	// Token: 0x040021C7 RID: 8647
	public AudioClip[] Clips;
}
