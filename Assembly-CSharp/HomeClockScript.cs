using System;
using System.Globalization;
using UnityEngine;

// Token: 0x02000313 RID: 787
public class HomeClockScript : MonoBehaviour
{
	// Token: 0x06001849 RID: 6217 RVA: 0x000EA6A8 File Offset: 0x000E88A8
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

	// Token: 0x0600184A RID: 6218 RVA: 0x000EA708 File Offset: 0x000E8908
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

	// Token: 0x0600184B RID: 6219 RVA: 0x000EA820 File Offset: 0x000E8A20
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

	// Token: 0x0600184C RID: 6220 RVA: 0x000EA870 File Offset: 0x000E8A70
	public void UpdateMoneyLabel()
	{
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x0600184D RID: 6221 RVA: 0x000EA8AC File Offset: 0x000E8AAC
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

	// Token: 0x04002418 RID: 9240
	public UILabel MoneyLabel;

	// Token: 0x04002419 RID: 9241
	public UILabel HourLabel;

	// Token: 0x0400241A RID: 9242
	public UILabel DayLabel;

	// Token: 0x0400241B RID: 9243
	public AudioSource MyAudio;

	// Token: 0x0400241C RID: 9244
	public bool ShakeMoney;

	// Token: 0x0400241D RID: 9245
	public Vector3 Origin;

	// Token: 0x0400241E RID: 9246
	public float Shake;

	// Token: 0x0400241F RID: 9247
	public float G;

	// Token: 0x04002420 RID: 9248
	public float B;
}
