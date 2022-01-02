using System;
using UnityEngine;

// Token: 0x0200032E RID: 814
public class IfElseScript : MonoBehaviour
{
	// Token: 0x060018B9 RID: 6329 RVA: 0x000F30AB File Offset: 0x000F12AB
	private void Start()
	{
		this.SwitchCase();
	}

	// Token: 0x060018BA RID: 6330 RVA: 0x000F30B4 File Offset: 0x000F12B4
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

	// Token: 0x060018BB RID: 6331 RVA: 0x000F3154 File Offset: 0x000F1354
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

	// Token: 0x040025B9 RID: 9657
	public int ID;

	// Token: 0x040025BA RID: 9658
	public string Day;
}
