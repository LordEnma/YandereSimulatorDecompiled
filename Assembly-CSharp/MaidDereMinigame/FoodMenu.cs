using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AC RID: 1452
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x0600249C RID: 9372 RVA: 0x001FB410 File Offset: 0x001F9610
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

		// Token: 0x0600249D RID: 9373 RVA: 0x001FB430 File Offset: 0x001F9630
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x0600249E RID: 9374 RVA: 0x001FB48C File Offset: 0x001F968C
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

		// Token: 0x0600249F RID: 9375 RVA: 0x001FB503 File Offset: 0x001F9703
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x060024A0 RID: 9376 RVA: 0x001FB533 File Offset: 0x001F9733
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x001FB568 File Offset: 0x001F9768
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x060024A2 RID: 9378 RVA: 0x001FB5B0 File Offset: 0x001F97B0
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

		// Token: 0x060024A3 RID: 9379 RVA: 0x001FB666 File Offset: 0x001F9866
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x060024A4 RID: 9380 RVA: 0x001FB689 File Offset: 0x001F9889
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

		// Token: 0x04004C67 RID: 19559
		private static FoodMenu instance;

		// Token: 0x04004C68 RID: 19560
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004C69 RID: 19561
		public Transform menuSelector;

		// Token: 0x04004C6A RID: 19562
		public Transform menuSlotParent;

		// Token: 0x04004C6B RID: 19563
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004C6C RID: 19564
		private List<Transform> menuSlots;

		// Token: 0x04004C6D RID: 19565
		private float menuSelectorTarget;

		// Token: 0x04004C6E RID: 19566
		private float startY;

		// Token: 0x04004C6F RID: 19567
		private float startZ;

		// Token: 0x04004C70 RID: 19568
		private float interpolator;

		// Token: 0x04004C71 RID: 19569
		private int activeIndex;
	}
}
