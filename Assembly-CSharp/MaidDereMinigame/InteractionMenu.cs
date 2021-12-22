using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A9 RID: 1449
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06002486 RID: 9350 RVA: 0x001F8800 File Offset: 0x001F6A00
		public static InteractionMenu Instance
		{
			get
			{
				if (InteractionMenu.instance == null)
				{
					InteractionMenu.instance = UnityEngine.Object.FindObjectOfType<InteractionMenu>();
				}
				return InteractionMenu.instance;
			}
		}

		// Token: 0x06002487 RID: 9351 RVA: 0x001F881E File Offset: 0x001F6A1E
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x06002488 RID: 9352 RVA: 0x001F8834 File Offset: 0x001F6A34
		public static void SetAButton(InteractionMenu.AButtonText text)
		{
			for (int i = 0; i < InteractionMenu.Instance.aButtonSprites.Length; i++)
			{
				if (i == (int)text)
				{
					InteractionMenu.Instance.aButtonSprites[i].gameObject.SetActive(true);
				}
				else
				{
					InteractionMenu.Instance.aButtonSprites[i].gameObject.SetActive(false);
				}
			}
			SpriteRenderer[] array = InteractionMenu.Instance.aButtons;
			for (int j = 0; j < array.Length; j++)
			{
				array[j].gameObject.SetActive(text != InteractionMenu.AButtonText.None);
			}
		}

		// Token: 0x06002489 RID: 9353 RVA: 0x001F88BC File Offset: 0x001F6ABC
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x0600248A RID: 9354 RVA: 0x001F88F0 File Offset: 0x001F6AF0
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004C31 RID: 19505
		private static InteractionMenu instance;

		// Token: 0x04004C32 RID: 19506
		public GameObject interactObject;

		// Token: 0x04004C33 RID: 19507
		public GameObject backObject;

		// Token: 0x04004C34 RID: 19508
		public GameObject moveObject;

		// Token: 0x04004C35 RID: 19509
		public SpriteRenderer[] aButtons;

		// Token: 0x04004C36 RID: 19510
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004C37 RID: 19511
		public SpriteRenderer[] backButtons;

		// Token: 0x04004C38 RID: 19512
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006E3 RID: 1763
		public enum AButtonText
		{
			// Token: 0x040051C5 RID: 20933
			ChoosePlate,
			// Token: 0x040051C6 RID: 20934
			GrabPlate,
			// Token: 0x040051C7 RID: 20935
			KitchenMenu,
			// Token: 0x040051C8 RID: 20936
			PlaceOrder,
			// Token: 0x040051C9 RID: 20937
			TakeOrder,
			// Token: 0x040051CA RID: 20938
			TossPlate,
			// Token: 0x040051CB RID: 20939
			GiveFood,
			// Token: 0x040051CC RID: 20940
			None
		}
	}
}
