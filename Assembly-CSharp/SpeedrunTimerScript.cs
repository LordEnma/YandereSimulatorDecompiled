using System;
using UnityEngine;

// Token: 0x02000436 RID: 1078
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001CCC RID: 7372 RVA: 0x00156C2B File Offset: 0x00154E2B
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001CCD RID: 7373 RVA: 0x00156C3C File Offset: 0x00154E3C
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

	// Token: 0x06001CCE RID: 7374 RVA: 0x00156CB8 File Offset: 0x00154EB8
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x040033F5 RID: 13301
	public PoliceScript Police;

	// Token: 0x040033F6 RID: 13302
	public UILabel Label;

	// Token: 0x040033F7 RID: 13303
	public float Timer;
}
