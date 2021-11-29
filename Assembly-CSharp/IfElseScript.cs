using System;
using UnityEngine;

// Token: 0x0200032D RID: 813
public class IfElseScript : MonoBehaviour
{
	// Token: 0x060018B0 RID: 6320 RVA: 0x000F2607 File Offset: 0x000F0807
	private void Start()
	{
		this.SwitchCase();
	}

	// Token: 0x060018B1 RID: 6321 RVA: 0x000F2610 File Offset: 0x000F0810
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

	// Token: 0x060018B2 RID: 6322 RVA: 0x000F26B0 File Offset: 0x000F08B0
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

	// Token: 0x04002595 RID: 9621
	public int ID;

	// Token: 0x04002596 RID: 9622
	public string Day;
}
