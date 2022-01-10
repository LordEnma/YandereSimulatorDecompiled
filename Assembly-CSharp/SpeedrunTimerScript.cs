using System;
using UnityEngine;

// Token: 0x02000435 RID: 1077
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001CC9 RID: 7369 RVA: 0x00154FDF File Offset: 0x001531DF
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001CCA RID: 7370 RVA: 0x00154FF0 File Offset: 0x001531F0
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

	// Token: 0x06001CCB RID: 7371 RVA: 0x0015506C File Offset: 0x0015326C
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x040033E9 RID: 13289
	public PoliceScript Police;

	// Token: 0x040033EA RID: 13290
	public UILabel Label;

	// Token: 0x040033EB RID: 13291
	public float Timer;
}
