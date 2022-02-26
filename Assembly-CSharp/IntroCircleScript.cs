using System;
using UnityEngine;

// Token: 0x0200033A RID: 826
public class IntroCircleScript : MonoBehaviour
{
	// Token: 0x060018E9 RID: 6377 RVA: 0x000F6214 File Offset: 0x000F4414
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

	// Token: 0x04002646 RID: 9798
	public UISprite Sprite;

	// Token: 0x04002647 RID: 9799
	public UILabel Label;

	// Token: 0x04002648 RID: 9800
	public float[] StartTime;

	// Token: 0x04002649 RID: 9801
	public float[] Duration;

	// Token: 0x0400264A RID: 9802
	public string[] Text;

	// Token: 0x0400264B RID: 9803
	public float CurrentTime;

	// Token: 0x0400264C RID: 9804
	public float LastTime;

	// Token: 0x0400264D RID: 9805
	public float Timer;

	// Token: 0x0400264E RID: 9806
	public int ID;
}
