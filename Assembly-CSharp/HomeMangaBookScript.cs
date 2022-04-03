using System;
using UnityEngine;

// Token: 0x02000320 RID: 800
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x06001894 RID: 6292 RVA: 0x000F04BC File Offset: 0x000EE6BC
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

	// Token: 0x06001895 RID: 6293 RVA: 0x000F0568 File Offset: 0x000EE768
	private void Update()
	{
		float y = (this.Manga.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x04002503 RID: 9475
	public HomeMangaScript Manga;

	// Token: 0x04002504 RID: 9476
	public float RotationSpeed;

	// Token: 0x04002505 RID: 9477
	public int ID;

	// Token: 0x04002506 RID: 9478
	public Renderer MyRenderer;

	// Token: 0x04002507 RID: 9479
	public Texture EightiesCover;

	// Token: 0x04002508 RID: 9480
	public Texture EightiesBack;

	// Token: 0x04002509 RID: 9481
	public Texture EightiesSpine;
}
