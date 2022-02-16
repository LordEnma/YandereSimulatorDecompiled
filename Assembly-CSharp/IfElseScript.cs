using System;
using UnityEngine;

// Token: 0x02000330 RID: 816
public class IfElseScript : MonoBehaviour
{
	// Token: 0x060018C7 RID: 6343 RVA: 0x000F3CC3 File Offset: 0x000F1EC3
	private void Start()
	{
		this.SwitchCase();
	}

	// Token: 0x060018C8 RID: 6344 RVA: 0x000F3CCC File Offset: 0x000F1ECC
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

	// Token: 0x060018C9 RID: 6345 RVA: 0x000F3D6C File Offset: 0x000F1F6C
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

	// Token: 0x040025D0 RID: 9680
	public int ID;

	// Token: 0x040025D1 RID: 9681
	public string Day;
}
