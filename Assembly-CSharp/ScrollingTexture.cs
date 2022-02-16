using System;
using UnityEngine;

// Token: 0x02000418 RID: 1048
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C61 RID: 7265 RVA: 0x0014B3FF File Offset: 0x001495FF
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C62 RID: 7266 RVA: 0x0014B410 File Offset: 0x00149610
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x04003257 RID: 12887
	public Renderer MyRenderer;

	// Token: 0x04003258 RID: 12888
	public float Offset;

	// Token: 0x04003259 RID: 12889
	public float Speed;
}
