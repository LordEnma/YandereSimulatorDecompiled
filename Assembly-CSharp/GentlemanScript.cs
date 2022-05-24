using System;
using UnityEngine;

// Token: 0x020002E6 RID: 742
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x06001511 RID: 5393 RVA: 0x000D8E54 File Offset: 0x000D7054
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

	// Token: 0x040021D9 RID: 8665
	public YandereScript Yandere;

	// Token: 0x040021DA RID: 8666
	public AudioClip[] Clips;
}
