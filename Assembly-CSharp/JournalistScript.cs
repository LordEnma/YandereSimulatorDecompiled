using System;
using Pathfinding;
using UnityEngine;

// Token: 0x0200033E RID: 830
public class JournalistScript : MonoBehaviour
{
	// Token: 0x060018E5 RID: 6373 RVA: 0x000F8F4C File Offset: 0x000F714C
	private void Start()
	{
		if (!GameGlobals.Eighties || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.gameObject.SetActive(false);
		}
		else
		{
			this.Pathfinding.target = this.Destinations[0];
		}
		this.PepperSpray.SetActive(false);
	}

	// Token: 0x060018E6 RID: 6374 RVA: 0x000F8FA0 File Offset: 0x000F71A0
	private void Update()
	{
		if (base.transform.position.z > -95f)
		{
			this.DistanceToDestination = Vector3.Distance(base.transform.position, this.Pathfinding.target.position);
			this.DistanceToPlayer = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
			if (!this.Chasing)
			{
				if (this.DistanceToPlayer < 5f && this.CanSeeYandere())
				{
					this.MyAnimation.CrossFade("idleTough_00");
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					if (this.DistanceToPlayer > 1f)
					{
						this.SpeechTimer -= Time.deltaTime;
						if (this.SpeechTimer <= 0f && this.SpeechID < this.SpeechLines.Length)
						{
							AudioSource.PlayClipAtPoint(this.SpeechClips[this.SpeechID], base.transform.position);
							if (this.Subtitle.EventSubtitle.text == "" || this.Subtitle.EventSubtitle.transform.localScale.x < 1f)
							{
								this.Subtitle.CustomText = this.SpeechLines[this.SpeechID];
								this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 4f);
							}
							this.SpeechTimer = 5f;
							this.SpeechID++;
						}
					}
					else
					{
						this.ThreatTimer -= Time.deltaTime;
						if (this.ThreatTimer <= 0f && this.ThreatID < this.ThreatLines.Length)
						{
							AudioSource.PlayClipAtPoint(this.ThreatClips[this.ThreatID], base.transform.position);
							if (this.Subtitle.EventSubtitle.text == "" || this.Subtitle.EventSubtitle.transform.localScale.x < 1f)
							{
								this.Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
								this.Subtitle.CustomText = this.ThreatLines[this.ThreatID];
								this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 4f);
							}
							this.ThreatTimer = 5f;
							this.ThreatID++;
						}
						if (this.Yandere.Armed)
						{
							this.Chase();
						}
					}
				}
				else if (this.DistanceToDestination < 1f)
				{
					this.MyAnimation.CrossFade("leaning_00");
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.targetRotation = Quaternion.LookRotation(this.LookTarget.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					this.Timer += Time.deltaTime;
					if (this.Timer > 5f)
					{
						if (this.Pathfinding.target != this.Destinations[1])
						{
							this.Pathfinding.target = this.Destinations[1];
						}
						else
						{
							this.Pathfinding.target = this.Destinations[2];
						}
						this.Timer = 0f;
					}
				}
				else
				{
					this.MyAnimation.CrossFade("walkTough_00");
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
				}
				if (this.DistanceToPlayer < 15f && this.CanSeeYandere())
				{
					this.CheckBehavior();
					return;
				}
			}
			else
			{
				this.targetRotation = Quaternion.LookRotation(base.transform.position - this.Yandere.transform.position);
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				this.ChaseTimer += Time.deltaTime;
				if (this.ChaseTimer > 1f)
				{
					if (this.DistanceToPlayer > 1f)
					{
						this.MyAnimation.CrossFade("sprint_00");
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.Pathfinding.speed = 5f;
						return;
					}
					if (!this.Yandere.Sprayed)
					{
						AudioSource.PlayClipAtPoint(this.PepperSpraySFX, base.transform.position);
					}
					this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					this.Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
					this.Yandere.SprayedByJournalist = true;
					this.Yandere.YandereVision = false;
					this.Yandere.NearSenpai = false;
					this.Yandere.Attacking = false;
					this.Yandere.FollowHips = true;
					this.Yandere.Punching = false;
					this.Yandere.CanMove = false;
					this.Yandere.Sprayed = true;
					this.Yandere.StudentManager.YandereDying = true;
					this.Yandere.StudentManager.StopMoving();
					this.Yandere.Jukebox.Volume = 0f;
					this.Yandere.Blur.Size = 1f;
					if (this.Yandere.DelinquentFighting)
					{
						this.Yandere.StudentManager.CombatMinigame.Stop();
					}
					this.MyAnimation.CrossFade("spray_00");
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.Pathfinding.speed = 0f;
					this.PepperSpray.SetActive(true);
					if ((double)this.MyAnimation["spray_00"].time > 0.66666)
					{
						this.PepperSprayEffect.Play();
						if (this.Yandere.Armed)
						{
							this.Yandere.EquippedWeapon.Drop();
						}
						this.Yandere.EmptyHands();
						base.enabled = false;
						return;
					}
				}
				else
				{
					this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				}
			}
		}
	}

	// Token: 0x060018E7 RID: 6375 RVA: 0x000F96FC File Offset: 0x000F78FC
	private void CheckBehavior()
	{
		if (this.Yandere.CanMove && !this.Yandere.Egg && ((this.Yandere.Armed && this.Yandere.EquippedWeapon.Bloody) || this.Yandere.Bloodiness > 0f || this.Yandere.Carrying || this.Yandere.Chased || this.Yandere.Chasers > 0 || this.Yandere.Dragging || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart && !this.Yandere.PickUp.Garbage)))
		{
			this.Chase();
		}
	}

	// Token: 0x060018E8 RID: 6376 RVA: 0x000F97D4 File Offset: 0x000F79D4
	public bool CanSeeYandere()
	{
		Vector3 position = this.Head.position;
		Vector3 end = new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z);
		RaycastHit raycastHit;
		return Physics.Linecast(position, end, out raycastHit, this.Mask) && raycastHit.collider.gameObject == this.Yandere.gameObject;
	}

	// Token: 0x060018E9 RID: 6377 RVA: 0x000F9868 File Offset: 0x000F7A68
	private void Chase()
	{
		this.Face.name = "RENAMED";
		this.Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
		AudioSource.PlayClipAtPoint(this.ChaseVoice, this.Yandere.MainCamera.transform.position);
		this.Subtitle.CustomText = "I knew it was you!";
		this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 4f);
		this.MyAnimation.CrossFade("readyToFight_00");
		this.Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
		this.Yandere.CanMove = false;
		this.Pathfinding.target = this.Yandere.transform;
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		if (this.Yandere.Carrying)
		{
			this.Yandere.EmptyHands();
		}
		this.Chasing = true;
	}

	// Token: 0x040026DF RID: 9951
	public ParticleSystem PepperSprayEffect;

	// Token: 0x040026E0 RID: 9952
	public float DistanceToDestination;

	// Token: 0x040026E1 RID: 9953
	public float DistanceToPlayer;

	// Token: 0x040026E2 RID: 9954
	public float SpeechTimer;

	// Token: 0x040026E3 RID: 9955
	public float ThreatTimer;

	// Token: 0x040026E4 RID: 9956
	public float ChaseTimer;

	// Token: 0x040026E5 RID: 9957
	public float Timer;

	// Token: 0x040026E6 RID: 9958
	public Quaternion targetRotation;

	// Token: 0x040026E7 RID: 9959
	public AudioClip PepperSpraySFX;

	// Token: 0x040026E8 RID: 9960
	public AudioClip ChaseVoice;

	// Token: 0x040026E9 RID: 9961
	public Transform[] Destinations;

	// Token: 0x040026EA RID: 9962
	public AudioClip[] SpeechClips;

	// Token: 0x040026EB RID: 9963
	public AudioClip[] ThreatClips;

	// Token: 0x040026EC RID: 9964
	public string[] SpeechLines;

	// Token: 0x040026ED RID: 9965
	public string[] ThreatLines;

	// Token: 0x040026EE RID: 9966
	public SubtitleScript Subtitle;

	// Token: 0x040026EF RID: 9967
	public YandereScript Yandere;

	// Token: 0x040026F0 RID: 9968
	public GameObject PepperSpray;

	// Token: 0x040026F1 RID: 9969
	public GameObject Face;

	// Token: 0x040026F2 RID: 9970
	public Animation MyAnimation;

	// Token: 0x040026F3 RID: 9971
	public Transform LookTarget;

	// Token: 0x040026F4 RID: 9972
	public AIPath Pathfinding;

	// Token: 0x040026F5 RID: 9973
	public bool Chasing;

	// Token: 0x040026F6 RID: 9974
	public int SpeechID;

	// Token: 0x040026F7 RID: 9975
	public int ThreatID;

	// Token: 0x040026F8 RID: 9976
	public Transform Head;

	// Token: 0x040026F9 RID: 9977
	public LayerMask Mask;
}
