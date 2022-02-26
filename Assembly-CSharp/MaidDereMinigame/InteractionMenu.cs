using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AE RID: 1454
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x060024AF RID: 9391 RVA: 0x001FC2B0 File Offset: 0x001FA4B0
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

		// Token: 0x060024B0 RID: 9392 RVA: 0x001FC2CE File Offset: 0x001FA4CE
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x001FC2E4 File Offset: 0x001FA4E4
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

		// Token: 0x060024B2 RID: 9394 RVA: 0x001FC36C File Offset: 0x001FA56C
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x001FC3A0 File Offset: 0x001FA5A0
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004C82 RID: 19586
		private static InteractionMenu instance;

		// Token: 0x04004C83 RID: 19587
		public GameObject interactObject;

		// Token: 0x04004C84 RID: 19588
		public GameObject backObject;

		// Token: 0x04004C85 RID: 19589
		public GameObject moveObject;

		// Token: 0x04004C86 RID: 19590
		public SpriteRenderer[] aButtons;

		// Token: 0x04004C87 RID: 19591
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004C88 RID: 19592
		public SpriteRenderer[] backButtons;

		// Token: 0x04004C89 RID: 19593
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006E4 RID: 1764
		public enum AButtonText
		{
			// Token: 0x040051ED RID: 20973
			ChoosePlate,
			// Token: 0x040051EE RID: 20974
			GrabPlate,
			// Token: 0x040051EF RID: 20975
			KitchenMenu,
			// Token: 0x040051F0 RID: 20976
			PlaceOrder,
			// Token: 0x040051F1 RID: 20977
			TakeOrder,
			// Token: 0x040051F2 RID: 20978
			TossPlate,
			// Token: 0x040051F3 RID: 20979
			GiveFood,
			// Token: 0x040051F4 RID: 20980
			None
		}
	}
}
