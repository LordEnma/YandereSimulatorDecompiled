using System;
using UnityEngine;

// Token: 0x0200032E RID: 814
public class IfElseScript : MonoBehaviour
{
	// Token: 0x060018B7 RID: 6327 RVA: 0x000F2DF7 File Offset: 0x000F0FF7
	private void Start()
	{
		this.SwitchCase();
	}

	// Token: 0x060018B8 RID: 6328 RVA: 0x000F2E00 File Offset: 0x000F1000
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

	// Token: 0x060018B9 RID: 6329 RVA: 0x000F2EA0 File Offset: 0x000F10A0
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

	// Token: 0x040025B5 RID: 9653
	public int ID;

	// Token: 0x040025B6 RID: 9654
	public string Day;
}
