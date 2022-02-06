using System;
using UnityEngine;

// Token: 0x0200023F RID: 575
public class CheapFilmGrainScript : MonoBehaviour
{
	// Token: 0x0600123E RID: 4670 RVA: 0x0008C1CE File Offset: 0x0008A3CE
	private void Update()
	{
		this.MyRenderer.material.mainTextureScale = new Vector2(UnityEngine.Random.Range(this.Floor, this.Ceiling), UnityEngine.Random.Range(this.Floor, this.Ceiling));
	}

	// Token: 0x04001701 RID: 5889
	public Renderer MyRenderer;

	// Token: 0x04001702 RID: 5890
	public float Floor = 100f;

	// Token: 0x04001703 RID: 5891
	public float Ceiling = 200f;
}
