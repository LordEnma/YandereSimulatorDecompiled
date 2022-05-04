using System;
using UnityEngine;

// Token: 0x0200033C RID: 828
public class IntroCircleScript : MonoBehaviour
{
	// Token: 0x06001903 RID: 6403 RVA: 0x000F7AC4 File Offset: 0x000F5CC4
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

	// Token: 0x04002698 RID: 9880
	public UISprite Sprite;

	// Token: 0x04002699 RID: 9881
	public UILabel Label;

	// Token: 0x0400269A RID: 9882
	public float[] StartTime;

	// Token: 0x0400269B RID: 9883
	public float[] Duration;

	// Token: 0x0400269C RID: 9884
	public string[] Text;

	// Token: 0x0400269D RID: 9885
	public float CurrentTime;

	// Token: 0x0400269E RID: 9886
	public float LastTime;

	// Token: 0x0400269F RID: 9887
	public float Timer;

	// Token: 0x040026A0 RID: 9888
	public int ID;
}
