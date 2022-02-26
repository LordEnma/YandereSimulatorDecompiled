using System;
using UnityEngine;

// Token: 0x020004B2 RID: 1202
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001F8C RID: 8076 RVA: 0x001BA7E8 File Offset: 0x001B89E8
	private void Start()
	{
		if (this.SnackMachine)
		{
			this.Prompt.Text[0] = "Buy Snack for $" + this.Price.ToString() + ".00";
		}
		else
		{
			this.Prompt.Text[0] = "Buy Drink for $" + this.Price.ToString() + ".00";
		}
		this.Prompt.Label[0].text = "     " + this.Prompt.Text[0];
	}

	// Token: 0x06001F8D RID: 8077 RVA: 0x001BA878 File Offset: 0x001B8A78
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Prompt.Yandere.Inventory.Money >= (float)this.Price)
			{
				if (!this.Sabotaged)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.Cans[UnityEngine.Random.Range(0, this.Cans.Length)], this.CanSpawn.position, this.CanSpawn.rotation).GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(0.9f, 1.1f);
				}
				if (this.SnackMachine && SchemeGlobals.GetSchemeStage(4) == 3)
				{
					SchemeGlobals.SetSchemeStage(4, 4);
					this.Prompt.Yandere.PauseScreen.Schemes.UpdateInstructions();
				}
				this.Prompt.Yandere.Inventory.Money -= (float)this.Price;
				this.Prompt.Yandere.Inventory.UpdateMoney();
				return;
			}
			this.Prompt.Yandere.StudentManager.TutorialWindow.ShowMoneyMessage = true;
			this.Prompt.Yandere.NotificationManager.CustomText = "Not enough money!";
			this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	// Token: 0x04004197 RID: 16791
	public PromptScript Prompt;

	// Token: 0x04004198 RID: 16792
	public Transform CanSpawn;

	// Token: 0x04004199 RID: 16793
	public GameObject[] Cans;

	// Token: 0x0400419A RID: 16794
	public bool SnackMachine;

	// Token: 0x0400419B RID: 16795
	public bool Sabotaged;

	// Token: 0x0400419C RID: 16796
	public int Price;
}
