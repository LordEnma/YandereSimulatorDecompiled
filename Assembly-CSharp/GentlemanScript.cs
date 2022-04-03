using System;
using UnityEngine;

// Token: 0x020002E4 RID: 740
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x06001503 RID: 5379 RVA: 0x000D826C File Offset: 0x000D646C
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

	// Token: 0x040021C2 RID: 8642
	public YandereScript Yandere;

	// Token: 0x040021C3 RID: 8643
	public AudioClip[] Clips;
}
