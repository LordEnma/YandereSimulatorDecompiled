using System;
using UnityEngine;

// Token: 0x02000333 RID: 819
public class IfElseScript : MonoBehaviour
{
	// Token: 0x060018EA RID: 6378 RVA: 0x000F5E30 File Offset: 0x000F4030
	private void Start()
	{
		this.SwitchCase();
	}

	// Token: 0x060018EB RID: 6379 RVA: 0x000F5E38 File Offset: 0x000F4038
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

	// Token: 0x060018EC RID: 6380 RVA: 0x000F5ED8 File Offset: 0x000F40D8
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

	// Token: 0x04002630 RID: 9776
	public int ID;

	// Token: 0x04002631 RID: 9777
	public string Day;
}
