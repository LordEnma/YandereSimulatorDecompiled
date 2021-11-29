using System;
using UnityEngine;

// Token: 0x0200031B RID: 795
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x06001869 RID: 6249 RVA: 0x000ED828 File Offset: 0x000EBA28
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

	// Token: 0x0600186A RID: 6250 RVA: 0x000ED8D4 File Offset: 0x000EBAD4
	private void Update()
	{
		float y = (this.Manga.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x04002482 RID: 9346
	public HomeMangaScript Manga;

	// Token: 0x04002483 RID: 9347
	public float RotationSpeed;

	// Token: 0x04002484 RID: 9348
	public int ID;

	// Token: 0x04002485 RID: 9349
	public Renderer MyRenderer;

	// Token: 0x04002486 RID: 9350
	public Texture EightiesCover;

	// Token: 0x04002487 RID: 9351
	public Texture EightiesBack;

	// Token: 0x04002488 RID: 9352
	public Texture EightiesSpine;
}
