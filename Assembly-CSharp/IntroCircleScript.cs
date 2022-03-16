using System;
using UnityEngine;

// Token: 0x0200033A RID: 826
public class IntroCircleScript : MonoBehaviour
{
	// Token: 0x060018EF RID: 6383 RVA: 0x000F6BF8 File Offset: 0x000F4DF8
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

	// Token: 0x04002671 RID: 9841
	public UISprite Sprite;

	// Token: 0x04002672 RID: 9842
	public UILabel Label;

	// Token: 0x04002673 RID: 9843
	public float[] StartTime;

	// Token: 0x04002674 RID: 9844
	public float[] Duration;

	// Token: 0x04002675 RID: 9845
	public string[] Text;

	// Token: 0x04002676 RID: 9846
	public float CurrentTime;

	// Token: 0x04002677 RID: 9847
	public float LastTime;

	// Token: 0x04002678 RID: 9848
	public float Timer;

	// Token: 0x04002679 RID: 9849
	public int ID;
}
