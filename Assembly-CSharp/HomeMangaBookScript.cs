using System;
using UnityEngine;

// Token: 0x02000321 RID: 801
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x0600189E RID: 6302 RVA: 0x000F0850 File Offset: 0x000EEA50
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

	// Token: 0x0600189F RID: 6303 RVA: 0x000F08FC File Offset: 0x000EEAFC
	private void Update()
	{
		float y = (this.Manga.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x0400250E RID: 9486
	public HomeMangaScript Manga;

	// Token: 0x0400250F RID: 9487
	public float RotationSpeed;

	// Token: 0x04002510 RID: 9488
	public int ID;

	// Token: 0x04002511 RID: 9489
	public Renderer MyRenderer;

	// Token: 0x04002512 RID: 9490
	public Texture EightiesCover;

	// Token: 0x04002513 RID: 9491
	public Texture EightiesBack;

	// Token: 0x04002514 RID: 9492
	public Texture EightiesSpine;
}
