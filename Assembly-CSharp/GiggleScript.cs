using UnityEngine;

public class GiggleScript : MonoBehaviour
{
	public GameObject EmptyGameObject;

	public GameObject Giggle;

	public StudentScript Student;

	public bool StudentIsBusy;

	public bool Distracted;

	public bool BangSnap;

	public int Frame;

	private void Start()
	{
		float num = 500f * (2f - SchoolGlobals.SchoolAtmosphere);
		base.transform.localScale = new Vector3(num, base.transform.localScale.y, num);
	}

	private void Update()
	{
		if (Frame > 0)
		{
			Object.Destroy(base.gameObject);
		}
		Frame++;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer != 9 || Distracted)
		{
			return;
		}
		Student = other.gameObject.GetComponent<StudentScript>();
		if (!(Student != null) || !Student.enabled || !(Student.Giggle == null))
		{
			return;
		}
		if (Student.StudentManager.LockerRoomArea.bounds.Contains(base.transform.position) || Student.StudentManager.WestBathroomArea.bounds.Contains(base.transform.position) || Student.StudentManager.EastBathroomArea.bounds.Contains(base.transform.position) || (Student.Club != ClubType.Delinquent && Student.StudentManager.IncineratorArea.bounds.Contains(base.transform.position)) || Student.StudentManager.HeadmasterArea.bounds.Contains(base.transform.position))
		{
			Debug.Log("Ignored because the giggle came from a bathroom/locker room.");
			if (Student.Yandere.NotificationManager.NotificationParent.childCount == 0)
			{
				Student.Yandere.NotificationManager.CustomText = "Nobody will investigate a sound from there...";
				Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			return;
		}
		if (Student.Clock.Period == 3 && Student.BusyAtLunch)
		{
			StudentIsBusy = true;
		}
		if ((Student.StudentID == 47 || Student.StudentID == 49) && Student.StudentManager.ConvoManager.BothCharactersInPosition)
		{
			StudentIsBusy = true;
		}
		if (Student.StudentID == Student.StudentManager.RivalID || Student.StudentID == 1)
		{
			_ = Student.CurrentAction;
			_ = 10;
		}
		if (!Student.YandereVisible && !Student.Alarmed && !Student.Distracted && !Student.Wet && !Student.Slave && !Student.WitnessedMurder && !Student.WitnessedCorpse && !Student.Investigating && !Student.InEvent && !Student.Following && !Student.Confessing && !Student.Meeting && !Student.TurnOffRadio && !Student.Fleeing && !Student.Distracting && !Student.GoAway && !Student.FocusOnYandere && !StudentIsBusy && !Student.MyBento.Tampered && !Student.Headache && Student.Routine && !Student.VisitSenpaiDesk && !Student.Restless && Student.Actions[Student.Phase] != StudentActionType.Teaching && Student.Actions[Student.Phase] != StudentActionType.SitAndTakeNotes && Student.Actions[Student.Phase] != StudentActionType.Graffiti && Student.Actions[Student.Phase] != StudentActionType.Bully)
		{
			Student.CharacterAnimation.CrossFade(Student.IdleAnim);
			Giggle = Object.Instantiate(EmptyGameObject, new Vector3(base.transform.position.x, Student.transform.position.y, base.transform.position.z), Quaternion.identity);
			Student.Giggle = Giggle;
			Student.AnnoyedByGiggles++;
			if (Student.Pathfinding != null && !Student.Nemesis)
			{
				if (Student.Drownable)
				{
					Student.Drownable = false;
					Student.StudentManager.UpdateMe(Student.StudentID);
				}
				if (Student.ChalkDust.isPlaying)
				{
					Student.ChalkDust.Stop();
					Student.Pushable = false;
					Student.StudentManager.UpdateMe(Student.StudentID);
				}
				Student.Pathfinding.canSearch = false;
				Student.Pathfinding.canMove = false;
				Student.InvestigationPhase = 0;
				Student.InvestigationTimer = 0f;
				Student.Investigating = true;
				Student.EatingSnack = false;
				Student.SpeechLines.Stop();
				Student.ChalkDust.Stop();
				Student.DiscCheck = true;
				Student.Routine = false;
				Student.CleanTimer = 0f;
				Student.ReadPhase = 0;
				Student.StopPairing();
				if (Student.SunbathePhase > 2)
				{
					Student.SunbathePhase = 2;
				}
				if (Student.Persona != PersonaType.PhoneAddict && !Student.Sleuthing)
				{
					Student.SmartPhone.SetActive(value: false);
				}
				else if (!Student.Phoneless)
				{
					Student.SmartPhone.SetActive(value: true);
				}
				Student.OccultBook.SetActive(value: false);
				Student.Pen.SetActive(value: false);
				if (!Student.Male)
				{
					Student.Cigarette.SetActive(value: false);
					Student.Lighter.SetActive(value: false);
				}
				bool flag = false;
				if (Student.Bento.activeInHierarchy && Student.StudentID > 1 && Student.Bento.transform.parent != null)
				{
					flag = true;
				}
				Student.EmptyHands();
				bool flag2 = false;
				if (Student.CurrentAction == StudentActionType.Sunbathe && Student.SunbathePhase > 2)
				{
					Student.SunbathePhase = 2;
					flag2 = true;
				}
				if (((Student.Persona == PersonaType.PhoneAddict && !Student.Phoneless && !flag2) || Student.Persona == PersonaType.Sleuth || Student.StudentID == 20) && !Student.Phoneless)
				{
					Student.SmartPhone.SetActive(value: true);
				}
				if (flag)
				{
					GenericBentoScript component = Student.Bento.GetComponent<GenericBentoScript>();
					component.enabled = true;
					component.Prompt.enabled = true;
					Student.Bento.SetActive(value: true);
					Student.Bento.transform.parent = Student.transform;
					if (Student.Male)
					{
						Student.Bento.transform.localPosition = new Vector3(0f, 0.4266666f, -0.075f);
					}
					else
					{
						Student.Bento.transform.localPosition = new Vector3(0f, 0.461f, -0.075f);
					}
					Student.Bento.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					Student.Bento.transform.parent = null;
				}
				if (BangSnap)
				{
					Student.Yandere.NotificationManager.CustomText = Student.Name + " heard a sound.";
				}
				else
				{
					Student.Yandere.NotificationManager.CustomText = Student.Name + " heard a giggle.";
				}
				Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Student.CuriosityPhase = 0;
				Student.CuriosityTimer = 0f;
			}
			Distracted = true;
		}
		else
		{
			if (Student.InEvent || Student.Restless)
			{
				Student.Yandere.NotificationManager.CustomText = Student.Name + " is in an event right now.";
				Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			if (BangSnap)
			{
				Student.Yandere.NotificationManager.CustomText = Student.Name + " ignored a sound.";
			}
			else
			{
				Student.Yandere.NotificationManager.CustomText = Student.Name + " ignored a giggle.";
			}
			Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}
}
