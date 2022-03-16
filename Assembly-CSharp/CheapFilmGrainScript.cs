using System;
using UnityEngine;

// Token: 0x0200023F RID: 575
public class CheapFilmGrainScript : MonoBehaviour
{
	// Token: 0x06001241 RID: 4673 RVA: 0x0008C8BE File Offset: 0x0008AABE
	private void Update()
	{
		this.MyRenderer.material.mainTextureScale = new Vector2(UnityEngine.Random.Range(this.Floor, this.Ceiling), UnityEngine.Random.Range(this.Floor, this.Ceiling));
	}

	// Token: 0x04001711 RID: 5905
	public Renderer MyRenderer;

	// Token: 0x04001712 RID: 5906
	public float Floor = 100f;

	// Token: 0x04001713 RID: 5907
	public float Ceiling = 200f;
}
