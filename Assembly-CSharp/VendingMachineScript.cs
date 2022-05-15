using System;
using UnityEngine;

// Token: 0x020004BB RID: 1211
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001FCC RID: 8140 RVA: 0x001C11C8 File Offset: 0x001BF3C8
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

	// Token: 0x06001FCD RID: 8141 RVA: 0x001C1258 File Offset: 0x001BF458
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

	// Token: 0x0400426D RID: 17005
	public PromptScript Prompt;

	// Token: 0x0400426E RID: 17006
	public Transform CanSpawn;

	// Token: 0x0400426F RID: 17007
	public GameObject[] Cans;

	// Token: 0x04004270 RID: 17008
	public bool SnackMachine;

	// Token: 0x04004271 RID: 17009
	public bool Sabotaged;

	// Token: 0x04004272 RID: 17010
	public int Price;
}
