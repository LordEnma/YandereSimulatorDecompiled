using System;
using UnityEngine;

// Token: 0x02000392 RID: 914
public class PassTimeScript : MonoBehaviour
{
	// Token: 0x06001A41 RID: 6721 RVA: 0x00116420 File Offset: 0x00114620
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

	// Token: 0x06001A42 RID: 6722 RVA: 0x0011650C File Offset: 0x0011470C
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

	// Token: 0x06001A43 RID: 6723 RVA: 0x001165D8 File Offset: 0x001147D8
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

	// Token: 0x06001A44 RID: 6724 RVA: 0x001166B4 File Offset: 0x001148B4
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

	// Token: 0x04002AEB RID: 10987
	public InputManagerScript InputManager;

	// Token: 0x04002AEC RID: 10988
	public ClockScript Clock;

	// Token: 0x04002AED RID: 10989
	public UILabel TimeDisplay;

	// Token: 0x04002AEE RID: 10990
	public Transform Highlight;

	// Token: 0x04002AEF RID: 10991
	public float[] MinimumDigits;

	// Token: 0x04002AF0 RID: 10992
	public float[] Digits;

	// Token: 0x04002AF1 RID: 10993
	public int TargetTime;

	// Token: 0x04002AF2 RID: 10994
	public int Selected = 1;

	// Token: 0x04002AF3 RID: 10995
	public string AMPM = "AM";
}
