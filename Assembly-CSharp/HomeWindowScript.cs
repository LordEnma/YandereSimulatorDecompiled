using System;
using UnityEngine;

// Token: 0x0200032D RID: 813
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x060018D4 RID: 6356 RVA: 0x000F4A54 File Offset: 0x000F2C54
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x060018D5 RID: 6357 RVA: 0x000F4AA8 File Offset: 0x000F2CA8
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x040025EF RID: 9711
	public UISprite Sprite;

	// Token: 0x040025F0 RID: 9712
	public bool Show;
}
