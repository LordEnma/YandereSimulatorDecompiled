using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AB RID: 1451
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x06002494 RID: 9364 RVA: 0x001F9790 File Offset: 0x001F7990
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

		// Token: 0x06002495 RID: 9365 RVA: 0x001F97AE File Offset: 0x001F79AE
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x06002496 RID: 9366 RVA: 0x001F97C4 File Offset: 0x001F79C4
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

		// Token: 0x06002497 RID: 9367 RVA: 0x001F984C File Offset: 0x001F7A4C
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x06002498 RID: 9368 RVA: 0x001F9880 File Offset: 0x001F7A80
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004C4E RID: 19534
		private static InteractionMenu instance;

		// Token: 0x04004C4F RID: 19535
		public GameObject interactObject;

		// Token: 0x04004C50 RID: 19536
		public GameObject backObject;

		// Token: 0x04004C51 RID: 19537
		public GameObject moveObject;

		// Token: 0x04004C52 RID: 19538
		public SpriteRenderer[] aButtons;

		// Token: 0x04004C53 RID: 19539
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004C54 RID: 19540
		public SpriteRenderer[] backButtons;

		// Token: 0x04004C55 RID: 19541
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006E5 RID: 1765
		public enum AButtonText
		{
			// Token: 0x040051E2 RID: 20962
			ChoosePlate,
			// Token: 0x040051E3 RID: 20963
			GrabPlate,
			// Token: 0x040051E4 RID: 20964
			KitchenMenu,
			// Token: 0x040051E5 RID: 20965
			PlaceOrder,
			// Token: 0x040051E6 RID: 20966
			TakeOrder,
			// Token: 0x040051E7 RID: 20967
			TossPlate,
			// Token: 0x040051E8 RID: 20968
			GiveFood,
			// Token: 0x040051E9 RID: 20969
			None
		}
	}
}
