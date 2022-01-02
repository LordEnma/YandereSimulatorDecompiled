using System;
using UnityEngine;

// Token: 0x02000414 RID: 1044
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C4E RID: 7246 RVA: 0x00148FB3 File Offset: 0x001471B3
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C4F RID: 7247 RVA: 0x00148FC4 File Offset: 0x001471C4
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x0400323C RID: 12860
	public Renderer MyRenderer;

	// Token: 0x0400323D RID: 12861
	public float Offset;

	// Token: 0x0400323E RID: 12862
	public float Speed;
}
