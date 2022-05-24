using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000345 RID: 837
public class JournalistScript : MonoBehaviour
{
	// Token: 0x06001925 RID: 6437 RVA: 0x000FCDA8 File Offset: 0x000FAFA8
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
		this.MyAnimation.CrossFade("crossarms_00");
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.PepperSpray.SetActive(false);
	}

	// Token: 0x06001926 RID: 6438 RVA: 0x000FCE24 File Offset: 0x000FB024
	private void Update()
	{
		this.DistanceToDestination = Vector3.Distance(base.transform.position, this.Pathfinding.target.position);
		this.DistanceToPlayer = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
		if (this.Waiting)
		{
			if (this.DistanceToPlayer < 5f)
			{
				this.SpeechCheck();
			}
			this.WaitTimer += Time.deltaTime;
			if (this.WaitTimer > 5f && this.RivalEvent == null)
			{
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Waiting = false;
				return;
			}
		}
		else if (this.Flee)
		{
			if (this.DistanceToDestination < 2.2f)
			{
				this.Yandere.StudentManager.Police.Show = true;
				base.gameObject.SetActive(false);
				return;
			}
		}
		else if (this.Freeze)
		{
			this.MyAnimation.CrossFade("readyToFight_00");
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
			if (this.Corpse != null)
			{
				this.FreezeTimer += Time.deltaTime;
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.Student.Hips.position.x, base.transform.position.y, this.Corpse.Student.Hips.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				if (this.FreezeTimer > 5f)
				{
					this.RunAway();
					return;
				}
			}
			else
			{
				this.targetRotation = Quaternion.LookRotation(this.Yandere.StudentManager.MindBrokenSlave.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				if (!this.Yandere.StudentManager.MindBrokenSlave.Alive)
				{
					this.RunAway();
					return;
				}
			}
		}
		else if (!this.Chasing)
		{
			if (this.Yandere.transform.position.z < -50f && this.Yandere.Attacking)
			{
				this.MyAnimation.CrossFade("sprint_00");
				this.Pathfinding.target = this.Yandere.transform;
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Pathfinding.speed = 5f;
				this.AwareOfMurder = true;
			}
			else
			{
				if (this.Yandere.transform.position.z < -50f)
				{
					this.Pathfinding.target = this.Yandere.transform;
				}
				else if (this.Pathfinding.target == this.Yandere.transform)
				{
					this.Pathfinding.target = this.Destinations[0];
				}
				if (this.DistanceToPlayer < 5f && this.CanSeeYandere())
				{
					this.MyAnimation.CrossFade("idleTough_00");
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					this.SpeechCheck();
				}
				else if (this.Yandere.transform.position.z < -50f && this.DistanceToPlayer < 10f)
				{
					this.MyAnimation.CrossFade("idleTough_00");
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
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
			}
			if ((this.DistanceToPlayer < 15f && this.CanSeeYandere()) || (this.DistanceToPlayer < 5f && this.AwareOfMurder))
			{
				this.CheckBehavior();
			}
			if (!this.Chasing)
			{
				if (this.Yandere.StudentManager.MurderTakingPlace)
				{
					if (this.Yandere.StudentManager.MindBrokenSlave.MurderSuicidePhase > 0 && Vector3.Distance(base.transform.position, this.Yandere.StudentManager.MindBrokenSlave.transform.position) < 10f)
					{
						this.Freeze = true;
						return;
					}
				}
				else if (this.Yandere.StudentManager.Police.Corpses > 0)
				{
					for (int i = 0; i < this.Yandere.StudentManager.Police.Corpses; i++)
					{
						if (this.Yandere.StudentManager.Police.CorpseList[i] != null && Vector3.Distance(base.transform.position, this.Yandere.StudentManager.Police.CorpseList[i].transform.position) < 10f)
						{
							this.Corpse = this.Yandere.StudentManager.Police.CorpseList[i];
							this.Freeze = true;
						}
					}
					return;
				}
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

	// Token: 0x06001927 RID: 6439 RVA: 0x000FD88C File Offset: 0x000FBA8C
	private void CheckBehavior()
	{
		if (this.Yandere.CanMove && !this.Yandere.Egg && (this.Yandere.Chased || this.Yandere.Chasers > 0 || this.Yandere.MurderousActionTimer > 0f || this.Yandere.PotentiallyMurderousTimer > 0f || (this.Yandere.Armed && this.Yandere.EquippedWeapon.Bloody) || (this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.Dragging && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.Bloodiness + (float)this.Yandere.GloveBlood > 0f && !this.Yandere.Paint && this.Yandere.MyProjector.enabled) || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart && !this.Yandere.PickUp.Garbage)))
		{
			this.Chase();
		}
	}

	// Token: 0x06001928 RID: 6440 RVA: 0x000FD9E8 File Offset: 0x000FBBE8
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

	// Token: 0x06001929 RID: 6441 RVA: 0x000FDA8C File Offset: 0x000FBC8C
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
		this.Waiting = false;
		this.Chasing = true;
	}

	// Token: 0x0600192A RID: 6442 RVA: 0x000FDB7C File Offset: 0x000FBD7C
	private void RunAway()
	{
		this.Pathfinding.target = this.Yandere.StudentManager.Exit;
		this.MyAnimation.CrossFade("sprint_00");
		this.Pathfinding.canSearch = true;
		this.Pathfinding.canMove = true;
		this.Pathfinding.speed = 5f;
		this.Flee = true;
	}

	// Token: 0x0600192B RID: 6443 RVA: 0x000FDBE4 File Offset: 0x000FBDE4
	private void SpeechCheck()
	{
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
				return;
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

	// Token: 0x04002797 RID: 10135
	public GenericRivalEventScript RivalEvent;

	// Token: 0x04002798 RID: 10136
	public ParticleSystem PepperSprayEffect;

	// Token: 0x04002799 RID: 10137
	public CharacterController MyController;

	// Token: 0x0400279A RID: 10138
	public RagdollScript Corpse;

	// Token: 0x0400279B RID: 10139
	public float DistanceToDestination;

	// Token: 0x0400279C RID: 10140
	public float DistanceToPlayer;

	// Token: 0x0400279D RID: 10141
	public float SpeechTimer;

	// Token: 0x0400279E RID: 10142
	public float ThreatTimer;

	// Token: 0x0400279F RID: 10143
	public float ChaseTimer;

	// Token: 0x040027A0 RID: 10144
	public float Timer;

	// Token: 0x040027A1 RID: 10145
	public Quaternion targetRotation;

	// Token: 0x040027A2 RID: 10146
	public AudioClip PepperSpraySFX;

	// Token: 0x040027A3 RID: 10147
	public AudioClip ChaseVoice;

	// Token: 0x040027A4 RID: 10148
	public Transform[] Destinations;

	// Token: 0x040027A5 RID: 10149
	public AudioClip[] SpeechClips;

	// Token: 0x040027A6 RID: 10150
	public AudioClip[] ThreatClips;

	// Token: 0x040027A7 RID: 10151
	public string[] SpeechLines;

	// Token: 0x040027A8 RID: 10152
	public string[] ThreatLines;

	// Token: 0x040027A9 RID: 10153
	public SubtitleScript Subtitle;

	// Token: 0x040027AA RID: 10154
	public YandereScript Yandere;

	// Token: 0x040027AB RID: 10155
	public GameObject PepperSpray;

	// Token: 0x040027AC RID: 10156
	public GameObject Face;

	// Token: 0x040027AD RID: 10157
	public Animation MyAnimation;

	// Token: 0x040027AE RID: 10158
	public Transform LookTarget;

	// Token: 0x040027AF RID: 10159
	public AIPath Pathfinding;

	// Token: 0x040027B0 RID: 10160
	public float FreezeTimer;

	// Token: 0x040027B1 RID: 10161
	public float WaitTimer;

	// Token: 0x040027B2 RID: 10162
	public bool AwareOfMurder;

	// Token: 0x040027B3 RID: 10163
	public bool Waiting;

	// Token: 0x040027B4 RID: 10164
	public bool Chasing;

	// Token: 0x040027B5 RID: 10165
	public bool Freeze;

	// Token: 0x040027B6 RID: 10166
	public bool Flee;

	// Token: 0x040027B7 RID: 10167
	public int SpeechID;

	// Token: 0x040027B8 RID: 10168
	public int ThreatID;

	// Token: 0x040027B9 RID: 10169
	public Transform Head;

	// Token: 0x040027BA RID: 10170
	public LayerMask Mask;
}
