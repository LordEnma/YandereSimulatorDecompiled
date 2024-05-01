using UnityEngine;

public class PickpocketScript : MonoBehaviour
{
	public PickpocketMinigameScript PickpocketMinigame;

	public StudentScript Student;

	public PromptScript Prompt;

	public UIPanel PickpocketPanel;

	public UISprite TimeBar;

	public Transform PickpocketSpot;

	public GameObject AlarmDisc;

	public GameObject Key;

	public float Timer;

	public int Frame;

	public int ID = 1;

	public bool NotNurse;

	public bool Test;

	private void Start()
	{
		if (Student.StudentID != 71)
		{
			Prompt.transform.parent.gameObject.SetActive(value: false);
			base.enabled = false;
			return;
		}
		PickpocketMinigame = Student.StudentManager.PickpocketMinigame;
		if (Student.StudentID == Student.StudentManager.NurseID)
		{
			ID = 2;
		}
		else if (ClubGlobals.GetClubClosed(Student.OriginalClub))
		{
			Prompt.transform.parent.gameObject.SetActive(value: false);
			base.enabled = false;
		}
		else
		{
			Prompt.Label[3].text = "     Steal Shed Key";
			NotNurse = true;
		}
	}

	private void Update()
	{
		if (Prompt.transform.parent != null)
		{
			if (Student.KeyStolen)
			{
				Frame++;
				if (Frame > 60)
				{
					PickpocketPanel.enabled = false;
					Prompt.enabled = false;
					Prompt.Hide();
					Key.SetActive(value: false);
					base.enabled = false;
				}
			}
			bool flag = false;
			if (Student.MyBento.Tampered && (Student.Emetic || Student.Lethal || Student.Sedated || Student.Headache))
			{
				flag = true;
			}
			if (Student.Routine && !flag)
			{
				if (Student.DistanceToDestination > 0.5f)
				{
					if (Prompt.enabled)
					{
						Prompt.Hide();
						Prompt.enabled = false;
						PickpocketPanel.enabled = false;
					}
					if (Student.Yandere.Pickpocketing && PickpocketMinigame.ID == ID)
					{
						Prompt.Yandere.Caught = true;
						PickpocketMinigame.End();
						Punish();
					}
				}
				else
				{
					PickpocketPanel.enabled = true;
					if (Student.Yandere.PickUp == null && Student.Yandere.Pursuer == null)
					{
						Prompt.enabled = true;
					}
					else
					{
						Prompt.enabled = false;
						Prompt.Hide();
					}
					if (TimeBar != null)
					{
						Timer += Time.deltaTime * Student.CharacterAnimation[Student.PatrolAnim].speed;
						TimeBar.fillAmount = 1f - Timer / Student.CharacterAnimation[Student.PatrolAnim].length;
						if (Timer > Student.CharacterAnimation[Student.PatrolAnim].length)
						{
							if (Student.Yandere.Pickpocketing && PickpocketMinigame.ID == ID)
							{
								Prompt.Yandere.Caught = true;
								PickpocketMinigame.End();
								Punish();
							}
							Timer = 0f;
						}
					}
				}
			}
			else if (Prompt.enabled)
			{
				Prompt.Hide();
				Prompt.enabled = false;
				PickpocketPanel.enabled = false;
				if (Student.Yandere.Pickpocketing && PickpocketMinigame.ID == ID)
				{
					Prompt.Yandere.Caught = true;
					PickpocketMinigame.End();
					Punish();
				}
			}
			if (Prompt.Circle[3].fillAmount == 0f)
			{
				Prompt.Circle[3].fillAmount = 1f;
				if (!Prompt.Yandere.Chased && Prompt.Yandere.Chasers == 0)
				{
					PickpocketMinigame.StartingAlerts = Prompt.Yandere.Alerts;
					PickpocketMinigame.PickpocketSpot = PickpocketSpot;
					PickpocketMinigame.NotNurse = NotNurse;
					PickpocketMinigame.Show = true;
					PickpocketMinigame.ID = ID;
					Student.Yandere.CharacterAnimation.CrossFade("f02_pickpocketing_00");
					Student.Yandere.Pickpocketing = true;
					Student.Yandere.EmptyHands();
					Student.Yandere.CanMove = false;
				}
			}
			if (PickpocketMinigame != null && PickpocketMinigame.ID == ID)
			{
				if (PickpocketMinigame.Success)
				{
					PickpocketMinigame.Success = false;
					PickpocketMinigame.ID = 0;
					Succeed();
					PickpocketPanel.enabled = false;
					Prompt.enabled = false;
					Prompt.Hide();
					Key.SetActive(value: false);
					base.enabled = false;
				}
				if (PickpocketMinigame.Failure)
				{
					PickpocketMinigame.Failure = false;
					PickpocketMinigame.ID = 0;
					Punish();
				}
			}
			if (!Student.Alive || Student.Tranquil)
			{
				base.transform.position = new Vector3(Student.transform.position.x, Student.transform.position.y + 1f, Student.transform.position.z);
				Prompt.gameObject.GetComponent<BoxCollider>().isTrigger = false;
				Prompt.gameObject.GetComponent<Rigidbody>().isKinematic = false;
				Prompt.gameObject.GetComponent<Rigidbody>().useGravity = true;
				Prompt.enabled = true;
				base.transform.parent = null;
				if (base.transform.position.x > -71f && base.transform.position.x < -61f && base.transform.position.z > -37.5f && base.transform.position.z < -27.5f)
				{
					Prompt.Yandere.NotificationManager.CustomText = "The dropped keys have been placed nearby.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					base.transform.position = new Vector3(-63f, 1f, -26.5f);
				}
			}
		}
		else if (Prompt.Circle[3].fillAmount == 0f)
		{
			Succeed();
			PickpocketPanel.enabled = false;
			Prompt.enabled = false;
			Prompt.Hide();
			Key.SetActive(value: false);
			base.enabled = false;
			base.gameObject.SetActive(value: false);
		}
	}

