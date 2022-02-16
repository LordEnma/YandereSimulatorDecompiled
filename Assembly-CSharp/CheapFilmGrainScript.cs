using System;
using UnityEngine;

// Token: 0x0200023F RID: 575
public class CheapFilmGrainScript : MonoBehaviour
{
	// Token: 0x0600123F RID: 4671 RVA: 0x0008C29A File Offset: 0x0008A49A
	private void Update()
	{
		this.MyRenderer.material.mainTextureScale = new Vector2(UnityEngine.Random.Range(this.Floor, this.Ceiling), UnityEngine.Random.Range(this.Floor, this.Ceiling));
	}

	// Token: 0x04001702 RID: 5890
	public Renderer MyRenderer;

	// Token: 0x04001703 RID: 5891
	public float Floor = 100f;

	// Token: 0x04001704 RID: 5892
	public float Ceiling = 200f;
}
