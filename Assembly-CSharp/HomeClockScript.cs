using System;
using System.Globalization;
using UnityEngine;

// Token: 0x02000319 RID: 793
public class HomeClockScript : MonoBehaviour
{
	// Token: 0x06001882 RID: 6274 RVA: 0x000EDB98 File Offset: 0x000EBD98
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

	// Token: 0x06001883 RID: 6275 RVA: 0x000EDBF8 File Offset: 0x000EBDF8
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

	// Token: 0x06001884 RID: 6276 RVA: 0x000EDD10 File Offset: 0x000EBF10
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

	// Token: 0x06001885 RID: 6277 RVA: 0x000EDD60 File Offset: 0x000EBF60
	public void UpdateMoneyLabel()
	{
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x06001886 RID: 6278 RVA: 0x000EDD9C File Offset: 0x000EBF9C
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

	// Token: 0x040024AD RID: 9389
	public UILabel MoneyLabel;

	// Token: 0x040024AE RID: 9390
	public UILabel HourLabel;

	// Token: 0x040024AF RID: 9391
	public UILabel DayLabel;

	// Token: 0x040024B0 RID: 9392
	public AudioSource MyAudio;

	// Token: 0x040024B1 RID: 9393
	public bool ShakeMoney;

	// Token: 0x040024B2 RID: 9394
	public Vector3 Origin;

	// Token: 0x040024B3 RID: 9395
	public float Shake;

	// Token: 0x040024B4 RID: 9396
	public float G;

	// Token: 0x040024B5 RID: 9397
	public float B;
}
