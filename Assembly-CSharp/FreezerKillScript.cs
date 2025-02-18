using UnityEngine;

public class FreezerKillScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public Collider FreezerRoomCollider;

	public Animation ControlPanelAnim;

	public Renderer[] FrostOverlay;

	public GameObject RoomBlocker;

	public AudioClip FemaleVoice;

	public AudioClip MaleVoice;

	public AudioClip DoorOpen;

	public Transform YandereSpot;

	public Transform VictimSpot;

	public Transform Door;

	public StudentScript Victim;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public ParticleSystem Fog;

	public float ShoveTimer;

	public float Alpha;

	public bool KilledRival;

	public bool Open;

	public bool Shut;

	public int ShovePhase;

	private void Start()
	{
		ControlPanelAnim["freezerMurderPanel"].speed = 0f;
		ControlPanelAnim.Play("freezerMurderPanel");
	}

	private void Update()
	{
		if (Prompt.Circle[2].fillAmount == 0f)
		{
			Prompt.Circle[2].fillAmount = 1f;
			if (!Shut)
			{
				if (Prompt.Yandere.Class.PhysicalGrade + Prompt.Yandere.Class.PhysicalBonus > 0)
				{
					if (!Prompt.Yandere.Chased && Prompt.Yandere.Chasers == 0)
					{
						for (int i = 2; i < 101; i++)
						{
							if (!(Victim == null))
							{
								break;
							}
							if (!(StudentManager.Students[i] != null) || !StudentManager.Students[i].Alive || !(Vector3.Distance(StudentManager.Students[i].transform.position, Prompt.Yandere.transform.position) < 1f))
							{
								continue;
							}
							if (i == 1)
							{
								Prompt.Yandere.NotificationManager.CustomText = "You would never do that!";
								Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
								continue;
							}
							if (StudentManager.Students[i].Strength == 9 || StudentManager.Students[i].Teacher)
							{
								StudentManager.Students[i].AttackReaction();
								continue;
							}
							Prompt.Yandere.Sanity -= (float)((Prompt.Yandere.Panties == 10) ? 10 : 20) * Prompt.Yandere.Numbness;
							Prompt.Yandere.CanMove = false;
							Victim = StudentManager.Students[i];
							if (i == StudentManager.RivalID)
							{
								KilledRival = true;
							}
							if (Victim.Male)
							{
								VictimSpot.transform.localPosition = new Vector3(0f, 0f, 0.6f);
							}
							Victim.CharacterAnimation.CrossFade(Victim.IdleAnim);
							Victim.FollowCountdown.gameObject.SetActive(value: false);
							Victim.MyRenderer.updateWhenOffscreen = true;
							Victim.Pathfinding.canSearch = false;
							Victim.Pathfinding.canMove = false;
							Victim.SmartPhone.SetActive(value: false);
							Victim.enabled = false;
							Victim.Hearts.Stop();
							ShovePhase = 1;
							ShoveTimer = 0f;
							Prompt.enabled = false;
							Prompt.Hide();
						}
						if (Victim == null)
						{
							Prompt.Yandere.NotificationManager.CustomText = "Bring a victim here first.";
							Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "Bring a victim here first.";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "You lack the physical strength";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			else if (!Open)
			{
				MyAudio.clip = DoorOpen;
				MyAudio.Play();
				Open = true;
			}
		}
		if (ShovePhase <= 0)
		{
			return;
		}
		if (ShovePhase == 1)
		{
			Prompt.Yandere.MoveTowardsTarget(YandereSpot.position);
			Prompt.Yandere.transform.rotation = Quaternion.Slerp(Prompt.Yandere.transform.rotation, YandereSpot.rotation, Time.deltaTime * 10f);
			Victim.MoveTowardsTarget(VictimSpot.position);
			Victim.transform.rotation = Quaternion.Slerp(Victim.transform.rotation, YandereSpot.rotation, Time.deltaTime * 10f);
			ShoveTimer += Time.deltaTime;
			if (ShoveTimer >= 1f)
			{
				TeleportStudentsOutOfRoom();
				if (Victim.Male)
				{
					MyAudio.clip = MaleVoice;
				}
				else
				{
					MyAudio.clip = FemaleVoice;
				}
				MyAudio.Play();
				Prompt.Yandere.CharacterAnimation.CrossFade("f02_freezerMurder_A");
				Prompt.Yandere.MurderousActionTimer = 10f;
				if (!Victim.Male)
				{
					Victim.CharacterAnimation.CrossFade("f02_freezerMurder_B");
				}
				else
				{
					Victim.CharacterAnimation.CrossFade("freezerMurder_B");
				}
				ControlPanelAnim["freezerMurderPanel"].speed = 1f;
				ControlPanelAnim["freezerMurderPanel"].time = 0f;
				ControlPanelAnim.Play("freezerMurderPanel");
				RoomBlocker.SetActive(value: true);
				ShoveTimer = 0f;
				ShovePhase++;
			}
		}
		else if (ShovePhase == 2)
		{
			ShoveTimer += Time.deltaTime;
			if (ShoveTimer >= 3f)
			{
				Door.transform.localPosition = Vector3.Lerp(Door.transform.localPosition, new Vector3(0.833333f, 0f, 0f), Time.deltaTime * 3f);
			}
			if (ShoveTimer >= 7f)
			{
				AddFrost();
			}
			if (ShoveTimer >= 10f)
			{
				Prompt.Yandere.MurderousActionTimer = 0f;
				Victim.MyController.enabled = false;
				Victim.Prompt.enabled = false;
				Victim.Prompt.Hide();
				Prompt.Yandere.CanMove = true;
				ShovePhase++;
			}
		}
		else if (ShovePhase == 3)
		{
			ShoveTimer += Time.deltaTime;
			AddFrost();
			if (ShoveTimer >= 28.86667f)
			{
				Victim.BecomeRagdoll();
				Victim.Ragdoll.BloodPoolSpawner.enabled = false;
				Victim.DeathCause = 12;
				Victim.DeathType = DeathType.Frozen;
				Debug.Log("Just froze the current rival to death. Setting EndOfDay.RivalEliminationMethod to ''Accident''.");
				Prompt.Yandere.StudentManager.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Accident;
				Fog.Stop();
				base.enabled = false;
				ShovePhase = 0;
			}
		}
	}

	private void AddFrost()
	{
		Alpha += Time.deltaTime * 0.05f;
		FrostOverlay[1].materials[0].color = new Color(1f, 1f, 1f, Alpha);
		FrostOverlay[1].materials[1].color = new Color(1f, 1f, 1f, Alpha);
		FrostOverlay[2].materials[0].color = new Color(1f, 1f, 1f, Alpha);
		FrostOverlay[2].materials[1].color = new Color(1f, 1f, 1f, Alpha);
		Victim.FrostProjector.enabled = true;
		Victim.FrostProjector.material.color = new Color(1f, 1f, 1f, Alpha);
		if (!Fog.isPlaying)
		{
			Fog.Play();
		}
	}

	private void TeleportStudentsOutOfRoom()
	{
		StudentScript[] students = StudentManager.Students;
		foreach (StudentScript studentScript in students)
		{
			if (studentScript != null && studentScript != Victim && FreezerRoomCollider.bounds.Contains(studentScript.transform.position))
			{
				studentScript.transform.position = new Vector3(24f, 8f, -3f);
			}
		}
		Physics.SyncTransforms();
	}
}
