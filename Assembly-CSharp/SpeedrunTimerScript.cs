using System;
using UnityEngine;

// Token: 0x0200043F RID: 1087
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001D10 RID: 7440 RVA: 0x0015BA0B File Offset: 0x00159C0B
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001D11 RID: 7441 RVA: 0x0015BA1C File Offset: 0x00159C1C
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

	// Token: 0x06001D12 RID: 7442 RVA: 0x0015BA98 File Offset: 0x00159C98
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x040034AF RID: 13487
	public PoliceScript Police;

	// Token: 0x040034B0 RID: 13488
	public UILabel Label;

	// Token: 0x040034B1 RID: 13489
	public float Timer;
}
