using System;
using UnityEngine;

// Token: 0x02000419 RID: 1049
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C6A RID: 7274 RVA: 0x0014BE77 File Offset: 0x0014A077
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C6B RID: 7275 RVA: 0x0014BE88 File Offset: 0x0014A088
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x04003267 RID: 12903
	public Renderer MyRenderer;

	// Token: 0x04003268 RID: 12904
	public float Offset;

	// Token: 0x04003269 RID: 12905
	public float Speed;
}
