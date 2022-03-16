using System;
using UnityEngine;

// Token: 0x02000331 RID: 817
public class IfElseScript : MonoBehaviour
{
	// Token: 0x060018D6 RID: 6358 RVA: 0x000F4F50 File Offset: 0x000F3150
	private void Start()
	{
		this.SwitchCase();
	}

	// Token: 0x060018D7 RID: 6359 RVA: 0x000F4F58 File Offset: 0x000F3158
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

	// Token: 0x060018D8 RID: 6360 RVA: 0x000F4FF8 File Offset: 0x000F31F8
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

	// Token: 0x04002609 RID: 9737
	public int ID;

	// Token: 0x0400260A RID: 9738
	public string Day;
}
