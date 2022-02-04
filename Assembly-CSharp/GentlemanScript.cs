using System;
using UnityEngine;

// Token: 0x020002E1 RID: 737
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x060014EC RID: 5356 RVA: 0x000D6B4C File Offset: 0x000D4D4C
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

	// Token: 0x0400217A RID: 8570
	public YandereScript Yandere;

	// Token: 0x0400217B RID: 8571
	public AudioClip[] Clips;
}
