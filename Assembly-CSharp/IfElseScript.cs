using System;
using UnityEngine;

// Token: 0x02000333 RID: 819
public class IfElseScript : MonoBehaviour
{
	// Token: 0x060018E2 RID: 6370 RVA: 0x000F5698 File Offset: 0x000F3898
	private void Start()
	{
		this.SwitchCase();
	}

	// Token: 0x060018E3 RID: 6371 RVA: 0x000F56A0 File Offset: 0x000F38A0
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

	// Token: 0x060018E4 RID: 6372 RVA: 0x000F5740 File Offset: 0x000F3940
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

	// Token: 0x0400261F RID: 9759
	public int ID;

	// Token: 0x04002620 RID: 9760
	public string Day;
}
