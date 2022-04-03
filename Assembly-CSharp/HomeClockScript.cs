using System;
using System.Globalization;
using UnityEngine;

// Token: 0x02000318 RID: 792
public class HomeClockScript : MonoBehaviour
{
	// Token: 0x06001874 RID: 6260 RVA: 0x000ED330 File Offset: 0x000EB530
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

	// Token: 0x06001875 RID: 6261 RVA: 0x000ED390 File Offset: 0x000EB590
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

	// Token: 0x06001876 RID: 6262 RVA: 0x000ED4A8 File Offset: 0x000EB6A8
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

	// Token: 0x06001877 RID: 6263 RVA: 0x000ED4F8 File Offset: 0x000EB6F8
	public void UpdateMoneyLabel()
	{
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x06001878 RID: 6264 RVA: 0x000ED534 File Offset: 0x000EB734
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

	// Token: 0x04002499 RID: 9369
	public UILabel MoneyLabel;

	// Token: 0x0400249A RID: 9370
	public UILabel HourLabel;

	// Token: 0x0400249B RID: 9371
	public UILabel DayLabel;

	// Token: 0x0400249C RID: 9372
	public AudioSource MyAudio;

	// Token: 0x0400249D RID: 9373
	public bool ShakeMoney;

	// Token: 0x0400249E RID: 9374
	public Vector3 Origin;

	// Token: 0x0400249F RID: 9375
	public float Shake;

	// Token: 0x040024A0 RID: 9376
	public float G;

	// Token: 0x040024A1 RID: 9377
	public float B;
}
