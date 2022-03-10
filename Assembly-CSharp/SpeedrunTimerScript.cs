using System;
using UnityEngine;

// Token: 0x02000438 RID: 1080
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001CE0 RID: 7392 RVA: 0x001580FB File Offset: 0x001562FB
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001CE1 RID: 7393 RVA: 0x0015810C File Offset: 0x0015630C
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

	// Token: 0x06001CE2 RID: 7394 RVA: 0x00158188 File Offset: 0x00156388
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x04003424 RID: 13348
	public PoliceScript Police;

	// Token: 0x04003425 RID: 13349
	public UILabel Label;

	// Token: 0x04003426 RID: 13350
	public float Timer;
}
