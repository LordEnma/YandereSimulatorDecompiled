using System;
using UnityEngine;

// Token: 0x0200023F RID: 575
public class CheapFilmGrainScript : MonoBehaviour
{
	// Token: 0x06001241 RID: 4673 RVA: 0x0008C95A File Offset: 0x0008AB5A
	private void Update()
	{
		this.MyRenderer.material.mainTextureScale = new Vector2(UnityEngine.Random.Range(this.Floor, this.Ceiling), UnityEngine.Random.Range(this.Floor, this.Ceiling));
	}

	// Token: 0x04001712 RID: 5906
	public Renderer MyRenderer;

	// Token: 0x04001713 RID: 5907
	public float Floor = 100f;

	// Token: 0x04001714 RID: 5908
	public float Ceiling = 200f;
}
