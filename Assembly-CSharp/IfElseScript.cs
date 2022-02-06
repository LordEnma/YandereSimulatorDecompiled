using System;
using UnityEngine;

// Token: 0x0200032F RID: 815
public class IfElseScript : MonoBehaviour
{
	// Token: 0x060018C0 RID: 6336 RVA: 0x000F3B1F File Offset: 0x000F1D1F
	private void Start()
	{
		this.SwitchCase();
	}

	// Token: 0x060018C1 RID: 6337 RVA: 0x000F3B28 File Offset: 0x000F1D28
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

	// Token: 0x060018C2 RID: 6338 RVA: 0x000F3BC8 File Offset: 0x000F1DC8
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

	// Token: 0x040025CA RID: 9674
	public int ID;

	// Token: 0x040025CB RID: 9675
	public string Day;
}
