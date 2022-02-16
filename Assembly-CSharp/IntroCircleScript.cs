using System;
using UnityEngine;

// Token: 0x02000339 RID: 825
public class IntroCircleScript : MonoBehaviour
{
	// Token: 0x060018E0 RID: 6368 RVA: 0x000F5910 File Offset: 0x000F3B10
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.ID < this.StartTime.Length && this.Timer > this.StartTime[this.ID])
		{
			this.CurrentTime = this.Duration[this.ID];
			this.LastTime = this.Duration[this.ID];
			this.Label.text = this.Text[this.ID];
			this.ID++;
		}
		if (this.CurrentTime > 0f)
		{
			this.CurrentTime -= Time.deltaTime;
		}
		if (this.Timer > 1f)
		{
			this.Sprite.fillAmount = this.CurrentTime / this.LastTime;
			if (this.Sprite.fillAmount == 0f)
			{
				this.Label.text = string.Empty;
			}
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.CurrentTime -= 5f;
			this.Timer += 5f;
		}
	}

	// Token: 0x04002637 RID: 9783
	public UISprite Sprite;

	// Token: 0x04002638 RID: 9784
	public UILabel Label;

	// Token: 0x04002639 RID: 9785
	public float[] StartTime;

	// Token: 0x0400263A RID: 9786
	public float[] Duration;

	// Token: 0x0400263B RID: 9787
	public string[] Text;

	// Token: 0x0400263C RID: 9788
	public float CurrentTime;

	// Token: 0x0400263D RID: 9789
	public float LastTime;

	// Token: 0x0400263E RID: 9790
	public float Timer;

	// Token: 0x0400263F RID: 9791
	public int ID;
}
