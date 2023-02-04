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

	public void Update()
	{
		if (Input.GetMouseButtonDown(0) || Input.GetAxis("RT") == 1f)
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
		if (!(YouTubeChat.instance != null) || YouTubeChat.instance.NextInQueue() == null)
		{
			return;
		}
		string message = YouTubeChat.instance.NextInQueue().Message;
		if (message[0] != '!')
		{
			return;
		}
		if (Check[1] && message.Contains(RepKeyword))
		{
			Yandere.StudentManager.Reputation.PendingRep += 1f;
			Yandere.StudentManager.Reputation.UpdateRep();
			Yandere.StudentManager.Reputation.UpdatePendingRepLabel();
			Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you +1 Rep!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[2] && message.Contains(CleanKeyword))
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
				Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " cleaned your clothing!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			if (Yandere.RightFootprintSpawner.Bloodiness > 0)
			{
				Yandere.RightFootprintSpawner.Bloodiness = 0;
			}
			if (Yandere.LeftFootprintSpawner.Bloodiness > 0)
			{
				Yandere.LeftFootprintSpawner.Bloodiness = 0;
			}
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[3] && message.Contains(MoneyKeyword))
		{
			Yandere.Inventory.Money += 1f;
			Yandere.Inventory.UpdateMoney();
			Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you $1.00!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[4] && message.Contains(SanityKeyword))
		{
			Yandere.Sanity++;
			Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " restored 1% Sanity!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[5] && message.Contains(FriendKeyword))
		{
			try
			{
				int num = Convert.ToInt32(message.Split(' ')[1]);
				if (num > 0 && num < 101 && Yandere.StudentManager.Students[num] != null)
				{
					Yandere.StudentManager.Students[num].Friend = true;
					Yandere.StudentManager.Students[num].Grudge = false;
					Yandere.StudentManager.StudentPhotographed[num] = true;
					Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " made you friends with Student #" + num + "!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			catch
			{
			}
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[6] && message.Contains(DelayKeyword))
		{
			if (!Yandere.Police.Delayed)
			{
				Yandere.Police.Timer += 300f;
				Yandere.Police.Delayed = true;
				Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " delayed the police!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[7] && message.Contains(InfoKeyword))
		{
			Yandere.Inventory.PantyShots++;
			Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you 1 Info Point!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[8] && message.Contains(CloakKeyword))
		{
			Debug.Log("Someone typed ''!cloak''.");
			Debug.Log("Attempting to disable ShoeLocker...");
			ShoeLocker.enabled = false;
			Debug.Log("Attempting to turn the girl invisible...");
			Yandere.Invisible = true;
			Yandere.Cloak();
			CloakTimer = 10f;
			Debug.Log("Attempting to spawn a notification...");
			Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " cloaked you for 10 seconds!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			Debug.Log("Attempting to remove this message from the deqeue...");
			YouTubeChat.instance.Dequeue();
			Debug.Log("We made it!");
		}
		else if (Check[9] && message.Contains(StudyKeyword))
		{
			Yandere.Class.BonusPoints++;
			Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you 1 Study Point!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[10] && message.Contains(DropKeyword))
		{
			try
			{
				int num2 = Convert.ToInt32(message.Split(' ')[1]);
				if (num2 > -1 && num2 < InfoChanWindow.Drops.Length)
				{
					InfoChanWindow.Orders++;
					InfoChanWindow.ItemsToDrop[InfoChanWindow.Orders] = num2;
					InfoChanWindow.DropObject();
					Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " ordered a Drop from Info-chan!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			catch
			{
			}
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[11] && message.Contains(GossipKeyword))
		{
			Yandere.StudentManager.Reputation.PendingRep -= 1f;
			Yandere.StudentManager.Reputation.UpdateRep();
			Yandere.StudentManager.Reputation.UpdatePendingRepLabel();
			Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " damaged your rep!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[12] && message.Contains(BloodKeyword))
		{
			Yandere.Bloodiness += 20f;
			Yandere.StainWeapon();
			Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " splashed blood on you!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[13] && message.Contains(RobKeyword))
		{
			Yandere.Inventory.Money -= 1f;
			if (Yandere.Inventory.Money < 0f)
			{
				Yandere.Inventory.Money = 0f;
			}
			Yandere.Inventory.UpdateMoney();
			Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " stole $1.00 from you!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[14] && message.Contains(InsaneKeyword))
		{
			Yandere.Sanity--;
			Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " reduced your Sanity!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[15] && message.Contains(GrudgeKeyword))
		{
			try
			{
				int num3 = Convert.ToInt32(message.Split(' ')[1]);
				if (num3 > 0 && num3 < 101 && Yandere.StudentManager.Students[num3] != null)
				{
					Yandere.StudentManager.Students[num3].Friend = false;
					Yandere.StudentManager.Students[num3].Grudge = true;
					Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " made you enemies with Student #" + num3 + "!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			catch
			{
			}
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[16] && message.Contains(CopsKeyword))
		{
			Yandere.Police.Show = true;
			Yandere.Police.Called = true;
			Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " called the cops!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[17] && message.Contains(NemesisKeyword))
		{
			if (!Yandere.PauseScreen.MissionMode.Nemesis.activeInHierarchy)
			{
				Yandere.PauseScreen.MissionMode.Nemesis.SetActive(value: true);
				Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " sent Nemesis after you!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[18] && message.Contains(AggroKeyword))
		{
			if (Yandere.PauseScreen.MissionMode.Nemesis.activeInHierarchy)
			{
				Yandere.PauseScreen.MissionMode.Nemesis.GetComponent<NemesisScript>().Aggressive = true;
				Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " made Nemesis aggressive!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[19] && message.Contains(GuiseKeyword))
		{
			if (Yandere.PauseScreen.MissionMode.Nemesis.activeInHierarchy)
			{
				Yandere.PauseScreen.MissionMode.Nemesis.GetComponent<NemesisScript>().PutOnDisguise = true;
				Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave Nemesis a disguise!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[20] && message.Contains(OopsKeyword))
		{
			if (Yandere.Armed || Yandere.Carrying || Yandere.HeavyWeight || Yandere.PickUp != null || Yandere.Dragging)
			{
				Yandere.EmptyHands();
				Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " made you drop it";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[21] && message.Contains(BustKeyword))
		{
			try
			{
				int num4 = Convert.ToInt32(message.Split(' ')[1]);
				if (num4 > -1 && num4 < 15)
				{
					Yandere.BreastSize = 0.5f + (float)num4 * 0.1f;
					Yandere.RightBreast.localScale = new Vector3(Yandere.BreastSize, Yandere.BreastSize, Yandere.BreastSize);
					Yandere.LeftBreast.localScale = new Vector3(Yandere.BreastSize, Yandere.BreastSize, Yandere.BreastSize);
					Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " changed your bust size!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			catch
			{
			}
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[22] && message.Contains(HairKeyword))
		{
			try
			{
				int num5 = Convert.ToInt32(message.Split(' ')[1]);
				if (num5 > -1 && num5 < Yandere.Hairstyles.Length)
				{
					Yandere.Hairstyle = num5;
					Yandere.UpdateHair();
					Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you a new hairstyle!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			catch
			{
			}
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[23] && message.Contains(PantyKeyword))
		{
			try
			{
				int num6 = Convert.ToInt32(message.Split(' ')[1]);
				if (num6 > 0 && num6 < 12)
				{
					PlayerGlobals.PantiesEquipped = num6;
					Yandere.PantyAttacher.PantyID = num6;
					Yandere.PantyAttacher.UpdatePanties();
					Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " changed your panties!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			catch
			{
			}
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[24] && message.Contains(PersonaKeyword))
		{
			try
			{
				int num7 = Convert.ToInt32(message.Split(' ')[1]);
				if (num7 > 0 && num7 < 12)
				{
					Yandere.PersonaID = num7;
					Yandere.StudentManager.Mirror.UpdatePersona();
				}
			}
			catch
			{
			}
			YouTubeChat.instance.Dequeue();
		}
		else if (Check[25] && message.Contains(AccessoryKeyword))
		{
			try
			{
				int num8 = Convert.ToInt32(message.Split(' ')[1]);
				if (num8 > -1 && num8 < Yandere.Accessories.Length)
				{
					Yandere.AccessoryID = num8;
					Yandere.UpdateAccessory();
					Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you a new accessory!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			catch
			{
			}
			YouTubeChat.instance.Dequeue();
		}
		else
		{
			YouTubeChat.instance.Dequeue();
		}
	}
}
