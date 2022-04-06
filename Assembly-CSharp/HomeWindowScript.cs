using System;
using UnityEngine;

// Token: 0x0200032C RID: 812
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x060018C7 RID: 6343 RVA: 0x000F3FF0 File Offset: 0x000F21F0
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x060018C8 RID: 6344 RVA: 0x000F4044 File Offset: 0x000F2244
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x040025D3 RID: 9683
	public UISprite Sprite;

	// Token: 0x040025D4 RID: 9684
	public bool Show;
}
