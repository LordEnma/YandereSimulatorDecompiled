using System;
using UnityEngine;

// Token: 0x02000331 RID: 817
public class IfElseScript : MonoBehaviour
{
	// Token: 0x060018D0 RID: 6352 RVA: 0x000F45A7 File Offset: 0x000F27A7
	private void Start()
	{
		this.SwitchCase();
	}

	// Token: 0x060018D1 RID: 6353 RVA: 0x000F45B0 File Offset: 0x000F27B0
	private void IfElse()
	{
		if (this.ID == 1)
		{
			this.Day = "Monday";
			return;
		}
		if (this.ID == 2)
		{
			this.Day = "Tuesday";
			return;
		}
		if (this.ID == 3)
		{
			this.Day = "Wednesday";
			return;
		}
		if (this.ID == 4)
		{
			this.Day = "Thursday";
			return;
		}
		if (this.ID == 5)
		{
			this.Day = "Friday";
			return;
		}
		if (this.ID == 6)
		{
			this.Day = "Saturday";
			return;
		}
		if (this.ID == 7)
		{
			this.Day = "Sunday";
		}
	}

	// Token: 0x060018D2 RID: 6354 RVA: 0x000F4650 File Offset: 0x000F2850
	private void SwitchCase()
	{
		switch (this.ID)
		{
		case 1:
			this.Day = "Monday";
			return;
		case 2:
			this.Day = "Tuesday";
			return;
		case 3:
			this.Day = "Wednesday";
			return;
		case 4:
			this.Day = "Thursday";
			return;
		case 5:
			this.Day = "Friday";
			return;
		case 6:
			this.Day = "Saturday";
			return;
		case 7:
			this.Day = "Sunday";
			return;
		default:
			return;
		}
	}

	// Token: 0x040025DF RID: 9695
	public int ID;

	// Token: 0x040025E0 RID: 9696
	public string Day;
}
