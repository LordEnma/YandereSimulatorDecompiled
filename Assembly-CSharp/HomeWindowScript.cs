using System;
using UnityEngine;

// Token: 0x0200032C RID: 812
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x060018CB RID: 6347 RVA: 0x000F4284 File Offset: 0x000F2484
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x060018CC RID: 6348 RVA: 0x000F42D8 File Offset: 0x000F24D8
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x040025DB RID: 9691
	public UISprite Sprite;

	// Token: 0x040025DC RID: 9692
	public bool Show;
}
