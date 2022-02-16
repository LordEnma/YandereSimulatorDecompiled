using System;
using UnityEngine;

// Token: 0x02000437 RID: 1079
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001CD5 RID: 7381 RVA: 0x001570CB File Offset: 0x001552CB
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001CD6 RID: 7382 RVA: 0x001570DC File Offset: 0x001552DC
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

	// Token: 0x06001CD7 RID: 7383 RVA: 0x00157158 File Offset: 0x00155358
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x040033FE RID: 13310
	public PoliceScript Police;

	// Token: 0x040033FF RID: 13311
	public UILabel Label;

	// Token: 0x04003400 RID: 13312
	public float Timer;
}
