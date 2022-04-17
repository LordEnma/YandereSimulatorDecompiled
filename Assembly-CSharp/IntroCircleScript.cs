using System;
using UnityEngine;

// Token: 0x0200033C RID: 828
public class IntroCircleScript : MonoBehaviour
{
	// Token: 0x060018FF RID: 6399 RVA: 0x000F75F4 File Offset: 0x000F57F4
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

	// Token: 0x0400268F RID: 9871
	public UISprite Sprite;

	// Token: 0x04002690 RID: 9872
	public UILabel Label;

	// Token: 0x04002691 RID: 9873
	public float[] StartTime;

	// Token: 0x04002692 RID: 9874
	public float[] Duration;

	// Token: 0x04002693 RID: 9875
	public string[] Text;

	// Token: 0x04002694 RID: 9876
	public float CurrentTime;

	// Token: 0x04002695 RID: 9877
	public float LastTime;

	// Token: 0x04002696 RID: 9878
	public float Timer;

	// Token: 0x04002697 RID: 9879
	public int ID;
}
