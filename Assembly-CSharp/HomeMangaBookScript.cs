using System;
using UnityEngine;

// Token: 0x0200031D RID: 797
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x06001879 RID: 6265 RVA: 0x000EECA8 File Offset: 0x000ECEA8
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

	// Token: 0x0600187A RID: 6266 RVA: 0x000EED54 File Offset: 0x000ECF54
	private void Update()
	{
		float y = (this.Manga.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024B6 RID: 9398
	public HomeMangaScript Manga;

	// Token: 0x040024B7 RID: 9399
	public float RotationSpeed;

	// Token: 0x040024B8 RID: 9400
	public int ID;

	// Token: 0x040024B9 RID: 9401
	public Renderer MyRenderer;

	// Token: 0x040024BA RID: 9402
	public Texture EightiesCover;

	// Token: 0x040024BB RID: 9403
	public Texture EightiesBack;

	// Token: 0x040024BC RID: 9404
	public Texture EightiesSpine;
}
