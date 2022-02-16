using System;
using System.Globalization;
using UnityEngine;

// Token: 0x02000316 RID: 790
public class HomeClockScript : MonoBehaviour
{
	// Token: 0x06001860 RID: 6240 RVA: 0x000EBCA4 File Offset: 0x000E9EA4
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

	// Token: 0x06001861 RID: 6241 RVA: 0x000EBD04 File Offset: 0x000E9F04
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

	// Token: 0x06001862 RID: 6242 RVA: 0x000EBE1C File Offset: 0x000EA01C
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

	// Token: 0x06001863 RID: 6243 RVA: 0x000EBE6C File Offset: 0x000EA06C
	public void UpdateMoneyLabel()
	{
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x06001864 RID: 6244 RVA: 0x000EBEA8 File Offset: 0x000EA0A8
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

	// Token: 0x04002452 RID: 9298
	public UILabel MoneyLabel;

	// Token: 0x04002453 RID: 9299
	public UILabel HourLabel;

	// Token: 0x04002454 RID: 9300
	public UILabel DayLabel;

	// Token: 0x04002455 RID: 9301
	public AudioSource MyAudio;

	// Token: 0x04002456 RID: 9302
	public bool ShakeMoney;

	// Token: 0x04002457 RID: 9303
	public Vector3 Origin;

	// Token: 0x04002458 RID: 9304
	public float Shake;

	// Token: 0x04002459 RID: 9305
	public float G;

	// Token: 0x0400245A RID: 9306
	public float B;
}
