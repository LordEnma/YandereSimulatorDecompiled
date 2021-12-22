using System;
using UnityEngine;

// Token: 0x0200023F RID: 575
public class CheapFilmGrainScript : MonoBehaviour
{
	// Token: 0x0600123E RID: 4670 RVA: 0x0008C076 File Offset: 0x0008A276
	private void Update()
	{
		this.MyRenderer.material.mainTextureScale = new Vector2(UnityEngine.Random.Range(this.Floor, this.Ceiling), UnityEngine.Random.Range(this.Floor, this.Ceiling));
	}

	// Token: 0x040016FC RID: 5884
	public Renderer MyRenderer;

	// Token: 0x040016FD RID: 5885
	public float Floor = 100f;

	// Token: 0x040016FE RID: 5886
	public float Ceiling = 200f;
}
