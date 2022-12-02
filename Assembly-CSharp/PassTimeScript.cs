using UnityEngine;

public class PassTimeScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public ClockScript Clock;

	public UILabel TimeDisplay;

	public Transform Highlight;

	public float[] MinimumDigits;

	public float[] Digits;

	public int TargetTime;

	public int Selected = 1;

	public string AMPM = "AM";

	private void Update()
	{
		if (InputManager.TappedLeft || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Selected--;
			if (Selected < 1)
			{
				Selected = 3;
			}
			UpdateHighlightPosition();
		}
		if (InputManager.TappedRight || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			Selected++;
			if (Selected > 3)
			{
				Selected = 1;
			}
			UpdateHighlightPosition();
		}
		if (InputManager.TappedUp || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			UpdateTime(1);
		}
		if (InputManager.TappedDown || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			UpdateTime(-1);
		}
	}

	private void UpdateHighlightPosition()
	{
		if (Selected == 1)
		{
			Highlight.localPosition = new Vector3(-130f, Highlight.localPosition.y, Highlight.localPosition.z);
		}
		else if (Selected == 2)
		{
			Highlight.localPosition = new Vector3(-40f, Highlight.localPosition.y, Highlight.localPosition.z);
		}
		else if (Selected == 3)
		{
			Highlight.localPosition = new Vector3(15f, Highlight.localPosition.y, Highlight.localPosition.z);
		}
	}

	public void GetCurrentTime()
	{
		Digits[1] = Clock.Hour;
		if (Clock.Minute < 9f)
		{
			Digits[2] = 0f;
			Digits[3] = Clock.Minute;
		}
		else
		{
			Digits[2] = Clock.Minute * 0.1f;
			Digits[2] = Mathf.Floor(Digits[2]);
			Digits[3] = Clock.Minute - Digits[2] * 10f;
		}
		MinimumDigits[1] = Digits[1];
		MinimumDigits[2] = Digits[2];
		MinimumDigits[3] = Digits[3];
		UpdateTime(0);
	}

	private void UpdateTime(int Increment)
	{
		Digits[Selected] += Increment;
		if (Selected == 1)
		{
			if (Digits[1] < MinimumDigits[1])
			{
				Digits[1] = MinimumDigits[1];
			}
			else if (Digits[1] > 17f)
			{
				Digits[1] = 17f;
			}
			if (Digits[1] == MinimumDigits[1])
			{
				if (Digits[2] < MinimumDigits[2])
				{
					Digits[2] = MinimumDigits[2];
				}
				if (Digits[2] == MinimumDigits[2] && Digits[3] < MinimumDigits[3])
				{
					Digits[3] = MinimumDigits[3];
				}
			}
		}
		else if (Selected == 2)
		{
			if (Digits[1] == MinimumDigits[1])
			{
				if (Digits[2] < MinimumDigits[2])
				{
					Digits[2] = MinimumDigits[2];
				}
				else if (Digits[2] > 5f)
				{
					Digits[2] = MinimumDigits[2];
				}
				if (Digits[2] == MinimumDigits[2] && Digits[3] < MinimumDigits[3])
				{
					Digits[3] = MinimumDigits[3];
				}
			}
			else if (Digits[2] < 0f)
			{
				Digits[2] = 5f;
			}
			else if (Digits[2] > 5f)
			{
				Digits[2] = 0f;
			}
		}
		else if (Selected == 3)
		{
			if (Digits[1] == MinimumDigits[1] && Digits[2] == MinimumDigits[2])
			{
				if (Digits[3] < MinimumDigits[3])
				{
					Digits[3] = MinimumDigits[3];
				}
				else if (Digits[3] > 9f)
				{
					Digits[3] = MinimumDigits[3];
				}
			}
			else if (Digits[3] < 0f)
			{
				Digits[3] = 9f;
			}
			else if (Digits[3] > 9f)
			{
				Digits[3] = 0f;
			}
		}
		if (Digits[1] < 12f)
		{
			AMPM = " AM";
		}
		else
		{
			AMPM = " PM";
		}
		if (Digits[1] < 10f)
		{
			TimeDisplay.text = "0" + Digits[1] + ":" + Digits[2] + Digits[3] + AMPM;
		}
		else if (Digits[1] < 13f)
		{
			TimeDisplay.text = Digits[1] + ":" + Digits[2] + Digits[3] + AMPM;
		}
		else
		{
			TimeDisplay.text = "0" + (Digits[1] - 12f) + ":" + Digits[2] + Digits[3] + AMPM;
		}
		TargetTime = (int)(Digits[1] * 60f + Digits[2] * 10f + Digits[3]);
	}
}
