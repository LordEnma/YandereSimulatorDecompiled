using System;
using UnityEngine;

// Token: 0x02000338 RID: 824
public class IntroCircleScript : MonoBehaviour
{
	// Token: 0x060018D7 RID: 6359 RVA: 0x000F5670 File Offset: 0x000F3870
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

	// Token: 0x0400262E RID: 9774
	public UISprite Sprite;

	// Token: 0x0400262F RID: 9775
	public UILabel Label;

	// Token: 0x04002630 RID: 9776
	public float[] StartTime;

	// Token: 0x04002631 RID: 9777
	public float[] Duration;

	// Token: 0x04002632 RID: 9778
	public string[] Text;

	// Token: 0x04002633 RID: 9779
	public float CurrentTime;

	// Token: 0x04002634 RID: 9780
	public float LastTime;

	// Token: 0x04002635 RID: 9781
	public float Timer;

	// Token: 0x04002636 RID: 9782
	public int ID;
}
