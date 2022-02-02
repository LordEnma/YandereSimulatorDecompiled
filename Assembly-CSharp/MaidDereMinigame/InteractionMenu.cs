using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AC RID: 1452
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x0600249A RID: 9370 RVA: 0x001FAD00 File Offset: 0x001F8F00
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

		// Token: 0x0600249B RID: 9371 RVA: 0x001FAD1E File Offset: 0x001F8F1E
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x0600249C RID: 9372 RVA: 0x001FAD34 File Offset: 0x001F8F34
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

		// Token: 0x0600249D RID: 9373 RVA: 0x001FADBC File Offset: 0x001F8FBC
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x0600249E RID: 9374 RVA: 0x001FADF0 File Offset: 0x001F8FF0
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004C60 RID: 19552
		private static InteractionMenu instance;

		// Token: 0x04004C61 RID: 19553
		public GameObject interactObject;

		// Token: 0x04004C62 RID: 19554
		public GameObject backObject;

		// Token: 0x04004C63 RID: 19555
		public GameObject moveObject;

		// Token: 0x04004C64 RID: 19556
		public SpriteRenderer[] aButtons;

		// Token: 0x04004C65 RID: 19557
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004C66 RID: 19558
		public SpriteRenderer[] backButtons;

		// Token: 0x04004C67 RID: 19559
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006E0 RID: 1760
		public enum AButtonText
		{
			// Token: 0x040051C6 RID: 20934
			ChoosePlate,
			// Token: 0x040051C7 RID: 20935
			GrabPlate,
			// Token: 0x040051C8 RID: 20936
			KitchenMenu,
			// Token: 0x040051C9 RID: 20937
			PlaceOrder,
			// Token: 0x040051CA RID: 20938
			TakeOrder,
			// Token: 0x040051CB RID: 20939
			TossPlate,
			// Token: 0x040051CC RID: 20940
			GiveFood,
			// Token: 0x040051CD RID: 20941
			None
		}
	}
}
