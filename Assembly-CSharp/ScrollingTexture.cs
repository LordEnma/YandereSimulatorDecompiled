using System;
using UnityEngine;

// Token: 0x0200041F RID: 1055
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C94 RID: 7316 RVA: 0x0014ECAB File Offset: 0x0014CEAB
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C95 RID: 7317 RVA: 0x0014ECBC File Offset: 0x0014CEBC
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x040032EA RID: 13034
	public Renderer MyRenderer;

	// Token: 0x040032EB RID: 13035
	public float Offset;

	// Token: 0x040032EC RID: 13036
	public float Speed;
}
