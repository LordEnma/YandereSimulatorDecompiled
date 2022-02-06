using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AC RID: 1452
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x0600249F RID: 9375 RVA: 0x001FB21C File Offset: 0x001F941C
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

		// Token: 0x060024A0 RID: 9376 RVA: 0x001FB23A File Offset: 0x001F943A
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x001FB250 File Offset: 0x001F9450
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

		// Token: 0x060024A2 RID: 9378 RVA: 0x001FB2D8 File Offset: 0x001F94D8
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x060024A3 RID: 9379 RVA: 0x001FB30C File Offset: 0x001F950C
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004C69 RID: 19561
		private static InteractionMenu instance;

		// Token: 0x04004C6A RID: 19562
		public GameObject interactObject;

		// Token: 0x04004C6B RID: 19563
		public GameObject backObject;

		// Token: 0x04004C6C RID: 19564
		public GameObject moveObject;

		// Token: 0x04004C6D RID: 19565
		public SpriteRenderer[] aButtons;

		// Token: 0x04004C6E RID: 19566
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004C6F RID: 19567
		public SpriteRenderer[] backButtons;

		// Token: 0x04004C70 RID: 19568
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006E0 RID: 1760
		public enum AButtonText
		{
			// Token: 0x040051CF RID: 20943
			ChoosePlate,
			// Token: 0x040051D0 RID: 20944
			GrabPlate,
			// Token: 0x040051D1 RID: 20945
			KitchenMenu,
			// Token: 0x040051D2 RID: 20946
			PlaceOrder,
			// Token: 0x040051D3 RID: 20947
			TakeOrder,
			// Token: 0x040051D4 RID: 20948
			TossPlate,
			// Token: 0x040051D5 RID: 20949
			GiveFood,
			// Token: 0x040051D6 RID: 20950
			None
		}
	}
}
