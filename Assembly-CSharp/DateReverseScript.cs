using System;
using UnityEngine;

// Token: 0x02000270 RID: 624
public class DateReverseScript : MonoBehaviour
{
	// Token: 0x0600133D RID: 4925 RVA: 0x000AC03B File Offset: 0x000AA23B
	private void Start()
	{
		Time.timeScale = 1f;
		this.UpdateDate();
	}

	// Token: 0x0600133E RID: 4926 RVA: 0x000AC050 File Offset: 0x000AA250
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.Rollback = true;
		}
		if (this.Rollback)
		{
			this.LifeTime += Time.deltaTime;
			this.Timer += Time.deltaTime;
			if (this.Timer > this.TimeLimit)
			{
				if ((this.Year == this.SlowYear && this.Month == this.SlowMonth && this.Day < this.SlowDay) || (this.Year == this.SlowYear && this.Month < this.SlowMonth))
				{
					this.TimeLimit *= 1.09f;
					if (this.Month == this.EndMonth && this.Day == this.EndDay + 1)
					{
						this.MyAudio.clip = this.Finish;
						this.Label.color = new Color(1f, 0f, 0f, 1f);
						base.enabled = false;
					}
				}
				else if (this.TimeLimit > 0.01f)
				{
					this.TimeLimit *= 0.9f;
				}
				else
				{
					this.Day += this.RollDirection * 19;
				}
				this.Timer = 0f;
				this.Day += this.RollDirection;
				this.UpdateDate();
				this.MyAudio.Play();
				if (!(this.MyAudio.clip != this.Finish))
				{
					this.MyAudio.pitch = 1f;
				}
			}
		}
	}

	// Token: 0x0600133F RID: 4927 RVA: 0x000AC1F8 File Offset: 0x000AA3F8
	private void UpdateDate()
	{
		if (this.Day < 1)
		{
			this.Day = 31;
			this.Month--;
			if (this.Month < 1)
			{
				this.Month = 12;
				this.Year--;
			}
		}
		else if (this.Day > 31)
		{
			this.Day = 1;
			this.Month++;
			if (this.Month > 11)
			{
				this.Month = 1;
				this.Year++;
			}
		}
		if (this.Day == 1 || this.Day == 21 || this.Day == 31)
		{
			this.Prefix = "st";
		}
		else if (this.Day == 2 || this.Day == 22)
		{
			this.Prefix = "nd";
		}
		else if (this.Day == 3 || this.Day == 23)
		{
			this.Prefix = "rd";
		}
		else
		{
			this.Prefix = "th";
		}
		this.Label.text = string.Concat(new string[]
		{
			this.MonthName[this.Month],
			" ",
			this.Day.ToString(),
			this.Prefix,
			", ",
			this.Year.ToString()
		});
	}

	// Token: 0x04001BA0 RID: 7072
	public AudioSource MyAudio;

	// Token: 0x04001BA1 RID: 7073
	public string[] MonthName;

	// Token: 0x04001BA2 RID: 7074
	public string Prefix;

	// Token: 0x04001BA3 RID: 7075
	public UILabel Label;

	// Token: 0x04001BA4 RID: 7076
	public AudioClip Finish;

	// Token: 0x04001BA5 RID: 7077
	public float TimeLimit;

	// Token: 0x04001BA6 RID: 7078
	public float LifeTime;

	// Token: 0x04001BA7 RID: 7079
	public float Timer;

	// Token: 0x04001BA8 RID: 7080
	public int RollDirection;

	// Token: 0x04001BA9 RID: 7081
	public int Month;

	// Token: 0x04001BAA RID: 7082
	public int Year;

	// Token: 0x04001BAB RID: 7083
	public int Day;

	// Token: 0x04001BAC RID: 7084
	public int SlowMonth;

	// Token: 0x04001BAD RID: 7085
	public int SlowYear;

	// Token: 0x04001BAE RID: 7086
	public int SlowDay;

	// Token: 0x04001BAF RID: 7087
	public int EndMonth;

	// Token: 0x04001BB0 RID: 7088
	public int EndYear;

	// Token: 0x04001BB1 RID: 7089
	public int EndDay;

	// Token: 0x04001BB2 RID: 7090
	public bool Rollback;
}
