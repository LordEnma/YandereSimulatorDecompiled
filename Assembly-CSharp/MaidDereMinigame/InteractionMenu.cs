using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AC RID: 1452
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x06002496 RID: 9366 RVA: 0x001FA460 File Offset: 0x001F8660
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

		// Token: 0x06002497 RID: 9367 RVA: 0x001FA47E File Offset: 0x001F867E
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x06002498 RID: 9368 RVA: 0x001FA494 File Offset: 0x001F8694
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

		// Token: 0x06002499 RID: 9369 RVA: 0x001FA51C File Offset: 0x001F871C
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x0600249A RID: 9370 RVA: 0x001FA550 File Offset: 0x001F8750
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004C55 RID: 19541
		private static InteractionMenu instance;

		// Token: 0x04004C56 RID: 19542
		public GameObject interactObject;

		// Token: 0x04004C57 RID: 19543
		public GameObject backObject;

		// Token: 0x04004C58 RID: 19544
		public GameObject moveObject;

		// Token: 0x04004C59 RID: 19545
		public SpriteRenderer[] aButtons;

		// Token: 0x04004C5A RID: 19546
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004C5B RID: 19547
		public SpriteRenderer[] backButtons;

		// Token: 0x04004C5C RID: 19548
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006E6 RID: 1766
		public enum AButtonText
		{
			// Token: 0x040051E9 RID: 20969
			ChoosePlate,
			// Token: 0x040051EA RID: 20970
			GrabPlate,
			// Token: 0x040051EB RID: 20971
			KitchenMenu,
			// Token: 0x040051EC RID: 20972
			PlaceOrder,
			// Token: 0x040051ED RID: 20973
			TakeOrder,
			// Token: 0x040051EE RID: 20974
			TossPlate,
			// Token: 0x040051EF RID: 20975
			GiveFood,
			// Token: 0x040051F0 RID: 20976
			None
		}
	}
}
