using System;
using UnityEngine;

// Token: 0x020002E5 RID: 741
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x0600150F RID: 5391 RVA: 0x000D8A34 File Offset: 0x000D6C34
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

	// Token: 0x040021CF RID: 8655
	public YandereScript Yandere;

	// Token: 0x040021D0 RID: 8656
	public AudioClip[] Clips;
}
