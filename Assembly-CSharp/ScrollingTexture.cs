using System;
using UnityEngine;

// Token: 0x0200041E RID: 1054
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C8D RID: 7309 RVA: 0x0014E46F File Offset: 0x0014C66F
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C8E RID: 7310 RVA: 0x0014E480 File Offset: 0x0014C680
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x040032DB RID: 13019
	public Renderer MyRenderer;

	// Token: 0x040032DC RID: 13020
	public float Offset;

	// Token: 0x040032DD RID: 13021
	public float Speed;
}
