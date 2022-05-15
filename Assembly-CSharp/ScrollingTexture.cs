using System;
using UnityEngine;

// Token: 0x02000420 RID: 1056
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C9A RID: 7322 RVA: 0x0014F92B File Offset: 0x0014DB2B
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C9B RID: 7323 RVA: 0x0014F93C File Offset: 0x0014DB3C
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x040032FF RID: 13055
	public Renderer MyRenderer;

	// Token: 0x04003300 RID: 13056
	public float Offset;

	// Token: 0x04003301 RID: 13057
	public float Speed;
}
