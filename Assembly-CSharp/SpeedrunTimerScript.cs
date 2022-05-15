using System;
using UnityEngine;

// Token: 0x0200043F RID: 1087
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001D0F RID: 7439 RVA: 0x0015B74F File Offset: 0x0015994F
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001D10 RID: 7440 RVA: 0x0015B760 File Offset: 0x00159960
	private void Update()
	{
		if (!this.Police.FadeOut)
		{
			this.Timer += Time.deltaTime;
			if (this.Label.enabled)
			{
				this.Label.text = (this.FormatTime(this.Timer) ?? "");
			}
			if (Input.GetKeyDown(KeyCode.Delete))
			{
				this.Label.enabled = !this.Label.enabled;
			}
		}
	}

	// Token: 0x06001D11 RID: 7441 RVA: 0x0015B7DC File Offset: 0x001599DC
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x040034A7 RID: 13479
	public PoliceScript Police;

	// Token: 0x040034A8 RID: 13480
	public UILabel Label;

	// Token: 0x040034A9 RID: 13481
	public float Timer;
}
