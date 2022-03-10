using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000521 RID: 1313
	public class YancordManager : MonoBehaviour
	{
		// Token: 0x06002175 RID: 8565 RVA: 0x001EACB8 File Offset: 0x001E8EB8
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

		// Token: 0x06002176 RID: 8566 RVA: 0x001EAE30 File Offset: 0x001E9030
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

		// Token: 0x06002177 RID: 8567 RVA: 0x001EB590 File Offset: 0x001E9790
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

		// Token: 0x06002178 RID: 8568 RVA: 0x001EB5F4 File Offset: 0x001E97F4
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

		// Token: 0x06002179 RID: 8569 RVA: 0x001EB658 File Offset: 0x001E9858
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

		// Token: 0x0600217A RID: 8570 RVA: 0x001EB7E4 File Offset: 0x001E99E4
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

		// Token: 0x0600217B RID: 8571 RVA: 0x001EBB48 File Offset: 0x001E9D48
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

		// Token: 0x0600217C RID: 8572 RVA: 0x001EBC21 File Offset: 0x001E9E21
		private void CalculateMessageDelay()
		{
			this.messageDelay = 3f;
		}

		// Token: 0x04004967 RID: 18791
		[Header("== Conversation related ==")]
		[Range(1f, 50f)]
		public int ConversationID = 1;

		// Token: 0x04004968 RID: 18792
		[Header("== Chatpartner related ==")]
		public Profile CurrentPartner;

		// Token: 0x04004969 RID: 18793
		public Profile MyProfile;

		// Token: 0x0400496A RID: 18794
		public Profile SystemProfile;

		// Token: 0x0400496B RID: 18795
		[Space(20f)]
		[Header("== Chat related ==")]
		public MessageScript MessagePrefab;

		// Token: 0x0400496C RID: 18796
		public List<MessageScript> Messages = new List<MessageScript>();

		// Token: 0x0400496D RID: 18797
		public List<NewTextMessage> Dialogue = new List<NewTextMessage>();

		// Token: 0x0400496E RID: 18798
		public Transform ConversationParent;

		// Token: 0x0400496F RID: 18799
		private int[] Choice;

		// Token: 0x04004970 RID: 18800
		public int currentPhase = 1;

		// Token: 0x04004971 RID: 18801
		public float Distance;

		// Token: 0x04004972 RID: 18802
		[Space(20f)]
		public UILabel ChatLabel;

		// Token: 0x04004973 RID: 18803
		[Header("== Dialogue Menu related ==")]
		public UILabel[] DialogueChooseLabel;

		// Token: 0x04004974 RID: 18804
		public GameObject DialogueChooseMenu;

		// Token: 0x04004975 RID: 18805
		public MessageScript DialogueQuestion;

		// Token: 0x04004976 RID: 18806
		[Header("== Server related ==")]
		public GameObject NewServer;

		// Token: 0x04004977 RID: 18807
		public Transform SelectedServer;

		// Token: 0x04004978 RID: 18808
		public Transform CreateNewServer;

		// Token: 0x04004979 RID: 18809
		public GameObject ServerRelated;

		// Token: 0x0400497A RID: 18810
		public GameObject PartnerOffline;

		// Token: 0x0400497B RID: 18811
		public GameObject PartnerOnline;

		// Token: 0x0400497C RID: 18812
		[Space(20f)]
		public UITexture BlueDiscordIcon;

		// Token: 0x0400497D RID: 18813
		public GameObject DirectMessages;

		// Token: 0x0400497E RID: 18814
		public GameObject FindLabel;

		// Token: 0x0400497F RID: 18815
		public Transform FirstTimeUI;

		// Token: 0x04004980 RID: 18816
		[SerializeField]
		private bool IsDebug;

		// Token: 0x04004981 RID: 18817
		[Header("== Delay related ==")]
		public float SystemMessageDelay = 3f;

		// Token: 0x04004982 RID: 18818
		public float LetterPerSecond = 0.05f;

		// Token: 0x04004983 RID: 18819
		public float messageDelay;

		// Token: 0x04004984 RID: 18820
		private bool Chatting;

		// Token: 0x04004985 RID: 18821
		private bool ShowingDialogueOption;

		// Token: 0x04004986 RID: 18822
		private bool FadeOut;

		// Token: 0x04004987 RID: 18823
		private bool FadeIn;

		// Token: 0x04004988 RID: 18824
		public UITexture Darkness;

		// Token: 0x04004989 RID: 18825
		public float timer;

		// Token: 0x0400498A RID: 18826
		private bool shouldScroll;
	}
}
