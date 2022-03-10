using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AE RID: 1454
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x060024AB RID: 9387 RVA: 0x001FC9C8 File Offset: 0x001FABC8
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

		// Token: 0x060024AC RID: 9388 RVA: 0x001FC9E8 File Offset: 0x001FABE8
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x060024AD RID: 9389 RVA: 0x001FCA44 File Offset: 0x001FAC44
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

		// Token: 0x060024AE RID: 9390 RVA: 0x001FCABB File Offset: 0x001FACBB
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x060024AF RID: 9391 RVA: 0x001FCAEB File Offset: 0x001FACEB
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x060024B0 RID: 9392 RVA: 0x001FCB20 File Offset: 0x001FAD20
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x001FCB68 File Offset: 0x001FAD68
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

		// Token: 0x060024B2 RID: 9394 RVA: 0x001FCC1E File Offset: 0x001FAE1E
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x001FCC41 File Offset: 0x001FAE41
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

		// Token: 0x04004C94 RID: 19604
		private static FoodMenu instance;

		// Token: 0x04004C95 RID: 19605
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004C96 RID: 19606
		public Transform menuSelector;

		// Token: 0x04004C97 RID: 19607
		public Transform menuSlotParent;

		// Token: 0x04004C98 RID: 19608
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004C99 RID: 19609
		private List<Transform> menuSlots;

		// Token: 0x04004C9A RID: 19610
		private float menuSelectorTarget;

		// Token: 0x04004C9B RID: 19611
		private float startY;

		// Token: 0x04004C9C RID: 19612
		private float startZ;

		// Token: 0x04004C9D RID: 19613
		private float interpolator;

		// Token: 0x04004C9E RID: 19614
		private int activeIndex;
	}
}