	private void Punish()
	{
		Debug.Log("Punishing Yandere-chan for pickpocketing.");
		Object.Instantiate(AlarmDisc, Student.Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
		if (!NotNurse && !Prompt.Yandere.Egg)
		{
			Debug.Log("A faculty member saw pickpocketing.");
			Student.Witnessed = StudentWitnessType.Theft;
			Student.SenpaiNoticed();
			Student.CameraEffects.MurderWitnessed();
			Student.Concern = 5;
		}
		else
		{
			Student.Witnessed = StudentWitnessType.Pickpocketing;
			Student.CameraEffects.Alarm();
			Student.Alarm += 200f;
		}
		Timer = 0f;
		Prompt.Hide();
		Prompt.enabled = false;
		PickpocketPanel.enabled = false;
		Student.CharacterAnimation[Student.PatrolAnim].time = 0f;
		Student.FocusOnYandere = true;
		Student.PatrolTimer = 0f;
	}

	private void Succeed()
	{
		if (ID == 1)
		{
			Student.StudentManager.ShedDoor.Prompt.Label[0].text = "     Open";
			Student.StudentManager.ShedDoor.Locked = false;
			Student.ClubManager.Padlock.SetActive(value: false);
			Student.Yandere.Inventory.ShedKey = true;
			Student.KeyStolen = true;
			if (Student.Clock.GameplayDay == 9)
			{
				Student.BountyCollider.SetActive(value: true);
			}
		}
		else
		{
			Student.StudentManager.CabinetDoor.Prompt.Label[0].text = "     Open";
			Student.StudentManager.CabinetDoor.Locked = false;
			Student.Yandere.Inventory.CabinetKey = true;
		}
		Student.Yandere.NotificationManager.CustomText = "Got the key!";
		Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
	}
}
