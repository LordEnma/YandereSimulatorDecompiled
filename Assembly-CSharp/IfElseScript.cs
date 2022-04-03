using System;
using UnityEngine;

// Token: 0x02000332 RID: 818
public class IfElseScript : MonoBehaviour
{
	// Token: 0x060018DC RID: 6364 RVA: 0x000F5598 File Offset: 0x000F3798
	private void Start()
	{
		this.SwitchCase();
	}

	// Token: 0x060018DD RID: 6365 RVA: 0x000F55A0 File Offset: 0x000F37A0
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

	// Token: 0x060018DE RID: 6366 RVA: 0x000F5640 File Offset: 0x000F3840
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

	// Token: 0x0400261C RID: 9756
	public int ID;

	// Token: 0x0400261D RID: 9757
	public string Day;
}
