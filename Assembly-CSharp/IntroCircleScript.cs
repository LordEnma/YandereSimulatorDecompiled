using System;
using UnityEngine;

// Token: 0x0200033D RID: 829
public class IntroCircleScript : MonoBehaviour
{
	// Token: 0x06001908 RID: 6408 RVA: 0x000F7DC8 File Offset: 0x000F5FC8
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

	// Token: 0x040026A4 RID: 9892
	public UISprite Sprite;

	// Token: 0x040026A5 RID: 9893
	public UILabel Label;

	// Token: 0x040026A6 RID: 9894
	public float[] StartTime;

	// Token: 0x040026A7 RID: 9895
	public float[] Duration;

	// Token: 0x040026A8 RID: 9896
	public string[] Text;

	// Token: 0x040026A9 RID: 9897
	public float CurrentTime;

	// Token: 0x040026AA RID: 9898
	public float LastTime;

	// Token: 0x040026AB RID: 9899
	public float Timer;

	// Token: 0x040026AC RID: 9900
	public int ID;
}
