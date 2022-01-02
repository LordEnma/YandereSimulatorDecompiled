using System;
using UnityEngine;

// Token: 0x0200031C RID: 796
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x06001872 RID: 6258 RVA: 0x000EE2CC File Offset: 0x000EC4CC
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

	// Token: 0x06001873 RID: 6259 RVA: 0x000EE378 File Offset: 0x000EC578
	private void Update()
	{
		float y = (this.Manga.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024A6 RID: 9382
	public HomeMangaScript Manga;

	// Token: 0x040024A7 RID: 9383
	public float RotationSpeed;

	// Token: 0x040024A8 RID: 9384
	public int ID;

	// Token: 0x040024A9 RID: 9385
	public Renderer MyRenderer;

	// Token: 0x040024AA RID: 9386
	public Texture EightiesCover;

	// Token: 0x040024AB RID: 9387
	public Texture EightiesBack;

	// Token: 0x040024AC RID: 9388
	public Texture EightiesSpine;
}
