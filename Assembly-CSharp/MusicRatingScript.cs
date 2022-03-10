using System;
using UnityEngine;

// Token: 0x0200001A RID: 26
public class MusicRatingScript : MonoBehaviour
{
	// Token: 0x06000057 RID: 87 RVA: 0x000097C1 File Offset: 0x000079C1
	private void Start()
	{
		if (this.SFX != null)
		{
			this.SFX.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
		}
	}

	// Token: 0x06000058 RID: 88 RVA: 0x000097EC File Offset: 0x000079EC
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

	// Token: 0x04000166 RID: 358
	public Renderer MyRenderer;

	// Token: 0x04000167 RID: 359
	public AudioSource SFX;

	// Token: 0x04000168 RID: 360
	public float Speed;

	// Token: 0x04000169 RID: 361
	public float Timer;
}
