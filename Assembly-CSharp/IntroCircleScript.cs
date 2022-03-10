using System;
using UnityEngine;

// Token: 0x0200033A RID: 826
public class IntroCircleScript : MonoBehaviour
{
	// Token: 0x060018E9 RID: 6377 RVA: 0x000F6554 File Offset: 0x000F4754
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

	// Token: 0x0400265B RID: 9819
	public UISprite Sprite;

	// Token: 0x0400265C RID: 9820
	public UILabel Label;

	// Token: 0x0400265D RID: 9821
	public float[] StartTime;

	// Token: 0x0400265E RID: 9822
	public float[] Duration;

	// Token: 0x0400265F RID: 9823
	public string[] Text;

	// Token: 0x04002660 RID: 9824
	public float CurrentTime;

	// Token: 0x04002661 RID: 9825
	public float LastTime;

	// Token: 0x04002662 RID: 9826
	public float Timer;

	// Token: 0x04002663 RID: 9827
	public int ID;
}
