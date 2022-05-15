using System;
using UnityEngine;

// Token: 0x020002E6 RID: 742
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x06001511 RID: 5393 RVA: 0x000D8CE8 File Offset: 0x000D6EE8
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

	// Token: 0x040021D8 RID: 8664
	public YandereScript Yandere;

	// Token: 0x040021D9 RID: 8665
	public AudioClip[] Clips;
}
