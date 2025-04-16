using UnityEngine;

public class IncineratorScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public ClockScript Clock;

	public Transform DumpPointForStudents;

	public Transform DumpPoint;

	public Transform RightDoor;

	public Transform LeftDoor;

	public AudioClip IncineratorActivate;

	public AudioClip IncineratorClose;

	public AudioClip IncineratorOpen;

	public GameObject OutOfOrderSign;

	public AudioSource FlameSound;

	public AudioSource MyAudio;

	public ParticleSystem Flames;

	public ParticleSystem Smoke;

	public GameObject Panel;

	public UILabel TimeLabel;

	public UISprite Circle;

	public bool YandereHoldingEvidence;

	public bool ActivateAfterClosing;

	public bool CannotIncinerate;

	public bool DoNotPlaySound;

	public bool Animate;

	public bool Ready;

	public bool Open;

	public int ClothingWithRedPaint;

	public int DestroyedEvidence;

	public int BloodyClothing;

	public int BloodyWeapons;

	public int HiddenCorpses;

	public int MurderWeapons;

	public int BodyParts;

	public int Contents;

	public int Corpses;

	public int Victims;

	public int Limbs;

	public int ID;

	public float OpenTimer;

	public float Timer;

	public int[] EvidenceList;

	public int[] CorpseList;

	public int[] VictimList;

	public int[] LimbList;

	public int[] ConfirmedDead;

	public Texture EightiesTexture;

	public Renderer MyRenderer;

	private void Start()
	{
		Panel.SetActive(value: false);
		Prompt.enabled = true;
		MyAudio = GetComponent<AudioSource>();
		if (GameGlobals.Eighties)
		{
			MyRenderer.material.mainTexture = EightiesTexture;
		}
	}

	public void ReturnFromSave()
	{
	}

	private void Update()
	{
		if (Animate)
		{
			if (Open)
			{
				if (RightDoor.transform.localEulerAngles.y == 0f)
				{
					MyAudio.clip = IncineratorOpen;
					MyAudio.Play();
				}
				RightDoor.transform.localEulerAngles = new Vector3(RightDoor.transform.localEulerAngles.x, Mathf.Lerp(RightDoor.transform.localEulerAngles.y, 135f, Time.deltaTime * 5f), RightDoor.transform.localEulerAngles.z);
				LeftDoor.transform.localEulerAngles = new Vector3(LeftDoor.transform.localEulerAngles.x, Mathf.Lerp(LeftDoor.transform.localEulerAngles.y, 135f, Time.deltaTime * 5f), LeftDoor.transform.localEulerAngles.z);
				if (RightDoor.transform.localEulerAngles.y > 134f)
				{
					RightDoor.transform.localEulerAngles = new Vector3(RightDoor.transform.localEulerAngles.x, 135f, RightDoor.transform.localEulerAngles.z);
				}
			}
			else
			{
				RightDoor.transform.localEulerAngles = new Vector3(RightDoor.transform.localEulerAngles.x, Mathf.MoveTowards(RightDoor.transform.localEulerAngles.y, 0f, Time.deltaTime * 360f), RightDoor.transform.localEulerAngles.z);
				LeftDoor.transform.localEulerAngles = new Vector3(LeftDoor.transform.localEulerAngles.x, Mathf.MoveTowards(LeftDoor.transform.localEulerAngles.y, 0f, Time.deltaTime * 360f), LeftDoor.transform.localEulerAngles.z);
				if (RightDoor.transform.localEulerAngles.y < 1f)
				{
					if (!DoNotPlaySound)
					{
						MyAudio.clip = IncineratorClose;
						MyAudio.Play();
					}
					DoNotPlaySound = false;
					Animate = false;
					RightDoor.transform.localEulerAngles = new Vector3(RightDoor.transform.localEulerAngles.x, 0f, RightDoor.transform.localEulerAngles.z);
					LeftDoor.transform.localEulerAngles = new Vector3(LeftDoor.transform.localEulerAngles.x, 0f, LeftDoor.transform.localEulerAngles.z);
					Contents++;
				}
			}
		}
		if (OpenTimer > 0f)
		{
			OpenTimer -= Time.deltaTime;
			if (OpenTimer <= 1f)
			{
				Open = false;
			}
			if (OpenTimer <= 0f)
			{
				Prompt.enabled = true;
			}
		}
		else
		{
			if (Timer > 0f && !Smoke.isPlaying)
			{
				Panel.SetActive(value: true);
				Flames.Play();
				Smoke.Play();
				Prompt.Hide();
				Prompt.enabled = false;
			}
			if (!Smoke.isPlaying)
			{
				YandereHoldingEvidence = Yandere.Ragdoll != null;
				if (!YandereHoldingEvidence)
				{
					if (Yandere.PickUp != null)
					{
						YandereHoldingEvidence = Yandere.PickUp.Evidence || Yandere.PickUp.Garbage;
					}
					else
					{
						YandereHoldingEvidence = false;
					}
				}
				if (!YandereHoldingEvidence)
				{
					if (Yandere.EquippedWeapon != null)
					{
						if (Yandere.EquippedWeapon.Bloody || Yandere.EquippedWeapon.MurderWeapon)
						{
							YandereHoldingEvidence = true;
						}
					}
					else
					{
						YandereHoldingEvidence = false;
					}
				}
				if (!YandereHoldingEvidence)
				{
					if (!Prompt.HideButton[3])
					{
						Prompt.HideButton[3] = true;
					}
				}
				else if (Prompt.HideButton[3])
				{
					Prompt.HideButton[3] = false;
				}
				if ((Yandere.Chased || Yandere.Chasers > 0 || !YandereHoldingEvidence) && !Prompt.HideButton[3])
				{
					Prompt.HideButton[3] = true;
				}
				if (Ready)
				{
					if (!Smoke.isPlaying)
					{
						if (CannotIncinerate)
						{
							Prompt.HideButton[0] = true;
						}
						if (!CannotIncinerate && Prompt.HideButton[0])
						{
							Prompt.HideButton[0] = false;
						}
					}
					else if (!Prompt.HideButton[0])
					{
						Prompt.HideButton[0] = true;
					}
				}
			}
		}
		if (Prompt.Circle[3].fillAmount == 0f)
		{
			Prompt.Circle[3].fillAmount = 1f;
			if (Yandere.Ragdoll != null)
			{
				if (Yandere.Dragging)
				{
					Yandere.NotificationManager.CustomText = "Must be carrying, not dragging.";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					Yandere.EmptyHands();
					Yandere.CurrentRagdoll.Prompt.Circle[3].fillAmount = 0f;
					DoNotPlaySound = true;
				}
				else
				{
					RagdollScript component = Yandere.Ragdoll.GetComponent<RagdollScript>();
					Yandere.CharacterAnimation.CrossFade(Yandere.Carrying ? "f02_carryIdleA_00" : "f02_dragIdle_00");
					Yandere.Incinerator = this;
					Yandere.YandereVision = false;
					Yandere.CanMove = false;
					Yandere.Dumping = true;
					Prompt.Hide();
					Prompt.enabled = false;
					Victims++;
					VictimList[Victims] = component.StudentID;
					Open = true;
				}
			}
			if (Yandere.PickUp != null)
			{
				Debug.Log("The " + Yandere.PickUp.gameObject.name + " that Yandere-chan was carrying is now being dumped into the incinerator.");
				if (Yandere.PickUp.BodyPart != null)
				{
					Limbs++;
					LimbList[Limbs] = Yandere.PickUp.GetComponent<BodyPartScript>().StudentID;
					if (Yandere.PickUp.GetComponent<BodyPartScript>().Type == 7)
					{
						BodyParts++;
					}
				}
				Yandere.PickUp.Incinerator = this;
				Yandere.PickUp.Dumped = true;
				Yandere.PickUp.Drop();
				Prompt.Hide();
				Prompt.enabled = false;
				OpenTimer = 2f;
				Ready = true;
				Open = true;
			}
			WeaponScript equippedWeapon = Yandere.EquippedWeapon;
			if (equippedWeapon != null)
			{
				DestroyedEvidence++;
				EvidenceList[DestroyedEvidence] = equippedWeapon.WeaponID;
				equippedWeapon.InsideIncinerator = true;
				equippedWeapon.Incinerator = this;
				equippedWeapon.Dumped = true;
				equippedWeapon.Drop();
				Prompt.Hide();
				Prompt.enabled = false;
				OpenTimer = 2f;
				Ready = true;
				Open = true;
			}
			Animate = true;
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			int num = 0;
			for (ID = 1; ID < Limbs + 1; ID++)
			{
				if (LimbList[ID] == Yandere.StudentManager.RivalID)
				{
					num++;
					if (num == 6)
					{
						Yandere.StudentManager.Police.EndOfDay.RivalDismemberedAndIncinerated = true;
						Debug.Log("The player dismembered and incinerated Osana.");
					}
				}
			}
			Prompt.Circle[0].fillAmount = 1f;
			Panel.SetActive(value: true);
			Timer = 60f;
			MyAudio.clip = IncineratorActivate;
			MyAudio.Play();
			Flames.Play();
			Smoke.Play();
			Prompt.Hide();
			Prompt.enabled = false;
			Debug.Log("Incinerating " + BloodyClothing + " bloody clothing.");
			Debug.Log("Incinerating " + BloodyWeapons + " bloody weapons.");
			Debug.Log("Incinerating " + MurderWeapons + " murder weapons.");
			Yandere.Police.IncineratedWeapons += BloodyWeapons;
			Yandere.Police.BloodyClothing -= BloodyClothing;
			Yandere.Police.MurderWeapons -= MurderWeapons;
			Yandere.Police.BloodyWeapons -= BloodyWeapons;
			Yandere.Police.HiddenCorpses -= HiddenCorpses;
			Yandere.Police.BodyParts -= BodyParts;
			Yandere.Police.Corpses -= Corpses;
			if (Yandere.Police.BloodyWeapons < 0)
			{
				Yandere.Police.BloodyWeapons = 0;
			}
			Yandere.Police.RedPaintClothing -= ClothingWithRedPaint;
			if (Yandere.Police.SuicideScene && Yandere.Police.Corpses == 1)
			{
				Yandere.Police.MurderScene = false;
			}
			if (Yandere.Police.Corpses == 0)
			{
				Yandere.Police.MurderScene = false;
			}
			BloodyClothing = 0;
			BloodyWeapons = 0;
			HiddenCorpses = 0;
			MurderWeapons = 0;
			BodyParts = 0;
			Corpses = 0;
			for (ID = 0; ID < 101; ID++)
			{
				if (Yandere.StudentManager.Students[CorpseList[ID]] != null)
				{
					Yandere.StudentManager.Students[CorpseList[ID]].Ragdoll.Disposed = true;
					ConfirmedDead[ID] = CorpseList[ID];
					if (Yandere.StudentManager.Students[CorpseList[ID]].Ragdoll.Drowned)
					{
						Yandere.Police.DrownVictims--;
					}
				}
			}
			if (Yandere.StudentManager.Students[Yandere.StudentManager.RivalID] != null && Yandere.StudentManager.Students[Yandere.StudentManager.RivalID].Ragdoll.Disposed)
			{
				Debug.Log("Just incinerated the current rival's corpse. Setting EndOfDay.RivalEliminationMethod to ''Vanished''.");
				Yandere.StudentManager.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Vanished;
			}
			Yandere.StudentManager.UpdateStudents();
			Yandere.WeaponManager.IncinerateWeapons();
			Debug.Log("Now firing the ForgetAboutTrash() function.");
			Yandere.StudentManager.ForgetAboutTrash();
		}
		if (Smoke.isPlaying)
		{
			Timer -= Time.deltaTime * (Clock.TimeSpeed / 60f);
			FlameSound.volume += Time.deltaTime;
			Circle.fillAmount = 1f - Timer / 60f;
			if (Timer <= 0f)
			{
				Finish();
			}
		}
		else
		{
			FlameSound.volume -= Time.deltaTime;
		}
		if (Panel.activeInHierarchy)
		{
			float num2 = Mathf.CeilToInt(Timer * 60f);
			float num3 = Mathf.Floor(num2 / 60f);
			float num4 = Mathf.RoundToInt(num2 % 60f);
			TimeLabel.text = $"{num3:00}:{num4:00}";
		}
	}

	public void SetVictimsMissing()
	{
		int[] confirmedDead = ConfirmedDead;
		for (int i = 0; i < confirmedDead.Length; i++)
		{
			int num = confirmedDead[i];
			if (num > 0)
			{
				Debug.Log("Student #" + num + " was incinerated and is now considered ''missing'.");
				StudentGlobals.SetStudentMissing(num, value: true);
			}
		}
	}

	public void DumpGarbageBag(PickUpScript PickUp)
	{
		Debug.Log("A garbage bag was dumped into the incinerator!");
		Limbs++;
		LimbList[Limbs] = PickUp.GetComponent<BodyPartScript>().StudentID;
		PickUp.Incinerator = this;
		PickUp.Dumped = true;
		PickUp.Drop();
		Prompt.Hide();
		Prompt.enabled = false;
		OpenTimer = 2f;
		Animate = true;
		Ready = true;
		Open = true;
	}

	public void Finish()
	{
		Prompt.HideButton[0] = true;
		Prompt.enabled = true;
		Panel.SetActive(value: false);
		Ready = false;
		Timer = 0f;
		Flames.Stop();
		Smoke.Stop();
	}
}
