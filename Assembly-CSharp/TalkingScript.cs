using System;
using UnityEngine;

// Token: 0x0200046B RID: 1131
public class TalkingScript : MonoBehaviour
{
	// Token: 0x06001EB1 RID: 7857 RVA: 0x001A9EE0 File Offset: 0x001A80E0
	private void Update()
	{
		if (this.S.Talking)
		{
			this.S.BoobsResized = false;
			if (this.S.Sleuthing && this.S.Club == ClubType.Photography)
			{
				this.ClubBonus = 5;
			}
			else
			{
				this.ClubBonus = 0;
			}
			if (this.S.StudentManager.EmptyDemon)
			{
				this.ClubBonus = (int)(this.S.Club * (ClubType)(-1));
			}
			if (this.S.Interaction == StudentInteractionType.Idle)
			{
				if (!this.Fake)
				{
					if (this.S.Yandere.TargetStudent != null && this.S.StudentID == 10 && this.S.FollowTarget != null && this.S.FollowTarget.Routine)
					{
						this.S.FollowTarget.Pathfinding.canSearch = false;
						this.S.FollowTarget.Pathfinding.canMove = false;
						this.S.FollowTarget.FocusOnYandere = true;
						this.S.FollowTarget.Routine = false;
					}
					if (this.S.Sleuthing)
					{
						this.IdleAnim = this.S.SleuthCalmAnim;
					}
					else if (this.S.Club == ClubType.Art && this.S.DialogueWheel.ClubLeader && this.S.Paintbrush.activeInHierarchy && !this.S.StudentManager.Eighties)
					{
						this.IdleAnim = "paintingIdle_00";
					}
					else if (this.S.Club != ClubType.Bully)
					{
						this.IdleAnim = this.S.IdleAnim;
					}
					else if (this.S.StudentManager.Reputation.Reputation < 33.33333f || this.S.Persona == PersonaType.Coward)
					{
						if (this.S.CurrentAction == StudentActionType.Sunbathe && this.S.SunbathePhase > 2)
						{
							this.IdleAnim = this.S.OriginalIdleAnim;
						}
						else
						{
							this.IdleAnim = this.S.IdleAnim;
						}
					}
					else
					{
						this.IdleAnim = this.S.CuteAnim;
					}
					this.S.CharacterAnimation.CrossFade(this.IdleAnim);
				}
				else if (this.IdleAnim != "")
				{
					this.S.CharacterAnimation.CrossFade(this.IdleAnim);
				}
				if (this.S.TalkTimer == 0f)
				{
					if (!this.S.DialogueWheel.AppearanceWindow.Show && !this.S.StudentManager.TutorialActive)
					{
						this.S.DialogueWheel.Impatience.fillAmount += Time.deltaTime * 0.1f;
					}
					if (this.S.DialogueWheel.Impatience.fillAmount > 0.5f && !this.S.StudentManager.Police.FadeOut && !this.S.StudentManager.Police.Show && this.S.Subtitle.Timer == 0f)
					{
						if (this.S.StudentID == 41 && !this.S.StudentManager.Eighties)
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 4, 5f);
						}
						else if (this.S.Pestered == 0)
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 0, 5f);
						}
						else
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 2, 5f);
						}
					}
					if (this.S.DialogueWheel.Impatience.fillAmount == 1f && this.S.DialogueWheel.Show)
					{
						if (this.S.StudentID == 41 && !this.S.StudentManager.Eighties)
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 4, 5f);
						}
						else if (this.S.Club == ClubType.Delinquent)
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 3, 5f);
						}
						else if (this.S.Pestered == 0)
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 1, 5f);
						}
						else
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 3, 5f);
						}
						this.S.WaitTimer = 0f;
						this.S.Pestered += 5;
						this.S.DialogueWheel.Pestered = true;
						this.S.DialogueWheel.End();
					}
				}
			}
			else if (this.S.Interaction == StudentInteractionType.Forgiving)
			{
				if (this.S.TalkTimer == 3f)
				{
					if (this.S.Club != ClubType.Delinquent)
					{
						this.S.CharacterAnimation.CrossFade(this.S.Nod2Anim);
						this.S.RepRecovery = 5f;
						if (PlayerGlobals.PantiesEquipped == 6)
						{
							this.S.RepRecovery += 2.5f;
						}
						if (this.S.Yandere.Class.SocialBonus > 0)
						{
							this.S.RepRecovery += 2.5f;
						}
						this.S.PendingRep += this.S.RepRecovery;
						this.S.Reputation.PendingRep += this.S.RepRecovery;
						this.S.ID = 0;
						while (this.S.ID < this.S.Outlines.Length)
						{
							if (this.S.Outlines[this.S.ID] != null)
							{
								this.S.Outlines[this.S.ID].color = new Color(0f, 1f, 0f, 1f);
							}
							this.S.ID++;
						}
						this.S.Forgave = true;
						if (this.S.Witnessed == StudentWitnessType.Insanity || this.S.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity || this.S.Witnessed == StudentWitnessType.WeaponAndInsanity || this.S.Witnessed == StudentWitnessType.BloodAndInsanity)
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.ForgivingInsanity, 0, 3f);
						}
						else if (this.S.Witnessed == StudentWitnessType.Accident)
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.ForgivingAccident, 0, 5f);
						}
						else
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.Forgiving, 0, 3f);
						}
					}
					else
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 0, 5f);
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.CharacterAnimation[this.S.Nod2Anim].time >= this.S.CharacterAnimation[this.S.Nod2Anim].length)
					{
						this.S.CharacterAnimation.CrossFade(this.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.IgnoreTimer = 5f;
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.ReceivingCompliment)
			{
				if (this.S.TalkTimer == 3f)
				{
					if (!ConversationGlobals.GetTopicDiscovered(20))
					{
						this.S.Yandere.NotificationManager.TopicName = "Socializing";
						this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
						ConversationGlobals.SetTopicDiscovered(20, true);
					}
					if (!ConversationGlobals.GetTopicLearnedByStudent(20, this.S.StudentID))
					{
						this.S.Yandere.NotificationManager.TopicName = "Socializing";
						this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
						ConversationGlobals.SetTopicLearnedByStudent(20, this.S.StudentID, true);
					}
					if (this.S.Club != ClubType.Delinquent)
					{
						this.S.CharacterAnimation.CrossFade(this.S.LookDownAnim);
						this.CalculateRepBonus();
						int topicSelected = this.S.StudentManager.DialogueWheel.TopicInterface.TopicSelected;
						if (!ConversationGlobals.GetTopicLearnedByStudent(topicSelected, this.S.StudentID))
						{
							this.S.Yandere.NotificationManager.TopicName = this.S.StudentManager.InterestManager.TopicNames[topicSelected];
							this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
							ConversationGlobals.SetTopicLearnedByStudent(topicSelected, this.S.StudentID, true);
						}
						if (this.S.DialogueWheel.TopicInterface.Success)
						{
							this.S.Subtitle.PersonaSubtitle.UpdateLabel(PersonaType.Nemesis, this.S.Reputation.Reputation, 5f);
							this.S.Reputation.PendingRep += 1f + (float)this.S.RepBonus;
							this.S.PendingRep += 1f + (float)this.S.RepBonus;
						}
						else
						{
							this.S.Subtitle.PersonaSubtitle.UpdateLabel(PersonaType.None, this.S.Reputation.Reputation, 5f);
							this.S.Reputation.PendingRep -= 1f;
							this.S.PendingRep -= 1f;
						}
					}
					else
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 1, 3f);
					}
					this.S.Complimented = true;
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.TalkTimer = 0f;
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					this.S.DialogueWheel.End();
				}
			}
			else if (this.S.Interaction == StudentInteractionType.Gossiping)
			{
				if (this.S.TalkTimer == 3f)
				{
					if (this.S.Club != ClubType.Delinquent)
					{
						this.S.Gossiped = true;
						if (this.S.DialogueWheel.TopicInterface.Success)
						{
							this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
							this.S.Subtitle.CustomText = "Ugh, I can't get along with people like that...";
							this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
							this.S.GossipBonus = 0;
							if (PlayerGlobals.PantiesEquipped == 9)
							{
								this.S.GossipBonus++;
							}
							if (this.S.Yandere.Class.SocialBonus > 0)
							{
								this.S.GossipBonus++;
							}
							if (this.S.Friend)
							{
								this.S.GossipBonus++;
							}
							if (this.S.StudentManager.EmbarassingSecret && this.S.DialogueWheel.Victim == this.S.StudentManager.RivalID)
							{
								this.S.GossipBonus++;
							}
							if ((this.S.Male && this.S.Yandere.Class.Seduction + this.S.Yandere.Class.SeductionBonus > 0) || this.S.Yandere.Class.Seduction == 5)
							{
								this.S.GossipBonus++;
							}
							if (this.S.Reputation.Reputation > 33.33333f)
							{
								this.S.GossipBonus++;
							}
							if (this.S.Club == ClubType.Bully)
							{
								this.S.GossipBonus++;
							}
							this.S.GossipBonus += this.S.Yandere.Class.PsychologyGrade + this.S.Yandere.Class.PsychologyBonus;
							this.S.StudentManager.StudentReps[this.S.DialogueWheel.Victim] -= (float)(1 + this.S.GossipBonus);
							if (this.S.Club != ClubType.Bully)
							{
								this.S.Reputation.PendingRep -= 2f;
								this.S.PendingRep -= 2f;
							}
							this.S.Gossiped = true;
							this.S.Yandere.NotificationManager.TopicName = "Gossip";
							if (this.S.StudentManager.Students[this.S.DialogueWheel.Victim] != null)
							{
								this.S.Yandere.NotificationManager.CustomText = this.S.StudentManager.Students[this.S.DialogueWheel.Victim].Name + "'s rep is now " + this.S.StudentManager.StudentReps[this.S.DialogueWheel.Victim].ToString();
								this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
							}
						}
						else
						{
							this.S.Subtitle.PersonaSubtitle.UpdateLabel(PersonaType.None, this.S.Reputation.Reputation, 5f);
							this.S.Reputation.PendingRep -= 1f;
							this.S.PendingRep -= 1f;
						}
						int topicSelected2 = this.S.StudentManager.DialogueWheel.TopicInterface.TopicSelected;
						if (!ConversationGlobals.GetTopicLearnedByStudent(topicSelected2, this.S.StudentID))
						{
							this.S.Yandere.NotificationManager.TopicName = this.S.StudentManager.InterestManager.TopicNames[topicSelected2];
							this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
							ConversationGlobals.SetTopicLearnedByStudent(topicSelected2, this.S.StudentID, true);
						}
						if (!ConversationGlobals.GetTopicLearnedByStudent(19, this.S.StudentID))
						{
							this.S.Yandere.NotificationManager.TopicName = "Gossip";
							this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
							ConversationGlobals.SetTopicLearnedByStudent(19, this.S.StudentID, true);
						}
					}
					else
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 2, 3f);
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.CharacterAnimation[this.S.GossipAnim].time >= this.S.CharacterAnimation[this.S.GossipAnim].length)
					{
						this.S.CharacterAnimation.CrossFade(this.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.Bye)
			{
				if (this.S.TalkTimer == 2f)
				{
					if (this.S.Club != ClubType.Delinquent)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 2f);
					}
					else
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 3, 3f);
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.TalkTimer = 0f;
				}
				this.S.CharacterAnimation.CrossFade(this.IdleAnim);
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					this.S.Pestered += 2;
					this.S.DialogueWheel.End();
				}
			}
			else if (this.S.Interaction == StudentInteractionType.GivingTask)
			{
				if (this.S.TalkTimer == 100f)
				{
					bool flag = true;
					if (this.S.StudentID == 46)
					{
						bool flag2 = this.S.StudentManager.Students[47] != null && this.S.StudentManager.Students[47].Friend;
						bool flag3 = this.S.StudentManager.Students[48] != null && this.S.StudentManager.Students[48].Friend;
						bool flag4 = this.S.StudentManager.Students[49] != null && this.S.StudentManager.Students[49].Friend;
						bool flag5 = this.S.StudentManager.Students[50] != null && this.S.StudentManager.Students[50].Friend;
						if (!flag2 || !flag3 || !flag4 || !flag5)
						{
							flag = false;
						}
					}
					if (flag)
					{
						this.S.Subtitle.UpdateLabel(this.S.TaskLineResponseType, this.S.TaskPhase, this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase));
						this.S.CharacterAnimation.CrossFade(this.S.TaskAnims[this.S.TaskPhase]);
						this.S.CurrentAnim = this.S.TaskAnims[this.S.TaskPhase];
						this.S.TalkTimer = this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase);
					}
					else
					{
						this.S.TaskPhase = 999;
						this.S.Subtitle.CustomText = "I'm sorry, it's a little difficult for me to confide in a complete stranger. If you befriend all of my clubmembers, I'd be able to trust you.";
						this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 10f);
						this.S.Subtitle.Timer = 0f;
						this.S.CharacterAnimation.CrossFade(this.S.TaskAnims[1]);
						this.S.CurrentAnim = this.S.TaskAnims[1];
						this.S.TalkTimer = 10f;
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = 0f;
				}
				if (this.S.CurrentAnim != "" && this.S.CharacterAnimation[this.S.CurrentAnim].time >= this.S.CharacterAnimation[this.S.CurrentAnim].length)
				{
					this.S.CharacterAnimation.CrossFade(this.IdleAnim);
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					if (this.S.TaskPhase == 5)
					{
						if (!ConversationGlobals.GetTopicDiscovered(21))
						{
							this.S.Yandere.NotificationManager.TopicName = "Solitude";
							this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
							ConversationGlobals.SetTopicDiscovered(21, true);
						}
						if (!ConversationGlobals.GetTopicLearnedByStudent(21, this.S.StudentID))
						{
							this.S.Yandere.NotificationManager.TopicName = "Solitude";
							this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
							ConversationGlobals.SetTopicLearnedByStudent(21, this.S.StudentID, true);
						}
						this.S.DialogueWheel.TaskWindow.TaskComplete = true;
						this.S.StudentManager.TaskManager.TaskStatus[this.S.StudentID] = 3;
						this.S.Police.EndOfDay.NewFriends++;
						this.S.Interaction = StudentInteractionType.Idle;
						this.S.Friend = true;
						if (this.S.Club != ClubType.Delinquent)
						{
							this.CalculateRepBonus();
							this.S.Reputation.PendingRep += 1f + (float)this.S.RepBonus;
							this.S.PendingRep += 1f + (float)this.S.RepBonus;
						}
						if (SchemeGlobals.GetSchemeStage(6) == 3)
						{
							SchemeGlobals.SetSchemeStage(6, 4);
							this.S.Yandere.PauseScreen.Schemes.UpdateInstructions();
						}
					}
					else if (this.S.TaskPhase == 4 || this.S.TaskPhase == 0)
					{
						this.S.StudentManager.TaskManager.UpdateTaskStatus();
						this.S.DialogueWheel.End();
					}
					else if (this.S.TaskPhase == 3)
					{
						this.S.DialogueWheel.TaskWindow.UpdateWindow(this.S.StudentID);
						this.S.Subtitle.Label.text = "";
						this.S.Interaction = StudentInteractionType.Idle;
					}
					else if (this.S.TaskPhase == 999)
					{
						this.S.TaskPhase = 0;
						this.S.Interaction = StudentInteractionType.Idle;
						this.S.DialogueWheel.End();
					}
					else
					{
						this.S.TaskPhase++;
						this.S.Subtitle.UpdateLabel(this.S.TaskLineResponseType, this.S.TaskPhase, this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase));
						this.S.Subtitle.Timer = 0f;
						this.S.CharacterAnimation.CrossFade(this.S.TaskAnims[this.S.TaskPhase]);
						this.S.CurrentAnim = this.S.TaskAnims[this.S.TaskPhase];
						this.S.TalkTimer = this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase);
					}
				}
			}
			else if (this.S.Interaction == StudentInteractionType.FollowingPlayer)
			{
				if (this.S.TalkTimer == 2f)
				{
					if (this.S.Club != ClubType.Delinquent)
					{
						bool flag6 = false;
						bool flag7 = false;
						if (this.S.StudentID == this.S.StudentManager.RivalID)
						{
							if (this.S.Follower != null && this.S.Follower.CurrentAction == StudentActionType.Follow && !this.S.Follower.Distracting && !this.S.Follower.GoAway && !this.S.Follower.EatingSnack)
							{
								flag6 = true;
							}
							else if (this.S.Reputation.Reputation < (float)(DateGlobals.Week * 10))
							{
								this.S.Yandere.NotificationManager.CustomText = "You need at least " + (DateGlobals.Week * 10).ToString() + " Reputation Points";
								this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
								flag7 = true;
							}
						}
						if ((this.S.Clock.HourTime > 8f && this.S.Clock.HourTime < 13f) || (this.S.Clock.HourTime > 13.375f && this.S.Clock.HourTime < 15.5f) || (this.S.StudentID == this.S.StudentManager.RivalID && flag6) || (this.S.StudentID == this.S.StudentManager.RivalID && flag7) || SchoolGlobals.SchoolAtmosphere <= 0.5f)
						{
							this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
							this.NegativeResponse = true;
							if (this.S.StudentID == this.S.StudentManager.RivalID)
							{
								if (this.S.Yandere.Club == ClubType.Delinquent)
								{
									this.S.Subtitle.CustomText = "Are you trying to intimidate me? Well, it won't work! Go away!";
									this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
									this.S.TalkTimer = 5f;
								}
								else if (flag6)
								{
									this.S.Subtitle.UpdateLabel(SubtitleType.StudentStay, 2, 5f);
									this.S.TalkTimer = 5f;
								}
								else if (flag7)
								{
									this.S.Subtitle.UpdateLabel(SubtitleType.StudentStay, 3, 13f);
									this.S.TalkTimer = 13f;
								}
								else if (SchoolGlobals.SchoolAtmosphere <= 0.5f)
								{
									this.S.Subtitle.CustomText = "I wouldn't be comfortable with that...the school doesn't feel safe right now.";
									this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
									this.S.TalkTimer = 5f;
								}
							}
							else if (SchoolGlobals.SchoolAtmosphere <= 0.5f)
							{
								this.S.Subtitle.CustomText = "I wouldn't be comfortable with that...the school doesn't feel safe right now.";
								this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 7.5f);
								this.S.TalkTimer = 5f;
							}
							else
							{
								this.S.Subtitle.UpdateLabel(SubtitleType.StudentStay, 0, 5f);
							}
						}
						else if (this.S.StudentManager.LockerRoomArea.bounds.Contains(this.S.Yandere.transform.position) || this.S.StudentManager.WestBathroomArea.bounds.Contains(this.S.Yandere.transform.position) || this.S.StudentManager.EastBathroomArea.bounds.Contains(this.S.Yandere.transform.position) || this.S.StudentManager.HeadmasterArea.bounds.Contains(this.S.Yandere.transform.position) || this.S.MyRenderer.sharedMesh == this.S.SchoolSwimsuit || this.S.MyRenderer.sharedMesh == this.S.SwimmingTrunks || this.S.Traumatized)
						{
							this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
							this.S.Subtitle.UpdateLabel(SubtitleType.StudentStay, 1, 5f);
							this.NegativeResponse = true;
						}
						else
						{
							int num = 0;
							if (this.S.Yandere.Club == ClubType.Delinquent)
							{
								this.S.Reputation.PendingRep -= 10f;
								this.S.PendingRep -= 10f;
								num++;
							}
							this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
							this.S.Subtitle.UpdateLabel(SubtitleType.StudentFollow, num, 2f);
							this.Follow = true;
						}
					}
					else
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 4, 5f);
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.CharacterAnimation[this.S.Nod1Anim].time >= this.S.CharacterAnimation[this.S.Nod1Anim].length)
					{
						this.S.CharacterAnimation.CrossFade(this.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
						if (this.Follow)
						{
							this.S.Pathfinding.target = this.S.Yandere.transform;
							this.S.Prompt.Label[0].text = "     Stop";
							if (this.S.StudentID == 30)
							{
								this.S.StudentManager.FollowerLookAtTarget.position = this.S.DefaultTarget.position;
								this.S.StudentManager.LoveManager.Follower = this.S;
							}
							this.S.FollowCountdown.Sprite.fillAmount = 1f;
							if (this.S.Yandere.Club != ClubType.Delinquent)
							{
								this.S.FollowCountdown.Speed = 1f / (35f + this.S.Reputation.Reputation * 0.25f);
							}
							else
							{
								this.S.FollowCountdown.Speed = 1f / (35f + this.S.Reputation.Reputation * -0.25f);
							}
							this.S.FollowCountdown.gameObject.SetActive(true);
							this.S.Yandere.Follower = this.S;
							this.S.Yandere.Followers++;
							this.S.Following = true;
							this.S.Hurry = false;
							this.S.StudentManager.InterestManager.FollowerID = this.S.StudentID;
							this.S.StudentManager.InterestManager.UpdateIgnore();
						}
						this.Follow = false;
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.GoingAway)
			{
				if (this.S.TalkTimer == 3f)
				{
					if (this.S.Club != ClubType.Delinquent)
					{
						if ((this.S.Clock.HourTime > 8f && this.S.Clock.HourTime < 13f) || (this.S.Clock.HourTime > 13.375f && this.S.Clock.HourTime < 15.5f) || SchoolGlobals.SchoolAtmosphere <= 0.5f)
						{
							if (SchoolGlobals.SchoolAtmosphere <= 0.5f)
							{
								this.S.Subtitle.CustomText = "I'm sorry, I wouldn't be comfortable with that...I'm not even sure if we're safe right now.";
								this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 7.5f);
								this.S.TalkTimer = 7.5f;
							}
							else
							{
								this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
								this.S.Subtitle.UpdateLabel(SubtitleType.StudentStay, 0, 5f);
							}
						}
						else
						{
							int num2 = 0;
							if (this.S.Yandere.Club == ClubType.Delinquent)
							{
								this.S.Reputation.PendingRep -= 10f;
								this.S.PendingRep -= 10f;
								num2++;
							}
							this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
							this.S.Subtitle.UpdateLabel(SubtitleType.StudentLeave, num2, 3f);
							this.S.GoAway = true;
						}
					}
					else
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 5, 5f);
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.CharacterAnimation[this.S.Nod1Anim].time >= this.S.CharacterAnimation[this.S.Nod1Anim].length)
					{
						this.S.CharacterAnimation.CrossFade(this.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.DistractingTarget)
			{
				if (this.S.TalkTimer == 3f)
				{
					if (this.S.Club != ClubType.Delinquent)
					{
						if ((this.S.Clock.HourTime > 8f && this.S.Clock.HourTime < 13f) || (this.S.Clock.HourTime > 13.375f && this.S.Clock.HourTime < 15.5f) || SchoolGlobals.SchoolAtmosphere <= 0.5f)
						{
							if (SchoolGlobals.SchoolAtmosphere <= 0.5f)
							{
								this.S.Subtitle.CustomText = "I'm sorry, I wouldn't be comfortable with that...I'm not even sure if we're safe right now.";
								this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 7.5f);
								this.S.TalkTimer = 7.5f;
								this.Refuse = true;
							}
							else
							{
								this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
								this.S.Subtitle.UpdateLabel(SubtitleType.StudentStay, 0, 5f);
							}
						}
						else
						{
							StudentScript studentScript = this.S.StudentManager.Students[this.S.DialogueWheel.Victim];
							this.Grudge = false;
							if (studentScript.Club == ClubType.Delinquent || (this.S.Bullied && studentScript.Club == ClubType.Bully) || (studentScript.StudentID == 36 && this.S.StudentManager.TaskManager.TaskStatus[36] < 3))
							{
								this.Grudge = true;
							}
							if (studentScript.Routine && !studentScript.TargetedForDistraction && !studentScript.InEvent && !this.Grudge && studentScript.Indoors && studentScript.gameObject.activeInHierarchy && studentScript.ClubActivityPhase < 16 && studentScript.CurrentAction != StudentActionType.Sunbathe)
							{
								int num3 = 0;
								if (this.S.Yandere.Club == ClubType.Delinquent)
								{
									this.S.Reputation.PendingRep -= 10f;
									this.S.PendingRep -= 10f;
									num3++;
								}
								this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
								this.S.Subtitle.UpdateLabel(SubtitleType.StudentDistract, num3, 3f);
								this.Refuse = false;
							}
							else
							{
								this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
								if (this.Grudge)
								{
									this.S.Subtitle.UpdateLabel(SubtitleType.StudentDistractBullyRefuse, 0, 3f);
								}
								else
								{
									this.S.Subtitle.UpdateLabel(SubtitleType.StudentDistractRefuse, 0, 3f);
								}
								this.Refuse = true;
							}
						}
					}
					else
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 6, 5f);
						this.Refuse = true;
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.CharacterAnimation[this.S.Nod1Anim].time >= this.S.CharacterAnimation[this.S.Nod1Anim].length)
					{
						this.S.CharacterAnimation.CrossFade(this.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
						if (!this.Refuse && (this.S.Clock.HourTime < 8f || (this.S.Clock.HourTime > 13f && this.S.Clock.HourTime < 13.375f) || this.S.Clock.HourTime > 15.5f) && !this.S.Distracting)
						{
							this.S.DistractionTarget = this.S.StudentManager.Students[this.S.DialogueWheel.Victim];
							this.S.DistractionTarget.TargetedForDistraction = true;
							this.S.CurrentDestination = this.S.DistractionTarget.transform;
							this.S.Pathfinding.target = this.S.DistractionTarget.transform;
							this.S.Pathfinding.speed = 4f;
							this.S.TargetDistance = 1f;
							this.S.DistractTimer = 10f;
							this.S.Distracting = true;
							this.S.Routine = false;
							this.S.CanTalk = false;
						}
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.PersonalGrudge)
			{
				if (this.S.TalkTimer == 5f)
				{
					if (this.S.Persona == PersonaType.Coward || this.S.Persona == PersonaType.Fragile)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.CowardGrudge, 0, 5f);
						this.S.CharacterAnimation.CrossFade(this.S.CowardAnim);
						this.S.TalkTimer = 5f;
					}
					else
					{
						if (!this.S.Male)
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.GrudgeWarning, 0, 99f);
						}
						else if (this.S.Club == ClubType.Delinquent)
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.DelinquentGrudge, 1, 99f);
						}
						else
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.GrudgeWarning, 1, 99f);
						}
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
						this.S.CharacterAnimation.CrossFade(this.S.GrudgeAnim);
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.ClubInfo)
			{
				if (this.S.TalkTimer == 100f)
				{
					this.S.Subtitle.UpdateLabel(this.S.ClubInfoResponseType, this.S.ClubPhase, 99f);
					this.S.TalkTimer = this.S.Subtitle.GetClubClipLength(this.S.Club, this.S.ClubPhase);
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = 0f;
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					if (this.S.ClubPhase == 3)
					{
						this.S.DialogueWheel.Panel.enabled = true;
						this.S.DialogueWheel.Show = true;
						this.S.Subtitle.Label.text = string.Empty;
						this.S.Interaction = StudentInteractionType.Idle;
						this.S.TalkTimer = 0f;
					}
					else
					{
						this.S.ClubPhase++;
						this.S.Subtitle.UpdateLabel(this.S.ClubInfoResponseType, this.S.ClubPhase, 99f);
						this.S.TalkTimer = this.S.Subtitle.GetClubClipLength(this.S.Club, this.S.ClubPhase);
					}
				}
			}
			else if (this.S.Interaction == StudentInteractionType.ClubJoin)
			{
				if (this.S.TalkTimer == 100f)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubJoin, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 2)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubAccept, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 3)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubRefuse, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 4)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubRejoin, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 5)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubExclusive, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 6)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubGrudge, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = 0f;
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.DialogueWheel.ClubWindow.Club = this.S.Club;
						this.S.DialogueWheel.ClubWindow.UpdateWindow();
						this.S.Subtitle.Label.text = string.Empty;
						this.S.Interaction = StudentInteractionType.Idle;
					}
					else
					{
						this.S.DialogueWheel.End();
						if (this.S.Club == ClubType.MartialArts)
						{
							this.S.ChangingBooth.CheckYandereClub();
						}
					}
				}
			}
			else if (this.S.Interaction == StudentInteractionType.ClubQuit)
			{
				if (this.S.TalkTimer == 100f)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubQuit, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 2)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubConfirm, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 3)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubDeny, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = 0f;
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.DialogueWheel.ClubWindow.Club = this.S.Club;
						this.S.DialogueWheel.ClubWindow.Quitting = true;
						this.S.DialogueWheel.ClubWindow.UpdateWindow();
						this.S.Subtitle.Label.text = string.Empty;
						this.S.Interaction = StudentInteractionType.Idle;
					}
					else
					{
						this.S.DialogueWheel.End();
						if (this.S.Club == ClubType.MartialArts)
						{
							this.S.ChangingBooth.CheckYandereClub();
						}
						if (this.S.ClubPhase == 2)
						{
						}
					}
				}
			}
			else if (this.S.Interaction == StudentInteractionType.ClubBye)
			{
				if (this.S.TalkTimer == this.S.Subtitle.ClubFarewellClips[(int)(this.S.Club + this.ClubBonus)].length)
				{
					this.S.Subtitle.UpdateLabel(SubtitleType.ClubFarewell, (int)(this.S.Club + this.ClubBonus), this.S.Subtitle.ClubFarewellClips[(int)(this.S.Club + this.ClubBonus)].length);
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.TalkTimer = 0f;
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					this.S.DialogueWheel.End();
				}
			}
			else if (this.S.Interaction == StudentInteractionType.ClubActivity)
			{
				if (this.S.TalkTimer == 100f)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubActivity, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 2)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubYes, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 3)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubNo, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 4)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubEarly, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 5)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubLate, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = 0f;
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.DialogueWheel.ClubWindow.Club = this.S.Club;
						this.S.DialogueWheel.ClubWindow.Activity = true;
						this.S.DialogueWheel.ClubWindow.UpdateWindow();
						this.S.Subtitle.Label.text = string.Empty;
						this.S.Interaction = StudentInteractionType.Idle;
					}
					else if (this.S.ClubPhase == 2)
					{
						this.S.Police.Darkness.enabled = true;
						this.S.Police.ClubActivity = true;
						this.S.Police.FadeOut = true;
						this.S.Subtitle.Label.text = string.Empty;
						this.S.Interaction = StudentInteractionType.Idle;
					}
					else
					{
						this.S.DialogueWheel.End();
					}
				}
			}
			else if (this.S.Interaction == StudentInteractionType.ClubUnwelcome)
			{
				this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
				if (this.S.TalkTimer == 5f)
				{
					this.S.Subtitle.UpdateLabel(SubtitleType.ClubUnwelcome, (int)(this.S.Club + this.ClubBonus), 99f);
					this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.ClubKick)
			{
				this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
				if (this.S.TalkTimer == 5f)
				{
					this.S.Subtitle.UpdateLabel(SubtitleType.ClubKick, (int)(this.S.Club + this.ClubBonus), 99f);
					this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.ClubManager.DeactivateClubBenefit();
						this.S.Yandere.Club = ClubType.None;
						this.S.DialogueWheel.End();
						this.S.Yandere.ClubAccessory();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.ClubGrudge)
			{
				this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
				if (this.S.TalkTimer == 5f)
				{
					this.S.Subtitle.UpdateLabel(SubtitleType.ClubGrudge, (int)(this.S.Club + this.ClubBonus), 99f);
					this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.ClubPractice)
			{
				if (this.S.TalkTimer == 100f)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubPractice, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 2)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubPracticeYes, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 3)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.ClubPracticeNo, (int)(this.S.Club + this.ClubBonus), 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = 0f;
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.DialogueWheel.PracticeWindow.Club = this.S.Club;
						this.S.DialogueWheel.PracticeWindow.UpdateWindow();
						this.S.DialogueWheel.PracticeWindow.Selected = 1;
						this.S.DialogueWheel.PracticeWindow.ID = 1;
						this.S.Subtitle.Label.text = string.Empty;
						this.S.Interaction = StudentInteractionType.Idle;
					}
					else if (this.S.ClubPhase == 2)
					{
						this.S.DialogueWheel.PracticeWindow.Club = this.S.Club;
						this.S.DialogueWheel.PracticeWindow.FadeOut = true;
						this.S.DialogueWheel.PracticeWindow.FadeIn = false;
						this.S.Subtitle.Label.text = string.Empty;
						this.S.Interaction = StudentInteractionType.Idle;
					}
					else if (this.S.ClubPhase == 3)
					{
						this.S.DialogueWheel.End();
					}
				}
			}
			else if (this.S.Interaction == StudentInteractionType.NamingCrush)
			{
				if (this.S.TalkTimer == 3f)
				{
					if (this.S.DialogueWheel.Victim != this.S.Crush)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.SuitorLove, 0, 3f);
						this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
						this.S.CurrentAnim = this.S.GossipAnim;
					}
					else
					{
						DatingGlobals.SuitorProgress = 1;
						this.S.Yandere.LoveManager.SuitorProgress++;
						this.S.Subtitle.UpdateLabel(SubtitleType.SuitorLove, 1, 3f);
						this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
						this.S.CurrentAnim = this.S.Nod1Anim;
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.CharacterAnimation[this.S.CurrentAnim].time >= this.S.CharacterAnimation[this.S.CurrentAnim].length)
					{
						this.S.CharacterAnimation.CrossFade(this.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.ChangingAppearance)
			{
				if (this.S.TalkTimer == 3f)
				{
					this.S.Subtitle.UpdateLabel(SubtitleType.SuitorLove, 2, 3f);
					this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.CharacterAnimation[this.S.Nod1Anim].time >= this.S.CharacterAnimation[this.S.Nod1Anim].length)
					{
						this.S.CharacterAnimation.CrossFade(this.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.Court)
			{
				if (this.S.TalkTimer == 3f)
				{
					if (this.S.Male)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.SuitorLove, 3, 5f);
					}
					else if (this.S.HelpOffered)
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.SuitorLove, 6, 5f);
						this.Refuse = true;
					}
					else
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.SuitorLove, 4, 5f);
					}
					this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.CharacterAnimation[this.S.Nod1Anim].time >= this.S.CharacterAnimation[this.S.Nod1Anim].length)
					{
						this.S.CharacterAnimation.CrossFade(this.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						if (!this.Refuse)
						{
							this.S.MeetTime = this.S.Clock.HourTime - 1f;
							if (this.S.Male)
							{
								this.S.MeetSpot = this.S.StudentManager.SuitorSpot;
							}
							else
							{
								this.S.MeetSpot = this.S.StudentManager.RomanceSpot;
								this.S.StudentManager.LoveManager.RivalWaiting = true;
							}
							this.S.Hurry = true;
							this.S.Pathfinding.speed = 4f;
							this.S.MeetTime = this.S.Clock.HourTime;
						}
						this.S.DialogueWheel.End();
						this.Refuse = false;
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.Advice)
			{
				if (this.S.TalkTimer == 5f)
				{
					this.S.Subtitle.UpdateLabel(SubtitleType.SuitorLove, 5, 99f);
					this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.CharacterAnimation[this.S.Nod1Anim].time >= this.S.CharacterAnimation[this.S.Nod1Anim].length)
					{
						this.S.CharacterAnimation.CrossFade(this.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.Rose = true;
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.Feeding)
			{
				Debug.Log("Feeding.");
				if (this.S.TalkTimer == 10f)
				{
					if (this.S.Club == ClubType.Delinquent)
					{
						this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
						this.S.Subtitle.UpdateLabel(SubtitleType.RejectFood, 1, 3f);
					}
					else if (this.S.Fed || this.S.Club == ClubType.Council || this.S.StudentID == 22)
					{
						this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
						this.S.Subtitle.UpdateLabel(SubtitleType.RejectFood, 0, 3f);
						this.S.Fed = true;
					}
					else
					{
						this.S.CharacterAnimation.CrossFade(this.S.Nod2Anim);
						this.S.Subtitle.UpdateLabel(SubtitleType.AcceptFood, 0, 3f);
						this.CalculateRepBonus();
						this.S.Reputation.PendingRep += 1f + (float)this.S.RepBonus;
						this.S.PendingRep += 1f + (float)this.S.RepBonus;
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.TalkTimer = 0f;
				}
				if (this.S.CharacterAnimation[this.S.Nod2Anim].time >= this.S.CharacterAnimation[this.S.Nod2Anim].length)
				{
					this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
				}
				if (this.S.CharacterAnimation[this.S.GossipAnim].time >= this.S.CharacterAnimation[this.S.GossipAnim].length)
				{
					this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					if (!this.S.Fed && this.S.Club != ClubType.Delinquent)
					{
						this.S.Yandere.PickUp.FoodPieces[this.S.Yandere.PickUp.Food].SetActive(false);
						this.S.Yandere.PickUp.Food--;
						this.S.Fed = true;
					}
					this.S.DialogueWheel.End();
					this.S.StudentManager.UpdateStudents(0);
				}
			}
			else if (this.S.Interaction == StudentInteractionType.TaskInquiry)
			{
				Debug.Log(this.S.Name + " is currently being told to respond to a Task Inquiry.");
				if (this.S.TalkTimer == 10f)
				{
					if (this.S.Club == ClubType.Bully)
					{
						this.S.CharacterAnimation.CrossFade("f02_embar_00");
						this.S.Subtitle.UpdateLabel(SubtitleType.TaskInquiry, this.S.StudentID - 80, 10f);
					}
					else if (this.S.StudentID == 10)
					{
						this.S.CharacterAnimation.CrossFade("f02_nod_00");
						if (this.S.FollowTarget != null)
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.TaskInquiry, 7, 10f);
						}
						else
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.TaskInquiry, 8, 8f);
						}
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.TalkTimer = 0f;
				}
				if (this.S.CharacterAnimation["f02_embar_00"].time >= this.S.CharacterAnimation["f02_embar_00"].length)
				{
					this.S.CharacterAnimation.CrossFade(this.IdleAnim);
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					if (this.S.Club == ClubType.Bully)
					{
						this.S.StudentManager.TaskManager.GirlsQuestioned[this.S.StudentID - 80] = true;
					}
					else if (this.S.StudentID == 10)
					{
						this.S.Destinations[this.S.Phase] = this.S.StudentManager.RaibaruMentorSpot;
						this.S.Pathfinding.target = this.S.StudentManager.RaibaruMentorSpot;
						this.S.CurrentDestination = this.S.StudentManager.RaibaruMentorSpot;
						this.S.Actions[this.S.Phase] = StudentActionType.Socializing;
						this.S.CurrentAction = StudentActionType.Socializing;
						if (this.S.FollowTarget != null)
						{
							this.S.FollowTarget.Follower = null;
						}
						this.S.Pathfinding.speed = 4f;
						this.S.InEvent = true;
						this.S.Hurry = true;
					}
					this.S.DialogueWheel.End();
				}
			}
			else if (this.S.Interaction == StudentInteractionType.TakingSnack)
			{
				Debug.Log(this.S.Name + " is reacting to being offered a snack.");
				if (this.S.TalkTimer == 5f)
				{
					bool flag8 = false;
					if (this.S.StudentID == this.S.StudentManager.RivalID)
					{
						if (this.S.StudentManager.Eighties)
						{
							if (this.S.Clock.Period > 2 && this.S.StudentManager.RivalBookBag.BentoStolen)
							{
								this.S.Hungry = true;
								this.S.Fed = false;
							}
						}
						else if (!this.S.Hungry)
						{
							Debug.Log("The rival is not hungry, so she is going to refuse the snack.");
							flag8 = true;
						}
						else
						{
							Debug.Log("Osana is hungry, and should accept the snack.");
						}
					}
					if (this.S.Club == ClubType.Delinquent && !this.S.StudentManager.MissionMode)
					{
						this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
						this.S.Subtitle.UpdateLabel(SubtitleType.RejectFood, 1, 3f);
						this.S.IgnoreFoodTimer = 10f;
					}
					else if (this.S.Fed || this.S.Club == ClubType.Council || flag8 || this.S.StudentID == 22)
					{
						this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
						this.S.Subtitle.UpdateLabel(SubtitleType.RejectFood, 0, 3f);
						this.S.IgnoreFoodTimer = 10f;
						this.S.Fed = true;
						if (this.S.StudentID == this.S.StudentManager.RivalID)
						{
							this.S.Subtitle.UpdateLabel(SubtitleType.RejectFood, 2, 5f);
						}
						Debug.Log(this.S.Name + " has refused the snack.");
					}
					else
					{
						this.S.CharacterAnimation.CrossFade(this.S.Nod2Anim);
						this.S.Subtitle.UpdateLabel(SubtitleType.AcceptFood, 0, 10f);
						this.CalculateRepBonus();
						this.S.Reputation.PendingRep += 1f + (float)this.S.RepBonus;
						this.S.PendingRep += 1f + (float)this.S.RepBonus;
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.TalkTimer = 0f;
				}
				if (this.S.CharacterAnimation[this.S.Nod2Anim].time >= this.S.CharacterAnimation[this.S.Nod2Anim].length)
				{
					this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
				}
				if (this.S.CharacterAnimation[this.S.GossipAnim].time >= this.S.CharacterAnimation[this.S.GossipAnim].length)
				{
					this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					bool flag9 = false;
					if (this.S.Club == ClubType.Delinquent && !this.S.StudentManager.MissionMode)
					{
						flag9 = true;
					}
					if (!this.S.Fed && !flag9)
					{
						if (this.S.StudentID == this.S.StudentManager.RivalID && SchemeGlobals.GetSchemeStage(4) == 5)
						{
							SchemeGlobals.SetSchemeStage(4, 6);
							this.S.Yandere.PauseScreen.Schemes.UpdateInstructions();
						}
						PickUpScript pickUp = this.S.Yandere.PickUp;
						this.S.Yandere.EmptyHands();
						this.S.EmptyHands();
						pickUp.GetComponent<MeshFilter>().mesh = this.S.StudentManager.OpenChipBag;
						pickUp.transform.parent = this.S.LeftItemParent;
						pickUp.transform.localPosition = new Vector3(-0.02f, -0.075f, 0f);
						pickUp.transform.localEulerAngles = new Vector3(-15f, -15f, 30f);
						pickUp.MyRigidbody.useGravity = false;
						pickUp.MyRigidbody.isKinematic = true;
						pickUp.Prompt.Hide();
						pickUp.Prompt.enabled = false;
						pickUp.enabled = false;
						this.S.BagOfChips = pickUp.gameObject;
						this.S.EatingSnack = true;
						this.S.Private = true;
						this.S.Hungry = false;
						this.S.Fed = true;
					}
					this.S.DialogueWheel.End();
					this.S.StudentManager.UpdateStudents(0);
				}
			}
			else if (this.S.Interaction == StudentInteractionType.GivingHelp)
			{
				if (this.S.TalkTimer == 4f)
				{
					if (this.S.Club == ClubType.Council || this.S.Club == ClubType.Delinquent)
					{
						this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
						this.S.Subtitle.UpdateLabel(SubtitleType.RejectHelp, 0, 4f);
					}
					else if (this.S.Yandere.Bloodiness > 0f)
					{
						this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
						this.S.Subtitle.UpdateLabel(SubtitleType.RejectHelp, 1, 4f);
					}
					else
					{
						this.S.CharacterAnimation.CrossFade(this.S.PullBoxCutterAnim);
						this.S.SmartPhone.SetActive(false);
						this.S.Subtitle.UpdateLabel(SubtitleType.GiveHelp, 0, 4f);
					}
				}
				else
				{
					Input.GetButtonDown("A");
				}
				if (this.S.CharacterAnimation[this.S.GossipAnim].time >= this.S.CharacterAnimation[this.S.GossipAnim].length)
				{
					this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
				}
				if (this.S.CharacterAnimation[this.S.PullBoxCutterAnim].time >= this.S.CharacterAnimation[this.S.PullBoxCutterAnim].length)
				{
					this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.Club != ClubType.Council && this.S.Club != ClubType.Delinquent)
				{
					this.S.MoveTowardsTarget(this.S.Yandere.transform.position + this.S.Yandere.transform.forward * 0.75f);
					if (this.S.CharacterAnimation[this.S.PullBoxCutterAnim].time >= this.S.CharacterAnimation[this.S.PullBoxCutterAnim].length)
					{
						this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
						this.StuckBoxCutter = null;
					}
					else if (this.S.CharacterAnimation[this.S.PullBoxCutterAnim].time >= 2f)
					{
						if (this.StuckBoxCutter.transform.parent != this.S.RightEye)
						{
							this.StuckBoxCutter.Prompt.enabled = true;
							this.StuckBoxCutter.enabled = true;
							this.StuckBoxCutter.transform.parent = this.S.Yandere.PickUp.transform;
							this.StuckBoxCutter.transform.localPosition = new Vector3(0f, 0.19f, 0f);
							this.StuckBoxCutter.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
						}
					}
					else if (this.S.CharacterAnimation[this.S.PullBoxCutterAnim].time >= 1.166666f && this.StuckBoxCutter == null)
					{
						this.StuckBoxCutter = this.S.Yandere.PickUp.StuckBoxCutter;
						this.S.Yandere.PickUp.StuckBoxCutter = null;
						this.StuckBoxCutter.FingerprintID = this.S.StudentID;
						this.StuckBoxCutter.transform.parent = this.S.RightHand;
						this.StuckBoxCutter.transform.localPosition = new Vector3(0f, 0f, 0f);
						this.StuckBoxCutter.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
					}
				}
				if (this.S.TalkTimer <= 0f)
				{
					this.S.DialogueWheel.End();
					this.S.StudentManager.UpdateStudents(0);
				}
			}
			else if (this.S.Interaction == StudentInteractionType.SentToLocker)
			{
				bool flag10 = false;
				if (this.S.Club == ClubType.Delinquent)
				{
					flag10 = true;
				}
				if (this.S.Friend)
				{
					flag10 = false;
				}
				if (this.S.TalkTimer == 5f)
				{
					if (!flag10)
					{
						this.Refuse = false;
						if ((this.S.Clock.HourTime > 8f && this.S.Clock.HourTime < 13f) || (this.S.Clock.HourTime > 13.375f && this.S.Clock.HourTime < 15.5f))
						{
							this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
							this.S.Subtitle.UpdateLabel(SubtitleType.SendToLocker, 1, 5f);
							this.Refuse = true;
						}
						else if (this.S.Club == ClubType.Council)
						{
							this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
							this.S.Subtitle.UpdateLabel(SubtitleType.SendToLocker, 3, 5f);
							this.Refuse = true;
						}
						else if (!this.S.StudentManager.MissionMode && this.S.Rival)
						{
							if (!this.S.Friend || this.S.Reputation.Reputation < (float)(DateGlobals.Week * 10))
							{
								if (!this.S.Friend)
								{
									this.S.Yandere.NotificationManager.CustomText = "You must befriend her first";
									this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
								}
								if (this.S.Reputation.Reputation < (float)(DateGlobals.Week * 10))
								{
									this.S.Yandere.NotificationManager.CustomText = "You need at least " + (DateGlobals.Week * 10).ToString() + " Reputation Points";
									this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
								}
								this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
								this.S.Subtitle.UpdateLabel(SubtitleType.SendToLocker, 4, 5f);
								this.Refuse = true;
							}
							else
							{
								this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
								this.S.Subtitle.UpdateLabel(SubtitleType.SendToLocker, 2, 5f);
							}
						}
						else
						{
							this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
							this.S.Subtitle.UpdateLabel(SubtitleType.SendToLocker, 2, 5f);
						}
					}
					else
					{
						this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 5, 5f);
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.CharacterAnimation[this.S.Nod1Anim].time >= this.S.CharacterAnimation[this.S.Nod1Anim].length)
					{
						this.S.CharacterAnimation.CrossFade(this.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						if (!this.Refuse)
						{
							if (!flag10)
							{
								this.S.Pathfinding.speed = 4f;
								this.S.TargetDistance = 1f;
								this.S.SentToLocker = true;
								this.S.Routine = false;
								this.S.CanTalk = false;
							}
							else
							{
								this.S.Pathfinding.speed = 1f;
								this.S.TargetDistance = 0.5f;
								this.S.Routine = true;
								this.S.CanTalk = true;
							}
						}
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.WaitingForBeatEmUpResult)
			{
				Debug.Log("We are currently ''waiting for beat em up result''");
				if (!this.FadeIn)
				{
					this.S.Subtitle.Darkness.alpha = Mathf.MoveTowards(this.S.Subtitle.Darkness.alpha, 1f, Time.deltaTime);
					if (this.S.Subtitle.Darkness.alpha == 1f)
					{
						this.S.TriggerBeatEmUpMinigame();
						this.FadeIn = true;
					}
				}
				else
				{
					Debug.Log("''FadeIn'' is false.");
					this.S.Subtitle.Darkness.alpha = Mathf.MoveTowards(this.S.Subtitle.Darkness.alpha, 0f, Time.deltaTime);
					if (this.S.Subtitle.Darkness.alpha == 0f)
					{
						Debug.Log("''Darkness'' is 0.");
						if (!GameGlobals.BeatEmUpSuccess)
						{
							this.S.DialogueWheel.End();
							this.Timer = 0f;
						}
						else
						{
							Debug.Log("''BeatEmUpSuccess'' is true.");
							this.S.StudentManager.UpdateAllAnimLayers();
							this.S.Yandere.SetAnimationLayers();
							AstarPath.active.Scan(null);
							this.S.TaskPhase = 5;
							this.S.Interaction = StudentInteractionType.GivingTask;
							this.Timer = 0f;
							Debug.Log("Now telling " + this.S.Name + " to go home.");
							this.S.CurrentDestination.transform.position = this.S.StudentManager.Exit.position;
							ScheduleBlock scheduleBlock = this.S.ScheduleBlocks[6];
							scheduleBlock.destination = "Exit";
							scheduleBlock.action = "Stand";
							this.S.GetDestinations();
						}
						this.FadeIn = false;
					}
				}
			}
			if (this.S.StudentID == 41 && !this.S.DialogueWheel.ClubLeader && this.S.Interaction != StudentInteractionType.ClubUnwelcome && !this.S.StudentManager.Eighties && this.S.TalkTimer > 0f)
			{
				Debug.Log("Geiju response.");
				if (this.NegativeResponse)
				{
					Debug.Log("Negative response.");
					this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
				}
				else
				{
					this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 5, 5f);
				}
			}
			if (this.S.Waiting)
			{
				this.S.WaitTimer -= Time.deltaTime;
				if (this.S.WaitTimer <= 0f)
				{
					this.S.DialogueWheel.TaskManager.UpdateTaskStatus();
					this.S.Talking = false;
					this.S.Waiting = false;
					base.enabled = false;
					if (!this.Fake && !this.S.StudentManager.CombatMinigame.Practice)
					{
						this.S.Pathfinding.canSearch = true;
						this.S.Pathfinding.canMove = true;
						this.S.Obstacle.enabled = false;
						this.S.Alarmed = false;
						if (!this.S.Following && !this.S.Distracting && !this.S.Wet && !this.S.EatingSnack && !this.S.SentToLocker)
						{
							this.S.Routine = true;
						}
						if (!this.S.Following)
						{
							this.S.Hearts.emission.enabled = false;
						}
					}
					this.S.StudentManager.EnablePrompts();
					if (this.S.GoAway)
					{
						Debug.Log("This student was just told to go away.");
						this.S.CurrentDestination = this.S.StudentManager.GoAwaySpots.List[this.S.StudentID];
						this.S.Pathfinding.target = this.S.StudentManager.GoAwaySpots.List[this.S.StudentID];
						this.S.Pathfinding.canSearch = true;
						this.S.Pathfinding.canMove = true;
						this.S.DistanceToDestination = 100f;
						return;
					}
				}
			}
			else
			{
				this.S.targetRotation = Quaternion.LookRotation(new Vector3(this.S.Yandere.transform.position.x, base.transform.position.y, this.S.Yandere.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.S.targetRotation, 10f * Time.deltaTime);
			}
		}
	}

	// Token: 0x06001EB2 RID: 7858 RVA: 0x001AFB8C File Offset: 0x001ADD8C
	private void CalculateRepBonus()
	{
		this.S.RepBonus = 0;
		if (PlayerGlobals.PantiesEquipped == 3)
		{
			this.S.RepBonus++;
		}
		if ((this.S.Male && this.S.Yandere.Class.Seduction + this.S.Yandere.Class.SeductionBonus > 0) || this.S.Yandere.Class.Seduction == 5)
		{
			this.S.RepBonus++;
		}
		if (this.S.Yandere.Class.SocialBonus > 0)
		{
			this.S.RepBonus++;
		}
		this.S.ChameleonCheck();
		if (this.S.Chameleon)
		{
			this.S.RepBonus++;
		}
		this.S.RepBonus += this.S.Yandere.Class.PsychologyGrade + this.S.Yandere.Class.PsychologyBonus;
	}

	// Token: 0x04003F40 RID: 16192
	private const float LongestTime = 100f;

	// Token: 0x04003F41 RID: 16193
	private const float LongTime = 5f;

	// Token: 0x04003F42 RID: 16194
	private const float MediumTime = 3f;

	// Token: 0x04003F43 RID: 16195
	private const float ShortTime = 2f;

	// Token: 0x04003F44 RID: 16196
	public StudentScript S;

	// Token: 0x04003F45 RID: 16197
	public WeaponScript StuckBoxCutter;

	// Token: 0x04003F46 RID: 16198
	public bool NegativeResponse;

	// Token: 0x04003F47 RID: 16199
	public bool FadeIn;

	// Token: 0x04003F48 RID: 16200
	public bool Follow;

	// Token: 0x04003F49 RID: 16201
	public bool Grudge;

	// Token: 0x04003F4A RID: 16202
	public bool Refuse;

	// Token: 0x04003F4B RID: 16203
	public bool Fake;

	// Token: 0x04003F4C RID: 16204
	public string IdleAnim = "";

	// Token: 0x04003F4D RID: 16205
	public float Timer;

	// Token: 0x04003F4E RID: 16206
	public int ClubBonus;
}
