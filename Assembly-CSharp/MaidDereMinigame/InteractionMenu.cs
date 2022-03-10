using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AF RID: 1455
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x060024B5 RID: 9397 RVA: 0x001FCC88 File Offset: 0x001FAE88
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

		// Token: 0x060024B6 RID: 9398 RVA: 0x001FCCA6 File Offset: 0x001FAEA6
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x001FCCBC File Offset: 0x001FAEBC
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

		// Token: 0x060024B8 RID: 9400 RVA: 0x001FCD44 File Offset: 0x001FAF44
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x060024B9 RID: 9401 RVA: 0x001FCD78 File Offset: 0x001FAF78
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004C9F RID: 19615
		private static InteractionMenu instance;

		// Token: 0x04004CA0 RID: 19616
		public GameObject interactObject;

		// Token: 0x04004CA1 RID: 19617
		public GameObject backObject;

		// Token: 0x04004CA2 RID: 19618
		public GameObject moveObject;

		// Token: 0x04004CA3 RID: 19619
		public SpriteRenderer[] aButtons;

		// Token: 0x04004CA4 RID: 19620
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004CA5 RID: 19621
		public SpriteRenderer[] backButtons;

		// Token: 0x04004CA6 RID: 19622
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006E5 RID: 1765
		public enum AButtonText
		{
			// Token: 0x0400520A RID: 21002
			ChoosePlate,
			// Token: 0x0400520B RID: 21003
			GrabPlate,
			// Token: 0x0400520C RID: 21004
			KitchenMenu,
			// Token: 0x0400520D RID: 21005
			PlaceOrder,
			// Token: 0x0400520E RID: 21006
			TakeOrder,
			// Token: 0x0400520F RID: 21007
			TossPlate,
			// Token: 0x04005210 RID: 21008
			GiveFood,
			// Token: 0x04005211 RID: 21009
			None
		}
	}
}
