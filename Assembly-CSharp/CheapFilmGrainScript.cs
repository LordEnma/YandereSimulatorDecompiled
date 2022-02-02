using System;
using UnityEngine;

// Token: 0x0200023F RID: 575
public class CheapFilmGrainScript : MonoBehaviour
{
	// Token: 0x0600123E RID: 4670 RVA: 0x0008C136 File Offset: 0x0008A336
	private void Update()
	{
		this.MyRenderer.material.mainTextureScale = new Vector2(UnityEngine.Random.Range(this.Floor, this.Ceiling), UnityEngine.Random.Range(this.Floor, this.Ceiling));
	}

	// Token: 0x040016FE RID: 5886
	public Renderer MyRenderer;

	// Token: 0x040016FF RID: 5887
	public float Floor = 100f;

	// Token: 0x04001700 RID: 5888
	public float Ceiling = 200f;
}
