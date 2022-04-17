using System;
using UnityEngine;

// Token: 0x02000333 RID: 819
public class IfElseScript : MonoBehaviour
{
	// Token: 0x060018E6 RID: 6374 RVA: 0x000F592C File Offset: 0x000F3B2C
	private void Start()
	{
		this.SwitchCase();
	}

	// Token: 0x060018E7 RID: 6375 RVA: 0x000F5934 File Offset: 0x000F3B34
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

	// Token: 0x060018E8 RID: 6376 RVA: 0x000F59D4 File Offset: 0x000F3BD4
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

	// Token: 0x04002627 RID: 9767
	public int ID;

	// Token: 0x04002628 RID: 9768
	public string Day;
}
