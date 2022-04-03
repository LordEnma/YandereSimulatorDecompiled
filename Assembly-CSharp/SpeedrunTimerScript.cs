using System;
using UnityEngine;

// Token: 0x0200043C RID: 1084
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001CF7 RID: 7415 RVA: 0x00159B63 File Offset: 0x00157D63
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001CF8 RID: 7416 RVA: 0x00159B74 File Offset: 0x00157D74
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

	// Token: 0x06001CF9 RID: 7417 RVA: 0x00159BF0 File Offset: 0x00157DF0
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x04003475 RID: 13429
	public PoliceScript Police;

	// Token: 0x04003476 RID: 13430
	public UILabel Label;

	// Token: 0x04003477 RID: 13431
	public float Timer;
}
