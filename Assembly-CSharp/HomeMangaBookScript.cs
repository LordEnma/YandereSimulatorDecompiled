using System;
using UnityEngine;

// Token: 0x0200031E RID: 798
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x06001880 RID: 6272 RVA: 0x000EEE20 File Offset: 0x000ED020
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

	// Token: 0x06001881 RID: 6273 RVA: 0x000EEECC File Offset: 0x000ED0CC
	private void Update()
	{
		float y = (this.Manga.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024BC RID: 9404
	public HomeMangaScript Manga;

	// Token: 0x040024BD RID: 9405
	public float RotationSpeed;

	// Token: 0x040024BE RID: 9406
	public int ID;

	// Token: 0x040024BF RID: 9407
	public Renderer MyRenderer;

	// Token: 0x040024C0 RID: 9408
	public Texture EightiesCover;

	// Token: 0x040024C1 RID: 9409
	public Texture EightiesBack;

	// Token: 0x040024C2 RID: 9410
	public Texture EightiesSpine;
}
