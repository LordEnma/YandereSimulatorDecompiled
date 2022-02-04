using System;
using System.Globalization;
using UnityEngine;

// Token: 0x02000315 RID: 789
public class HomeClockScript : MonoBehaviour
{
	// Token: 0x06001857 RID: 6231 RVA: 0x000EBA44 File Offset: 0x000E9C44
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

	// Token: 0x06001858 RID: 6232 RVA: 0x000EBAA4 File Offset: 0x000E9CA4
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

	// Token: 0x06001859 RID: 6233 RVA: 0x000EBBBC File Offset: 0x000E9DBC
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

	// Token: 0x0600185A RID: 6234 RVA: 0x000EBC0C File Offset: 0x000E9E0C
	public void UpdateMoneyLabel()
	{
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x0600185B RID: 6235 RVA: 0x000EBC48 File Offset: 0x000E9E48
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

	// Token: 0x04002449 RID: 9289
	public UILabel MoneyLabel;

	// Token: 0x0400244A RID: 9290
	public UILabel HourLabel;

	// Token: 0x0400244B RID: 9291
	public UILabel DayLabel;

	// Token: 0x0400244C RID: 9292
	public AudioSource MyAudio;

	// Token: 0x0400244D RID: 9293
	public bool ShakeMoney;

	// Token: 0x0400244E RID: 9294
	public Vector3 Origin;

	// Token: 0x0400244F RID: 9295
	public float Shake;

	// Token: 0x04002450 RID: 9296
	public float G;

	// Token: 0x04002451 RID: 9297
	public float B;
}
