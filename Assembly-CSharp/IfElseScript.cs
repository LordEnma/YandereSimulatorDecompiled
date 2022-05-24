using System;
using UnityEngine;

// Token: 0x02000334 RID: 820
public class IfElseScript : MonoBehaviour
{
	// Token: 0x060018EF RID: 6383 RVA: 0x000F625C File Offset: 0x000F445C
	private void Start()
	{
		this.SwitchCase();
	}

	// Token: 0x060018F0 RID: 6384 RVA: 0x000F6264 File Offset: 0x000F4464
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

	// Token: 0x060018F1 RID: 6385 RVA: 0x000F6304 File Offset: 0x000F4504
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

	// Token: 0x0400263E RID: 9790
	public int ID;

	// Token: 0x0400263F RID: 9791
	public string Day;
}
