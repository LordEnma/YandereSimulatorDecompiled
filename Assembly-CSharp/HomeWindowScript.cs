using System;
using UnityEngine;

// Token: 0x0200032A RID: 810
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x060018B6 RID: 6326 RVA: 0x000F33D4 File Offset: 0x000F15D4
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x060018B7 RID: 6327 RVA: 0x000F3428 File Offset: 0x000F1628
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x040025AC RID: 9644
	public UISprite Sprite;

	// Token: 0x040025AD RID: 9645
	public bool Show;
}
