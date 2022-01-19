using System;
using UnityEngine;

// Token: 0x02000417 RID: 1047
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C57 RID: 7255 RVA: 0x0014AA2F File Offset: 0x00148C2F
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C58 RID: 7256 RVA: 0x0014AA40 File Offset: 0x00148C40
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x04003247 RID: 12871
	public Renderer MyRenderer;

	// Token: 0x04003248 RID: 12872
	public float Offset;

	// Token: 0x04003249 RID: 12873
	public float Speed;
}
