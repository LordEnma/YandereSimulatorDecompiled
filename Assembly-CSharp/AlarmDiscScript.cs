using UnityEngine;

public class AlarmDiscScript : MonoBehaviour
{
	public AudioClip[] LongFemaleScreams;

	public AudioClip[] LongMaleScreams;

	public AudioClip[] FemaleScreams;

	public AudioClip[] MaleScreams;

	public AudioClip[] DelinquentScreams;

	public StudentScript Originator;

	public RadioScript SourceRadio;

	public StudentScript Student;

	public bool FocusOnYandere;

	public bool StudentIsBusy;

	public bool Delinquent;

	public bool NoScream;

	public bool Shocking;

	public bool Persist;

	public bool Silent;

	public bool Radio;

	public bool Loud;

	public bool Male;

	public bool Long;

	public float Hesitation = 1f;

	public int Frame;

	private void Start()
	{
		Vector3 localScale = base.transform.localScale;
		localScale.x *= 2f - SchoolGlobals.SchoolAtmosphere;
		localScale.z = localScale.x;
		base.transform.localScale = localScale;
		if (Loud)
		{
			base.transform.localScale *= 3f;
			Debug.Log("Alarming death! Alarm Disc scale is thrice as big as normal!");
		}
	}

	private void Update()
	{
		if (Frame > 0)
		{
			Object.Destroy(base.gameObject);
		}
		else if (!NoScream && !Silent)
		{
			if (!Long)
			{
				if (Originator != null)
				{
					Male = Originator.Male;
				}
				if (!Male)
				{
					PlayClip(FemaleScreams[Random.Range(0, FemaleScreams.Length)], base.transform.position);
				}
				else if (Delinquent)
				{
					PlayClip(DelinquentScreams[Random.Range(0, DelinquentScreams.Length)], base.transform.position);
				}
				else
				{
					PlayClip(MaleScreams[Random.Range(0, MaleScreams.Length)], base.transform.position);
				}
			}
			else if (!Male)
			{
				PlayClip(LongFemaleScreams[Random.Range(0, LongFemaleScreams.Length)], base.transform.position);
			}
			else
			{
				PlayClip(LongMaleScreams[Random.Range(0, LongMaleScreams.Length)], base.transform.position);
			}
		}
		Frame++;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			Student = other.gameObject.GetComponent<StudentScript>();
			if (Student != null && Student.enabled && Student.DistractionSpot != new Vector3(base.transform.position.x, Student.transform.position.y, base.transform.position.z))
			{
				if (!Persist)
				{
					Object.Destroy(Student.Giggle);
				}
				Student.InvestigationTimer = 0f;
				Student.InvestigationPhase = 0;
				Student.Investigating = false;
				Student.DiscCheck = false;
				Student.VisionDistance += 1f;
				if (Loud)
				{
					Student.VisionDistance += 4f;
				}
				Student.ChalkDust.Stop();
				Student.CleanTimer = 0f;
				if (!Radio)
				{
					if (Student != Originator)
					{
						if (Student.Clock.Period == 3 && Student.BusyAtLunch)
						{
							StudentIsBusy = true;
						}
						if ((Student.StudentID == 47 || Student.StudentID == 49) && Student.StudentManager.ConvoManager.BothCharactersInPosition)
						{
							StudentIsBusy = true;
						}
						if (Student.StudentID == 7 && Student.Hurry)
						{
							Student.Distracted = false;
						}
						if (Student.StudentID == Student.StudentManager.RivalID || Student.StudentID == 1)
						{
							_ = Student.CurrentAction;
							_ = 10;
						}
						if ((!Student.TurnOffRadio && Student.Alive && !Student.Blind && !Student.Pushed && !Student.Dying && !Student.Alarmed && !Student.Guarding && !Student.Wet && !Student.Slave && !Student.CheckingNote && !Student.WitnessedMurder && !Student.WitnessedCorpse && !Student.Emetic && !Student.Confessing && !StudentIsBusy && !Student.FocusOnYandere && !Student.Fleeing && !Student.Shoving && !Student.SentHome && Student.ClubActivityPhase < 16 && !Student.Vomiting && !Student.Lethal && !Student.Headache && !Student.Sedated && !Student.SenpaiWitnessingRivalDie && !Student.Hunted && !Student.Drowned && !Student.DramaticReaction && !Student.Yandere.Chased && !Student.Hunting && !Student.ImmuneToLaughter && !Student.ListeningToReport && !Student.Distracted && !Student.RetreivingMedicine) || (Student.Persona == PersonaType.Protective && Originator != null && Originator.StudentID == 11 && !Student.Hunted && !Student.Emetic && !Student.Headache))
						{
							_ = Student.Male;
							if (!Student.Struggling)
							{
								Student.CharacterAnimation.CrossFade(Student.LeanAnim);
							}
							if (Originator != null)
							{
								Debug.Log(Student.Name + " just heard an alarm disc that originated from " + Originator.Name + ".");
								Student.FocusOnYandere = false;
								if (Originator.WitnessedMurder)
								{
									Debug.Log(Originator.Name + " witnessed murder, and so " + Student.Name + " should look towards Yandere-chan.");
									Student.DistractionSpot = new Vector3(base.transform.position.x, Student.Yandere.transform.position.y, base.transform.position.z);
									Student.FocusOnYandere = true;
								}
								else if (Originator.Hunting)
								{
									Debug.Log(Originator.Name + " is a mind-broken slave! People should be staring.");
									Student.DistractionSpot = new Vector3(base.transform.position.x, Originator.transform.position.y, base.transform.position.z);
									Student.FocusOnStudent = true;
									Student.WeirdStudent = Originator.transform;
									Student.CharacterAnimation.CrossFade(Student.LeanAnim);
								}
								else if (Originator.Corpse == null)
								{
									Debug.Log("Originator didn't see a corpse.");
									Student.DistractionSpot = new Vector3(base.transform.position.x, Student.transform.position.y, base.transform.position.z);
								}
								else
								{
									Debug.Log(Student.Name + " heard a scream from " + Originator?.ToString() + ", who witnessed a corpse. So, " + Student.Name + " really should be looking towards that corpse.");
									Student.DistractionSpot = new Vector3(Originator.Corpse.transform.position.x, Student.transform.position.y, Originator.Corpse.transform.position.z);
								}
							}
							else
							{
								Student.DistractionSpot = new Vector3(base.transform.position.x, Student.transform.position.y, base.transform.position.z);
							}
							Student.DiscCheck = true;
							Debug.Log(Student.Name + "'s ''DiskCheck'' was just set to ''true''.");
							if (Shocking)
							{
								Student.Hesitation = 0.5f;
							}
							Student.Alarm = 200f;
							if (Originator != null && Originator.Attacked)
							{
								Debug.Log(Originator.Name + " spawned an Alarm Disc because they were attacked.");
							}
							if (Student.StudentID == 10 && Originator != null && Originator.StudentID == 11 && Originator.Attacked)
							{
								Debug.Log("Raibaru just became aware that Yandere-chan committed murder.");
								Student.AwareOfMurder = true;
								Student.AmnesiaTimer = 0f;
								Student.GoAwayTimer = 0f;
								Student.Distracted = false;
								Student.GoAway = false;
							}
							if (!NoScream)
							{
								Debug.Log("This alarm disc had a scream attached to it.");
								Student.Giggle = null;
								InvestigateScream();
							}
							if (FocusOnYandere)
							{
								Student.FocusOnYandere = true;
							}
							if (Hesitation != 1f)
							{
								Student.Hesitation = Hesitation;
							}
							if (Student.Talking)
							{
								Student.DialogueWheel.End();
							}
						}
					}
				}
				else
				{
					if (Student.Giggle != null)
					{
						Student.StopInvestigating();
					}
					if (!Student.Nemesis && Student.Alive && !Student.Dying && !Student.Guarding && !Student.Alarmed && !Student.Wet && !Student.Slave && !Student.Headache && !Student.WitnessedMurder && !Student.WitnessedCorpse && !Student.Lethal && !Student.InEvent && !Student.Following && !Student.Distracting && !Student.GoAway && Student.Routine && !Student.CheckingNote && !Student.SentHome)
					{
						if (Student.CharacterAnimation != null)
						{
							Student.AnnoyedByRadio++;
							if (SourceRadio.Victim == null)
							{
								if (Student.StudentManager.LockerRoomArea.bounds.Contains(base.transform.position) || Student.StudentManager.WestBathroomArea.bounds.Contains(base.transform.position) || Student.StudentManager.EastBathroomArea.bounds.Contains(base.transform.position) || (Student.Club != ClubType.Delinquent && Student.StudentManager.IncineratorArea.bounds.Contains(base.transform.position)) || Student.StudentManager.HeadmasterArea.bounds.Contains(base.transform.position) || (Student.Rival && Student.Actions[Student.Phase] == StudentActionType.SitAndTakeNotes))
								{
									if (Student.Yandere.NotificationManager.NotificationParent.childCount < 5)
									{
										Student.Yandere.NotificationManager.CustomText = Student.Name + " ignored a radio.";
										if (Student.Yandere.NotificationManager.CustomText != Student.Yandere.NotificationManager.PreviousText)
										{
											Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
										}
									}
								}
								else
								{
									Debug.Log(Student.Name + " has just been alarmed by a radio!");
									Student.CharacterAnimation.CrossFade(Student.LeanAnim);
									Student.Pathfinding.canSearch = false;
									Student.Pathfinding.canMove = false;
									Student.EatingSnack = false;
									Student.Radio = SourceRadio;
									Student.TurnOffRadio = true;
									Student.Routine = false;
									Student.GoAway = false;
									bool flag = false;
									if (Student.CurrentAction == StudentActionType.SitAndEatBento && Student.Bento.activeInHierarchy && Student.StudentID > 1)
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
										if (!Student.MyBento.Tampered)
										{
											Student.MyBento.enabled = true;
											Student.MyBento.Prompt.enabled = true;
										}
										Student.Bento.SetActive(value: true);
										Student.Bento.transform.parent = Student.transform;
										if (Student.Male)
										{
											Student.Bento.transform.localPosition = new Vector3(0f, 0.4266666f, -0.075f);
										}
										else
										{
											Debug.Log("This female student was distracted by a giggle, so her bento has teleported.");
											Student.Bento.transform.localPosition = new Vector3(0f, 0.461f, -0.075f);
										}
										Student.Bento.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
										Student.Bento.transform.parent = null;
									}
									Student.SpeechLines.Stop();
									Student.ChalkDust.Stop();
									Student.CleanTimer = 0f;
									Student.RadioTimer = 0f;
									Student.ReadPhase = 0;
									SourceRadio.Victim = Student;
									if (Student.StudentID == 97 && SchemeGlobals.GetSchemeStage(5) == 3)
									{
										SchemeGlobals.SetSchemeStage(5, 4);
										Student.Yandere.PauseScreen.Schemes.UpdateInstructions();
										base.enabled = false;
									}
									Student.Yandere.NotificationManager.CustomText = Student.Name + " hears the radio.";
									Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
								}
							}
						}
					}
					else if (Student.Yandere.NotificationManager.NotificationParent.childCount < 5)
					{
						if (Student.Routine)
						{
							Student.Yandere.NotificationManager.CustomText = Student.Name + " is in an event right now!";
							Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
						Student.Yandere.NotificationManager.CustomText = Student.Name + " ignored a radio.";
						if (Student.Yandere.NotificationManager.CustomText != Student.Yandere.NotificationManager.PreviousText)
						{
							Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
				}
			}
		}
		Student = null;
	}

	private void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = 5f;
		audioSource.maxDistance = 10f;
		audioSource.spatialBlend = 1f;
		audioSource.volume = 0.5f;
		if (Student != null)
		{
			Student.DeathScream = gameObject;
		}
	}

