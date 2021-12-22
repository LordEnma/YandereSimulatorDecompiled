using System;
using UnityEngine;

// Token: 0x02000414 RID: 1044
public class ScrollingTexture : MonoBehaviour
{
	// Token: 0x06001C4C RID: 7244 RVA: 0x00148BAB File Offset: 0x00146DAB
	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06001C4D RID: 7245 RVA: 0x00148BBC File Offset: 0x00146DBC
	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	// Token: 0x04003235 RID: 12853
	public Renderer MyRenderer;

	// Token: 0x04003236 RID: 12854
	public float Offset;

	// Token: 0x04003237 RID: 12855
	public float Speed;
}
