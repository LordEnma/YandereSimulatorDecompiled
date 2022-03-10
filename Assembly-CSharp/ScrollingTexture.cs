using System;
using UnityEngine;

// Token: 0x02000419 RID: 1049
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C6C RID: 7276 RVA: 0x0014C3B3 File Offset: 0x0014A5B3
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C6D RID: 7277 RVA: 0x0014C3C4 File Offset: 0x0014A5C4
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x0400327D RID: 12925
	public Renderer MyRenderer;

	// Token: 0x0400327E RID: 12926
	public float Offset;

	// Token: 0x0400327F RID: 12927
	public float Speed;
}
