using System;
using UnityEngine;

public class YouTubeCommandTestScript : MonoBehaviour
{
	public InfoChanWindowScript InfoChanWindow;

	public YandereShoeLockerScript ShoeLocker;

	public YandereScript Yandere;

	public YouTubeChat Chat;

	public string RepKeyword;

	public string CleanKeyword;

	public string MoneyKeyword;

	public string SanityKeyword;

	public string FriendKeyword;

	public string DelayKeyword;

	public string InfoKeyword;

	public string CloakKeyword;

	public string StudyKeyword;

	public string DropKeyword;

	public string GossipKeyword;

	public string BloodKeyword;

	public string RobKeyword;

	public string InsaneKeyword;

	public string GrudgeKeyword;

	public string CopsKeyword;

	public string NemesisKeyword;

	public string AggroKeyword;

	public string GuiseKeyword;

	public string OopsKeyword;

	public string BustKeyword;

	public string HairKeyword;

	public string PantyKeyword;

	public string PersonaKeyword;

	public string AccessoryKeyword;

	public UISprite CountdownCircle;

	public string WeaponKeyword;

	public float CloakTimer;

	public bool[] Check;

	public bool TikTok;

	public void Update()
	{
		if (Input.GetMouseButtonDown(InputNames.Mouse_LMB) || Input.GetAxis(InputNames.Xbox_RT) == 1f)
		{
			Chat.UpdateMessagesList(initialRun: false);
		}
		if (CloakTimer > 0f)
		{
			CloakTimer = Mathf.MoveTowards(CloakTimer, 0f, Time.deltaTime);
			if (CloakTimer == 0f)
			{
				Yandere.Invisible = false;
				Yandere.Decloak();
			}
		}
		if (Chat.isValidURL && Chat.TimeBased)
		{
			CountdownCircle.fillAmount = 1f - Chat.Timer / 10f;
		}
		if ((!TikTok && !(YouTubeChat.instance != null)) || (!TikTok && YouTubeChat.instance.NextInQueue() == null))
		{
			return;
		}
		string text = "A viewer";
		string text2 = "";
		if (!TikTok)
		{
			text2 = YouTubeChat.instance.NextInQueue().Message;
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.Keypad0))
			{
				text2 = RepKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.Keypad1))
			{
				text2 = CleanKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.Keypad2))
			{
				text2 = MoneyKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.Keypad3))
			{
				text2 = SanityKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.Keypad4))
			{
				text2 = FriendKeyword + " " + UnityEngine.Random.Range(1, 101);
			}
			else if (Input.GetKeyDown(KeyCode.Keypad5))
			{
				text2 = DelayKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.Keypad6))
			{
				text2 = InfoKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.Keypad7))
			{
				text2 = CloakKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.Keypad8))
			{
				text2 = StudyKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.Keypad9))
			{
				text2 = DropKeyword + " " + UnityEngine.Random.Range(0, 16);
			}
			else if (Input.GetKeyDown(KeyCode.KeypadDivide))
			{
				text2 = GossipKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.KeypadEquals))
			{
				text2 = BloodKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.KeypadMinus))
			{
				text2 = RobKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.KeypadMultiply))
			{
				text2 = InsaneKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.KeypadPeriod))
			{
				text2 = GrudgeKeyword + " " + UnityEngine.Random.Range(0, 16);
			}
			else if (Input.GetKeyDown(KeyCode.KeypadPlus))
			{
				text2 = CopsKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.Pause))
			{
				text2 = NemesisKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.PageUp))
			{
				text2 = AggroKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.PageDown))
			{
				text2 = GuiseKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.Home))
			{
				text2 = OopsKeyword;
			}
			else if (Input.GetKeyDown(KeyCode.End))
			{
				text2 = BustKeyword + " " + UnityEngine.Random.Range(1, 15);
			}
			else if (Input.GetKeyDown(KeyCode.Insert))
			{
				text2 = HairKeyword + " " + UnityEngine.Random.Range(0, Yandere.Hairstyles.Length);
			}
			else if (Input.GetKeyDown(KeyCode.Delete))
			{
				text2 = PantyKeyword + " " + UnityEngine.Random.Range(1, 12);
			}
			else if (Input.GetKeyDown(KeyCode.F12))
			{
				text2 = PersonaKeyword + " " + UnityEngine.Random.Range(0, 21);
			}
			else if (Input.GetKeyDown(KeyCode.F11))
			{
				text2 = AccessoryKeyword + " " + UnityEngine.Random.Range(0, Yandere.Accessories.Length);
			}
			if (text2 != "")
			{
				Debug.Log("msg is: " + text2);
			}
		}
		if (text2.Length <= 0 || text2[0] != '!')
		{
			return;
		}
		if (Check[1] && text2.Contains(RepKeyword))
		{
			Yandere.StudentManager.Reputation.PendingRep++;
			Yandere.StudentManager.Reputation.UpdateRep();
			Yandere.StudentManager.Reputation.UpdatePendingRepLabel();
			if (!TikTok)
			{
				text = YouTubeChat.instance.NextInQueue().Author;
				YouTubeChat.instance.Dequeue();
			}
			Yandere.NotificationManager.CustomText = text + " gave you +1 Rep!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		if (Check[2] && text2.Contains(CleanKeyword))
		{
			Debug.Log("Someone typed ''!clean''.");
			if (Yandere.Bloodiness > 0f)
			{
				Debug.Log("Player was bloody at the time. Cleaning blood.");
				Yandere.Bloodiness = 0f;
				if (Yandere.Schoolwear != 2)
				{
					if (Yandere.CurrentUniformOrigin == 1)
					{
						Yandere.StudentManager.OriginalUniforms++;
					}
					else
					{
						Yandere.StudentManager.NewUniforms++;
					}
					Yandere.Police.BloodyClothing--;
				}
			}
			if (Yandere.RightFootprintSpawner.Bloodiness > 0)
			{
				Yandere.RightFootprintSpawner.Bloodiness = 0;
			}
			if (Yandere.LeftFootprintSpawner.Bloodiness > 0)
			{
				Yandere.LeftFootprintSpawner.Bloodiness = 0;
			}
			if (!TikTok)
			{
				text = YouTubeChat.instance.NextInQueue().Author;
				YouTubeChat.instance.Dequeue();
			}
			Yandere.NotificationManager.CustomText = text + " cleaned your clothing!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		if (Check[3] && text2.Contains(MoneyKeyword))
		{
			Yandere.Inventory.Money++;
			Yandere.Inventory.UpdateMoney();
			if (!TikTok)
			{
				text = YouTubeChat.instance.NextInQueue().Author;
				YouTubeChat.instance.Dequeue();
			}
			Yandere.NotificationManager.CustomText = text + " gave you $1.00!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		if (Check[4] && text2.Contains(SanityKeyword))
		{
			Yandere.Sanity++;
			if (!TikTok)
			{
				text = YouTubeChat.instance.NextInQueue().Author;
				YouTubeChat.instance.Dequeue();
			}
			Yandere.NotificationManager.CustomText = text + " restored 1% Sanity!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		if (Check[5] && text2.Contains(FriendKeyword))
		{
			try
			{
				int num = Convert.ToInt32(text2.Split(' ')[1]);
				if (num > 0 && num < 101 && Yandere.StudentManager.Students[num] != null)
				{
					Yandere.StudentManager.Students[num].Friend = true;
					Yandere.StudentManager.Students[num].Grudge = false;
					Yandere.StudentManager.StudentPhotographed[num] = true;
					if (!TikTok)
					{
						text = YouTubeChat.instance.NextInQueue().Author;
						YouTubeChat.instance.Dequeue();
					}
					Yandere.NotificationManager.CustomText = text + " made you friends with Student #" + num + "!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				return;
			}
			catch
			{
				return;
			}
		}
		if (Check[6] && text2.Contains(DelayKeyword))
		{
			Yandere.Police.Timer += 300f;
			if (!TikTok)
			{
				text = YouTubeChat.instance.NextInQueue().Author;
				YouTubeChat.instance.Dequeue();
			}
			Yandere.NotificationManager.CustomText = text + " delayed the police!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		if (Check[7] && text2.Contains(InfoKeyword))
		{
			Yandere.Inventory.PantyShots++;
			if (!TikTok)
			{
				text = YouTubeChat.instance.NextInQueue().Author;
				YouTubeChat.instance.Dequeue();
			}
			Yandere.NotificationManager.CustomText = text + " gave you 1 Info Point!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		if (Check[8] && text2.Contains(CloakKeyword))
		{
			Debug.Log("Someone typed ''!cloak''.");
			Debug.Log("Attempting to disable ShoeLocker...");
			ShoeLocker.enabled = false;
			Debug.Log("Attempting to turn the girl invisible...");
			Yandere.Invisible = true;
			Yandere.Cloak();
			CloakTimer = 10f;
			Debug.Log("Attempting to spawn a notification...");
			if (!TikTok)
			{
				text = YouTubeChat.instance.NextInQueue().Author;
				Debug.Log("Attempting to remove this message from the deqeue...");
				YouTubeChat.instance.Dequeue();
			}
			Yandere.NotificationManager.CustomText = text + " cloaked you for 10 seconds!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			Debug.Log("We made it!");
			return;
		}
		if (Check[9] && text2.Contains(StudyKeyword))
		{
			Yandere.Class.BonusPoints++;
			if (!TikTok)
			{
				text = YouTubeChat.instance.NextInQueue().Author;
				YouTubeChat.instance.Dequeue();
			}
			Yandere.NotificationManager.CustomText = text + " gave you 1 Study Point!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		if (Check[10] && text2.Contains(DropKeyword))
		{
			try
			{
				int num2 = Convert.ToInt32(text2.Split(' ')[1]);
				if (num2 > -1 && num2 < InfoChanWindow.Drops.Length)
				{
					InfoChanWindow.Orders++;
					InfoChanWindow.ItemsToDrop[InfoChanWindow.Orders] = num2;
					InfoChanWindow.DropObject();
					if (!TikTok)
					{
						text = YouTubeChat.instance.NextInQueue().Author;
						YouTubeChat.instance.Dequeue();
					}
					Yandere.NotificationManager.CustomText = text + " ordered a Drop from Info-chan!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				return;
			}
			catch
			{
				return;
			}
		}
		if (Check[11] && text2.Contains(GossipKeyword))
		{
			Yandere.StudentManager.Reputation.PendingRep--;
			Yandere.StudentManager.Reputation.UpdateRep();
			Yandere.StudentManager.Reputation.UpdatePendingRepLabel();
			if (!TikTok)
			{
				text = YouTubeChat.instance.NextInQueue().Author;
				YouTubeChat.instance.Dequeue();
			}
			Yandere.NotificationManager.CustomText = text + " damaged your rep!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		if (Check[12] && text2.Contains(BloodKeyword))
		{
			Yandere.Bloodiness += 20f;
			Yandere.StainWeapon();
			if (!TikTok)
			{
				text = YouTubeChat.instance.NextInQueue().Author;
				YouTubeChat.instance.Dequeue();
			}
			Yandere.NotificationManager.CustomText = text + " splashed blood on you!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		if (Check[13] && text2.Contains(RobKeyword))
		{
			Yandere.Inventory.Money--;
			if (Yandere.Inventory.Money < 0f)
			{
				Yandere.Inventory.Money = 0f;
			}
			Yandere.Inventory.UpdateMoney();
			if (!TikTok)
			{
				text = YouTubeChat.instance.NextInQueue().Author;
				YouTubeChat.instance.Dequeue();
			}
			Yandere.NotificationManager.CustomText = text + " stole $1.00 from you!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		if (Check[14] && text2.Contains(InsaneKeyword))
		{
			Yandere.Sanity--;
			if (!TikTok)
			{
				text = YouTubeChat.instance.NextInQueue().Author;
				YouTubeChat.instance.Dequeue();
			}
			Yandere.NotificationManager.CustomText = text + " reduced your Sanity!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		if (Check[15] && text2.Contains(GrudgeKeyword))
		{
			try
			{
				int num3 = Convert.ToInt32(text2.Split(' ')[1]);
				if (num3 > 0 && num3 < 101 && Yandere.StudentManager.Students[num3] != null)
				{
					Yandere.StudentManager.Students[num3].Friend = false;
					Yandere.StudentManager.Students[num3].Grudge = true;
					if (!TikTok)
					{
						text = YouTubeChat.instance.NextInQueue().Author;
						YouTubeChat.instance.Dequeue();
					}
					Yandere.NotificationManager.CustomText = text + " made you enemies with Student #" + num3 + "!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				return;
			}
			catch
			{
				return;
			}
		}
		if (Check[16] && text2.Contains(CopsKeyword))
		{
			Yandere.Police.Show = true;
			Yandere.Police.Called = true;
			if (!TikTok)
			{
				text = YouTubeChat.instance.NextInQueue().Author;
				YouTubeChat.instance.Dequeue();
			}
			Yandere.NotificationManager.CustomText = text + " called the cops!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		if (Check[17] && text2.Contains(NemesisKeyword))
		{
			if (!Yandere.PauseScreen.MissionMode.Nemesis.activeInHierarchy)
			{
				Yandere.PauseScreen.MissionMode.Nemesis.SetActive(value: true);
				if (!TikTok)
				{
					text = YouTubeChat.instance.NextInQueue().Author;
					YouTubeChat.instance.Dequeue();
				}
				Yandere.NotificationManager.CustomText = text + " sent Nemesis after you!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			return;
		}
		if (Check[18] && text2.Contains(AggroKeyword))
		{
			if (Yandere.PauseScreen.MissionMode.Nemesis.activeInHierarchy)
			{
				Yandere.PauseScreen.MissionMode.Nemesis.GetComponent<NemesisScript>().Aggressive = true;
				if (!TikTok)
				{
					text = YouTubeChat.instance.NextInQueue().Author;
					YouTubeChat.instance.Dequeue();
				}
				Yandere.NotificationManager.CustomText = text + " made Nemesis aggressive!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			return;
		}
		if (Check[19] && text2.Contains(GuiseKeyword))
		{
			if (Yandere.PauseScreen.MissionMode.Nemesis.activeInHierarchy)
			{
				Yandere.PauseScreen.MissionMode.Nemesis.GetComponent<NemesisScript>().PutOnDisguise = true;
				if (!TikTok)
				{
					text = YouTubeChat.instance.NextInQueue().Author;
					YouTubeChat.instance.Dequeue();
				}
				Yandere.NotificationManager.CustomText = text + " gave Nemesis a disguise!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			return;
		}
		if (Check[20] && text2.Contains(OopsKeyword))
		{
			if (!TikTok)
			{
				text = YouTubeChat.instance.NextInQueue().Author;
				YouTubeChat.instance.Dequeue();
			}
			if (Yandere.Armed || Yandere.Carrying || Yandere.HeavyWeight || Yandere.PickUp != null || Yandere.Dragging)
			{
				if (Yandere.Armed && Yandere.EquippedWeapon != null)
				{
					Yandere.EquippedWeapon.Drop();
				}
				Yandere.EmptyHands();
				Yandere.NotificationManager.CustomText = text + " made you drop it!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else
			{
				Yandere.NotificationManager.CustomText = "holding, but you weren't holding anything!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Yandere.NotificationManager.CustomText = text + " tried to make you drop what you were";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			return;
		}
		if (Check[21] && text2.Contains(BustKeyword))
		{
			try
			{
				int num4 = Convert.ToInt32(text2.Split(' ')[1]);
				if (num4 > -1 && num4 < 15)
				{
					Yandere.BreastSize = 0.5f + (float)num4 * 0.1f;
					Yandere.RightBreast.localScale = new Vector3(Yandere.BreastSize, Yandere.BreastSize, Yandere.BreastSize);
					Yandere.LeftBreast.localScale = new Vector3(Yandere.BreastSize, Yandere.BreastSize, Yandere.BreastSize);
					if (!TikTok)
					{
						text = YouTubeChat.instance.NextInQueue().Author;
						YouTubeChat.instance.Dequeue();
					}
					Yandere.NotificationManager.CustomText = text + " changed your bust size!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				return;
			}
			catch
			{
				return;
			}
		}
		if (Check[22] && text2.Contains(HairKeyword))
		{
			try
			{
				int num5 = Convert.ToInt32(text2.Split(' ')[1]);
				if (num5 > -1 && num5 < Yandere.Hairstyles.Length)
				{
					Yandere.Hairstyle = num5;
					Yandere.UpdateHair();
					if (!TikTok)
					{
						text = YouTubeChat.instance.NextInQueue().Author;
						YouTubeChat.instance.Dequeue();
					}
					Yandere.NotificationManager.CustomText = text + " gave you a new hairstyle!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				return;
			}
			catch
			{
				return;
			}
		}
		if (Check[23] && text2.Contains(PantyKeyword))
		{
			try
			{
				int num6 = Convert.ToInt32(text2.Split(' ')[1]);
				if (num6 > 0 && num6 < 12)
				{
					PlayerGlobals.PantiesEquipped = num6;
					Yandere.PantyAttacher.PantyID = num6;
					Yandere.PantyAttacher.UpdatePanties();
					if (!TikTok)
					{
						text = YouTubeChat.instance.NextInQueue().Author;
						YouTubeChat.instance.Dequeue();
					}
					Yandere.NotificationManager.CustomText = text + " changed your panties!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				return;
			}
			catch
			{
				return;
			}
		}
		if (Check[24] && text2.Contains(PersonaKeyword))
		{
			try
			{
				int num7 = Convert.ToInt32(text2.Split(' ')[1]);
				if (num7 > 0 && num7 < 21)
				{
					Yandere.PersonaID = num7;
					Yandere.StudentManager.Mirror.UpdatePersona();
				}
				if (!TikTok)
				{
					text = YouTubeChat.instance.NextInQueue().Author;
					YouTubeChat.instance.Dequeue();
				}
				Yandere.NotificationManager.CustomText = text + " changed your persona!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				return;
			}
			catch
			{
				return;
			}
		}
		if (Check[25] && text2.Contains(AccessoryKeyword))
		{
			try
			{
				int num8 = Convert.ToInt32(text2.Split(' ')[1]);
				if (num8 > -1 && num8 < Yandere.Accessories.Length)
				{
					Yandere.AccessoryID = num8;
					Yandere.UpdateAccessory();
					if (!TikTok)
					{
						text = YouTubeChat.instance.NextInQueue().Author;
						YouTubeChat.instance.Dequeue();
					}
					Yandere.NotificationManager.CustomText = text + " gave you a new accessory!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				return;
			}
			catch
			{
				return;
			}
		}
		if (!TikTok)
		{
			YouTubeChat.instance.Dequeue();
		}
	}
}
