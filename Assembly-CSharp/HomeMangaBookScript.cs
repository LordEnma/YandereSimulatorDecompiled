using System;
using UnityEngine;

// Token: 0x0200031D RID: 797
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x06001876 RID: 6262 RVA: 0x000EE6F0 File Offset: 0x000EC8F0
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

	// Token: 0x06001877 RID: 6263 RVA: 0x000EE79C File Offset: 0x000EC99C
	private void Update()
	{
		float y = (this.Manga.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024AD RID: 9389
	public HomeMangaScript Manga;

	// Token: 0x040024AE RID: 9390
	public float RotationSpeed;

	// Token: 0x040024AF RID: 9391
	public int ID;

	// Token: 0x040024B0 RID: 9392
	public Renderer MyRenderer;

	// Token: 0x040024B1 RID: 9393
	public Texture EightiesCover;

	// Token: 0x040024B2 RID: 9394
	public Texture EightiesBack;

	// Token: 0x040024B3 RID: 9395
	public Texture EightiesSpine;
}
