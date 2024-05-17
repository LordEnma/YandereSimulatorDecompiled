using UnityEngine;

public class BakeSaleScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public GameObject AmaiSuccess;

	public GameObject AmaiFail;

	public Transform MeetSpot;

	public float Timer;

	public bool Poisoned;

	public int ID = 2;

	private void Update()
	{
		float hourTime = StudentManager.Clock.HourTime;
		if (!(hourTime < 8f) && (!(hourTime > 13f) || !((double)hourTime < 13.5)) && (!(hourTime > 16f) || !(hourTime < 17f)))
		{
			return;
		}
		Timer += Time.deltaTime;
		if (Timer > 30f && StudentManager.Students[ID] != null)
		{
			while ((ID > 9 && ID < 26) || ID > 86 || StudentManager.Students[ID] == null)
			{
				IncreaseID();
			}
			if (StudentManager.Students[ID].Routine && StudentManager.Students[ID].Indoors && !StudentManager.Students[ID].Slave && !StudentManager.Students[ID].Bullied && !StudentManager.Students[ID].Meeting)
			{
				Timer = 0f;
				StudentManager.Students[ID].Meeting = true;
				StudentManager.Students[ID].BakeSale = true;
				StudentManager.Students[ID].MeetTime = 0.0001f;
				StudentManager.Students[ID].MeetSpot = MeetSpot;
				IncreaseID();
			}
			else
			{
				IncreaseID();
			}
		}
	}

	private void IncreaseID()
	{
		ID++;
		if (ID > 89)
		{
			ID = 2;
		}
	}
}
