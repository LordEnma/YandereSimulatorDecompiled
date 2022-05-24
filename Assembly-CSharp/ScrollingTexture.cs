using System;
using UnityEngine;

// Token: 0x02000420 RID: 1056
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C9B RID: 7323 RVA: 0x0014FBE7 File Offset: 0x0014DDE7
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C9C RID: 7324 RVA: 0x0014FBF8 File Offset: 0x0014DDF8
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x04003307 RID: 13063
	public Renderer MyRenderer;

	// Token: 0x04003308 RID: 13064
	public float Offset;

	// Token: 0x04003309 RID: 13065
	public float Speed;
}
