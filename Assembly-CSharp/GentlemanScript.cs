using System;
using UnityEngine;

// Token: 0x020002DF RID: 735
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x060014E0 RID: 5344 RVA: 0x000D5854 File Offset: 0x000D3A54
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

	// Token: 0x0400214A RID: 8522
	public YandereScript Yandere;

	// Token: 0x0400214B RID: 8523
	public AudioClip[] Clips;
}
