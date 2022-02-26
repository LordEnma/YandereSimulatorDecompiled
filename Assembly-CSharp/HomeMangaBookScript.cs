using System;
using UnityEngine;

// Token: 0x0200031F RID: 799
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x06001889 RID: 6281 RVA: 0x000EF704 File Offset: 0x000ED904
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

	// Token: 0x0600188A RID: 6282 RVA: 0x000EF7B0 File Offset: 0x000ED9B0
	private void Update()
	{
		float y = (this.Manga.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024CB RID: 9419
	public HomeMangaScript Manga;

	// Token: 0x040024CC RID: 9420
	public float RotationSpeed;

	// Token: 0x040024CD RID: 9421
	public int ID;

	// Token: 0x040024CE RID: 9422
	public Renderer MyRenderer;

	// Token: 0x040024CF RID: 9423
	public Texture EightiesCover;

	// Token: 0x040024D0 RID: 9424
	public Texture EightiesBack;

	// Token: 0x040024D1 RID: 9425
	public Texture EightiesSpine;
}
