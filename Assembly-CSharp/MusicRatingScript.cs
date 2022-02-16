using System;
using UnityEngine;

// Token: 0x0200001A RID: 26
public class MusicRatingScript : MonoBehaviour
{
	// Token: 0x06000057 RID: 87 RVA: 0x000096C9 File Offset: 0x000078C9
	private void Start()
	{
		if (this.SFX != null)
		{
			this.SFX.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
		}
	}

	// Token: 0x06000058 RID: 88 RVA: 0x000096F4 File Offset: 0x000078F4
	private void Update()
	{
		base.transform.localPosition += new Vector3(0f, this.Speed * Time.deltaTime, 0f);
		base.transform.localScale = Vector3.MoveTowards(base.transform.localScale, new Vector3(0.2f, 0.1f, 0.1f), Time.deltaTime);
		this.Timer += Time.deltaTime * 5f;
		if (this.Timer > 1f)
		{
			this.MyRenderer.material.color = new Color(1f, 1f, 1f, 2f - this.Timer);
			if (this.MyRenderer.material.color.a <= 0f)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x0400015D RID: 349
	public Renderer MyRenderer;

	// Token: 0x0400015E RID: 350
	public AudioSource SFX;

	// Token: 0x0400015F RID: 351
	public float Speed;

	// Token: 0x04000160 RID: 352
	public float Timer;
}
