using System;
using UnityEngine;

// Token: 0x0200041D RID: 1053
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C83 RID: 7299 RVA: 0x0014DD7B File Offset: 0x0014BF7B
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C84 RID: 7300 RVA: 0x0014DD8C File Offset: 0x0014BF8C
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x040032CD RID: 13005
	public Renderer MyRenderer;

	// Token: 0x040032CE RID: 13006
	public float Offset;

	// Token: 0x040032CF RID: 13007
	public float Speed;
}
