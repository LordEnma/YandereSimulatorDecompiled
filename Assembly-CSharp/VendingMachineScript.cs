﻿using System;
using UnityEngine;

// Token: 0x020004B0 RID: 1200
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001F7C RID: 8060 RVA: 0x001B9848 File Offset: 0x001B7A48
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

	// Token: 0x06001F7D RID: 8061 RVA: 0x001B98D8 File Offset: 0x001B7AD8
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

	// Token: 0x0400417E RID: 16766
	public PromptScript Prompt;

	// Token: 0x0400417F RID: 16767
	public Transform CanSpawn;

	// Token: 0x04004180 RID: 16768
	public GameObject[] Cans;

	// Token: 0x04004181 RID: 16769
	public bool SnackMachine;

	// Token: 0x04004182 RID: 16770
	public bool Sabotaged;

	// Token: 0x04004183 RID: 16771
	public int Price;
}
