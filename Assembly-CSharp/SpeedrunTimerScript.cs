using System;
using UnityEngine;

// Token: 0x02000439 RID: 1081
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001CED RID: 7405 RVA: 0x00159007 File Offset: 0x00157207
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001CEE RID: 7406 RVA: 0x00159018 File Offset: 0x00157218
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

	// Token: 0x06001CEF RID: 7407 RVA: 0x00159094 File Offset: 0x00157294
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x04003459 RID: 13401
	public PoliceScript Police;

	// Token: 0x0400345A RID: 13402
	public UILabel Label;

	// Token: 0x0400345B RID: 13403
	public float Timer;
}
