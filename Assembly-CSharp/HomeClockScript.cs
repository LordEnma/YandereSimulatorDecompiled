using System;
using System.Globalization;
using UnityEngine;

// Token: 0x0200031A RID: 794
public class HomeClockScript : MonoBehaviour
{
	// Token: 0x06001887 RID: 6279 RVA: 0x000EE014 File Offset: 0x000EC214
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

	// Token: 0x06001888 RID: 6280 RVA: 0x000EE074 File Offset: 0x000EC274
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

	// Token: 0x06001889 RID: 6281 RVA: 0x000EE18C File Offset: 0x000EC38C
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

	// Token: 0x0600188A RID: 6282 RVA: 0x000EE1DC File Offset: 0x000EC3DC
	public void UpdateMoneyLabel()
	{
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x0600188B RID: 6283 RVA: 0x000EE218 File Offset: 0x000EC418
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

	// Token: 0x040024B9 RID: 9401
	public UILabel MoneyLabel;

	// Token: 0x040024BA RID: 9402
	public UILabel HourLabel;

	// Token: 0x040024BB RID: 9403
	public UILabel DayLabel;

	// Token: 0x040024BC RID: 9404
	public AudioSource MyAudio;

	// Token: 0x040024BD RID: 9405
	public bool ShakeMoney;

	// Token: 0x040024BE RID: 9406
	public Vector3 Origin;

	// Token: 0x040024BF RID: 9407
	public float Shake;

	// Token: 0x040024C0 RID: 9408
	public float G;

	// Token: 0x040024C1 RID: 9409
	public float B;
}
