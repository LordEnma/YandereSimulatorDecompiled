using System;
using System.Globalization;
using UnityEngine;

// Token: 0x02000319 RID: 793
public class HomeClockScript : MonoBehaviour
{
	// Token: 0x0600187E RID: 6270 RVA: 0x000ED6D0 File Offset: 0x000EB8D0
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

	// Token: 0x0600187F RID: 6271 RVA: 0x000ED730 File Offset: 0x000EB930
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

	// Token: 0x06001880 RID: 6272 RVA: 0x000ED848 File Offset: 0x000EBA48
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

	// Token: 0x06001881 RID: 6273 RVA: 0x000ED898 File Offset: 0x000EBA98
	public void UpdateMoneyLabel()
	{
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x06001882 RID: 6274 RVA: 0x000ED8D4 File Offset: 0x000EBAD4
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

	// Token: 0x040024A4 RID: 9380
	public UILabel MoneyLabel;

	// Token: 0x040024A5 RID: 9381
	public UILabel HourLabel;

	// Token: 0x040024A6 RID: 9382
	public UILabel DayLabel;

	// Token: 0x040024A7 RID: 9383
	public AudioSource MyAudio;

	// Token: 0x040024A8 RID: 9384
	public bool ShakeMoney;

	// Token: 0x040024A9 RID: 9385
	public Vector3 Origin;

	// Token: 0x040024AA RID: 9386
	public float Shake;

	// Token: 0x040024AB RID: 9387
	public float G;

	// Token: 0x040024AC RID: 9388
	public float B;
}
