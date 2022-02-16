using System;
using System.Globalization;
using UnityEngine;

// Token: 0x0200033E RID: 830
public class InventoryScript : MonoBehaviour
{
	// Token: 0x060018F1 RID: 6385 RVA: 0x000F98E8 File Offset: 0x000F7AE8
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

	// Token: 0x060018F2 RID: 6386 RVA: 0x000F9A0C File Offset: 0x000F7C0C
	public void UpdateMoney()
	{
		this.MoneyLabel.text = "$" + this.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x040026B7 RID: 9911
	public SchemesScript Schemes;

	// Token: 0x040026B8 RID: 9912
	public GameObject ExplosiveDeviceSet;

	// Token: 0x040026B9 RID: 9913
	public bool FinishedHomework;

	// Token: 0x040026BA RID: 9914
	public bool ModifiedUniform;

	// Token: 0x040026BB RID: 9915
	public bool DirectionalMic;

	// Token: 0x040026BC RID: 9916
	public bool DuplicateSheet;

	// Token: 0x040026BD RID: 9917
	public bool AnswerSheet;

	// Token: 0x040026BE RID: 9918
	public bool MaskingTape;

	// Token: 0x040026BF RID: 9919
	public bool RivalPhone;

	// Token: 0x040026C0 RID: 9920
	public bool Narcotics;

	// Token: 0x040026C1 RID: 9921
	public bool LockPick;

	// Token: 0x040026C2 RID: 9922
	public bool Condoms;

	// Token: 0x040026C3 RID: 9923
	public bool Headset;

	// Token: 0x040026C4 RID: 9924
	public bool FakeID;

	// Token: 0x040026C5 RID: 9925
	public bool IDCard;

	// Token: 0x040026C6 RID: 9926
	public bool Book;

	// Token: 0x040026C7 RID: 9927
	public bool Cigs;

	// Token: 0x040026C8 RID: 9928
	public bool Ring;

	// Token: 0x040026C9 RID: 9929
	public bool Rose;

	// Token: 0x040026CA RID: 9930
	public bool Sake;

	// Token: 0x040026CB RID: 9931
	public bool Soda;

	// Token: 0x040026CC RID: 9932
	public bool Bra;

	// Token: 0x040026CD RID: 9933
	public bool AmnesiaBomb;

	// Token: 0x040026CE RID: 9934
	public bool SmokeBomb;

	// Token: 0x040026CF RID: 9935
	public bool StinkBomb;

	// Token: 0x040026D0 RID: 9936
	public bool LethalPoison;

	// Token: 0x040026D1 RID: 9937
	public bool ChemicalPoison;

	// Token: 0x040026D2 RID: 9938
	public bool EmeticPoison;

	// Token: 0x040026D3 RID: 9939
	public bool RatPoison;

	// Token: 0x040026D4 RID: 9940
	public bool HeadachePoison;

	// Token: 0x040026D5 RID: 9941
	public bool Tranquilizer;

	// Token: 0x040026D6 RID: 9942
	public bool Sedative;

	// Token: 0x040026D7 RID: 9943
	public bool CabinetKey;

	// Token: 0x040026D8 RID: 9944
	public bool CaseKey;

	// Token: 0x040026D9 RID: 9945
	public bool SafeKey;

	// Token: 0x040026DA RID: 9946
	public bool ShedKey;

	// Token: 0x040026DB RID: 9947
	public bool Ammonium;

	// Token: 0x040026DC RID: 9948
	public bool Balloons;

	// Token: 0x040026DD RID: 9949
	public bool Bandages;

	// Token: 0x040026DE RID: 9950
	public bool Glass;

	// Token: 0x040026DF RID: 9951
	public bool Hairpins;

	// Token: 0x040026E0 RID: 9952
	public bool Nails;

	// Token: 0x040026E1 RID: 9953
	public bool Paper;

	// Token: 0x040026E2 RID: 9954
	public bool PaperClips;

	// Token: 0x040026E3 RID: 9955
	public bool SilverFulminate;

	// Token: 0x040026E4 RID: 9956
	public bool WoodenSticks;

	// Token: 0x040026E5 RID: 9957
	public int MysteriousKeys;

	// Token: 0x040026E6 RID: 9958
	public int LethalPoisons;

	// Token: 0x040026E7 RID: 9959
	public int RivalPhoneID;

	// Token: 0x040026E8 RID: 9960
	public int SenpaiShots;

	// Token: 0x040026E9 RID: 9961
	public int PantyShots;

	// Token: 0x040026EA RID: 9962
	public float Money;

	// Token: 0x040026EB RID: 9963
	public bool[] ShrineCollectibles;

	// Token: 0x040026EC RID: 9964
	public UILabel MoneyLabel;

	// Token: 0x040026ED RID: 9965
	public bool ArrivedWithRatPoison;

	// Token: 0x040026EE RID: 9966
	public bool ArrivedWithSake;

	// Token: 0x040026EF RID: 9967
	public bool ArrivedWithCigs;

	// Token: 0x040026F0 RID: 9968
	public bool ArrivedWithCondoms;

	// Token: 0x040026F1 RID: 9969
	public bool ArrivedWithSedative;

	// Token: 0x040026F2 RID: 9970
	public bool ArrivedWithPoison;
}
