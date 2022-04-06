using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B8 RID: 1464
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x060024DB RID: 9435 RVA: 0x002006D0 File Offset: 0x001FE8D0
		public static FoodMenu Instance
		{
			get
			{
				if (FoodMenu.instance == null)
				{
					FoodMenu.instance = UnityEngine.Object.FindObjectOfType<FoodMenu>();
				}
				return FoodMenu.instance;
			}
		}

		// Token: 0x060024DC RID: 9436 RVA: 0x002006F0 File Offset: 0x001FE8F0
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x060024DD RID: 9437 RVA: 0x0020074C File Offset: 0x001FE94C
		public void SetMenuIcons()
		{
			this.menuSlots = new List<Transform>();
			for (int i = 0; i < this.menuSlotParent.childCount; i++)
			{
				Transform child = this.menuSlotParent.GetChild(i);
				this.menuSlots.Add(child);
				if (this.foodItems.Count >= i)
				{
					child.GetChild(0).GetComponent<SpriteRenderer>().sprite = this.foodItems[i].largeSprite;
				}
			}
		}

		// Token: 0x060024DE RID: 9438 RVA: 0x002007C3 File Offset: 0x001FE9C3
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x060024DF RID: 9439 RVA: 0x002007F3 File Offset: 0x001FE9F3
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x060024E0 RID: 9440 RVA: 0x00200828 File Offset: 0x001FEA28
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x060024E1 RID: 9441 RVA: 0x00200870 File Offset: 0x001FEA70
		private void Update()
		{
			if (this.interpolator < 1f)
			{
				float x = Mathf.Lerp(this.menuSelector.position.x, this.menuSelectorTarget, this.interpolator);
				this.menuSelector.position = new Vector3(x, this.startY, this.startZ);
				this.interpolator += Time.deltaTime * this.selectorMoveSpeed;
			}
			else
			{
				this.menuSelector.transform.position = new Vector3(this.menuSelectorTarget, this.startY, this.startZ);
			}
			if (YandereController.rightButton)
			{
				this.IncrementSelection();
				return;
			}
			if (YandereController.leftButton)
			{
				this.DecrementSelection();
			}
		}

		// Token: 0x060024E2 RID: 9442 RVA: 0x00200926 File Offset: 0x001FEB26
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x060024E3 RID: 9443 RVA: 0x00200949 File Offset: 0x001FEB49
		private void DecrementSelection()
		{
			if (this.activeIndex == 0)
			{
				this.SetActive(this.menuSlots.Count - 1);
			}
			else
			{
				this.SetActive(this.activeIndex - 1);
			}
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x04004D29 RID: 19753
		private static FoodMenu instance;

		// Token: 0x04004D2A RID: 19754
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004D2B RID: 19755
		public Transform menuSelector;

		// Token: 0x04004D2C RID: 19756
		public Transform menuSlotParent;

		// Token: 0x04004D2D RID: 19757
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004D2E RID: 19758
		private List<Transform> menuSlots;

		// Token: 0x04004D2F RID: 19759
		private float menuSelectorTarget;

		// Token: 0x04004D30 RID: 19760
		private float startY;

		// Token: 0x04004D31 RID: 19761
		private float startZ;

		// Token: 0x04004D32 RID: 19762
		private float interpolator;

		// Token: 0x04004D33 RID: 19763
		private int activeIndex;
	}
}
