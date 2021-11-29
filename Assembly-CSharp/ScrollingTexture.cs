using System;
using UnityEngine;

// Token: 0x02000413 RID: 1043
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C44 RID: 7236 RVA: 0x001482CF File Offset: 0x001464CF
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C45 RID: 7237 RVA: 0x001482E0 File Offset: 0x001464E0
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x0400320A RID: 12810
	public Renderer MyRenderer;

	// Token: 0x0400320B RID: 12811
	public float Offset;

	// Token: 0x0400320C RID: 12812
	public float Speed;
}
