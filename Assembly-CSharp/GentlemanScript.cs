using System;
using UnityEngine;

// Token: 0x020002E2 RID: 738
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x060014F1 RID: 5361 RVA: 0x000D6CF4 File Offset: 0x000D4EF4
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

	// Token: 0x04002181 RID: 8577
	public YandereScript Yandere;

	// Token: 0x04002182 RID: 8578
	public AudioClip[] Clips;
}
