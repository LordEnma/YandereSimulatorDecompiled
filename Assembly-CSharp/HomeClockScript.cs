using System;
using System.Globalization;
using UnityEngine;

// Token: 0x02000317 RID: 791
public class HomeClockScript : MonoBehaviour
{
	// Token: 0x0600186E RID: 6254 RVA: 0x000ECD78 File Offset: 0x000EAF78
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

	// Token: 0x0600186F RID: 6255 RVA: 0x000ECDD8 File Offset: 0x000EAFD8
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

	// Token: 0x06001870 RID: 6256 RVA: 0x000ECEF0 File Offset: 0x000EB0F0
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

	// Token: 0x06001871 RID: 6257 RVA: 0x000ECF40 File Offset: 0x000EB140
	public void UpdateMoneyLabel()
	{
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x06001872 RID: 6258 RVA: 0x000ECF7C File Offset: 0x000EB17C
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

	// Token: 0x04002486 RID: 9350
	public UILabel MoneyLabel;

	// Token: 0x04002487 RID: 9351
	public UILabel HourLabel;

	// Token: 0x04002488 RID: 9352
	public UILabel DayLabel;

	// Token: 0x04002489 RID: 9353
	public AudioSource MyAudio;

	// Token: 0x0400248A RID: 9354
	public bool ShakeMoney;

	// Token: 0x0400248B RID: 9355
	public Vector3 Origin;

	// Token: 0x0400248C RID: 9356
	public float Shake;

	// Token: 0x0400248D RID: 9357
	public float G;

	// Token: 0x0400248E RID: 9358
	public float B;
}
