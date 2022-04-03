using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B8 RID: 1464
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x060024DD RID: 9437 RVA: 0x00200460 File Offset: 0x001FE660
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

		// Token: 0x060024DE RID: 9438 RVA: 0x0020047E File Offset: 0x001FE67E
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x060024DF RID: 9439 RVA: 0x00200494 File Offset: 0x001FE694
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

		// Token: 0x060024E0 RID: 9440 RVA: 0x0020051C File Offset: 0x001FE71C
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x060024E1 RID: 9441 RVA: 0x00200550 File Offset: 0x001FE750
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004D30 RID: 19760
		private static InteractionMenu instance;

		// Token: 0x04004D31 RID: 19761
		public GameObject interactObject;

		// Token: 0x04004D32 RID: 19762
		public GameObject backObject;

		// Token: 0x04004D33 RID: 19763
		public GameObject moveObject;

		// Token: 0x04004D34 RID: 19764
		public SpriteRenderer[] aButtons;

		// Token: 0x04004D35 RID: 19765
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004D36 RID: 19766
		public SpriteRenderer[] backButtons;

		// Token: 0x04004D37 RID: 19767
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006EE RID: 1774
		public enum AButtonText
		{
			// Token: 0x0400529B RID: 21147
			ChoosePlate,
			// Token: 0x0400529C RID: 21148
			GrabPlate,
			// Token: 0x0400529D RID: 21149
			KitchenMenu,
			// Token: 0x0400529E RID: 21150
			PlaceOrder,
			// Token: 0x0400529F RID: 21151
			TakeOrder,
			// Token: 0x040052A0 RID: 21152
			TossPlate,
			// Token: 0x040052A1 RID: 21153
			GiveFood,
			// Token: 0x040052A2 RID: 21154
			None
		}
	}
}
