using System;
using UnityEngine;

// Token: 0x02000262 RID: 610
public class CountdownTimerScript : MonoBehaviour
{
	// Token: 0x060012F2 RID: 4850 RVA: 0x000A6D06 File Offset: 0x000A4F06
	private void Update()
	{
		this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
		this.DisplayTime(this.Timer);
	}

	// Token: 0x060012F3 RID: 4851 RVA: 0x000A6D30 File Offset: 0x000A4F30
	private void DisplayTime(float timeToDisplay)
	{
		float num = (float)Mathf.FloorToInt(timeToDisplay / 60f);
		float num2 = (float)Mathf.FloorToInt(timeToDisplay % 60f);
		this.CountdownLabel.text = string.Format("{0:0}:{1:00}", num, num2);
	}

	// Token: 0x04001AD6 RID: 6870
	public UILabel CountdownLabel;

	// Token: 0x04001AD7 RID: 6871
	public float Timer;
}
