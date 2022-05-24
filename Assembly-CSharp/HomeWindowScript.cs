using System;
using UnityEngine;

// Token: 0x0200032D RID: 813
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x060018D4 RID: 6356 RVA: 0x000F4BD0 File Offset: 0x000F2DD0
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x060018D5 RID: 6357 RVA: 0x000F4C24 File Offset: 0x000F2E24
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x040025F2 RID: 9714
	public UISprite Sprite;

	// Token: 0x040025F3 RID: 9715
	public bool Show;
}
