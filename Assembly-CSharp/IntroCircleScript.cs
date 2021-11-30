using System;
using UnityEngine;

// Token: 0x02000336 RID: 822
public class IntroCircleScript : MonoBehaviour
{
	// Token: 0x060018C9 RID: 6345 RVA: 0x000F4254 File Offset: 0x000F2454
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

	// Token: 0x040025FC RID: 9724
	public UISprite Sprite;

	// Token: 0x040025FD RID: 9725
	public UILabel Label;

	// Token: 0x040025FE RID: 9726
	public float[] StartTime;

	// Token: 0x040025FF RID: 9727
	public float[] Duration;

	// Token: 0x04002600 RID: 9728
	public string[] Text;

	// Token: 0x04002601 RID: 9729
	public float CurrentTime;

	// Token: 0x04002602 RID: 9730
	public float LastTime;

	// Token: 0x04002603 RID: 9731
	public float Timer;

	// Token: 0x04002604 RID: 9732
	public int ID;
}
