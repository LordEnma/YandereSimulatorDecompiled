using System;
using UnityEngine;

// Token: 0x02000399 RID: 921
public class PassTimeScript : MonoBehaviour
{
	// Token: 0x06001A7F RID: 6783 RVA: 0x0011A6CC File Offset: 0x001188CC
	private void Update()
	{
		if (this.InputManager.TappedLeft || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			this.Selected--;
			if (this.Selected < 1)
			{
				this.Selected = 3;
			}
			this.UpdateHighlightPosition();
		}
		if (this.InputManager.TappedRight || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			this.Selected++;
			if (this.Selected > 3)
			{
				this.Selected = 1;
			}
			this.UpdateHighlightPosition();
		}
		if (this.InputManager.TappedUp || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			this.UpdateTime(1);
		}
		if (this.InputManager.TappedDown || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			this.UpdateTime(-1);
		}
	}

	// Token: 0x06001A80 RID: 6784 RVA: 0x0011A7B8 File Offset: 0x001189B8
	private void UpdateHighlightPosition()
	{
		if (this.Selected == 1)
		{
			this.Highlight.localPosition = new Vector3(-130f, this.Highlight.localPosition.y, this.Highlight.localPosition.z);
			return;
		}
		if (this.Selected == 2)
		{
			this.Highlight.localPosition = new Vector3(-40f, this.Highlight.localPosition.y, this.Highlight.localPosition.z);
			return;
		}
		if (this.Selected == 3)
		{
			this.Highlight.localPosition = new Vector3(15f, this.Highlight.localPosition.y, this.Highlight.localPosition.z);
		}
	}

	// Token: 0x06001A81 RID: 6785 RVA: 0x0011A884 File Offset: 0x00118A84
	public void GetCurrentTime()
	{
		this.Digits[1] = this.Clock.Hour;
		if (this.Clock.Minute < 9f)
		{
			this.Digits[2] = 0f;
			this.Digits[3] = this.Clock.Minute;
		}
		else
		{
			this.Digits[2] = this.Clock.Minute * 0.1f;
			this.Digits[2] = Mathf.Floor(this.Digits[2]);
			this.Digits[3] = this.Clock.Minute - this.Digits[2] * 10f;
		}
		this.MinimumDigits[1] = this.Digits[1];
		this.MinimumDigits[2] = this.Digits[2];
		this.MinimumDigits[3] = this.Digits[3];
		this.UpdateTime(0);
	}

	// Token: 0x06001A82 RID: 6786 RVA: 0x0011A960 File Offset: 0x00118B60
	private void UpdateTime(int Increment)
	{
		this.Digits[this.Selected] += (float)Increment;
		if (this.Selected == 1)
		{
			if (this.Digits[1] < this.MinimumDigits[1])
			{
				this.Digits[1] = this.MinimumDigits[1];
			}
			else if (this.Digits[1] > 17f)
			{
				this.Digits[1] = 17f;
			}
			if (this.Digits[1] == this.MinimumDigits[1])
			{
				if (this.Digits[2] < this.MinimumDigits[2])
				{
					this.Digits[2] = this.MinimumDigits[2];
				}
				if (this.Digits[2] == this.MinimumDigits[2] && this.Digits[3] < this.MinimumDigits[3])
				{
					this.Digits[3] = this.MinimumDigits[3];
				}
			}
		}
		else if (this.Selected == 2)
		{
			if (this.Digits[1] == this.MinimumDigits[1])
			{
				if (this.Digits[2] < this.MinimumDigits[2])
				{
					this.Digits[2] = this.MinimumDigits[2];
				}
				else if (this.Digits[2] > 5f)
				{
					this.Digits[2] = this.MinimumDigits[2];
				}
				if (this.Digits[2] == this.MinimumDigits[2] && this.Digits[3] < this.MinimumDigits[3])
				{
					this.Digits[3] = this.MinimumDigits[3];
				}
			}
			else if (this.Digits[2] < 0f)
			{
				this.Digits[2] = 5f;
			}
			else if (this.Digits[2] > 5f)
			{
				this.Digits[2] = 0f;
			}
		}
		else if (this.Selected == 3)
		{
			if (this.Digits[1] == this.MinimumDigits[1] && this.Digits[2] == this.MinimumDigits[2])
			{
				if (this.Digits[3] < this.MinimumDigits[3])
				{
					this.Digits[3] = this.MinimumDigits[3];
				}
				else if (this.Digits[3] > 9f)
				{
					this.Digits[3] = this.MinimumDigits[3];
				}
			}
			else if (this.Digits[3] < 0f)
			{
				this.Digits[3] = 9f;
			}
			else if (this.Digits[3] > 9f)
			{
				this.Digits[3] = 0f;
			}
		}
		if (this.Digits[1] < 12f)
		{
			this.AMPM = " AM";
		}
		else
		{
			this.AMPM = " PM";
		}
		if (this.Digits[1] < 10f)
		{
			this.TimeDisplay.text = string.Concat(new string[]
			{
				"0",
				this.Digits[1].ToString(),
				":",
				this.Digits[2].ToString(),
				this.Digits[3].ToString(),
				this.AMPM
			});
		}
		else if (this.Digits[1] < 13f)
		{
			this.TimeDisplay.text = string.Concat(new string[]
			{
				this.Digits[1].ToString(),
				":",
				this.Digits[2].ToString(),
				this.Digits[3].ToString(),
				this.AMPM
			});
		}
		else
		{
			this.TimeDisplay.text = string.Concat(new string[]
			{
				"0",
				(this.Digits[1] - 12f).ToString(),
				":",
				this.Digits[2].ToString(),
				this.Digits[3].ToString(),
				this.AMPM
			});
		}
		this.TargetTime = (int)(this.Digits[1] * 60f + this.Digits[2] * 10f + this.Digits[3]);
	}

	// Token: 0x04002B95 RID: 11157
	public InputManagerScript InputManager;

	// Token: 0x04002B96 RID: 11158
	public ClockScript Clock;

	// Token: 0x04002B97 RID: 11159
	public UILabel TimeDisplay;

	// Token: 0x04002B98 RID: 11160
	public Transform Highlight;

	// Token: 0x04002B99 RID: 11161
	public float[] MinimumDigits;

	// Token: 0x04002B9A RID: 11162
	public float[] Digits;

	// Token: 0x04002B9B RID: 11163
	public int TargetTime;

	// Token: 0x04002B9C RID: 11164
	public int Selected = 1;

	// Token: 0x04002B9D RID: 11165
	public string AMPM = "AM";
}
