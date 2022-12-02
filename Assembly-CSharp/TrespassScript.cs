using UnityEngine;

public class TrespassScript : MonoBehaviour
{
	public GameObject YandereObject;

	public YandereScript Yandere;

	public PoliceScript Police;

	public bool HideNotification;

	public bool OffLimits;

	public bool FacultyRoom;

	public bool CookingClub;

	private void OnTriggerEnter(Collider other)
	{
		if (!base.enabled || CookingClub || other.gameObject.layer != 13)
		{
			return;
		}
		YandereObject = other.gameObject;
		Yandere = other.gameObject.GetComponent<YandereScript>();
		if (Yandere != null)
		{
			if (!Yandere.Trespassing)
			{
				Yandere.NotificationManager.DisplayNotification(NotificationType.Intrude);
			}
			Yandere.Trespassing = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (Yandere != null && other.gameObject == YandereObject)
		{
			Yandere.Trespassing = false;
			if (FacultyRoom)
			{
				Yandere.StudentManager.CanSelfReport = false;
				Yandere.StudentManager.UpdateTeachers();
			}
		}
	}
}
