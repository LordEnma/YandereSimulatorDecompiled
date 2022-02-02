using System;
using System.Globalization;
using UnityEngine;

// Token: 0x0200033D RID: 829
public class InventoryScript : MonoBehaviour
{
	// Token: 0x060018E8 RID: 6376 RVA: 0x000F958C File Offset: 0x000F778C
	private void Start()
	{
		this.DirectionalMic = PlayerGlobals.DirectionalMic;
		this.Headset = PlayerGlobals.Headset;
		this.SenpaiShots = PlayerGlobals.SenpaiShots;
		this.PantyShots = PlayerGlobals.PantyShots;
		this.Money = PlayerGlobals.Money;
		int bringingItem = PlayerGlobals.BringingItem;
		if (bringingItem > 0)
		{
			Debug.Log("The player brought an item. ID is: " + bringingItem.ToString());
		}
		if (bringingItem == 4)
		{
			this.ArrivedWithRatPoison = true;
			this.RatPoison = true;
		}
		else if (bringingItem == 5)
		{
			this.ArrivedWithSake = true;
			this.Sake = true;
		}
		else if (bringingItem == 6)
		{
			this.ArrivedWithCigs = true;
			this.Cigs = true;
		}
		else if (bringingItem == 7)
		{
			this.ArrivedWithCondoms = true;
			this.Condoms = true;
		}
		else if (bringingItem == 8)
		{
			this.LockPick = true;
		}
		else if (bringingItem == 9)
		{
			this.ArrivedWithSedative = true;
			this.Sedative = true;
		}
		else if (bringingItem == 10)
		{
			this.Narcotics = true;
		}
		else if (bringingItem == 11)
		{
			this.ArrivedWithPoison = true;
			this.LethalPoison = true;
			this.LethalPoisons++;
		}
		else if (bringingItem == 12)
		{
			this.ExplosiveDeviceSet.SetActive(true);
		}
		this.UpdateMoney();
	}

	// Token: 0x060018E9 RID: 6377 RVA: 0x000F96B0 File Offset: 0x000F78B0
	public void UpdateMoney()
	{
		this.MoneyLabel.text = "$" + this.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x040026AD RID: 9901
	public SchemesScript Schemes;

	// Token: 0x040026AE RID: 9902
	public GameObject ExplosiveDeviceSet;

	// Token: 0x040026AF RID: 9903
	public bool FinishedHomework;

	// Token: 0x040026B0 RID: 9904
	public bool ModifiedUniform;

	// Token: 0x040026B1 RID: 9905
	public bool DirectionalMic;

	// Token: 0x040026B2 RID: 9906
	public bool DuplicateSheet;

	// Token: 0x040026B3 RID: 9907
	public bool AnswerSheet;

	// Token: 0x040026B4 RID: 9908
	public bool MaskingTape;

	// Token: 0x040026B5 RID: 9909
	public bool RivalPhone;

	// Token: 0x040026B6 RID: 9910
	public bool Narcotics;

	// Token: 0x040026B7 RID: 9911
	public bool LockPick;

	// Token: 0x040026B8 RID: 9912
	public bool Condoms;

	// Token: 0x040026B9 RID: 9913
	public bool Headset;

	// Token: 0x040026BA RID: 9914
	public bool FakeID;

	// Token: 0x040026BB RID: 9915
	public bool IDCard;

	// Token: 0x040026BC RID: 9916
	public bool Book;

	// Token: 0x040026BD RID: 9917
	public bool Cigs;

	// Token: 0x040026BE RID: 9918
	public bool Ring;

	// Token: 0x040026BF RID: 9919
	public bool Rose;

	// Token: 0x040026C0 RID: 9920
	public bool Sake;

	// Token: 0x040026C1 RID: 9921
	public bool Soda;

	// Token: 0x040026C2 RID: 9922
	public bool Bra;

	// Token: 0x040026C3 RID: 9923
	public bool AmnesiaBomb;

	// Token: 0x040026C4 RID: 9924
	public bool SmokeBomb;

	// Token: 0x040026C5 RID: 9925
	public bool StinkBomb;

	// Token: 0x040026C6 RID: 9926
	public bool LethalPoison;

	// Token: 0x040026C7 RID: 9927
	public bool ChemicalPoison;

	// Token: 0x040026C8 RID: 9928
	public bool EmeticPoison;

	// Token: 0x040026C9 RID: 9929
	public bool RatPoison;

	// Token: 0x040026CA RID: 9930
	public bool HeadachePoison;

	// Token: 0x040026CB RID: 9931
	public bool Tranquilizer;

	// Token: 0x040026CC RID: 9932
	public bool Sedative;

	// Token: 0x040026CD RID: 9933
	public bool CabinetKey;

	// Token: 0x040026CE RID: 9934
	public bool CaseKey;

	// Token: 0x040026CF RID: 9935
	public bool SafeKey;

	// Token: 0x040026D0 RID: 9936
	public bool ShedKey;

	// Token: 0x040026D1 RID: 9937
	public bool Ammonium;

	// Token: 0x040026D2 RID: 9938
	public bool Balloons;

	// Token: 0x040026D3 RID: 9939
	public bool Bandages;

	// Token: 0x040026D4 RID: 9940
	public bool Glass;

	// Token: 0x040026D5 RID: 9941
	public bool Hairpins;

	// Token: 0x040026D6 RID: 9942
	public bool Nails;

	// Token: 0x040026D7 RID: 9943
	public bool Paper;

	// Token: 0x040026D8 RID: 9944
	public bool PaperClips;

	// Token: 0x040026D9 RID: 9945
	public bool SilverFulminate;

	// Token: 0x040026DA RID: 9946
	public bool WoodenSticks;

	// Token: 0x040026DB RID: 9947
	public int MysteriousKeys;

	// Token: 0x040026DC RID: 9948
	public int LethalPoisons;

	// Token: 0x040026DD RID: 9949
	public int RivalPhoneID;

	// Token: 0x040026DE RID: 9950
	public int SenpaiShots;

	// Token: 0x040026DF RID: 9951
	public int PantyShots;

	// Token: 0x040026E0 RID: 9952
	public float Money;

	// Token: 0x040026E1 RID: 9953
	public bool[] ShrineCollectibles;

	// Token: 0x040026E2 RID: 9954
	public UILabel MoneyLabel;

	// Token: 0x040026E3 RID: 9955
	public bool ArrivedWithRatPoison;

	// Token: 0x040026E4 RID: 9956
	public bool ArrivedWithSake;

	// Token: 0x040026E5 RID: 9957
	public bool ArrivedWithCigs;

	// Token: 0x040026E6 RID: 9958
	public bool ArrivedWithCondoms;

	// Token: 0x040026E7 RID: 9959
	public bool ArrivedWithSedative;

	// Token: 0x040026E8 RID: 9960
	public bool ArrivedWithPoison;
}
