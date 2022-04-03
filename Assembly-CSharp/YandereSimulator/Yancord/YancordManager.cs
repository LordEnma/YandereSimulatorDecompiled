using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200052A RID: 1322
	public class YancordManager : MonoBehaviour
	{
		// Token: 0x0600219D RID: 8605 RVA: 0x001EE490 File Offset: 0x001EC690
		public void Start()
		{
			if (YancordGlobals.CurrentConversation > 5)
			{
				YancordGlobals.CurrentConversation = 1;
			}
			if (!YancordGlobals.JoinedYancord)
			{
				Debug.Log("This is the player's first time launching Yancord.");
				YancordGlobals.CurrentConversation = 1;
				if (this.ConversationID != YancordGlobals.CurrentConversation)
				{
					base.enabled = false;
				}
				this.ChatLabel.text = string.Empty;
				this.Dialogue[1].isSystemMessage = true;
				this.Dialogue[1].Message = "Ayano Aishi has joined the Moonlit Warrior Selene Fanserver.";
				this.FirstTimeUI.gameObject.SetActive(true);
			}
			else
			{
				Debug.Log("The player has launched Yancord before.");
				if (this.ConversationID != YancordGlobals.CurrentConversation)
				{
					base.enabled = false;
				}
				this.JoinServer();
				this.Dialogue[1].isSystemMessage = true;
				this.Dialogue[1].Message = "Ayano Aishi has logged in.";
				this.PartnerOnline.SetActive(true);
				this.BlueDiscordIcon.alpha = 0f;
				this.ChatLabel.text = "Press E to start chatting on the Moonlit Warrior Selene Fanserver!";
			}
			Debug.Log("YancordGlobals.CurrentConversation is: " + YancordGlobals.CurrentConversation.ToString());
			this.CurrentPartner.CurrentStatus = Status.Online;
			this.SpawnAll();
			this.Choice = new int[this.Dialogue.Count];
			this.Darkness.color = new Color(0f, 0f, 0f, 1f);
			this.FadeIn = true;
		}

		// Token: 0x0600219E RID: 8606 RVA: 0x001EE608 File Offset: 0x001EC808
		public void Update()
		{
			if (this.FadeIn)
			{
				float num = this.Darkness.color.a;
				num = Mathf.MoveTowards(num, 0f, Time.deltaTime);
				this.Darkness.color = new Color(0f, 0f, 0f, num);
				if (this.Darkness.color.a == 0f)
				{
					this.FadeIn = false;
				}
			}
			else if (this.FadeOut)
			{
				float num2 = this.Darkness.color.a;
				num2 = Mathf.MoveTowards(num2, 2f, Time.deltaTime);
				this.Darkness.color = new Color(0f, 0f, 0f, num2);
				if (this.Darkness.color.a > 1f)
				{
					SceneManager.LoadScene("HomeScene");
					DateGlobals.DayPassed = false;
				}
			}
			else if (this.Chatting)
			{
				if (this.currentPhase < this.Dialogue.Count)
				{
					this.CalculateMessageDelay();
					if (this.Dialogue[this.currentPhase].isQuestion)
					{
						if (!this.ShowingDialogueOption)
						{
							this.timer += Time.deltaTime;
							if (string.IsNullOrEmpty(this.ChatLabel.text))
							{
								this.ChatLabel.text = this.CurrentPartner.FirstName + " is typing...";
							}
							if (this.timer > this.messageDelay)
							{
								this.ChatLabel.text = string.Empty;
								this.Messages[this.currentPhase].MyProfile = this.CurrentPartner;
								this.SpawnChatMessage();
								this.timer = 0f;
								this.ShowingDialogueOption = true;
							}
						}
					}
					else if (this.Dialogue[this.currentPhase].isSystemMessage)
					{
						this.timer += Time.deltaTime;
						if (this.timer > this.SystemMessageDelay)
						{
							this.ChatLabel.text = string.Empty;
							this.SpawnChatMessage();
							this.Messages[this.currentPhase].MyProfile = this.SystemProfile;
							this.timer = 0f;
							this.currentPhase++;
						}
					}
					else if (this.currentPhase < this.Dialogue.Count)
					{
						if (this.Dialogue[this.currentPhase].sentByPlayer)
						{
							this.Messages[this.currentPhase].MyProfile = this.MyProfile;
							this.SpawnChatMessage();
							this.currentPhase++;
						}
						else
						{
							this.timer += Time.deltaTime;
							if (string.IsNullOrEmpty(this.ChatLabel.text))
							{
								this.ChatLabel.text = this.CurrentPartner.FirstName + " is typing...";
							}
							if (this.timer > this.messageDelay)
							{
								this.ChatLabel.text = string.Empty;
								this.SpawnChatMessage();
								this.Messages[this.currentPhase].MyProfile = this.CurrentPartner;
								this.timer = 0f;
								this.currentPhase++;
							}
						}
					}
					else
					{
						this.currentPhase++;
					}
					if (Input.GetButtonDown("A"))
					{
						this.timer = this.messageDelay;
					}
				}
				else
				{
					if (string.IsNullOrEmpty(this.ChatLabel.text))
					{
						this.ChatLabel.text = "Press E to log out of Yancord.";
						this.CurrentPartner.CurrentStatus = Status.Invisible;
						this.PartnerOnline.SetActive(false);
						this.PartnerOffline.SetActive(true);
					}
					if (Input.GetButtonDown("A"))
					{
						Debug.Log("Quitting!");
						YancordGlobals.CurrentConversation++;
						this.FadeOut = true;
					}
				}
				if (this.ShowingDialogueOption)
				{
					if (Input.GetButtonDown("A") && !this.DialogueChooseMenu.activeInHierarchy)
					{
						this.ChatLabel.text = "Choose one of the following answers to respond.";
						this.DialogueChooseMenu.SetActive(true);
						this.DialogueChooseLabel[1].text = this.Dialogue[this.currentPhase].OptionQ;
						this.DialogueChooseLabel[2].text = this.Dialogue[this.currentPhase].OptionR;
						this.DialogueChooseLabel[3].text = this.Dialogue[this.currentPhase].OptionF;
						this.DialogueQuestion.MyProfile = this.CurrentPartner;
						this.DialogueQuestion.MessageLabel.text = this.Dialogue[this.currentPhase].Message;
						this.DialogueQuestion.Awake();
					}
					if (this.DialogueChooseMenu.activeInHierarchy)
					{
						if (Input.GetButtonDown("B"))
						{
							this.Choice[this.currentPhase] = 1;
						}
						else if (Input.GetButtonDown("Y"))
						{
							this.Choice[this.currentPhase] = 2;
						}
						else if (Input.GetButtonDown("X"))
						{
							this.Choice[this.currentPhase] = 3;
						}
						if (this.Choice[this.currentPhase] != 0)
						{
							this.Dialogue[this.currentPhase + 1].Message = this.GetAnswer(this.currentPhase);
							this.Dialogue[this.currentPhase + 2].Message = this.GetReaction(this.currentPhase);
							this.Dialogue[this.currentPhase + 1].sentByPlayer = true;
							this.DialogueChooseMenu.SetActive(false);
							this.ChatLabel.text = "";
							this.ShowingDialogueOption = false;
							this.timer = 0f;
							this.currentPhase++;
						}
					}
					else if (string.IsNullOrEmpty(this.ChatLabel.text))
					{
						this.ChatLabel.text = "Press E to respond.";
					}
				}
				if (this.BlueDiscordIcon.alpha >= 0f)
				{
					this.BlueDiscordIcon.alpha -= Time.deltaTime * 10f;
				}
			}
			else if (!YancordGlobals.JoinedYancord)
			{
				if (Input.GetButtonDown("A"))
				{
					YancordGlobals.JoinedYancord = true;
					this.JoinServer();
					this.SpawnChatMessage();
					this.PartnerOnline.SetActive(true);
					this.Chatting = true;
				}
				else if (Input.GetButtonDown("B"))
				{
					Debug.Log("Quitting!");
					this.FadeOut = true;
				}
			}
			else if (Input.GetButtonDown("A"))
			{
				this.ChatLabel.text = string.Empty;
				this.SpawnChatMessage();
				this.Chatting = true;
			}
			else if (Input.GetButtonDown("B"))
			{
				Debug.Log("Quitting!");
				this.FadeOut = true;
			}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				YancordGlobals.JoinedYancord = false;
			}
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				YancordGlobals.CurrentConversation = 1;
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				YancordGlobals.CurrentConversation = 2;
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				YancordGlobals.CurrentConversation = 3;
			}
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				YancordGlobals.CurrentConversation = 4;
			}
			if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				YancordGlobals.CurrentConversation = 5;
			}
		}

		// Token: 0x0600219F RID: 8607 RVA: 0x001EED68 File Offset: 0x001ECF68
		private string GetReaction(int phase)
		{
			switch (this.Choice[phase])
			{
			case 1:
				return this.Dialogue[phase].ReactionQ;
			case 2:
				return this.Dialogue[phase].ReactionR;
			case 3:
				return this.Dialogue[phase].ReactionF;
			default:
				return null;
			}
		}

		// Token: 0x060021A0 RID: 8608 RVA: 0x001EEDCC File Offset: 0x001ECFCC
		private string GetAnswer(int phase)
		{
			switch (this.Choice[phase])
			{
			case 1:
				return this.Dialogue[phase].OptionQ;
			case 2:
				return this.Dialogue[phase].OptionR;
			case 3:
				return this.Dialogue[phase].OptionF;
			default:
				return null;
			}
		}

		// Token: 0x060021A1 RID: 8609 RVA: 0x001EEE30 File Offset: 0x001ED030
		private void SpawnAll()
		{
			for (int i = 1; i < this.Dialogue.Count; i++)
			{
				MessageScript item = UnityEngine.Object.Instantiate<MessageScript>(this.MessagePrefab, new Vector3(0f, this.Messages[i - 1].transform.position.y - ((float)this.Messages[i - 1].MessageLabel.height * 0.0016723945f + this.Distance * 0.0016723945f), 0f), Quaternion.identity, this.ConversationParent);
				this.Messages.Add(item);
				this.Messages[i].MessageLabel.text = this.Dialogue[i].Message;
				if (this.Dialogue[i].isQuestion)
				{
					this.Dialogue[i + 1].sentByPlayer = true;
				}
				if (this.Dialogue[i].isSystemMessage)
				{
					this.Messages[i].MyProfile = this.SystemProfile;
				}
				else if (this.Dialogue[i].sentByPlayer)
				{
					this.Messages[i].MyProfile = this.MyProfile;
				}
				else
				{
					this.Messages[i].MyProfile = this.CurrentPartner;
				}
				this.Messages[i].Awake();
				this.Messages[i].gameObject.SetActive(false);
			}
		}

		// Token: 0x060021A2 RID: 8610 RVA: 0x001EEFBC File Offset: 0x001ED1BC
		private void SpawnChatMessage()
		{
			if (this.Messages[this.currentPhase].transform.position.y < -400f || this.Messages[this.currentPhase].transform.localPosition.y - (float)this.Messages[this.currentPhase].MessageLabel.height < -400f)
			{
				if (!this.Messages[this.currentPhase].gameObject.activeInHierarchy)
				{
					this.Messages[this.currentPhase].gameObject.SetActive(true);
					this.Messages[this.currentPhase].MessageLabel.text = this.Dialogue[this.currentPhase].Message;
					float num = -400f + (float)this.Messages[this.currentPhase].MessageLabel.height - 10f;
					Vector3 position = this.Messages[this.currentPhase].transform.position;
					this.Messages[this.currentPhase].transform.position = new Vector3(0f, num * 0.0016723945f, 0f);
					for (int i = this.currentPhase - 1; i >= 0; i--)
					{
						this.Messages[i].transform.position = new Vector3(0f, this.Messages[i + 1].transform.position.y + ((float)this.Messages[i].MessageLabel.height * 0.0016723945f + this.Distance * 0.0016723945f), 0f);
					}
					for (int j = 1; j < this.Messages.Count; j++)
					{
						this.Messages[j].transform.position = new Vector3(0f, this.Messages[j - 1].transform.position.y - ((float)this.Messages[j - 1].MessageLabel.height * 0.0016723945f + this.Distance * 0.0016723945f), 0f);
					}
					return;
				}
			}
			else if (!this.Messages[this.currentPhase].gameObject.activeInHierarchy)
			{
				this.Messages[this.currentPhase].gameObject.SetActive(true);
				this.Messages[this.currentPhase].MessageLabel.text = this.Dialogue[this.currentPhase].Message;
				for (int k = this.currentPhase; k < this.Messages.Count; k++)
				{
					this.Messages[k].transform.position = new Vector3(0f, this.Messages[k - 1].transform.position.y - ((float)this.Messages[k - 1].MessageLabel.height * 0.0016723945f + this.Distance * 0.0016723945f), 0f);
				}
			}
		}

		// Token: 0x060021A3 RID: 8611 RVA: 0x001EF320 File Offset: 0x001ED520
		private void JoinServer()
		{
			this.NewServer.SetActive(true);
			this.SelectedServer.gameObject.SetActive(true);
			this.SelectedServer.position = new Vector3(this.SelectedServer.position.x, this.NewServer.transform.position.y, this.SelectedServer.position.z);
			this.CreateNewServer.position = new Vector3(this.CreateNewServer.position.x, 0.37407407f, this.CreateNewServer.position.z);
			this.DirectMessages.SetActive(false);
			this.FindLabel.SetActive(false);
			this.ServerRelated.SetActive(true);
			this.FirstTimeUI.gameObject.SetActive(false);
		}

		// Token: 0x060021A4 RID: 8612 RVA: 0x001EF3F9 File Offset: 0x001ED5F9
		private void CalculateMessageDelay()
		{
			this.messageDelay = 3f;
		}

		// Token: 0x040049F8 RID: 18936
		[Header("== Conversation related ==")]
		[Range(1f, 50f)]
		public int ConversationID = 1;

		// Token: 0x040049F9 RID: 18937
		[Header("== Chatpartner related ==")]
		public Profile CurrentPartner;

		// Token: 0x040049FA RID: 18938
		public Profile MyProfile;

		// Token: 0x040049FB RID: 18939
		public Profile SystemProfile;

		// Token: 0x040049FC RID: 18940
		[Space(20f)]
		[Header("== Chat related ==")]
		public MessageScript MessagePrefab;

		// Token: 0x040049FD RID: 18941
		public List<MessageScript> Messages = new List<MessageScript>();

		// Token: 0x040049FE RID: 18942
		public List<NewTextMessage> Dialogue = new List<NewTextMessage>();

		// Token: 0x040049FF RID: 18943
		public Transform ConversationParent;

		// Token: 0x04004A00 RID: 18944
		private int[] Choice;

		// Token: 0x04004A01 RID: 18945
		public int currentPhase = 1;

		// Token: 0x04004A02 RID: 18946
		public float Distance;

		// Token: 0x04004A03 RID: 18947
		[Space(20f)]
		public UILabel ChatLabel;

		// Token: 0x04004A04 RID: 18948
		[Header("== Dialogue Menu related ==")]
		public UILabel[] DialogueChooseLabel;

		// Token: 0x04004A05 RID: 18949
		public GameObject DialogueChooseMenu;

		// Token: 0x04004A06 RID: 18950
		public MessageScript DialogueQuestion;

		// Token: 0x04004A07 RID: 18951
		[Header("== Server related ==")]
		public GameObject NewServer;

		// Token: 0x04004A08 RID: 18952
		public Transform SelectedServer;

		// Token: 0x04004A09 RID: 18953
		public Transform CreateNewServer;

		// Token: 0x04004A0A RID: 18954
		public GameObject ServerRelated;

		// Token: 0x04004A0B RID: 18955
		public GameObject PartnerOffline;

		// Token: 0x04004A0C RID: 18956
		public GameObject PartnerOnline;

		// Token: 0x04004A0D RID: 18957
		[Space(20f)]
		public UITexture BlueDiscordIcon;

		// Token: 0x04004A0E RID: 18958
		public GameObject DirectMessages;

		// Token: 0x04004A0F RID: 18959
		public GameObject FindLabel;

		// Token: 0x04004A10 RID: 18960
		public Transform FirstTimeUI;

		// Token: 0x04004A11 RID: 18961
		[SerializeField]
		private bool IsDebug;

		// Token: 0x04004A12 RID: 18962
		[Header("== Delay related ==")]
		public float SystemMessageDelay = 3f;

		// Token: 0x04004A13 RID: 18963
		public float LetterPerSecond = 0.05f;

		// Token: 0x04004A14 RID: 18964
		public float messageDelay;

		// Token: 0x04004A15 RID: 18965
		private bool Chatting;

		// Token: 0x04004A16 RID: 18966
		private bool ShowingDialogueOption;

		// Token: 0x04004A17 RID: 18967
		private bool FadeOut;

		// Token: 0x04004A18 RID: 18968
		private bool FadeIn;

		// Token: 0x04004A19 RID: 18969
		public UITexture Darkness;

		// Token: 0x04004A1A RID: 18970
		public float timer;

		// Token: 0x04004A1B RID: 18971
		private bool shouldScroll;
	}
}
