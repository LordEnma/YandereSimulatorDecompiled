using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000341 RID: 833
public class JournalistScript : MonoBehaviour
{
	// Token: 0x060018FC RID: 6396 RVA: 0x000FA638 File Offset: 0x000F8838
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

	// Token: 0x060018FD RID: 6397 RVA: 0x000FA68C File Offset: 0x000F888C
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

	// Token: 0x060018FE RID: 6398 RVA: 0x000FADE8 File Offset: 0x000F8FE8
	private void CheckBehavior()
	{
		if (this.Yandere.CanMove && !this.Yandere.Egg && ((this.Yandere.Armed && this.Yandere.EquippedWeapon.Bloody) || (this.Yandere.Bloodiness + (float)this.Yandere.GloveBlood > 0f && !this.Yandere.Paint) || this.Yandere.Carrying || this.Yandere.Chased || this.Yandere.Chasers > 0 || this.Yandere.Dragging || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart && !this.Yandere.PickUp.Garbage)))
		{
			this.Chase();
		}
	}

	// Token: 0x060018FF RID: 6399 RVA: 0x000FAEDC File Offset: 0x000F90DC
	public bool CanSeeYandere()
	{
		if (!this.Yandere.Egg)
		{
			Vector3 position = this.Head.position;
			Vector3 end = new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z);
			RaycastHit raycastHit;
			if (Physics.Linecast(position, end, out raycastHit, this.Mask) && raycastHit.collider.gameObject == this.Yandere.gameObject)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001900 RID: 6400 RVA: 0x000FAF80 File Offset: 0x000F9180
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

	// Token: 0x0400271F RID: 10015
	public ParticleSystem PepperSprayEffect;

	// Token: 0x04002720 RID: 10016
	public float DistanceToDestination;

	// Token: 0x04002721 RID: 10017
	public float DistanceToPlayer;

	// Token: 0x04002722 RID: 10018
	public float SpeechTimer;

	// Token: 0x04002723 RID: 10019
	public float ThreatTimer;

	// Token: 0x04002724 RID: 10020
	public float ChaseTimer;

	// Token: 0x04002725 RID: 10021
	public float Timer;

	// Token: 0x04002726 RID: 10022
	public Quaternion targetRotation;

	// Token: 0x04002727 RID: 10023
	public AudioClip PepperSpraySFX;

	// Token: 0x04002728 RID: 10024
	public AudioClip ChaseVoice;

	// Token: 0x04002729 RID: 10025
	public Transform[] Destinations;

	// Token: 0x0400272A RID: 10026
	public AudioClip[] SpeechClips;

	// Token: 0x0400272B RID: 10027
	public AudioClip[] ThreatClips;

	// Token: 0x0400272C RID: 10028
	public string[] SpeechLines;

	// Token: 0x0400272D RID: 10029
	public string[] ThreatLines;

	// Token: 0x0400272E RID: 10030
	public SubtitleScript Subtitle;

	// Token: 0x0400272F RID: 10031
	public YandereScript Yandere;

	// Token: 0x04002730 RID: 10032
	public GameObject PepperSpray;

	// Token: 0x04002731 RID: 10033
	public GameObject Face;

	// Token: 0x04002732 RID: 10034
	public Animation MyAnimation;

	// Token: 0x04002733 RID: 10035
	public Transform LookTarget;

	// Token: 0x04002734 RID: 10036
	public AIPath Pathfinding;

	// Token: 0x04002735 RID: 10037
	public bool Chasing;

	// Token: 0x04002736 RID: 10038
	public int SpeechID;

	// Token: 0x04002737 RID: 10039
	public int ThreatID;

	// Token: 0x04002738 RID: 10040
	public Transform Head;

	// Token: 0x04002739 RID: 10041
	public LayerMask Mask;
}
