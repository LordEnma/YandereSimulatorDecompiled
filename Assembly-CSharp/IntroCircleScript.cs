using System;
using UnityEngine;

// Token: 0x02000338 RID: 824
public class IntroCircleScript : MonoBehaviour
{
	// Token: 0x060018D6 RID: 6358 RVA: 0x000F5030 File Offset: 0x000F3230
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

	// Token: 0x04002624 RID: 9764
	public UISprite Sprite;

	// Token: 0x04002625 RID: 9765
	public UILabel Label;

	// Token: 0x04002626 RID: 9766
	public float[] StartTime;

	// Token: 0x04002627 RID: 9767
	public float[] Duration;

	// Token: 0x04002628 RID: 9768
	public string[] Text;

	// Token: 0x04002629 RID: 9769
	public float CurrentTime;

	// Token: 0x0400262A RID: 9770
	public float LastTime;

	// Token: 0x0400262B RID: 9771
	public float Timer;

	// Token: 0x0400262C RID: 9772
	public int ID;
}
