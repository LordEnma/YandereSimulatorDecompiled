using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B3 RID: 1459
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x060024CD RID: 9421 RVA: 0x001FEBF0 File Offset: 0x001FCDF0
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

		// Token: 0x060024CE RID: 9422 RVA: 0x001FEC0E File Offset: 0x001FCE0E
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x060024CF RID: 9423 RVA: 0x001FEC24 File Offset: 0x001FCE24
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

		// Token: 0x060024D0 RID: 9424 RVA: 0x001FECAC File Offset: 0x001FCEAC
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x060024D1 RID: 9425 RVA: 0x001FECE0 File Offset: 0x001FCEE0
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004CFE RID: 19710
		private static InteractionMenu instance;

		// Token: 0x04004CFF RID: 19711
		public GameObject interactObject;

		// Token: 0x04004D00 RID: 19712
		public GameObject backObject;

		// Token: 0x04004D01 RID: 19713
		public GameObject moveObject;

		// Token: 0x04004D02 RID: 19714
		public SpriteRenderer[] aButtons;

		// Token: 0x04004D03 RID: 19715
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004D04 RID: 19716
		public SpriteRenderer[] backButtons;

		// Token: 0x04004D05 RID: 19717
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006E9 RID: 1769
		public enum AButtonText
		{
			// Token: 0x04005269 RID: 21097
			ChoosePlate,
			// Token: 0x0400526A RID: 21098
			GrabPlate,
			// Token: 0x0400526B RID: 21099
			KitchenMenu,
			// Token: 0x0400526C RID: 21100
			PlaceOrder,
			// Token: 0x0400526D RID: 21101
			TakeOrder,
			// Token: 0x0400526E RID: 21102
			TossPlate,
			// Token: 0x0400526F RID: 21103
			GiveFood,
			// Token: 0x04005270 RID: 21104
			None
		}
	}
}
