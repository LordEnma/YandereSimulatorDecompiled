using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace YandereSimulator.Yancord
{
	public class YancordManager : MonoBehaviour
	{
		[Header("== Conversation related ==")]
		[Range(1f, 50f)]
		public int ConversationID = 1;

		[Header("== Chatpartner related ==")]
		public Profile CurrentPartner;

		public Profile MyProfile;

		public Profile SystemProfile;

		[Space(20f)]
		[Header("== Chat related ==")]
		public MessageScript MessagePrefab;

		public List<MessageScript> Messages = new List<MessageScript>();

		public List<NewTextMessage> Dialogue = new List<NewTextMessage>();

		public Transform ConversationParent;

		private int[] Choice;

		public int currentPhase = 1;

		public float Distance;

		[Space(20f)]
		public UILabel ChatLabel;

		[Header("== Dialogue Menu related ==")]
		public UILabel[] DialogueChooseLabel;

		public GameObject DialogueChooseMenu;

		public MessageScript DialogueQuestion;

		[Header("== Server related ==")]
		public GameObject NewServer;

		public Transform SelectedServer;

		public Transform CreateNewServer;

		public GameObject ServerRelated;

		public GameObject PartnerOffline;

		public GameObject PartnerOnline;

		[Space(20f)]
		public UITexture BlueDiscordIcon;

		public GameObject DirectMessages;

		public GameObject FindLabel;

		public Transform FirstTimeUI;

		[SerializeField]
		private bool IsDebug;

		[Header("== Delay related ==")]
		public float SystemMessageDelay = 3f;

		public float LetterPerSecond = 0.05f;

		public float messageDelay;

		private bool Chatting;

		private bool ShowingDialogueOption;

		private bool FadeOut;

		private bool FadeIn;

		public UITexture Darkness;

		public float timer;

		private bool shouldScroll;

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
				if (ConversationID != YancordGlobals.CurrentConversation)
				{
					base.enabled = false;
				}
				ChatLabel.text = string.Empty;
				Dialogue[1].isSystemMessage = true;
				Dialogue[1].Message = "Ayano Aishi has joined the Moonlit Warrior Selene Fanserver.";
				FirstTimeUI.gameObject.SetActive(true);
			}
			else
			{
				Debug.Log("The player has launched Yancord before.");
				if (ConversationID != YancordGlobals.CurrentConversation)
				{
					base.enabled = false;
				}
				JoinServer();
				Dialogue[1].isSystemMessage = true;
				Dialogue[1].Message = "Ayano Aishi has logged in.";
				PartnerOnline.SetActive(true);
				BlueDiscordIcon.alpha = 0f;
				ChatLabel.text = "Press E to start chatting on the Moonlit Warrior Selene Fanserver!";
			}
			Debug.Log("YancordGlobals.CurrentConversation is: " + YancordGlobals.CurrentConversation);
			CurrentPartner.CurrentStatus = Status.Online;
			SpawnAll();
			Choice = new int[Dialogue.Count];
			Darkness.color = new Color(0f, 0f, 0f, 1f);
			FadeIn = true;
		}

		public void Update()
		{
			if (FadeIn)
			{
				float a = Darkness.color.a;
				a = Mathf.MoveTowards(a, 0f, Time.deltaTime);
				Darkness.color = new Color(0f, 0f, 0f, a);
				if (Darkness.color.a == 0f)
				{
					FadeIn = false;
				}
			}
			else if (FadeOut)
			{
				float a2 = Darkness.color.a;
				a2 = Mathf.MoveTowards(a2, 2f, Time.deltaTime);
				Darkness.color = new Color(0f, 0f, 0f, a2);
				if (Darkness.color.a > 1f)
				{
					SceneManager.LoadScene("HomeScene");
					DateGlobals.DayPassed = false;
				}
			}
			else if (Chatting)
			{
				if (currentPhase < Dialogue.Count)
				{
					CalculateMessageDelay();
					if (Dialogue[currentPhase].isQuestion)
					{
						if (!ShowingDialogueOption)
						{
							timer += Time.deltaTime;
							if (string.IsNullOrEmpty(ChatLabel.text))
							{
								ChatLabel.text = CurrentPartner.FirstName + " is typing...";
							}
							if (timer > messageDelay)
							{
								ChatLabel.text = string.Empty;
								Messages[currentPhase].MyProfile = CurrentPartner;
								SpawnChatMessage();
								timer = 0f;
								ShowingDialogueOption = true;
							}
						}
					}
					else if (Dialogue[currentPhase].isSystemMessage)
					{
						timer += Time.deltaTime;
						if (timer > SystemMessageDelay)
						{
							ChatLabel.text = string.Empty;
							SpawnChatMessage();
							Messages[currentPhase].MyProfile = SystemProfile;
							timer = 0f;
							currentPhase++;
						}
					}
					else if (currentPhase < Dialogue.Count)
					{
						if (Dialogue[currentPhase].sentByPlayer)
						{
							Messages[currentPhase].MyProfile = MyProfile;
							SpawnChatMessage();
							currentPhase++;
						}
						else
						{
							timer += Time.deltaTime;
							if (string.IsNullOrEmpty(ChatLabel.text))
							{
								ChatLabel.text = CurrentPartner.FirstName + " is typing...";
							}
							if (timer > messageDelay)
							{
								ChatLabel.text = string.Empty;
								SpawnChatMessage();
								Messages[currentPhase].MyProfile = CurrentPartner;
								timer = 0f;
								currentPhase++;
							}
						}
					}
					else
					{
						currentPhase++;
					}
					if (Input.GetButtonDown("A"))
					{
						timer = messageDelay;
					}
				}
				else
				{
					if (string.IsNullOrEmpty(ChatLabel.text))
					{
						ChatLabel.text = "Press E to log out of Yancord.";
						CurrentPartner.CurrentStatus = Status.Invisible;
						PartnerOnline.SetActive(false);
						PartnerOffline.SetActive(true);
					}
					if (Input.GetButtonDown("A"))
					{
						Debug.Log("Quitting!");
						YancordGlobals.CurrentConversation++;
						if (YancordGlobals.CurrentConversation > 5 && !GameGlobals.Debug)
						{
							PlayerPrefs.SetInt("Selene", 1);
							PlayerPrefs.SetInt("a", 1);
						}
						FadeOut = true;
					}
				}
				if (ShowingDialogueOption)
				{
					if (Input.GetButtonDown("A") && !DialogueChooseMenu.activeInHierarchy)
					{
						ChatLabel.text = "Choose one of the following answers to respond.";
						DialogueChooseMenu.SetActive(true);
						DialogueChooseLabel[1].text = Dialogue[currentPhase].OptionQ;
						DialogueChooseLabel[2].text = Dialogue[currentPhase].OptionR;
						DialogueChooseLabel[3].text = Dialogue[currentPhase].OptionF;
						DialogueQuestion.MyProfile = CurrentPartner;
						DialogueQuestion.MessageLabel.text = Dialogue[currentPhase].Message;
						DialogueQuestion.Awake();
					}
					if (DialogueChooseMenu.activeInHierarchy)
					{
						if (Input.GetButtonDown("B"))
						{
							Choice[currentPhase] = 1;
						}
						else if (Input.GetButtonDown("Y"))
						{
							Choice[currentPhase] = 2;
						}
						else if (Input.GetButtonDown("X"))
						{
							Choice[currentPhase] = 3;
						}
						if (Choice[currentPhase] != 0)
						{
							Dialogue[currentPhase + 1].Message = GetAnswer(currentPhase);
							Dialogue[currentPhase + 2].Message = GetReaction(currentPhase);
							Dialogue[currentPhase + 1].sentByPlayer = true;
							DialogueChooseMenu.SetActive(false);
							ChatLabel.text = "";
							ShowingDialogueOption = false;
							timer = 0f;
							currentPhase++;
						}
					}
					else if (string.IsNullOrEmpty(ChatLabel.text))
					{
						ChatLabel.text = "Press E to respond.";
					}
				}
				if (BlueDiscordIcon.alpha >= 0f)
				{
					BlueDiscordIcon.alpha -= Time.deltaTime * 10f;
				}
			}
			else if (!YancordGlobals.JoinedYancord)
			{
				if (Input.GetButtonDown("A"))
				{
					YancordGlobals.JoinedYancord = true;
					JoinServer();
					SpawnChatMessage();
					PartnerOnline.SetActive(true);
					Chatting = true;
				}
				else if (Input.GetButtonDown("B"))
				{
					Debug.Log("Quitting!");
					FadeOut = true;
				}
			}
			else if (Input.GetButtonDown("A"))
			{
				ChatLabel.text = string.Empty;
				SpawnChatMessage();
				Chatting = true;
			}
			else if (Input.GetButtonDown("B"))
			{
				Debug.Log("Quitting!");
				FadeOut = true;
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

		private string GetReaction(int phase)
		{
			switch (Choice[phase])
			{
			case 1:
				return Dialogue[phase].ReactionQ;
			case 2:
				return Dialogue[phase].ReactionR;
			case 3:
				return Dialogue[phase].ReactionF;
			default:
				return null;
			}
		}

		private string GetAnswer(int phase)
		{
			switch (Choice[phase])
			{
			case 1:
				return Dialogue[phase].OptionQ;
			case 2:
				return Dialogue[phase].OptionR;
			case 3:
				return Dialogue[phase].OptionF;
			default:
				return null;
			}
		}

		private void SpawnAll()
		{
			for (int i = 1; i < Dialogue.Count; i++)
			{
				MessageScript item = Object.Instantiate(MessagePrefab, new Vector3(0f, Messages[i - 1].transform.position.y - ((float)Messages[i - 1].MessageLabel.height * 0.0016723945f + Distance * 0.0016723945f), 0f), Quaternion.identity, ConversationParent);
				Messages.Add(item);
				Messages[i].MessageLabel.text = Dialogue[i].Message;
				if (Dialogue[i].isQuestion)
				{
					Dialogue[i + 1].sentByPlayer = true;
				}
				if (Dialogue[i].isSystemMessage)
				{
					Messages[i].MyProfile = SystemProfile;
				}
				else if (Dialogue[i].sentByPlayer)
				{
					Messages[i].MyProfile = MyProfile;
				}
				else
				{
					Messages[i].MyProfile = CurrentPartner;
				}
				Messages[i].Awake();
				Messages[i].gameObject.SetActive(false);
			}
		}

		private void SpawnChatMessage()
		{
			if (Messages[currentPhase].transform.position.y < -400f || Messages[currentPhase].transform.localPosition.y - (float)Messages[currentPhase].MessageLabel.height < -400f)
			{
				if (!Messages[currentPhase].gameObject.activeInHierarchy)
				{
					Messages[currentPhase].gameObject.SetActive(true);
					Messages[currentPhase].MessageLabel.text = Dialogue[currentPhase].Message;
					float num = -400f + (float)Messages[currentPhase].MessageLabel.height - 10f;
					Vector3 position = Messages[currentPhase].transform.position;
					Messages[currentPhase].transform.position = new Vector3(0f, num * 0.0016723945f, 0f);
					for (int num2 = currentPhase - 1; num2 >= 0; num2--)
					{
						Messages[num2].transform.position = new Vector3(0f, Messages[num2 + 1].transform.position.y + ((float)Messages[num2].MessageLabel.height * 0.0016723945f + Distance * 0.0016723945f), 0f);
					}
					for (int i = 1; i < Messages.Count; i++)
					{
						Messages[i].transform.position = new Vector3(0f, Messages[i - 1].transform.position.y - ((float)Messages[i - 1].MessageLabel.height * 0.0016723945f + Distance * 0.0016723945f), 0f);
					}
				}
			}
			else if (!Messages[currentPhase].gameObject.activeInHierarchy)
			{
				Messages[currentPhase].gameObject.SetActive(true);
				Messages[currentPhase].MessageLabel.text = Dialogue[currentPhase].Message;
				for (int j = currentPhase; j < Messages.Count; j++)
				{
					Messages[j].transform.position = new Vector3(0f, Messages[j - 1].transform.position.y - ((float)Messages[j - 1].MessageLabel.height * 0.0016723945f + Distance * 0.0016723945f), 0f);
				}
			}
		}

		private void JoinServer()
		{
			NewServer.SetActive(true);
			SelectedServer.gameObject.SetActive(true);
			SelectedServer.position = new Vector3(SelectedServer.position.x, NewServer.transform.position.y, SelectedServer.position.z);
			CreateNewServer.position = new Vector3(CreateNewServer.position.x, 0.37407407f, CreateNewServer.position.z);
			DirectMessages.SetActive(false);
			FindLabel.SetActive(false);
			ServerRelated.SetActive(true);
			FirstTimeUI.gameObject.SetActive(false);
		}

		private void CalculateMessageDelay()
		{
			messageDelay = 3f;
		}
	}
}
