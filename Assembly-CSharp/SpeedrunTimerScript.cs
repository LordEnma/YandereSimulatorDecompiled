using System;
using UnityEngine;

// Token: 0x02000433 RID: 1075
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001CC2 RID: 7362 RVA: 0x00154CDB File Offset: 0x00152EDB
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001CC3 RID: 7363 RVA: 0x00154CEC File Offset: 0x00152EEC
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

	// Token: 0x06001CC4 RID: 7364 RVA: 0x00154D68 File Offset: 0x00152F68
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x040033E3 RID: 13283
	public PoliceScript Police;

	// Token: 0x040033E4 RID: 13284
	public UILabel Label;

	// Token: 0x040033E5 RID: 13285
	public float Timer;
}
