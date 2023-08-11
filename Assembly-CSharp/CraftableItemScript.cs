using UnityEngine;

public class CraftableItemScript : MonoBehaviour
{
	public PromptScript Prompt;

	public bool DoNotDisappear;

	public bool Chemistry;

	public string Name;

	public int ID;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if (!Input.GetKeyDown("z"))
			{
				Prompt.Yandere.NotificationManager.CustomText = "Grabbed some " + Name + "!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			Prompt.Circle[0].fillAmount = 1f;
			switch (ID)
			{
			case 1:
				Prompt.Yandere.Inventory.Ammonium = true;
				break;
			case 2:
				Prompt.Yandere.Inventory.Balloons = true;
				break;
			case 3:
				Prompt.Yandere.Inventory.Bandages = true;
				break;
			case 4:
				Prompt.Yandere.Inventory.Glass = true;
				break;
			case 5:
				Prompt.Yandere.Inventory.Hairpins = true;
				break;
			case 6:
				Prompt.Yandere.Inventory.Nails = true;
				break;
			case 7:
				Prompt.Yandere.Inventory.Paper = true;
				break;
			case 8:
				Prompt.Yandere.Inventory.PaperClips = true;
				break;
			case 9:
				Prompt.Yandere.Inventory.SilverFulminate = true;
				break;
			case 10:
				Prompt.Yandere.Inventory.WoodenSticks = true;
				break;
			case 11:
				Prompt.Yandere.Inventory.Mustard = true;
				break;
			case 12:
				Prompt.Yandere.Inventory.Salt = true;
				break;
			case 13:
				Prompt.Yandere.Inventory.Tyramine = true;
				break;
			case 14:
				Prompt.Yandere.Inventory.Phenylethylamine = true;
				break;
			case 15:
				Prompt.Yandere.Inventory.Acetone = true;
				break;
			case 16:
				Prompt.Yandere.Inventory.Chloroform = true;
				break;
			case 17:
				Prompt.Yandere.Inventory.AceticAcid = true;
				break;
			case 18:
				Prompt.Yandere.Inventory.BariumCarbonate = true;
				break;
			case 19:
				Prompt.Yandere.Inventory.PotassiumNitrate = true;
				break;
			case 20:
				Prompt.Yandere.Inventory.Sugar = true;
				break;
			}
			Prompt.Hide();
			if (!DoNotDisappear)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