	private void InvestigateScream()
	{
		Debug.Log(Student.Name + " just heard a scream.");
		if (Student.Clock.Period == 3 && Student.BusyAtLunch)
		{
			StudentIsBusy = true;
		}
		if (!Student.YandereVisible && !Student.Distracted && !Student.Wet && !Student.Slave && !Student.WitnessedMurder && !Student.WitnessedCorpse && !Student.Headache && !Student.InEvent && !Student.Following && !Student.Confessing && !Student.Meeting && !Student.TurnOffRadio && !Student.Fleeing && !Student.Distracting && !Student.GoAway && !Student.FocusOnYandere && !StudentIsBusy && Student.Actions[Student.Phase] != StudentActionType.Teaching && Student.Actions[Student.Phase] != StudentActionType.SitAndTakeNotes && Student.Actions[Student.Phase] != StudentActionType.Graffiti && Student.Actions[Student.Phase] != StudentActionType.Bully)
		{
			Debug.Log(Student.Name + " should be going to investigate that scream now.");
			Student.CharacterAnimation.CrossFade(Student.IdleAnim);
			GameObject giggle = Object.Instantiate(Student.EmptyGameObject, new Vector3(base.transform.position.x, Student.transform.position.y, base.transform.position.z), Quaternion.identity);
			Student.Giggle = giggle;
			if (Student.Pathfinding != null && !Student.Nemesis)
			{
				Debug.Log(Student.Name + " just heard a scream, so their ''DiskCheck'' was set to ''true''.");
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
				Student.EmptyHands();
				Student.HeardScream = true;
				Student.Drownable = false;
				Student.StudentManager.UpdateMe(Student.StudentID);
			}
		}
		else
		{
			Debug.Log(Student.Name + " has chosen to ignore a scream.");
		}
	}
}
