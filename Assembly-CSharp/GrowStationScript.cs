using UnityEngine;

public class GrowStationScript : MonoBehaviour
{
	public PromptScript Prompt;

	public int Seeds;

	public int SeedProgress;

	public bool Initialized;

	public bool BiologyLab;

	public Renderer MyRenderer;

	public Texture PlantTexture;

	private void Start()
	{
		if (!Initialized)
		{
			if (BiologyLab)
			{
				Seeds = SchoolGlobals.BiologySeeds;
				SeedProgress = SchoolGlobals.BiologySeedProgress;
			}
			else
			{
				Seeds = SchoolGlobals.Seeds;
				SeedProgress = SchoolGlobals.SeedProgress;
			}
			Initialized = true;
		}
		else
		{
			Debug.Log("Updating grow stations!");
		}
		if (Seeds > 0)
		{
			UpdateButtons();
		}
		if (SeedProgress >= 4)
		{
			MyRenderer.materials[1].mainTexture = PlantTexture;
			if (Seeds == 1)
			{
				MyRenderer.materials[1].color = Color.red;
			}
			else if (Seeds == 2)
			{
				MyRenderer.materials[1].color = Color.green;
			}
			else if (Seeds == 3)
			{
				MyRenderer.materials[1].color = Color.blue;
			}
			else if (Seeds == 4)
			{
				MyRenderer.materials[1].color = Color.grey;
			}
		}
	}

	private void Update()
	{
		if (Seeds == 0)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (!Prompt.Yandere.Inventory.LethalSeeds)
				{
					Prompt.Yandere.NotificationManager.CustomText = "You lack lethal seeds.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					return;
				}
				Prompt.Yandere.NotificationManager.CustomText = "Seeds planted!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Prompt.Yandere.Inventory.LethalSeeds = false;
				UpdateButtons();
				Seeds = 1;
				SeedProgress = 0;
			}
			else if (Prompt.Circle[1].fillAmount == 0f)
			{
				Prompt.Circle[1].fillAmount = 1f;
				if (!Prompt.Yandere.Inventory.EmeticSeeds)
				{
					Prompt.Yandere.NotificationManager.CustomText = "You lack emetic seeds.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					return;
				}
				Prompt.Yandere.NotificationManager.CustomText = "Seeds planted!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Prompt.Yandere.Inventory.EmeticSeeds = false;
				UpdateButtons();
				Seeds = 2;
				SeedProgress = 0;
			}
			else if (Prompt.Circle[2].fillAmount == 0f)
			{
				Prompt.Circle[2].fillAmount = 1f;
				if (!Prompt.Yandere.Inventory.SedativeSeeds)
				{
					Prompt.Yandere.NotificationManager.CustomText = "You lack sedative seeds.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					return;
				}
				Prompt.Yandere.NotificationManager.CustomText = "Seeds planted!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Prompt.Yandere.Inventory.SedativeSeeds = false;
				UpdateButtons();
				Seeds = 3;
				SeedProgress = 0;
			}
			else if (Prompt.Circle[3].fillAmount == 0f)
			{
				Prompt.Circle[3].fillAmount = 1f;
				if (!Prompt.Yandere.Inventory.HeadacheSeeds)
				{
					Prompt.Yandere.NotificationManager.CustomText = "You lack headache seeds.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					return;
				}
				Prompt.Yandere.NotificationManager.CustomText = "Seeds planted!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Prompt.Yandere.Inventory.HeadacheSeeds = false;
				UpdateButtons();
				Seeds = 4;
				SeedProgress = 0;
			}
		}
		else
		{
			if (Prompt.Circle[0].fillAmount != 0f)
			{
				return;
			}
			Prompt.Circle[0].fillAmount = 1f;
			if (SeedProgress < 4)
			{
				if (4 - SeedProgress > 1)
				{
					Prompt.Yandere.NotificationManager.CustomText = "Wait " + (4 - SeedProgress) + " more days.";
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "Wait 1 more day.";
				}
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				return;
			}
			if (Seeds == 1)
			{
				Prompt.Yandere.Inventory.LethalPoisons++;
				Prompt.Yandere.NotificationManager.CustomText = "Lethal poison obtained!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (Seeds == 2)
			{
				Prompt.Yandere.Inventory.EmeticPoisons++;
				Prompt.Yandere.NotificationManager.CustomText = "Emetic poison obtained!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (Seeds == 3)
			{
				Prompt.Yandere.Inventory.SedativePoisons++;
				Prompt.Yandere.NotificationManager.CustomText = "Sedative poison obtained!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (Seeds == 4)
			{
				Prompt.Yandere.Inventory.HeadachePoisons++;
				Prompt.Yandere.NotificationManager.CustomText = "Headache poison obtained!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			Seeds = 0;
			SeedProgress = 0;
			MyRenderer.materials[1].color = new Color(1f, 1f, 1f, 0f);
			InitializeButtons();
			Prompt.Yandere.StudentManager.UpdateAllBentos();
		}
	}

	public void InitializeButtons()
	{
		Prompt.Label[0].text = "     Plant Lethal Seeds";
		Prompt.HideButton[1] = false;
		Prompt.HideButton[2] = false;
		Prompt.HideButton[3] = false;
	}

	public void UpdateButtons()
	{
		Prompt.Label[0].text = "     Harvest Plant";
		Prompt.HideButton[1] = true;
		Prompt.HideButton[2] = true;
		Prompt.HideButton[3] = true;
	}

	public void SaveSeeds()
	{
		if (BiologyLab)
		{
			SchoolGlobals.BiologySeeds = Seeds;
			SchoolGlobals.BiologySeedProgress = SeedProgress;
		}
		else
		{
			SchoolGlobals.Seeds = Seeds;
			SchoolGlobals.SeedProgress = SeedProgress;
		}
	}
}
