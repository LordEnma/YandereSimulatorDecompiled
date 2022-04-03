using System;
using UnityEngine;

// Token: 0x02000262 RID: 610
public class CountdownTimerScript : MonoBehaviour
{
	// Token: 0x060012EE RID: 4846 RVA: 0x000A66F6 File Offset: 0x000A48F6
	private void Update()
	{
		this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
		this.DisplayTime(this.Timer);
	}

	// Token: 0x060012EF RID: 4847 RVA: 0x000A6720 File Offset: 0x000A4920
	private void DisplayTime(float timeToDisplay)
	{
		float num = (float)Mathf.FloorToInt(timeToDisplay / 60f);
		float num2 = (float)Mathf.FloorToInt(timeToDisplay % 60f);
		this.CountdownLabel.text = string.Format("{0:0}:{1:00}", num, num2);
	}

	// Token: 0x04001ACD RID: 6861
	public UILabel CountdownLabel;

	// Token: 0x04001ACE RID: 6862
	public float Timer;
}
