using UnityEngine;

public class IfElseScript : MonoBehaviour
{
	public int ID;

	public string Day;

	private void Start()
	{
		SwitchCase();
	}

	private void IfElse()
	{
		if (ID == 1)
		{
			Day = "Monday";
		}
		else if (ID == 2)
		{
			Day = "Tuesday";
		}
		else if (ID == 3)
		{
			Day = "Wednesday";
		}
		else if (ID == 4)
		{
			Day = "Thursday";
		}
		else if (ID == 5)
		{
			Day = "Friday";
		}
		else if (ID == 6)
		{
			Day = "Saturday";
		}
		else if (ID == 7)
		{
			Day = "Sunday";
		}
	}

	private void SwitchCase()
	{
		switch (ID)
		{
		case 1:
			Day = "Monday";
			break;
		case 2:
			Day = "Tuesday";
			break;
		case 3:
			Day = "Wednesday";
			break;
		case 4:
			Day = "Thursday";
			break;
		case 5:
			Day = "Friday";
			break;
		case 6:
			Day = "Saturday";
			break;
		case 7:
			Day = "Sunday";
			break;
		}
	}
}
