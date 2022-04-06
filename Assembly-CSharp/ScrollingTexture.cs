using System;
using UnityEngine;

// Token: 0x0200041E RID: 1054
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C89 RID: 7305 RVA: 0x0014E05F File Offset: 0x0014C25F
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C8A RID: 7306 RVA: 0x0014E070 File Offset: 0x0014C270
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x040032D0 RID: 13008
	public Renderer MyRenderer;

	// Token: 0x040032D1 RID: 13009
	public float Offset;

	// Token: 0x040032D2 RID: 13010
	public float Speed;
}
