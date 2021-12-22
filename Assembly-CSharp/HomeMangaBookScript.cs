using System;
using UnityEngine;

// Token: 0x0200031C RID: 796
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x06001870 RID: 6256 RVA: 0x000EDFE8 File Offset: 0x000EC1E8
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

	// Token: 0x06001871 RID: 6257 RVA: 0x000EE094 File Offset: 0x000EC294
	private void Update()
	{
		float y = (this.Manga.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024A2 RID: 9378
	public HomeMangaScript Manga;

	// Token: 0x040024A3 RID: 9379
	public float RotationSpeed;

	// Token: 0x040024A4 RID: 9380
	public int ID;

	// Token: 0x040024A5 RID: 9381
	public Renderer MyRenderer;

	// Token: 0x040024A6 RID: 9382
	public Texture EightiesCover;

	// Token: 0x040024A7 RID: 9383
	public Texture EightiesBack;

	// Token: 0x040024A8 RID: 9384
	public Texture EightiesSpine;
}
