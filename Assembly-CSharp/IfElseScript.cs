using System;
using UnityEngine;

// Token: 0x02000334 RID: 820
public class IfElseScript : MonoBehaviour
{
	// Token: 0x060018EF RID: 6383 RVA: 0x000F60E0 File Offset: 0x000F42E0
	private void Start()
	{
		this.SwitchCase();
	}

	// Token: 0x060018F0 RID: 6384 RVA: 0x000F60E8 File Offset: 0x000F42E8
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

	// Token: 0x060018F1 RID: 6385 RVA: 0x000F6188 File Offset: 0x000F4388
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

	// Token: 0x0400263B RID: 9787
	public int ID;

	// Token: 0x0400263C RID: 9788
	public string Day;
}
