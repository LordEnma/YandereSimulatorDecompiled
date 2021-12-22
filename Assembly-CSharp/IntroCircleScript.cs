using System;
using UnityEngine;

// Token: 0x02000337 RID: 823
public class IntroCircleScript : MonoBehaviour
{
	// Token: 0x060018D0 RID: 6352 RVA: 0x000F4A44 File Offset: 0x000F2C44
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

	// Token: 0x0400261C RID: 9756
	public UISprite Sprite;

	// Token: 0x0400261D RID: 9757
	public UILabel Label;

	// Token: 0x0400261E RID: 9758
	public float[] StartTime;

	// Token: 0x0400261F RID: 9759
	public float[] Duration;

	// Token: 0x04002620 RID: 9760
	public string[] Text;

	// Token: 0x04002621 RID: 9761
	public float CurrentTime;

	// Token: 0x04002622 RID: 9762
	public float LastTime;

	// Token: 0x04002623 RID: 9763
	public float Timer;

	// Token: 0x04002624 RID: 9764
	public int ID;
}
