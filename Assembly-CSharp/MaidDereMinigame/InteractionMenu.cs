using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B9 RID: 1465
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x060024EC RID: 9452 RVA: 0x002013EC File Offset: 0x001FF5EC
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

		// Token: 0x060024ED RID: 9453 RVA: 0x0020140A File Offset: 0x001FF60A
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x060024EE RID: 9454 RVA: 0x00201420 File Offset: 0x001FF620
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

		// Token: 0x060024EF RID: 9455 RVA: 0x002014A8 File Offset: 0x001FF6A8
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x060024F0 RID: 9456 RVA: 0x002014DC File Offset: 0x001FF6DC
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004D46 RID: 19782
		private static InteractionMenu instance;

		// Token: 0x04004D47 RID: 19783
		public GameObject interactObject;

		// Token: 0x04004D48 RID: 19784
		public GameObject backObject;

		// Token: 0x04004D49 RID: 19785
		public GameObject moveObject;

		// Token: 0x04004D4A RID: 19786
		public SpriteRenderer[] aButtons;

		// Token: 0x04004D4B RID: 19787
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004D4C RID: 19788
		public SpriteRenderer[] backButtons;

		// Token: 0x04004D4D RID: 19789
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006EF RID: 1775
		public enum AButtonText
		{
			// Token: 0x040052B1 RID: 21169
			ChoosePlate,
			// Token: 0x040052B2 RID: 21170
			GrabPlate,
			// Token: 0x040052B3 RID: 21171
			KitchenMenu,
			// Token: 0x040052B4 RID: 21172
			PlaceOrder,
			// Token: 0x040052B5 RID: 21173
			TakeOrder,
			// Token: 0x040052B6 RID: 21174
			TossPlate,
			// Token: 0x040052B7 RID: 21175
			GiveFood,
			// Token: 0x040052B8 RID: 21176
			None
		}
	}
}
