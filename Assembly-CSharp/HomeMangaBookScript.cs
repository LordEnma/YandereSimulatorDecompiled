using System;
using UnityEngine;

// Token: 0x02000321 RID: 801
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x060018A2 RID: 6306 RVA: 0x000F0D20 File Offset: 0x000EEF20
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

	// Token: 0x060018A3 RID: 6307 RVA: 0x000F0DCC File Offset: 0x000EEFCC
	private void Update()
	{
		float y = (this.Manga.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x04002517 RID: 9495
	public HomeMangaScript Manga;

	// Token: 0x04002518 RID: 9496
	public float RotationSpeed;

	// Token: 0x04002519 RID: 9497
	public int ID;

	// Token: 0x0400251A RID: 9498
	public Renderer MyRenderer;

	// Token: 0x0400251B RID: 9499
	public Texture EightiesCover;

	// Token: 0x0400251C RID: 9500
	public Texture EightiesBack;

	// Token: 0x0400251D RID: 9501
	public Texture EightiesSpine;
}
