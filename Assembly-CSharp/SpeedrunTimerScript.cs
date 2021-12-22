using System;
using UnityEngine;

// Token: 0x02000433 RID: 1075
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001CC0 RID: 7360 RVA: 0x00154897 File Offset: 0x00152A97
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001CC1 RID: 7361 RVA: 0x001548A8 File Offset: 0x00152AA8
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

	// Token: 0x06001CC2 RID: 7362 RVA: 0x00154924 File Offset: 0x00152B24
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x040033DC RID: 13276
	public PoliceScript Police;

	// Token: 0x040033DD RID: 13277
	public UILabel Label;

	// Token: 0x040033DE RID: 13278
	public float Timer;
}
