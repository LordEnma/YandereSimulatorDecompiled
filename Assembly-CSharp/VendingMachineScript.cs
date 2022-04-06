using System;
using UnityEngine;

// Token: 0x020004B9 RID: 1209
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001FB3 RID: 8115 RVA: 0x001BE19C File Offset: 0x001BC39C
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

	// Token: 0x06001FB4 RID: 8116 RVA: 0x001BE22C File Offset: 0x001BC42C
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

	// Token: 0x04004229 RID: 16937
	public PromptScript Prompt;

	// Token: 0x0400422A RID: 16938
	public Transform CanSpawn;

	// Token: 0x0400422B RID: 16939
	public GameObject[] Cans;

	// Token: 0x0400422C RID: 16940
	public bool SnackMachine;

	// Token: 0x0400422D RID: 16941
	public bool Sabotaged;

	// Token: 0x0400422E RID: 16942
	public int Price;
}
