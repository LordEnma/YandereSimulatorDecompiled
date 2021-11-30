using System;
using System.Globalization;
using UnityEngine;

// Token: 0x0200033B RID: 827
public class InventoryScript : MonoBehaviour
{
	// Token: 0x060018DA RID: 6362 RVA: 0x000F822C File Offset: 0x000F642C
	private void Start()
	{
		this.DirectionalMic = PlayerGlobals.DirectionalMic;
		this.Headset = PlayerGlobals.Headset;
		this.SenpaiShots = PlayerGlobals.SenpaiShots;
		this.PantyShots = PlayerGlobals.PantyShots;
		this.Money = PlayerGlobals.Money;
		if (PlayerGlobals.BringingItem == 4)
		{
			this.ArrivedWithRatPoison = true;
			this.RatPoison = true;
		}
		else if (PlayerGlobals.BringingItem == 5)
		{
			this.Sake = true;
		}
		else if (PlayerGlobals.BringingItem == 6)
		{
			this.Cigs = true;
		}
		else if (PlayerGlobals.BringingItem == 7)
		{
			this.Condoms = true;
		}
		else if (PlayerGlobals.BringingItem == 8)
		{
			this.LockPick = true;
		}
		else if (PlayerGlobals.BringingItem == 9)
		{
			this.Sedative = true;
		}
		else if (PlayerGlobals.BringingItem == 10)
		{
			this.Narcotics = true;
		}
		else if (PlayerGlobals.BringingItem == 11)
		{
			this.LethalPoison = true;
		}
		else if (PlayerGlobals.BringingItem == 12)
		{
			this.ExplosiveDeviceSet.SetActive(true);
		}
		this.UpdateMoney();
	}

	// Token: 0x060018DB RID: 6363 RVA: 0x000F8320 File Offset: 0x000F6520
	public void UpdateMoney()
	{
		this.MoneyLabel.text = "$" + this.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x0400267C RID: 9852
	public SchemesScript Schemes;

	// Token: 0x0400267D RID: 9853
	public GameObject ExplosiveDeviceSet;

	// Token: 0x0400267E RID: 9854
	public bool FinishedHomework;

	// Token: 0x0400267F RID: 9855
	public bool ModifiedUniform;

	// Token: 0x04002680 RID: 9856
	public bool DirectionalMic;

	// Token: 0x04002681 RID: 9857
	public bool DuplicateSheet;

	// Token: 0x04002682 RID: 9858
	public bool AnswerSheet;

	// Token: 0x04002683 RID: 9859
	public bool MaskingTape;

	// Token: 0x04002684 RID: 9860
	public bool RivalPhone;

	// Token: 0x04002685 RID: 9861
	public bool Narcotics;

	// Token: 0x04002686 RID: 9862
	public bool LockPick;

	// Token: 0x04002687 RID: 9863
	public bool Condoms;

	// Token: 0x04002688 RID: 9864
	public bool Headset;

	// Token: 0x04002689 RID: 9865
	public bool FakeID;

	// Token: 0x0400268A RID: 9866
	public bool IDCard;

	// Token: 0x0400268B RID: 9867
	public bool Book;

	// Token: 0x0400268C RID: 9868
	public bool Cigs;

	// Token: 0x0400268D RID: 9869
	public bool Ring;

	// Token: 0x0400268E RID: 9870
	public bool Rose;

	// Token: 0x0400268F RID: 9871
	public bool Sake;

	// Token: 0x04002690 RID: 9872
	public bool Soda;

	// Token: 0x04002691 RID: 9873
	public bool Bra;

	// Token: 0x04002692 RID: 9874
	public bool AmnesiaBomb;

	// Token: 0x04002693 RID: 9875
	public bool SmokeBomb;

	// Token: 0x04002694 RID: 9876
	public bool StinkBomb;

	// Token: 0x04002695 RID: 9877
	public bool LethalPoison;

	// Token: 0x04002696 RID: 9878
	public bool ChemicalPoison;

	// Token: 0x04002697 RID: 9879
	public bool EmeticPoison;

	// Token: 0x04002698 RID: 9880
	public bool RatPoison;

	// Token: 0x04002699 RID: 9881
	public bool HeadachePoison;

	// Token: 0x0400269A RID: 9882
	public bool Tranquilizer;

	// Token: 0x0400269B RID: 9883
	public bool Sedative;

	// Token: 0x0400269C RID: 9884
	public bool CabinetKey;

	// Token: 0x0400269D RID: 9885
	public bool CaseKey;

	// Token: 0x0400269E RID: 9886
	public bool SafeKey;

	// Token: 0x0400269F RID: 9887
	public bool ShedKey;

	// Token: 0x040026A0 RID: 9888
	public bool Ammonium;

	// Token: 0x040026A1 RID: 9889
	public bool Balloons;

	// Token: 0x040026A2 RID: 9890
	public bool Bandages;

	// Token: 0x040026A3 RID: 9891
	public bool Glass;

	// Token: 0x040026A4 RID: 9892
	public bool Hairpins;

	// Token: 0x040026A5 RID: 9893
	public bool Nails;

	// Token: 0x040026A6 RID: 9894
	public bool Paper;

	// Token: 0x040026A7 RID: 9895
	public bool PaperClips;

	// Token: 0x040026A8 RID: 9896
	public bool SilverFulminate;

	// Token: 0x040026A9 RID: 9897
	public bool WoodenSticks;

	// Token: 0x040026AA RID: 9898
	public int MysteriousKeys;

	// Token: 0x040026AB RID: 9899
	public int LethalPoisons;

	// Token: 0x040026AC RID: 9900
	public int RivalPhoneID;

	// Token: 0x040026AD RID: 9901
	public int SenpaiShots;

	// Token: 0x040026AE RID: 9902
	public int PantyShots;

	// Token: 0x040026AF RID: 9903
	public float Money;

	// Token: 0x040026B0 RID: 9904
	public bool[] ShrineCollectibles;

	// Token: 0x040026B1 RID: 9905
	public UILabel MoneyLabel;

	// Token: 0x040026B2 RID: 9906
	public bool ArrivedWithRatPoison;
}
