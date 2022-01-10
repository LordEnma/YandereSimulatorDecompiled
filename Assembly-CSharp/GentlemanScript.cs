using System;
using UnityEngine;

// Token: 0x020002E1 RID: 737
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x060014EB RID: 5355 RVA: 0x000D658C File Offset: 0x000D478C
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

	// Token: 0x04002171 RID: 8561
	public YandereScript Yandere;

	// Token: 0x04002172 RID: 8562
	public AudioClip[] Clips;
}
