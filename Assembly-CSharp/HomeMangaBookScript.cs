using System;
using UnityEngine;

// Token: 0x0200031F RID: 799
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x06001889 RID: 6281 RVA: 0x000EFA3C File Offset: 0x000EDC3C
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

	// Token: 0x0600188A RID: 6282 RVA: 0x000EFAE8 File Offset: 0x000EDCE8
	private void Update()
	{
		float y = (this.Manga.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024DF RID: 9439
	public HomeMangaScript Manga;

	// Token: 0x040024E0 RID: 9440
	public float RotationSpeed;

	// Token: 0x040024E1 RID: 9441
	public int ID;

	// Token: 0x040024E2 RID: 9442
	public Renderer MyRenderer;

	// Token: 0x040024E3 RID: 9443
	public Texture EightiesCover;

	// Token: 0x040024E4 RID: 9444
	public Texture EightiesBack;

	// Token: 0x040024E5 RID: 9445
	public Texture EightiesSpine;
}
