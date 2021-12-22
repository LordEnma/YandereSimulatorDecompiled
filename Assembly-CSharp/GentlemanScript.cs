using System;
using UnityEngine;

// Token: 0x020002E0 RID: 736
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x060014E7 RID: 5351 RVA: 0x000D6014 File Offset: 0x000D4214
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

	// Token: 0x0400216A RID: 8554
	public YandereScript Yandere;

	// Token: 0x0400216B RID: 8555
	public AudioClip[] Clips;
}
