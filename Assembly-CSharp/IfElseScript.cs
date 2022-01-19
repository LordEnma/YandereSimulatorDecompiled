using System;
using UnityEngine;

// Token: 0x0200032F RID: 815
public class IfElseScript : MonoBehaviour
{
	// Token: 0x060018BD RID: 6333 RVA: 0x000F352F File Offset: 0x000F172F
	private void Start()
	{
		this.SwitchCase();
	}

	// Token: 0x060018BE RID: 6334 RVA: 0x000F3538 File Offset: 0x000F1738
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

	// Token: 0x060018BF RID: 6335 RVA: 0x000F35D8 File Offset: 0x000F17D8
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

	// Token: 0x040025C0 RID: 9664
	public int ID;

	// Token: 0x040025C1 RID: 9665
	public string Day;
}
