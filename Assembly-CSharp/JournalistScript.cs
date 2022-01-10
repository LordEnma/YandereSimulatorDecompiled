using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000340 RID: 832
public class JournalistScript : MonoBehaviour
{
	// Token: 0x060018F2 RID: 6386 RVA: 0x000F9D58 File Offset: 0x000F7F58
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

	// Token: 0x060018F3 RID: 6387 RVA: 0x000F9DAC File Offset: 0x000F7FAC
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

	// Token: 0x060018F4 RID: 6388 RVA: 0x000FA508 File Offset: 0x000F8708
	private void CheckBehavior()
	{
		if (this.Yandere.CanMove && !this.Yandere.Egg && ((this.Yandere.Armed && this.Yandere.EquippedWeapon.Bloody) || this.Yandere.Bloodiness > 0f || this.Yandere.Carrying || this.Yandere.Chased || this.Yandere.Chasers > 0 || this.Yandere.Dragging || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart && !this.Yandere.PickUp.Garbage)))
		{
			this.Chase();
		}
	}

	// Token: 0x060018F5 RID: 6389 RVA: 0x000FA5E0 File Offset: 0x000F87E0
	public bool CanSeeYandere()
	{
		Vector3 position = this.Head.position;
		Vector3 end = new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z);
		RaycastHit raycastHit;
		return Physics.Linecast(position, end, out raycastHit, this.Mask) && raycastHit.collider.gameObject == this.Yandere.gameObject;
	}

	// Token: 0x060018F6 RID: 6390 RVA: 0x000FA674 File Offset: 0x000F8874
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

	// Token: 0x0400270C RID: 9996
	public ParticleSystem PepperSprayEffect;

	// Token: 0x0400270D RID: 9997
	public float DistanceToDestination;

	// Token: 0x0400270E RID: 9998
	public float DistanceToPlayer;

	// Token: 0x0400270F RID: 9999
	public float SpeechTimer;

	// Token: 0x04002710 RID: 10000
	public float ThreatTimer;

	// Token: 0x04002711 RID: 10001
	public float ChaseTimer;

	// Token: 0x04002712 RID: 10002
	public float Timer;

	// Token: 0x04002713 RID: 10003
	public Quaternion targetRotation;

	// Token: 0x04002714 RID: 10004
	public AudioClip PepperSpraySFX;

	// Token: 0x04002715 RID: 10005
	public AudioClip ChaseVoice;

	// Token: 0x04002716 RID: 10006
	public Transform[] Destinations;

	// Token: 0x04002717 RID: 10007
	public AudioClip[] SpeechClips;

	// Token: 0x04002718 RID: 10008
	public AudioClip[] ThreatClips;

	// Token: 0x04002719 RID: 10009
	public string[] SpeechLines;

	// Token: 0x0400271A RID: 10010
	public string[] ThreatLines;

	// Token: 0x0400271B RID: 10011
	public SubtitleScript Subtitle;

	// Token: 0x0400271C RID: 10012
	public YandereScript Yandere;

	// Token: 0x0400271D RID: 10013
	public GameObject PepperSpray;

	// Token: 0x0400271E RID: 10014
	public GameObject Face;

	// Token: 0x0400271F RID: 10015
	public Animation MyAnimation;

	// Token: 0x04002720 RID: 10016
	public Transform LookTarget;

	// Token: 0x04002721 RID: 10017
	public AIPath Pathfinding;

	// Token: 0x04002722 RID: 10018
	public bool Chasing;

	// Token: 0x04002723 RID: 10019
	public int SpeechID;

	// Token: 0x04002724 RID: 10020
	public int ThreatID;

	// Token: 0x04002725 RID: 10021
	public Transform Head;

	// Token: 0x04002726 RID: 10022
	public LayerMask Mask;
}
