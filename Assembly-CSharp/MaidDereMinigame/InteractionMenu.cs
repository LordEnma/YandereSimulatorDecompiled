using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B9 RID: 1465
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x060024E5 RID: 9445 RVA: 0x00200990 File Offset: 0x001FEB90
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

		// Token: 0x060024E6 RID: 9446 RVA: 0x002009AE File Offset: 0x001FEBAE
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x060024E7 RID: 9447 RVA: 0x002009C4 File Offset: 0x001FEBC4
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

		// Token: 0x060024E8 RID: 9448 RVA: 0x00200A4C File Offset: 0x001FEC4C
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x060024E9 RID: 9449 RVA: 0x00200A80 File Offset: 0x001FEC80
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004D34 RID: 19764
		private static InteractionMenu instance;

		// Token: 0x04004D35 RID: 19765
		public GameObject interactObject;

		// Token: 0x04004D36 RID: 19766
		public GameObject backObject;

		// Token: 0x04004D37 RID: 19767
		public GameObject moveObject;

		// Token: 0x04004D38 RID: 19768
		public SpriteRenderer[] aButtons;

		// Token: 0x04004D39 RID: 19769
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004D3A RID: 19770
		public SpriteRenderer[] backButtons;

		// Token: 0x04004D3B RID: 19771
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006EF RID: 1775
		public enum AButtonText
		{
			// Token: 0x0400529F RID: 21151
			ChoosePlate,
			// Token: 0x040052A0 RID: 21152
			GrabPlate,
			// Token: 0x040052A1 RID: 21153
			KitchenMenu,
			// Token: 0x040052A2 RID: 21154
			PlaceOrder,
			// Token: 0x040052A3 RID: 21155
			TakeOrder,
			// Token: 0x040052A4 RID: 21156
			TossPlate,
			// Token: 0x040052A5 RID: 21157
			GiveFood,
			// Token: 0x040052A6 RID: 21158
			None
		}
	}
}
