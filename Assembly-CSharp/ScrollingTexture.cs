using System;
using UnityEngine;

// Token: 0x02000417 RID: 1047
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C58 RID: 7256 RVA: 0x0014AE63 File Offset: 0x00149063
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C59 RID: 7257 RVA: 0x0014AE74 File Offset: 0x00149074
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x0400324D RID: 12877
	public Renderer MyRenderer;

	// Token: 0x0400324E RID: 12878
	public float Offset;

	// Token: 0x0400324F RID: 12879
	public float Speed;
}
