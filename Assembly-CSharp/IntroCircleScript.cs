using System;
using UnityEngine;

// Token: 0x0200033B RID: 827
public class IntroCircleScript : MonoBehaviour
{
	// Token: 0x060018F5 RID: 6389 RVA: 0x000F7260 File Offset: 0x000F5460
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

	// Token: 0x04002684 RID: 9860
	public UISprite Sprite;

	// Token: 0x04002685 RID: 9861
	public UILabel Label;

	// Token: 0x04002686 RID: 9862
	public float[] StartTime;

	// Token: 0x04002687 RID: 9863
	public float[] Duration;

	// Token: 0x04002688 RID: 9864
	public string[] Text;

	// Token: 0x04002689 RID: 9865
	public float CurrentTime;

	// Token: 0x0400268A RID: 9866
	public float LastTime;

	// Token: 0x0400268B RID: 9867
	public float Timer;

	// Token: 0x0400268C RID: 9868
	public int ID;
}
