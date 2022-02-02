using System;
using UnityEngine;

// Token: 0x0200031D RID: 797
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x06001877 RID: 6263 RVA: 0x000EEB04 File Offset: 0x000ECD04
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

	// Token: 0x06001878 RID: 6264 RVA: 0x000EEBB0 File Offset: 0x000ECDB0
	private void Update()
	{
		float y = (this.Manga.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024B2 RID: 9394
	public HomeMangaScript Manga;

	// Token: 0x040024B3 RID: 9395
	public float RotationSpeed;

	// Token: 0x040024B4 RID: 9396
	public int ID;

	// Token: 0x040024B5 RID: 9397
	public Renderer MyRenderer;

	// Token: 0x040024B6 RID: 9398
	public Texture EightiesCover;

	// Token: 0x040024B7 RID: 9399
	public Texture EightiesBack;

	// Token: 0x040024B8 RID: 9400
	public Texture EightiesSpine;
}
