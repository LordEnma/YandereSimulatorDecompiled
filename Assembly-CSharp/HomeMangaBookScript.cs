using System;
using UnityEngine;

// Token: 0x0200031F RID: 799
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x0600188E RID: 6286 RVA: 0x000EFEFC File Offset: 0x000EE0FC
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

	// Token: 0x0600188F RID: 6287 RVA: 0x000EFFA8 File Offset: 0x000EE1A8
	private void Update()
	{
		float y = (this.Manga.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024F0 RID: 9456
	public HomeMangaScript Manga;

	// Token: 0x040024F1 RID: 9457
	public float RotationSpeed;

	// Token: 0x040024F2 RID: 9458
	public int ID;

	// Token: 0x040024F3 RID: 9459
	public Renderer MyRenderer;

	// Token: 0x040024F4 RID: 9460
	public Texture EightiesCover;

	// Token: 0x040024F5 RID: 9461
	public Texture EightiesBack;

	// Token: 0x040024F6 RID: 9462
	public Texture EightiesSpine;
}
