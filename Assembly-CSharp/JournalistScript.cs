using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000344 RID: 836
public class JournalistScript : MonoBehaviour
{
	// Token: 0x06001920 RID: 6432 RVA: 0x000FC95C File Offset: 0x000FAB5C
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

	// Token: 0x06001921 RID: 6433 RVA: 0x000FC9B0 File Offset: 0x000FABB0
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

	// Token: 0x06001922 RID: 6434 RVA: 0x000FD10C File Offset: 0x000FB30C
	private void CheckBehavior()
	{
		if (this.Yandere.CanMove && !this.Yandere.Egg && (this.Yandere.Chased || this.Yandere.Chasers > 0 || (this.Yandere.Armed && this.Yandere.EquippedWeapon.Bloody) || (this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.Dragging && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.Bloodiness + (float)this.Yandere.GloveBlood > 0f && !this.Yandere.Paint) || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart && !this.Yandere.PickUp.Garbage)))
		{
			this.Chase();
		}
	}

	// Token: 0x06001923 RID: 6435 RVA: 0x000FD22C File Offset: 0x000FB42C
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

	// Token: 0x06001924 RID: 6436 RVA: 0x000FD2D0 File Offset: 0x000FB4D0
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

	// Token: 0x04002788 RID: 10120
	public ParticleSystem PepperSprayEffect;

	// Token: 0x04002789 RID: 10121
	public float DistanceToDestination;

	// Token: 0x0400278A RID: 10122
	public float DistanceToPlayer;

	// Token: 0x0400278B RID: 10123
	public float SpeechTimer;

	// Token: 0x0400278C RID: 10124
	public float ThreatTimer;

	// Token: 0x0400278D RID: 10125
	public float ChaseTimer;

	// Token: 0x0400278E RID: 10126
	public float Timer;

	// Token: 0x0400278F RID: 10127
	public Quaternion targetRotation;

	// Token: 0x04002790 RID: 10128
	public AudioClip PepperSpraySFX;

	// Token: 0x04002791 RID: 10129
	public AudioClip ChaseVoice;

	// Token: 0x04002792 RID: 10130
	public Transform[] Destinations;

	// Token: 0x04002793 RID: 10131
	public AudioClip[] SpeechClips;

	// Token: 0x04002794 RID: 10132
	public AudioClip[] ThreatClips;

	// Token: 0x04002795 RID: 10133
	public string[] SpeechLines;

	// Token: 0x04002796 RID: 10134
	public string[] ThreatLines;

	// Token: 0x04002797 RID: 10135
	public SubtitleScript Subtitle;

	// Token: 0x04002798 RID: 10136
	public YandereScript Yandere;

	// Token: 0x04002799 RID: 10137
	public GameObject PepperSpray;

	// Token: 0x0400279A RID: 10138
	public GameObject Face;

	// Token: 0x0400279B RID: 10139
	public Animation MyAnimation;

	// Token: 0x0400279C RID: 10140
	public Transform LookTarget;

	// Token: 0x0400279D RID: 10141
	public AIPath Pathfinding;

	// Token: 0x0400279E RID: 10142
	public bool Chasing;

	// Token: 0x0400279F RID: 10143
	public int SpeechID;

	// Token: 0x040027A0 RID: 10144
	public int ThreatID;

	// Token: 0x040027A1 RID: 10145
	public Transform Head;

	// Token: 0x040027A2 RID: 10146
	public LayerMask Mask;
}
