using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AC RID: 1452
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x0600249C RID: 9372 RVA: 0x001FB018 File Offset: 0x001F9218
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

		// Token: 0x0600249D RID: 9373 RVA: 0x001FB036 File Offset: 0x001F9236
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x0600249E RID: 9374 RVA: 0x001FB04C File Offset: 0x001F924C
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

		// Token: 0x0600249F RID: 9375 RVA: 0x001FB0D4 File Offset: 0x001F92D4
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x060024A0 RID: 9376 RVA: 0x001FB108 File Offset: 0x001F9308
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004C66 RID: 19558
		private static InteractionMenu instance;

		// Token: 0x04004C67 RID: 19559
		public GameObject interactObject;

		// Token: 0x04004C68 RID: 19560
		public GameObject backObject;

		// Token: 0x04004C69 RID: 19561
		public GameObject moveObject;

		// Token: 0x04004C6A RID: 19562
		public SpriteRenderer[] aButtons;

		// Token: 0x04004C6B RID: 19563
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004C6C RID: 19564
		public SpriteRenderer[] backButtons;

		// Token: 0x04004C6D RID: 19565
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006E0 RID: 1760
		public enum AButtonText
		{
			// Token: 0x040051CC RID: 20940
			ChoosePlate,
			// Token: 0x040051CD RID: 20941
			GrabPlate,
			// Token: 0x040051CE RID: 20942
			KitchenMenu,
			// Token: 0x040051CF RID: 20943
			PlaceOrder,
			// Token: 0x040051D0 RID: 20944
			TakeOrder,
			// Token: 0x040051D1 RID: 20945
			TossPlate,
			// Token: 0x040051D2 RID: 20946
			GiveFood,
			// Token: 0x040051D3 RID: 20947
			None
		}
	}
}
