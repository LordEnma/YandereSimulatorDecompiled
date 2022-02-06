using System;
using UnityEngine;

// Token: 0x02000417 RID: 1047
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C5A RID: 7258 RVA: 0x0014B0FF File Offset: 0x001492FF
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C5B RID: 7259 RVA: 0x0014B110 File Offset: 0x00149310
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x04003251 RID: 12881
	public Renderer MyRenderer;

	// Token: 0x04003252 RID: 12882
	public float Offset;

	// Token: 0x04003253 RID: 12883
	public float Speed;
}
