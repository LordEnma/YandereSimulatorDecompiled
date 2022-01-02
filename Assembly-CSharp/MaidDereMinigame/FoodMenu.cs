using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A8 RID: 1448
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x0600247F RID: 9343 RVA: 0x001F8B30 File Offset: 0x001F6D30
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

		// Token: 0x06002480 RID: 9344 RVA: 0x001F8B50 File Offset: 0x001F6D50
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x06002481 RID: 9345 RVA: 0x001F8BAC File Offset: 0x001F6DAC
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

		// Token: 0x06002482 RID: 9346 RVA: 0x001F8C23 File Offset: 0x001F6E23
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x06002483 RID: 9347 RVA: 0x001F8C53 File Offset: 0x001F6E53
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x06002484 RID: 9348 RVA: 0x001F8C88 File Offset: 0x001F6E88
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x06002485 RID: 9349 RVA: 0x001F8CD0 File Offset: 0x001F6ED0
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

		// Token: 0x06002486 RID: 9350 RVA: 0x001F8D86 File Offset: 0x001F6F86
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x06002487 RID: 9351 RVA: 0x001F8DA9 File Offset: 0x001F6FA9
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

		// Token: 0x04004C2F RID: 19503
		private static FoodMenu instance;

		// Token: 0x04004C30 RID: 19504
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004C31 RID: 19505
		public Transform menuSelector;

		// Token: 0x04004C32 RID: 19506
		public Transform menuSlotParent;

		// Token: 0x04004C33 RID: 19507
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004C34 RID: 19508
		private List<Transform> menuSlots;

		// Token: 0x04004C35 RID: 19509
		private float menuSelectorTarget;

		// Token: 0x04004C36 RID: 19510
		private float startY;

		// Token: 0x04004C37 RID: 19511
		private float startZ;

		// Token: 0x04004C38 RID: 19512
		private float interpolator;

		// Token: 0x04004C39 RID: 19513
		private int activeIndex;
	}
}
