using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BA RID: 1466
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x060024F6 RID: 9462 RVA: 0x00202A88 File Offset: 0x00200C88
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

		// Token: 0x060024F7 RID: 9463 RVA: 0x00202AA6 File Offset: 0x00200CA6
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x060024F8 RID: 9464 RVA: 0x00202ABC File Offset: 0x00200CBC
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

		// Token: 0x060024F9 RID: 9465 RVA: 0x00202B44 File Offset: 0x00200D44
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x060024FA RID: 9466 RVA: 0x00202B78 File Offset: 0x00200D78
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004D64 RID: 19812
		private static InteractionMenu instance;

		// Token: 0x04004D65 RID: 19813
		public GameObject interactObject;

		// Token: 0x04004D66 RID: 19814
		public GameObject backObject;

		// Token: 0x04004D67 RID: 19815
		public GameObject moveObject;

		// Token: 0x04004D68 RID: 19816
		public SpriteRenderer[] aButtons;

		// Token: 0x04004D69 RID: 19817
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004D6A RID: 19818
		public SpriteRenderer[] backButtons;

		// Token: 0x04004D6B RID: 19819
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006F0 RID: 1776
		public enum AButtonText
		{
			// Token: 0x040052CF RID: 21199
			ChoosePlate,
			// Token: 0x040052D0 RID: 21200
			GrabPlate,
			// Token: 0x040052D1 RID: 21201
			KitchenMenu,
			// Token: 0x040052D2 RID: 21202
			PlaceOrder,
			// Token: 0x040052D3 RID: 21203
			TakeOrder,
			// Token: 0x040052D4 RID: 21204
			TossPlate,
			// Token: 0x040052D5 RID: 21205
			GiveFood,
			// Token: 0x040052D6 RID: 21206
			None
		}
	}
}
