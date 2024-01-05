using UnityEngine;

public class IronMaidenScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public RagdollScript Corpse;

	public StudentScript Victim;

	public PromptScript Prompt;

	public GameObject KeepInsideCollider;

	public GameObject ExteriorColliders;

	public GameObject InteriorColliders;

	public GameObject[] Blood;

	public AudioClip FemaleVoice;

	public AudioClip MaleVoice;

	public AudioClip DoorOpen;

	public AudioClip DoorSlam;

	public Transform YandereSpot;

	public Transform VictimSpot;

	public Transform[] Door;

	public AudioSource MyAudio;

	public float[] Rotation;

	public float ShakeStrength;

	public float ShoveTimer;

	public int ShovePhase;

	public bool Bloody;

	public bool Shut;

	public bool Open;

	public bool ABC;

	public UISprite CleanUpDarkness;

	public bool FadeOut;

	public bool FadeIn;

	private void Start()
	{
		ABC = GameGlobals.AlphabetMode;
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
							if (StudentManager.Students[i] != null && StudentManager.Students[i].Alive && Vector3.Distance(StudentManager.Students[i].transform.position, Prompt.Yandere.transform.position) < 1f)
							{
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
								Victim.CharacterAnimation.CrossFade(Victim.IdleAnim);
								Victim.Pathfinding.canSearch = false;
								Victim.Pathfinding.canMove = false;
								Victim.enabled = false;
								ExteriorColliders.SetActive(value: false);
								InteriorColliders.SetActive(value: false);
								ShovePhase = 1;
								ShoveTimer = 0f;
							}
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
			else
			{
				if (!Open)
				{
					MyAudio.clip = DoorOpen;
					MyAudio.Play();
					Open = true;
				}
				SpitCorpseOut();
			}
		}
		if (ShovePhase > 0)
		{
			if (ShovePhase == 1)
			{
				Prompt.Yandere.MoveTowardsTarget(YandereSpot.position);
				Prompt.Yandere.transform.rotation = Quaternion.Slerp(Prompt.Yandere.transform.rotation, YandereSpot.rotation, Time.deltaTime * 10f);
				Victim.MoveTowardsTarget(VictimSpot.position);
				Victim.transform.rotation = Quaternion.Slerp(Victim.transform.rotation, YandereSpot.rotation, Time.deltaTime * 10f);
				ShoveTimer += Time.deltaTime;
				if (ShoveTimer >= 1f)
				{
					if (Victim.Male)
					{
						MyAudio.clip = MaleVoice;
					}
					else
					{
						MyAudio.clip = FemaleVoice;
					}
					MyAudio.Play();
					Prompt.Yandere.CharacterAnimation.CrossFade("f02_pushIntoIronMaiden_00_A");
					Prompt.Yandere.MurderousActionTimer = 1f;
					if (!Victim.Male)
					{
						Victim.CharacterAnimation.CrossFade("f02_pushIntoIronMaiden_00_B");
					}
					else
					{
						Victim.CharacterAnimation.CrossFade("pushIntoIronMaiden_01_B");
					}
					ShoveTimer = 0f;
					ShovePhase++;
				}
			}
			else if (ShovePhase == 2)
			{
				Prompt.Yandere.MoveTowardsTarget(YandereSpot.position);
				Victim.MoveTowardsTarget(VictimSpot.position);
				Prompt.Yandere.transform.rotation = Quaternion.Slerp(Prompt.Yandere.transform.rotation, YandereSpot.rotation, Time.deltaTime * 10f);
				Victim.transform.rotation = Quaternion.Slerp(Victim.transform.rotation, YandereSpot.rotation, Time.deltaTime * 10f);
				ShoveTimer += Time.deltaTime;
				if (ShoveTimer >= 2f)
				{
					MyAudio.clip = DoorSlam;
					MyAudio.Play();
					Victim.CharacterAnimation.CrossFade(Victim.IdleAnim);
					ShoveTimer = 0f;
					ShovePhase++;
				}
			}
			else if (ShovePhase == 3)
			{
				Prompt.Yandere.MoveTowardsTarget(YandereSpot.position);
				Victim.MoveTowardsTarget(base.transform.position);
				Rotation[0] = Mathf.MoveTowards(Rotation[0], 0f, Time.deltaTime * 360f);
				Rotation[1] = Mathf.MoveTowards(Rotation[1], 0f, Time.deltaTime * 360f);
				Door[0].transform.localEulerAngles = new Vector3(0f, 6.5f, Rotation[0]);
				Door[1].transform.localEulerAngles = new Vector3(0f, -6.5f, Rotation[1]);
				if (Rotation[0] == 0f)
				{
					KeepInsideCollider.SetActive(value: true);
					Prompt.Label[2].text = "     Open Doors";
					Blood[0].SetActive(value: true);
					Blood[1].SetActive(value: true);
					Blood[2].SetActive(value: true);
					Bloody = true;
					TurnVictimIntoCorpse();
					Prompt.Yandere.Zoom.ShakeStrength = 1f;
					Prompt.HideButton[0] = true;
					ShoveTimer = 0f;
					Shut = true;
					ShovePhase++;
				}
			}
			else if (ShovePhase == 4 && Prompt.Yandere.CharacterAnimation["f02_pushIntoIronMaiden_00_A"].time >= Prompt.Yandere.CharacterAnimation["f02_pushIntoIronMaiden_00_A"].length)
			{
				Prompt.Yandere.CanMove = true;
				Victim = null;
			}
		}
		if (Open)
		{
			Rotation[0] = Mathf.Lerp(Rotation[0], -45f, Time.deltaTime);
			Rotation[1] = Mathf.Lerp(Rotation[1], 45f, Time.deltaTime);
			if (Rotation[0] < -44f)
			{
				Prompt.Label[2].text = "     Push Victim Inside";
				InteriorColliders.SetActive(value: false);
				Rotation[0] = -45f;
				Open = false;
				Shut = false;
			}
			Door[0].transform.localEulerAngles = new Vector3(0f, 6.5f, Rotation[0]);
			Door[1].transform.localEulerAngles = new Vector3(0f, -6.5f, Rotation[1]);
		}
		if (!Bloody || Rotation[0] != -45f)
		{
			return;
		}
		if (Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.Mop != null && Prompt.Yandere.PickUp.Mop.Bleached)
		{
			Prompt.HideButton[0] = false;
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Yandere.CanMove = false;
				FadeOut = true;
			}
			if (FadeOut)
			{
				CleanUpDarkness.alpha = Mathf.MoveTowards(CleanUpDarkness.alpha, 1f, Time.deltaTime);
				if (CleanUpDarkness.alpha == 1f)
				{
					Prompt.Yandere.PickUp.Mop.Bloodiness = 100f;
					Prompt.Yandere.PickUp.Mop.UpdateBlood();
					Blood[0].SetActive(value: false);
					Blood[1].SetActive(value: false);
					Blood[2].SetActive(value: false);
					FadeOut = false;
					FadeIn = true;
				}
			}
			if (FadeIn)
			{
				CleanUpDarkness.alpha = Mathf.MoveTowards(CleanUpDarkness.alpha, 0f, Time.deltaTime);
				if (CleanUpDarkness.alpha == 0f)
				{
					Prompt.Hide();
					Prompt.Yandere.CanMove = true;
					Prompt.HideButton[0] = true;
					Bloody = false;
				}
			}
		}
		else
		{
			Prompt.HideButton[0] = true;
		}
	}

	public void TurnVictimIntoCorpse()
	{
		Corpse = Victim.Ragdoll;
		Corpse.Student.BecomeRagdoll();
		Corpse.Student.DeathType = DeathType.Weight;
		Corpse.Student.LiquidProjector.material = Corpse.Student.BloodMaterial;
		Corpse.Student.LiquidProjector.gameObject.SetActive(value: true);
		Corpse.Student.LiquidProjector.enabled = true;
		if (Corpse.AddingToCount)
		{
			Prompt.Yandere.NearBodies--;
			Corpse.AddingToCount = false;
		}
		Prompt.Yandere.NearestCorpseID = 0;
		Prompt.Yandere.CorpseWarning = false;
		Prompt.Yandere.StudentManager.UpdateStudents();
		Corpse.transform.parent = base.transform;
		Corpse.transform.position = base.transform.position + new Vector3(0f, 0f, 0f);
		Corpse.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
		if (Corpse.Police == null)
		{
			Corpse.Police = Corpse.Student.Police;
		}
		Corpse.Police.HiddenCorpses++;
		Corpse.enabled = false;
		Corpse.Hidden = true;
		Corpse.BloodSpawnerCollider.enabled = false;
		Corpse.Prompt.MyCollider.enabled = false;
		Corpse.BloodPoolSpawner.enabled = false;
		Corpse.DisableRigidbodies();
		Corpse.Student.CharacterAnimation.enabled = true;
		Corpse.Student.CharacterAnimation.Play("f02_lockerPose_00");
		if (Corpse.Decapitated)
		{
			Corpse.Head.transform.localScale = Vector3.zero;
		}
	}

	public void SpitCorpseOut()
	{
		if (Corpse != null)
		{
			KeepInsideCollider.SetActive(value: false);
			Corpse.enabled = true;
			Corpse.gameObject.SetActive(value: true);
			Corpse.CharacterAnimation.enabled = false;
			Corpse.transform.position = base.transform.position;
			Corpse.transform.eulerAngles = new Vector3(0f, 180f, 0f);
			Corpse.transform.parent = null;
			Corpse.BloodSpawnerCollider.enabled = true;
			Corpse.Prompt.MyCollider.enabled = true;
			Corpse.BloodPoolSpawner.NearbyBlood = 0;
			Corpse.AddingToCount = false;
			Corpse.EnableRigidbodies();
			if (!Corpse.Cauterized && !Corpse.Concealed)
			{
				Corpse.BloodPoolSpawner.enabled = true;
			}
			for (int i = 0; i < Corpse.Student.FireEmitters.Length; i++)
			{
				Corpse.Student.FireEmitters[i].gameObject.SetActive(value: false);
			}
			Corpse = null;
		}
		else
		{
			Prompt.Yandere.NotificationManager.CustomText = "The doors aren't open yet.";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}
}
