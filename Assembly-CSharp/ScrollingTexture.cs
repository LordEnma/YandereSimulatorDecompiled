using System;
using UnityEngine;

// Token: 0x0200041A RID: 1050
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C79 RID: 7289 RVA: 0x0014D257 File Offset: 0x0014B457
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C7A RID: 7290 RVA: 0x0014D268 File Offset: 0x0014B468
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x040032B1 RID: 12977
	public Renderer MyRenderer;

	// Token: 0x040032B2 RID: 12978
	public float Offset;

	// Token: 0x040032B3 RID: 12979
	public float Speed;
}
