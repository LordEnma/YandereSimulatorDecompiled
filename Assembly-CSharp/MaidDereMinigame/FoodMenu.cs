using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B2 RID: 1458
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x060024C3 RID: 9411 RVA: 0x001FE930 File Offset: 0x001FCB30
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

		// Token: 0x060024C4 RID: 9412 RVA: 0x001FE950 File Offset: 0x001FCB50
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x060024C5 RID: 9413 RVA: 0x001FE9AC File Offset: 0x001FCBAC
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

		// Token: 0x060024C6 RID: 9414 RVA: 0x001FEA23 File Offset: 0x001FCC23
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x060024C7 RID: 9415 RVA: 0x001FEA53 File Offset: 0x001FCC53
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x060024C8 RID: 9416 RVA: 0x001FEA88 File Offset: 0x001FCC88
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x060024C9 RID: 9417 RVA: 0x001FEAD0 File Offset: 0x001FCCD0
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

		// Token: 0x060024CA RID: 9418 RVA: 0x001FEB86 File Offset: 0x001FCD86
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x060024CB RID: 9419 RVA: 0x001FEBA9 File Offset: 0x001FCDA9
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

		// Token: 0x04004CF3 RID: 19699
		private static FoodMenu instance;

		// Token: 0x04004CF4 RID: 19700
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004CF5 RID: 19701
		public Transform menuSelector;

		// Token: 0x04004CF6 RID: 19702
		public Transform menuSlotParent;

		// Token: 0x04004CF7 RID: 19703
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004CF8 RID: 19704
		private List<Transform> menuSlots;

		// Token: 0x04004CF9 RID: 19705
		private float menuSelectorTarget;

		// Token: 0x04004CFA RID: 19706
		private float startY;

		// Token: 0x04004CFB RID: 19707
		private float startZ;

		// Token: 0x04004CFC RID: 19708
		private float interpolator;

		// Token: 0x04004CFD RID: 19709
		private int activeIndex;
	}
}
