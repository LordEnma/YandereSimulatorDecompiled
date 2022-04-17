using System;
using UnityEngine;

// Token: 0x020000C4 RID: 196
public class AlarmDiscScript : MonoBehaviour
{
	// Token: 0x060009A7 RID: 2471 RVA: 0x0004E5A8 File Offset: 0x0004C7A8
	private void Start()
	{
		Vector3 localScale = base.transform.localScale;
		localScale.x *= 2f - SchoolGlobals.SchoolAtmosphere;
		localScale.z = localScale.x;
		base.transform.localScale = localScale;
	}

	// Token: 0x060009A8 RID: 2472 RVA: 0x0004E5F0 File Offset: 0x0004C7F0
	private void Update()
	{
		if (this.Frame > 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else if (!this.NoScream)
		{
			if (!this.Long)
			{
				if (this.Originator != null)
				{
					this.Male = this.Originator.Male;
				}
				if (!this.Male)
				{
					this.PlayClip(this.FemaleScreams[UnityEngine.Random.Range(0, this.FemaleScreams.Length)], base.transform.position);
				}
				else if (this.Delinquent)
				{
					this.PlayClip(this.DelinquentScreams[UnityEngine.Random.Range(0, this.DelinquentScreams.Length)], base.transform.position);
				}
				else
				{
					this.PlayClip(this.MaleScreams[UnityEngine.Random.Range(0, this.MaleScreams.Length)], base.transform.position);
				}
			}
			else if (!this.Male)
			{
				this.PlayClip(this.LongFemaleScreams[UnityEngine.Random.Range(0, this.LongFemaleScreams.Length)], base.transform.position);
			}
			else
			{
				this.PlayClip(this.LongMaleScreams[UnityEngine.Random.Range(0, this.LongMaleScreams.Length)], base.transform.position);
			}
		}
		this.Frame++;
	}

	// Token: 0x060009A9 RID: 2473 RVA: 0x0004E73C File Offset: 0x0004C93C
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Student = other.gameObject.GetComponent<StudentScript>();
			if (this.Student != null && this.Student.enabled && this.Student.DistractionSpot != new Vector3(base.transform.position.x, this.Student.transform.position.y, base.transform.position.z))
			{
				UnityEngine.Object.Destroy(this.Student.Giggle);
				this.Student.InvestigationTimer = 0f;
				this.Student.InvestigationPhase = 0;
				this.Student.Investigating = false;
				this.Student.DiscCheck = false;
				this.Student.VisionDistance += 1f;
				this.Student.ChalkDust.Stop();
				this.Student.CleanTimer = 0f;
				if (!this.Radio)
				{
					if (this.Student != this.Originator)
					{
						if (this.Student.Clock.Period == 3 && this.Student.BusyAtLunch)
						{
							this.StudentIsBusy = true;
						}
						if ((this.Student.StudentID == 47 || this.Student.StudentID == 49) && this.Student.StudentManager.ConvoManager.Confirmed)
						{
							this.StudentIsBusy = true;
						}
						if (this.Student.StudentID == 7 && this.Student.Hurry)
						{
							this.Student.Distracted = false;
						}
						if (this.Student.StudentID == this.Student.StudentManager.RivalID || this.Student.StudentID == 1)
						{
							StudentActionType currentAction = this.Student.CurrentAction;
						}
						if ((!this.Student.TurnOffRadio && this.Student.Alive && !this.Student.Pushed && !this.Student.Dying && !this.Student.Alarmed && !this.Student.Guarding && !this.Student.Wet && !this.Student.Slave && !this.Student.CheckingNote && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.Emetic && !this.Student.Confessing && !this.StudentIsBusy && !this.Student.FocusOnYandere && !this.Student.Fleeing && !this.Student.Shoving && !this.Student.SentHome && this.Student.ClubActivityPhase < 16 && !this.Student.Vomiting && !this.Student.Lethal && !this.Student.Headache && !this.Student.Sedated && !this.Student.SenpaiWitnessingRivalDie && !this.Student.Hunted && !this.Student.Drowned && !this.Student.DramaticReaction && !this.Student.Blind && !this.Student.Yandere.Chased && !this.Student.ImmuneToLaughter && !this.Student.ListeningToReport) || (this.Student.Persona == PersonaType.Protective && this.Originator != null && this.Originator.StudentID == 11 && !this.Student.Hunted && !this.Student.Emetic))
						{
							bool male = this.Student.Male;
							if (!this.Student.Struggling)
							{
								this.Student.Character.GetComponent<Animation>().CrossFade(this.Student.LeanAnim);
							}
							if (this.Originator != null)
							{
								if (this.Originator.WitnessedMurder)
								{
									this.Student.DistractionSpot = new Vector3(base.transform.position.x, this.Student.Yandere.transform.position.y, base.transform.position.z);
								}
								else if (this.Originator.Corpse == null)
								{
									this.Student.DistractionSpot = new Vector3(base.transform.position.x, this.Student.transform.position.y, base.transform.position.z);
								}
								else
								{
									this.Student.DistractionSpot = new Vector3(this.Originator.Corpse.transform.position.x, this.Student.transform.position.y, this.Originator.Corpse.transform.position.z);
								}
							}
							else
							{
								this.Student.DistractionSpot = new Vector3(base.transform.position.x, this.Student.transform.position.y, base.transform.position.z);
							}
							this.Student.DiscCheck = true;
							if (this.Shocking)
							{
								this.Student.Hesitation = 0.5f;
							}
							this.Student.Alarm = 200f;
							if (this.Originator != null && this.Originator.Attacked)
							{
								Debug.Log(this.Originator.Name + " spawned an Alarm Disc because they were attacked.");
							}
							if (this.Student.StudentID == 10 && this.Originator != null && this.Originator.StudentID == 11 && this.Originator.Attacked)
							{
								Debug.Log("Raibaru just became aware that Yandere-chan committed murder.");
								this.Student.AwareOfMurder = true;
							}
							if (!this.NoScream)
							{
								Debug.Log("This alarm disc had a scream attached to it.");
								this.Student.Giggle = null;
								this.InvestigateScream();
							}
							if (this.FocusOnYandere)
							{
								this.Student.FocusOnYandere = true;
							}
							if (this.Hesitation != 1f)
							{
								this.Student.Hesitation = this.Hesitation;
							}
						}
					}
				}
				else
				{
					Debug.Log("A student just heard a radio...");
					if (this.Student.Giggle != null)
					{
						this.Student.StopInvestigating();
					}
					if (!this.Student.Nemesis && this.Student.Alive && !this.Student.Dying && !this.Student.Guarding && !this.Student.Alarmed && !this.Student.Wet && !this.Student.Slave && !this.Student.Headache && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.Lethal && !this.Student.InEvent && !this.Student.Following && !this.Student.Distracting && this.Student.Actions[this.Student.Phase] != StudentActionType.Teaching && this.Student.Actions[this.Student.Phase] != StudentActionType.SitAndTakeNotes && !this.Student.GoAway && this.Student.Routine && !this.Student.CheckingNote && !this.Student.SentHome)
					{
						if (this.Student.CharacterAnimation != null && this.SourceRadio.Victim == null)
						{
							if (this.Student.StudentManager.LockerRoomArea.bounds.Contains(base.transform.position) || this.Student.StudentManager.WestBathroomArea.bounds.Contains(base.transform.position) || this.Student.StudentManager.EastBathroomArea.bounds.Contains(base.transform.position) || (this.Student.Club != ClubType.Delinquent && this.Student.StudentManager.IncineratorArea.bounds.Contains(base.transform.position)) || this.Student.StudentManager.HeadmasterArea.bounds.Contains(base.transform.position))
							{
								if (this.Student.Yandere.NotificationManager.NotificationParent.childCount < 5)
								{
									this.Student.Yandere.NotificationManager.CustomText = this.Student.Name + " ignored a radio.";
									if (this.Student.Yandere.NotificationManager.CustomText != this.Student.Yandere.NotificationManager.PreviousText)
									{
										this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
									}
								}
							}
							else
							{
								Debug.Log(this.Student.Name + " has just been alarmed by a radio!");
								this.Student.CharacterAnimation.CrossFade(this.Student.LeanAnim);
								this.Student.Pathfinding.canSearch = false;
								this.Student.Pathfinding.canMove = false;
								this.Student.EatingSnack = false;
								this.Student.Radio = this.SourceRadio;
								this.Student.TurnOffRadio = true;
								this.Student.Routine = false;
								this.Student.GoAway = false;
								bool flag = false;
								if (this.Student.CurrentAction == StudentActionType.SitAndEatBento && this.Student.Bento.activeInHierarchy && this.Student.StudentID > 1)
								{
									flag = true;
								}
								this.Student.EmptyHands();
								bool flag2 = false;
								if (this.Student.CurrentAction == StudentActionType.Sunbathe && this.Student.SunbathePhase > 2)
								{
									this.Student.SunbathePhase = 2;
									flag2 = true;
								}
								if ((this.Student.Persona == PersonaType.PhoneAddict && !this.Student.Phoneless && !flag2) || this.Student.Persona == PersonaType.Sleuth || this.Student.StudentID == 20)
								{
									this.Student.SmartPhone.SetActive(true);
								}
								if (flag)
								{
									if (!this.Student.MyBento.Tampered)
									{
										this.Student.MyBento.enabled = true;
										this.Student.MyBento.Prompt.enabled = true;
									}
									this.Student.Bento.SetActive(true);
									this.Student.Bento.transform.parent = this.Student.transform;
									if (this.Student.Male)
									{
										this.Student.Bento.transform.localPosition = new Vector3(0f, 0.4266666f, -0.075f);
									}
									else
									{
										Debug.Log("This female student was distracted by a giggle, so her bento has teleported.");
										this.Student.Bento.transform.localPosition = new Vector3(0f, 0.461f, -0.075f);
									}
									this.Student.Bento.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
									this.Student.Bento.transform.parent = null;
								}
								this.Student.SpeechLines.Stop();
								this.Student.ChalkDust.Stop();
								this.Student.CleanTimer = 0f;
								this.Student.RadioTimer = 0f;
								this.Student.ReadPhase = 0;
								this.SourceRadio.Victim = this.Student;
								if (this.Student.StudentID == 97 && SchemeGlobals.GetSchemeStage(5) == 3)
								{
									SchemeGlobals.SetSchemeStage(5, 4);
									this.Student.Yandere.PauseScreen.Schemes.UpdateInstructions();
									base.enabled = false;
								}
								this.Student.Yandere.NotificationManager.CustomText = this.Student.Name + " hears the radio.";
								this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
							}
						}
					}
					else if (this.Student.Yandere.NotificationManager.NotificationParent.childCount < 5)
					{
						if (this.Student.Routine)
						{
							this.Student.Yandere.NotificationManager.CustomText = this.Student.Name + " is in an event right now!";
							this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
						this.Student.Yandere.NotificationManager.CustomText = this.Student.Name + " ignored a radio.";
						if (this.Student.Yandere.NotificationManager.CustomText != this.Student.Yandere.NotificationManager.PreviousText)
						{
							this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
				}
			}
		}
		this.Student = null;
	}

	// Token: 0x060009AA RID: 2474 RVA: 0x0004F588 File Offset: 0x0004D788
	private void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = 5f;
		audioSource.maxDistance = 10f;
		audioSource.spatialBlend = 1f;
		audioSource.volume = 0.5f;
		if (this.Student != null)
		{
			this.Student.DeathScream = gameObject;
		}
	}

	// Token: 0x060009AB RID: 2475 RVA: 0x0004F618 File Offset: 0x0004D818
	private void InvestigateScream()
	{
		Debug.Log(this.Student.Name + " just heard a scream.");
		if (this.Student.Clock.Period == 3 && this.Student.BusyAtLunch)
		{
			this.StudentIsBusy = true;
		}
		if (!this.Student.YandereVisible && !this.Student.Distracted && !this.Student.Wet && !this.Student.Slave && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.Headache && !this.Student.InEvent && !this.Student.Following && !this.Student.Confessing && !this.Student.Meeting && !this.Student.TurnOffRadio && !this.Student.Fleeing && !this.Student.Distracting && !this.Student.GoAway && !this.Student.FocusOnYandere && !this.StudentIsBusy && this.Student.Actions[this.Student.Phase] != StudentActionType.Teaching && this.Student.Actions[this.Student.Phase] != StudentActionType.SitAndTakeNotes && this.Student.Actions[this.Student.Phase] != StudentActionType.Graffiti && this.Student.Actions[this.Student.Phase] != StudentActionType.Bully)
		{
			Debug.Log(this.Student.Name + " should be going to investigate that scream now.");
			this.Student.CharacterAnimation.CrossFade(this.Student.IdleAnim);
			GameObject giggle = UnityEngine.Object.Instantiate<GameObject>(this.Student.EmptyGameObject, new Vector3(base.transform.position.x, this.Student.transform.position.y, base.transform.position.z), Quaternion.identity);
			this.Student.Giggle = giggle;
			if (this.Student.Pathfinding != null && !this.Student.Nemesis)
			{
				this.Student.Pathfinding.canSearch = false;
				this.Student.Pathfinding.canMove = false;
				this.Student.InvestigationPhase = 0;
				this.Student.InvestigationTimer = 0f;
				this.Student.Investigating = true;
				this.Student.EatingSnack = false;
				this.Student.SpeechLines.Stop();
				this.Student.ChalkDust.Stop();
				this.Student.DiscCheck = true;
				this.Student.Routine = false;
				this.Student.CleanTimer = 0f;
				this.Student.ReadPhase = 0;
				this.Student.StopPairing();
				this.Student.EmptyHands();
				this.Student.HeardScream = true;
				return;
			}
		}
		else
		{
			Debug.Log("For some reason, " + this.Student.Name + " decided to completely ignore a SCREAM.");
		}
	}

	// Token: 0x04000897 RID: 2199
	public AudioClip[] LongFemaleScreams;

	// Token: 0x04000898 RID: 2200
	public AudioClip[] LongMaleScreams;

	// Token: 0x04000899 RID: 2201
	public AudioClip[] FemaleScreams;

	// Token: 0x0400089A RID: 2202
	public AudioClip[] MaleScreams;

	// Token: 0x0400089B RID: 2203
	public AudioClip[] DelinquentScreams;

	// Token: 0x0400089C RID: 2204
	public StudentScript Originator;

	// Token: 0x0400089D RID: 2205
	public RadioScript SourceRadio;

	// Token: 0x0400089E RID: 2206
	public StudentScript Student;

	// Token: 0x0400089F RID: 2207
	public bool FocusOnYandere;

	// Token: 0x040008A0 RID: 2208
	public bool StudentIsBusy;

	// Token: 0x040008A1 RID: 2209
	public bool Delinquent;

	// Token: 0x040008A2 RID: 2210
	public bool NoScream;

	// Token: 0x040008A3 RID: 2211
	public bool Shocking;

	// Token: 0x040008A4 RID: 2212
	public bool Radio;

	// Token: 0x040008A5 RID: 2213
	public bool Male;

	// Token: 0x040008A6 RID: 2214
	public bool Long;

	// Token: 0x040008A7 RID: 2215
	public float Hesitation = 1f;

	// Token: 0x040008A8 RID: 2216
	public int Frame;
}
