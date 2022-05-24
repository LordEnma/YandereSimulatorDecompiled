using System;
using UnityEngine;

// Token: 0x02000322 RID: 802
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x060018A7 RID: 6311 RVA: 0x000F119C File Offset: 0x000EF39C
	private void Start()
	{
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
		if (this.MyRenderer != null && this.ID < 10 && GameGlobals.Eighties)
		{
			this.MyRenderer.materials[0].mainTexture = this.EightiesCover;
			this.MyRenderer.materials[1].mainTexture = this.EightiesBack;
			this.MyRenderer.materials[2].mainTexture = this.EightiesSpine;
		}
	}

	// Token: 0x060018A8 RID: 6312 RVA: 0x000F1248 File Offset: 0x000EF448
	private void Update()
	{
		float y = (this.Manga.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x04002523 RID: 9507
	public HomeMangaScript Manga;

	// Token: 0x04002524 RID: 9508
	public float RotationSpeed;

	// Token: 0x04002525 RID: 9509
	public int ID;

	// Token: 0x04002526 RID: 9510
	public Renderer MyRenderer;

	// Token: 0x04002527 RID: 9511
	public Texture EightiesCover;

	// Token: 0x04002528 RID: 9512
	public Texture EightiesBack;

	// Token: 0x04002529 RID: 9513
	public Texture EightiesSpine;
}
