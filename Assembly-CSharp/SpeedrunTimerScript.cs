using System;
using UnityEngine;

// Token: 0x0200043D RID: 1085
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001CFE RID: 7422 RVA: 0x00159E83 File Offset: 0x00158083
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001CFF RID: 7423 RVA: 0x00159E94 File Offset: 0x00158094
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

	// Token: 0x06001D00 RID: 7424 RVA: 0x00159F10 File Offset: 0x00158110
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x04003478 RID: 13432
	public PoliceScript Police;

	// Token: 0x04003479 RID: 13433
	public UILabel Label;

	// Token: 0x0400347A RID: 13434
	public float Timer;
}
