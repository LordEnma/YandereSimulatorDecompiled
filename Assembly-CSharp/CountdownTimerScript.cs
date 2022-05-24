using System;
using UnityEngine;

// Token: 0x02000263 RID: 611
public class CountdownTimerScript : MonoBehaviour
{
	// Token: 0x060012F4 RID: 4852 RVA: 0x000A6FE6 File Offset: 0x000A51E6
	private void Update()
	{
		this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
		this.DisplayTime(this.Timer);
	}

	// Token: 0x060012F5 RID: 4853 RVA: 0x000A7010 File Offset: 0x000A5210
	private void DisplayTime(float timeToDisplay)
	{
		float num = (float)Mathf.FloorToInt(timeToDisplay / 60f);
		float num2 = (float)Mathf.FloorToInt(timeToDisplay % 60f);
		this.CountdownLabel.text = string.Format("{0:0}:{1:00}", num, num2);
	}

	// Token: 0x04001ADD RID: 6877
	public UILabel CountdownLabel;

	// Token: 0x04001ADE RID: 6878
	public float Timer;
}
