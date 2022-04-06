using System;
using UnityEngine;

// Token: 0x02000321 RID: 801
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x0600189A RID: 6298 RVA: 0x000F05BC File Offset: 0x000EE7BC
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

	// Token: 0x0600189B RID: 6299 RVA: 0x000F0668 File Offset: 0x000EE868
	private void Update()
	{
		float y = (this.Manga.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x04002506 RID: 9478
	public HomeMangaScript Manga;

	// Token: 0x04002507 RID: 9479
	public float RotationSpeed;

	// Token: 0x04002508 RID: 9480
	public int ID;

	// Token: 0x04002509 RID: 9481
	public Renderer MyRenderer;

	// Token: 0x0400250A RID: 9482
	public Texture EightiesCover;

	// Token: 0x0400250B RID: 9483
	public Texture EightiesBack;

	// Token: 0x0400250C RID: 9484
	public Texture EightiesSpine;
}
