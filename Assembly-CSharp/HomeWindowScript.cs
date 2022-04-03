using System;
using UnityEngine;

// Token: 0x0200032B RID: 811
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x060018C1 RID: 6337 RVA: 0x000F3EF0 File Offset: 0x000F20F0
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x060018C2 RID: 6338 RVA: 0x000F3F44 File Offset: 0x000F2144
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x040025D0 RID: 9680
	public UISprite Sprite;

	// Token: 0x040025D1 RID: 9681
	public bool Show;
}
