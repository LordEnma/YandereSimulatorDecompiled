using System;
using UnityEngine;

// Token: 0x02000340 RID: 832
public class InventoryMenuScript : MonoBehaviour
{
	// Token: 0x0600190E RID: 6414 RVA: 0x000FB2B4 File Offset: 0x000F94B4
	public void UpdateLabels()
	{
		this.Labels[0].alpha = ((!this.Inventory.ModifiedUniform) ? 0.75f : 1f);
		this.Labels[1].alpha = ((!this.Inventory.DirectionalMic) ? 0.75f : 1f);
		this.Labels[2].alpha = ((!this.Inventory.DuplicateSheet) ? 0.75f : 1f);
		this.Labels[3].alpha = ((!this.Inventory.AnswerSheet) ? 0.75f : 1f);
		this.Labels[4].alpha = ((!this.Inventory.MaskingTape) ? 0.75f : 1f);
		this.Labels[5].alpha = ((!this.Inventory.RivalPhone) ? 0.75f : 1f);
		this.Labels[6].alpha = ((!this.Inventory.LockPick) ? 0.75f : 1f);
		this.Labels[7].alpha = ((!this.Inventory.Headset) ? 0.75f : 1f);
		this.Labels[8].alpha = ((!this.Inventory.FakeID) ? 0.75f : 1f);
		this.Labels[9].alpha = ((!this.Inventory.IDCard) ? 0.75f : 1f);
		this.Labels[10].alpha = ((!this.Inventory.Book) ? 0.75f : 1f);
		this.Labels[11].alpha = ((!this.Inventory.LethalPoison) ? 0.75f : 1f);
		this.Labels[12].alpha = ((!this.Inventory.ChemicalPoison) ? 0.75f : 1f);
		this.Labels[13].alpha = ((!this.Inventory.EmeticPoison) ? 0.75f : 1f);
		this.Labels[14].alpha = ((!this.Inventory.RatPoison) ? 0.75f : 1f);
		this.Labels[15].alpha = ((!this.Inventory.HeadachePoison) ? 0.75f : 1f);
		this.Labels[16].alpha = ((!this.Inventory.Tranquilizer) ? 0.75f : 1f);
		this.Labels[17].alpha = ((!this.Inventory.Sedative) ? 0.75f : 1f);
		this.Labels[18].alpha = ((!this.Inventory.Cigs) ? 0.75f : 1f);
		this.Labels[19].alpha = ((!this.Inventory.Ring) ? 0.75f : 1f);
		this.Labels[20].alpha = ((!this.Inventory.Sake) ? 0.75f : 1f);
		this.Labels[21].alpha = ((!this.Inventory.Soda) ? 0.75f : 1f);
		this.Labels[22].alpha = ((!this.Inventory.Bra) ? 0.75f : 1f);
		this.Labels[23].alpha = ((!this.Inventory.CabinetKey) ? 0.75f : 1f);
		this.Labels[24].alpha = ((!this.Inventory.CaseKey) ? 0.75f : 1f);
		this.Labels[25].alpha = ((!this.Inventory.SafeKey) ? 0.75f : 1f);
		this.Labels[26].alpha = ((!this.Inventory.ShedKey) ? 0.75f : 1f);
	}

	// Token: 0x0600190F RID: 6415 RVA: 0x000FB6D5 File Offset: 0x000F98D5
	private void Update()
	{
		if (Input.GetButtonDown("B"))
		{
			this.PauseScreen.MainMenu.SetActive(true);
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x04002713 RID: 10003
	public PauseScreenScript PauseScreen;

	// Token: 0x04002714 RID: 10004
	public InventoryScript Inventory;

	// Token: 0x04002715 RID: 10005
	public UILabel[] Labels;
}
