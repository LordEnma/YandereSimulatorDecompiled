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
		if (Timer > 60f && StudentManager.Students[ID] != null)
		{
			bool flag = false;
			if (ID == 12 || (ID > 20 && ID < 26) || ID > 86)
			{
				flag = true;
			}
			if (!flag && (StudentManager.Students[ID].Routine & StudentManager.Students[ID].Indoors) && !StudentManager.Students[ID].Slave && !StudentManager.Students[ID].BakeSale)
			{
				Debug.Log(StudentManager.Students[ID].Name + " has decided to go to the bake sale.");
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
