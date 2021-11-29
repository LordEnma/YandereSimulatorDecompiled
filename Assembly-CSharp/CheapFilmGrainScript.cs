using System;
using UnityEngine;

// Token: 0x0200023E RID: 574
public class CheapFilmGrainScript : MonoBehaviour
{
	// Token: 0x0600123B RID: 4667 RVA: 0x0008BF52 File Offset: 0x0008A152
	private void Update()
	{
		this.MyRenderer.material.mainTextureScale = new Vector2(UnityEngine.Random.Range(this.Floor, this.Ceiling), UnityEngine.Random.Range(this.Floor, this.Ceiling));
	}

	// Token: 0x040016FA RID: 5882
	public Renderer MyRenderer;

	// Token: 0x040016FB RID: 5883
	public float Floor = 100f;

	// Token: 0x040016FC RID: 5884
	public float Ceiling = 200f;
}
