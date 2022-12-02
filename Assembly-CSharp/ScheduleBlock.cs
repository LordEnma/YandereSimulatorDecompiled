using System;

[Serializable]
public class ScheduleBlock
{
	public float time;

	public string destination;

	public string action;

	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}
}
