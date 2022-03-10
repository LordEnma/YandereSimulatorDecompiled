using System;
using UnityEngine;

// Token: 0x0200023F RID: 575
public class CheapFilmGrainScript : MonoBehaviour
{
	// Token: 0x0600123F RID: 4671 RVA: 0x0008C4F6 File Offset: 0x0008A6F6
	private void Update()
	{
		this.MyRenderer.material.mainTextureScale = new Vector2(UnityEngine.Random.Range(this.Floor, this.Ceiling), UnityEngine.Random.Range(this.Floor, this.Ceiling));
	}

	// Token: 0x0400170B RID: 5899
	public Renderer MyRenderer;

	// Token: 0x0400170C RID: 5900
	public float Floor = 100f;

	// Token: 0x0400170D RID: 5901
	public float Ceiling = 200f;
}
