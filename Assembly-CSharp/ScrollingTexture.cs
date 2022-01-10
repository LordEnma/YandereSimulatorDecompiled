using System;
using UnityEngine;

// Token: 0x02000416 RID: 1046
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C55 RID: 7253 RVA: 0x00149327 File Offset: 0x00147527
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C56 RID: 7254 RVA: 0x00149338 File Offset: 0x00147538
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x04003242 RID: 12866
	public Renderer MyRenderer;

	// Token: 0x04003243 RID: 12867
	public float Offset;

	// Token: 0x04003244 RID: 12868
	public float Speed;
}
