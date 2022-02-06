using System;
using UnityEngine;

// Token: 0x02000338 RID: 824
public class IntroCircleScript : MonoBehaviour
{
	// Token: 0x060018D9 RID: 6361 RVA: 0x000F576C File Offset: 0x000F396C
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

	// Token: 0x04002631 RID: 9777
	public UISprite Sprite;

	// Token: 0x04002632 RID: 9778
	public UILabel Label;

	// Token: 0x04002633 RID: 9779
	public float[] StartTime;

	// Token: 0x04002634 RID: 9780
	public float[] Duration;

	// Token: 0x04002635 RID: 9781
	public string[] Text;

	// Token: 0x04002636 RID: 9782
	public float CurrentTime;

	// Token: 0x04002637 RID: 9783
	public float LastTime;

	// Token: 0x04002638 RID: 9784
	public float Timer;

	// Token: 0x04002639 RID: 9785
	public int ID;
}
