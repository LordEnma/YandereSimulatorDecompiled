using System;
using System.Globalization;
using UnityEngine;

// Token: 0x02000319 RID: 793
public class HomeClockScript : MonoBehaviour
{
	// Token: 0x0600187A RID: 6266 RVA: 0x000ED430 File Offset: 0x000EB630
	private void Start()
	{
		this.DayLabel.text = this.GetWeekdayText(DateGlobals.Weekday);
		if (HomeGlobals.Night)
		{
			this.HourLabel.text = "8:00 PM";
		}
		else
		{
			this.HourLabel.text = (HomeGlobals.LateForSchool ? "7:30 AM" : "6:30 AM");
		}
		this.UpdateMoneyLabel();
	}

	// Token: 0x0600187B RID: 6267 RVA: 0x000ED490 File Offset: 0x000EB690
	private void Update()
	{
		if (this.ShakeMoney)
		{
			this.Shake = Mathf.MoveTowards(this.Shake, 0f, Time.deltaTime * 10f);
			this.MoneyLabel.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(this.Shake * -1f, this.Shake * 1f), this.Origin.y + UnityEngine.Random.Range(this.Shake * -1f, this.Shake * 1f), 0f);
			this.G = Mathf.MoveTowards(this.G, 0.75f, Time.deltaTime);
			this.B = Mathf.MoveTowards(this.B, 1f, Time.deltaTime);
			this.MoneyLabel.color = new Color(1f, this.G, this.B, 1f);
			if (this.Shake == 0f)
			{
				this.ShakeMoney = false;
			}
		}
	}

	// Token: 0x0600187C RID: 6268 RVA: 0x000ED5A8 File Offset: 0x000EB7A8
	private string GetWeekdayText(DayOfWeek weekday)
	{
		if (weekday == DayOfWeek.Sunday)
		{
			return "SUNDAY";
		}
		if (weekday == DayOfWeek.Monday)
		{
			return "MONDAY";
		}
		if (weekday == DayOfWeek.Tuesday)
		{
			return "TUESDAY";
		}
		if (weekday == DayOfWeek.Wednesday)
		{
			return "WEDNESDAY";
		}
		if (weekday == DayOfWeek.Thursday)
		{
			return "THURSDAY";
		}
		if (weekday == DayOfWeek.Friday)
		{
			return "FRIDAY";
		}
		return "SATURDAY";
	}

	// Token: 0x0600187D RID: 6269 RVA: 0x000ED5F8 File Offset: 0x000EB7F8
	public void UpdateMoneyLabel()
	{
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x0600187E RID: 6270 RVA: 0x000ED634 File Offset: 0x000EB834
	public void MoneyFail()
	{
		if (this.Origin != Vector3.zero)
		{
			this.MoneyLabel.transform.localPosition = this.Origin;
		}
		this.Origin = this.MoneyLabel.transform.localPosition;
		this.ShakeMoney = true;
		this.Shake = 10f;
		this.G = 0f;
		this.B = 0f;
		this.MyAudio.Play();
	}

	// Token: 0x0400249C RID: 9372
	public UILabel MoneyLabel;

	// Token: 0x0400249D RID: 9373
	public UILabel HourLabel;

	// Token: 0x0400249E RID: 9374
	public UILabel DayLabel;

	// Token: 0x0400249F RID: 9375
	public AudioSource MyAudio;

	// Token: 0x040024A0 RID: 9376
	public bool ShakeMoney;

	// Token: 0x040024A1 RID: 9377
	public Vector3 Origin;

	// Token: 0x040024A2 RID: 9378
	public float Shake;

	// Token: 0x040024A3 RID: 9379
	public float G;

	// Token: 0x040024A4 RID: 9380
	public float B;
}
