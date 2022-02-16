using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AD RID: 1453
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x060024A6 RID: 9382 RVA: 0x001FB6D0 File Offset: 0x001F98D0
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

		// Token: 0x060024A7 RID: 9383 RVA: 0x001FB6EE File Offset: 0x001F98EE
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x060024A8 RID: 9384 RVA: 0x001FB704 File Offset: 0x001F9904
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

		// Token: 0x060024A9 RID: 9385 RVA: 0x001FB78C File Offset: 0x001F998C
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x060024AA RID: 9386 RVA: 0x001FB7C0 File Offset: 0x001F99C0
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004C72 RID: 19570
		private static InteractionMenu instance;

		// Token: 0x04004C73 RID: 19571
		public GameObject interactObject;

		// Token: 0x04004C74 RID: 19572
		public GameObject backObject;

		// Token: 0x04004C75 RID: 19573
		public GameObject moveObject;

		// Token: 0x04004C76 RID: 19574
		public SpriteRenderer[] aButtons;

		// Token: 0x04004C77 RID: 19575
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004C78 RID: 19576
		public SpriteRenderer[] backButtons;

		// Token: 0x04004C79 RID: 19577
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006E1 RID: 1761
		public enum AButtonText
		{
			// Token: 0x040051D8 RID: 20952
			ChoosePlate,
			// Token: 0x040051D9 RID: 20953
			GrabPlate,
			// Token: 0x040051DA RID: 20954
			KitchenMenu,
			// Token: 0x040051DB RID: 20955
			PlaceOrder,
			// Token: 0x040051DC RID: 20956
			TakeOrder,
			// Token: 0x040051DD RID: 20957
			TossPlate,
			// Token: 0x040051DE RID: 20958
			GiveFood,
			// Token: 0x040051DF RID: 20959
			None
		}
	}
}
