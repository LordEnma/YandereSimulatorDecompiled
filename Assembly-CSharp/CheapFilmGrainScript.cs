using System;
using UnityEngine;

// Token: 0x02000240 RID: 576
public class CheapFilmGrainScript : MonoBehaviour
{
	// Token: 0x06001243 RID: 4675 RVA: 0x0008CF22 File Offset: 0x0008B122
	private void Update()
	{
		this.MyRenderer.material.mainTextureScale = new Vector2(UnityEngine.Random.Range(this.Floor, this.Ceiling), UnityEngine.Random.Range(this.Floor, this.Ceiling));
	}

	// Token: 0x0400171B RID: 5915
	public Renderer MyRenderer;

	// Token: 0x0400171C RID: 5916
	public float Floor = 100f;

	// Token: 0x0400171D RID: 5917
	public float Ceiling = 200f;
}
