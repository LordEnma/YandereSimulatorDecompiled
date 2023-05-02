using UnityEngine;

public class RivalScheduleScript : MonoBehaviour
{
	public string[] Morning;

	public string[] Lunch;

	public string[] AfterClass;

	public ScheduleList[] Rival2Morning;

	public ScheduleList[] Rival2Lunch;

	public ScheduleList[] Rival2AfterClass;

	public ScheduleList[] Rival3Morning;

	public ScheduleList[] Rival3Lunch;

	public ScheduleList[] Rival3AfterClass;

	public ScheduleList[] Rival4Morning;

	public ScheduleList[] Rival4Lunch;

	public ScheduleList[] Rival4AfterClass;

	public ScheduleList[] Rival5Morning;

	public ScheduleList[] Rival5Lunch;

	public ScheduleList[] Rival5AfterClass;

	public ScheduleList[] Rival6Morning;

	public ScheduleList[] Rival6Lunch;

	public ScheduleList[] Rival6AfterClass;

	public ScheduleList[] Rival7Morning;

	public ScheduleList[] Rival7Lunch;

	public ScheduleList[] Rival7AfterClass;

	public ScheduleList[] Rival8Morning;

	public ScheduleList[] Rival8Lunch;

	public ScheduleList[] Rival8AfterClass;

	public ScheduleList[] Rival9Morning;

	public ScheduleList[] Rival9Lunch;

	public ScheduleList[] Rival9AfterClass;

	public ScheduleList[] Rival10Morning;

	public ScheduleList[] Rival10Lunch;

	public ScheduleList[] Rival10AfterClass;

	private void Start()
	{
		if (DateGlobals.Week == 2)
		{
			Morning = Rival2Morning[(int)DateGlobals.Weekday].Weekday;
			Lunch = Rival2Lunch[(int)DateGlobals.Weekday].Weekday;
			AfterClass = Rival2AfterClass[(int)DateGlobals.Weekday].Weekday;
		}
		else if (DateGlobals.Week == 3)
		{
			Morning = Rival3Morning[(int)DateGlobals.Weekday].Weekday;
			Lunch = Rival3Lunch[(int)DateGlobals.Weekday].Weekday;
			AfterClass = Rival3AfterClass[(int)DateGlobals.Weekday].Weekday;
		}
		else if (DateGlobals.Week == 4)
		{
			Morning = Rival4Morning[(int)DateGlobals.Weekday].Weekday;
			Lunch = Rival4Lunch[(int)DateGlobals.Weekday].Weekday;
			AfterClass = Rival4AfterClass[(int)DateGlobals.Weekday].Weekday;
		}
		else if (DateGlobals.Week == 5)
		{
			Morning = Rival5Morning[(int)DateGlobals.Weekday].Weekday;
			Lunch = Rival5Lunch[(int)DateGlobals.Weekday].Weekday;
			AfterClass = Rival5AfterClass[(int)DateGlobals.Weekday].Weekday;
		}
		else if (DateGlobals.Week == 6)
		{
			Morning = Rival6Morning[(int)DateGlobals.Weekday].Weekday;
			Lunch = Rival6Lunch[(int)DateGlobals.Weekday].Weekday;
			AfterClass = Rival6AfterClass[(int)DateGlobals.Weekday].Weekday;
		}
		else if (DateGlobals.Week == 7)
		{
			Morning = Rival7Morning[(int)DateGlobals.Weekday].Weekday;
			Lunch = Rival7Lunch[(int)DateGlobals.Weekday].Weekday;
			AfterClass = Rival7AfterClass[(int)DateGlobals.Weekday].Weekday;
		}
		else if (DateGlobals.Week == 8)
		{
			Morning = Rival8Morning[(int)DateGlobals.Weekday].Weekday;
			Lunch = Rival8Lunch[(int)DateGlobals.Weekday].Weekday;
			AfterClass = Rival8AfterClass[(int)DateGlobals.Weekday].Weekday;
		}
		else if (DateGlobals.Week == 9)
		{
			Morning = Rival9Morning[(int)DateGlobals.Weekday].Weekday;
			Lunch = Rival9Lunch[(int)DateGlobals.Weekday].Weekday;
			AfterClass = Rival9AfterClass[(int)DateGlobals.Weekday].Weekday;
		}
		else if (DateGlobals.Week == 10)
		{
			Morning = Rival10Morning[(int)DateGlobals.Weekday].Weekday;
			Lunch = Rival10Lunch[(int)DateGlobals.Weekday].Weekday;
			AfterClass = Rival10AfterClass[(int)DateGlobals.Weekday].Weekday;
		}
	}
}
