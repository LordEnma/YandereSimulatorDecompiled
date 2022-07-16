// Decompiled with JetBrains decompiler
// Type: YandereSimulator.Yancord.YancordManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
        YancordGlobals.CurrentConversation = 1;
      if (!YancordGlobals.JoinedYancord)
      {
        Debug.Log((object) "This is the player's first time launching Yancord.");
        YancordGlobals.CurrentConversation = 1;
        if (this.ConversationID != YancordGlobals.CurrentConversation)
          this.enabled = false;
        this.ChatLabel.text = string.Empty;
        this.Dialogue[1].isSystemMessage = true;
        this.Dialogue[1].Message = "Ayano Aishi has joined the Moonlit Warrior Selene Fanserver.";
        this.FirstTimeUI.gameObject.SetActive(true);
      }
      else
      {
        Debug.Log((object) "The player has launched Yancord before.");
        if (this.ConversationID != YancordGlobals.CurrentConversation)
          this.enabled = false;
        this.JoinServer();
        this.Dialogue[1].isSystemMessage = true;
        this.Dialogue[1].Message = "Ayano Aishi has logged in.";
        this.PartnerOnline.SetActive(true);
        this.BlueDiscordIcon.alpha = 0.0f;
        this.ChatLabel.text = "Press E to start chatting on the Moonlit Warrior Selene Fanserver!";
      }
      Debug.Log((object) ("YancordGlobals.CurrentConversation is: " + YancordGlobals.CurrentConversation.ToString()));
      this.CurrentPartner.CurrentStatus = Status.Online;
      this.SpawnAll();
      this.Choice = new int[this.Dialogue.Count];
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.FadeIn = true;
    }

    public void Update()
    {
      if (this.FadeIn)
      {
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
        if ((double) this.Darkness.color.a == 0.0)
          this.FadeIn = false;
      }
      else if (this.FadeOut)
      {
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Darkness.color.a, 2f, Time.deltaTime));
        if ((double) this.Darkness.color.a > 1.0)
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
                this.ChatLabel.text = this.CurrentPartner.FirstName + " is typing...";
              if ((double) this.timer > (double) this.messageDelay)
              {
                this.ChatLabel.text = string.Empty;
                this.Messages[this.currentPhase].MyProfile = this.CurrentPartner;
                this.SpawnChatMessage();
                this.timer = 0.0f;
                this.ShowingDialogueOption = true;
              }
            }
          }
          else if (this.Dialogue[this.currentPhase].isSystemMessage)
          {
            this.timer += Time.deltaTime;
            if ((double) this.timer > (double) this.SystemMessageDelay)
            {
              this.ChatLabel.text = string.Empty;
              this.SpawnChatMessage();
              this.Messages[this.currentPhase].MyProfile = this.SystemProfile;
              this.timer = 0.0f;
              ++this.currentPhase;
            }
          }
          else if (this.currentPhase < this.Dialogue.Count)
          {
            if (this.Dialogue[this.currentPhase].sentByPlayer)
            {
              this.Messages[this.currentPhase].MyProfile = this.MyProfile;
              this.SpawnChatMessage();
              ++this.currentPhase;
            }
            else
            {
              this.timer += Time.deltaTime;
              if (string.IsNullOrEmpty(this.ChatLabel.text))
                this.ChatLabel.text = this.CurrentPartner.FirstName + " is typing...";
              if ((double) this.timer > (double) this.messageDelay)
              {
                this.ChatLabel.text = string.Empty;
                this.SpawnChatMessage();
                this.Messages[this.currentPhase].MyProfile = this.CurrentPartner;
                this.timer = 0.0f;
                ++this.currentPhase;
              }
            }
          }
          else
            ++this.currentPhase;
          if (Input.GetButtonDown("A"))
            this.timer = this.messageDelay;
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
            Debug.Log((object) "Quitting!");
            ++YancordGlobals.CurrentConversation;
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
              this.Choice[this.currentPhase] = 1;
            else if (Input.GetButtonDown("Y"))
              this.Choice[this.currentPhase] = 2;
            else if (Input.GetButtonDown("X"))
              this.Choice[this.currentPhase] = 3;
            if (this.Choice[this.currentPhase] != 0)
            {
              this.Dialogue[this.currentPhase + 1].Message = this.GetAnswer(this.currentPhase);
              this.Dialogue[this.currentPhase + 2].Message = this.GetReaction(this.currentPhase);
              this.Dialogue[this.currentPhase + 1].sentByPlayer = true;
              this.DialogueChooseMenu.SetActive(false);
              this.ChatLabel.text = "";
              this.ShowingDialogueOption = false;
              this.timer = 0.0f;
              ++this.currentPhase;
            }
          }
          else if (string.IsNullOrEmpty(this.ChatLabel.text))
            this.ChatLabel.text = "Press E to respond.";
        }
        if ((double) this.BlueDiscordIcon.alpha >= 0.0)
          this.BlueDiscordIcon.alpha -= Time.deltaTime * 10f;
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
          Debug.Log((object) "Quitting!");
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
        Debug.Log((object) "Quitting!");
        this.FadeOut = true;
      }
      if (Input.GetKeyDown(KeyCode.Space))
        YancordGlobals.JoinedYancord = false;
      if (Input.GetKeyDown(KeyCode.Alpha1))
        YancordGlobals.CurrentConversation = 1;
      if (Input.GetKeyDown(KeyCode.Alpha2))
        YancordGlobals.CurrentConversation = 2;
      if (Input.GetKeyDown(KeyCode.Alpha3))
        YancordGlobals.CurrentConversation = 3;
      if (Input.GetKeyDown(KeyCode.Alpha4))
        YancordGlobals.CurrentConversation = 4;
      if (!Input.GetKeyDown(KeyCode.Alpha5))
        return;
      YancordGlobals.CurrentConversation = 5;
    }

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
          return (string) null;
      }
    }

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
          return (string) null;
      }
    }

    private void SpawnAll()
    {
      for (int index = 1; index < this.Dialogue.Count; ++index)
      {
        this.Messages.Add(Object.Instantiate<MessageScript>(this.MessagePrefab, new Vector3(0.0f, this.Messages[index - 1].transform.position.y - (float) ((double) this.Messages[index - 1].MessageLabel.height * 0.00167239445727319 + (double) this.Distance * 0.00167239445727319), 0.0f), Quaternion.identity, this.ConversationParent));
        this.Messages[index].MessageLabel.text = this.Dialogue[index].Message;
        if (this.Dialogue[index].isQuestion)
          this.Dialogue[index + 1].sentByPlayer = true;
        this.Messages[index].MyProfile = !this.Dialogue[index].isSystemMessage ? (!this.Dialogue[index].sentByPlayer ? this.CurrentPartner : this.MyProfile) : this.SystemProfile;
        this.Messages[index].Awake();
        this.Messages[index].gameObject.SetActive(false);
      }
    }

    private void SpawnChatMessage()
    {
      if ((double) this.Messages[this.currentPhase].transform.position.y < -400.0 || (double) this.Messages[this.currentPhase].transform.localPosition.y - (double) this.Messages[this.currentPhase].MessageLabel.height < -400.0)
      {
        if (this.Messages[this.currentPhase].gameObject.activeInHierarchy)
          return;
        this.Messages[this.currentPhase].gameObject.SetActive(true);
        this.Messages[this.currentPhase].MessageLabel.text = this.Dialogue[this.currentPhase].Message;
        float num = (float) ((double) this.Messages[this.currentPhase].MessageLabel.height - 400.0 - 10.0);
        Vector3 position = this.Messages[this.currentPhase].transform.position;
        this.Messages[this.currentPhase].transform.position = new Vector3(0.0f, num * 0.001672394f, 0.0f);
        for (int index = this.currentPhase - 1; index >= 0; --index)
          this.Messages[index].transform.position = new Vector3(0.0f, this.Messages[index + 1].transform.position.y + (float) ((double) this.Messages[index].MessageLabel.height * 0.00167239445727319 + (double) this.Distance * 0.00167239445727319), 0.0f);
        for (int index = 1; index < this.Messages.Count; ++index)
          this.Messages[index].transform.position = new Vector3(0.0f, this.Messages[index - 1].transform.position.y - (float) ((double) this.Messages[index - 1].MessageLabel.height * 0.00167239445727319 + (double) this.Distance * 0.00167239445727319), 0.0f);
      }
      else
      {
        if (this.Messages[this.currentPhase].gameObject.activeInHierarchy)
          return;
        this.Messages[this.currentPhase].gameObject.SetActive(true);
        this.Messages[this.currentPhase].MessageLabel.text = this.Dialogue[this.currentPhase].Message;
        for (int currentPhase = this.currentPhase; currentPhase < this.Messages.Count; ++currentPhase)
          this.Messages[currentPhase].transform.position = new Vector3(0.0f, this.Messages[currentPhase - 1].transform.position.y - (float) ((double) this.Messages[currentPhase - 1].MessageLabel.height * 0.00167239445727319 + (double) this.Distance * 0.00167239445727319), 0.0f);
      }
    }

    private void JoinServer()
    {
      this.NewServer.SetActive(true);
      this.SelectedServer.gameObject.SetActive(true);
      this.SelectedServer.position = new Vector3(this.SelectedServer.position.x, this.NewServer.transform.position.y, this.SelectedServer.position.z);
      this.CreateNewServer.position = new Vector3(this.CreateNewServer.position.x, 0.3740741f, this.CreateNewServer.position.z);
      this.DirectMessages.SetActive(false);
      this.FindLabel.SetActive(false);
      this.ServerRelated.SetActive(true);
      this.FirstTimeUI.gameObject.SetActive(false);
    }

    private void CalculateMessageDelay() => this.messageDelay = 3f;
  }
}
