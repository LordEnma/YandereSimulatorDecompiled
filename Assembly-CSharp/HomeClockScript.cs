using System;
using System.Globalization;
using UnityEngine;

// Token: 0x02000314 RID: 788
public class HomeClockScript : MonoBehaviour
{
	// Token: 0x06001850 RID: 6224 RVA: 0x000EAE68 File Offset: 0x000E9068
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

	// Token: 0x06001851 RID: 6225 RVA: 0x000EAEC8 File Offset: 0x000E90C8
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

	// Token: 0x06001852 RID: 6226 RVA: 0x000EAFE0 File Offset: 0x000E91E0
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

	// Token: 0x06001853 RID: 6227 RVA: 0x000EB030 File Offset: 0x000E9230
	public void UpdateMoneyLabel()
	{
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x06001854 RID: 6228 RVA: 0x000EB06C File Offset: 0x000E926C
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

	// Token: 0x04002438 RID: 9272
	public UILabel MoneyLabel;

	// Token: 0x04002439 RID: 9273
	public UILabel HourLabel;

	// Token: 0x0400243A RID: 9274
	public UILabel DayLabel;

	// Token: 0x0400243B RID: 9275
	public AudioSource MyAudio;

	// Token: 0x0400243C RID: 9276
	public bool ShakeMoney;

	// Token: 0x0400243D RID: 9277
	public Vector3 Origin;

	// Token: 0x0400243E RID: 9278
	public float Shake;

	// Token: 0x0400243F RID: 9279
	public float G;

	// Token: 0x04002440 RID: 9280
	public float B;
}
