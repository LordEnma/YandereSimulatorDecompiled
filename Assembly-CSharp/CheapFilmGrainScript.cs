using System;
using UnityEngine;

// Token: 0x0200023F RID: 575
public class CheapFilmGrainScript : MonoBehaviour
{
	// Token: 0x06001241 RID: 4673 RVA: 0x0008CBCA File Offset: 0x0008ADCA
	private void Update()
	{
		this.MyRenderer.material.mainTextureScale = new Vector2(UnityEngine.Random.Range(this.Floor, this.Ceiling), UnityEngine.Random.Range(this.Floor, this.Ceiling));
	}

	// Token: 0x04001715 RID: 5909
	public Renderer MyRenderer;

	// Token: 0x04001716 RID: 5910
	public float Floor = 100f;

	// Token: 0x04001717 RID: 5911
	public float Ceiling = 200f;
}
