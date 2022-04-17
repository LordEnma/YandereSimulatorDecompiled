using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B8 RID: 1464
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x060024E2 RID: 9442 RVA: 0x0020112C File Offset: 0x001FF32C
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

		// Token: 0x060024E3 RID: 9443 RVA: 0x0020114C File Offset: 0x001FF34C
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x060024E4 RID: 9444 RVA: 0x002011A8 File Offset: 0x001FF3A8
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

		// Token: 0x060024E5 RID: 9445 RVA: 0x0020121F File Offset: 0x001FF41F
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x060024E6 RID: 9446 RVA: 0x0020124F File Offset: 0x001FF44F
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x060024E7 RID: 9447 RVA: 0x00201284 File Offset: 0x001FF484
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x060024E8 RID: 9448 RVA: 0x002012CC File Offset: 0x001FF4CC
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

		// Token: 0x060024E9 RID: 9449 RVA: 0x00201382 File Offset: 0x001FF582
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x060024EA RID: 9450 RVA: 0x002013A5 File Offset: 0x001FF5A5
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

		// Token: 0x04004D3B RID: 19771
		private static FoodMenu instance;

		// Token: 0x04004D3C RID: 19772
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004D3D RID: 19773
		public Transform menuSelector;

		// Token: 0x04004D3E RID: 19774
		public Transform menuSlotParent;

		// Token: 0x04004D3F RID: 19775
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004D40 RID: 19776
		private List<Transform> menuSlots;

		// Token: 0x04004D41 RID: 19777
		private float menuSelectorTarget;

		// Token: 0x04004D42 RID: 19778
		private float startY;

		// Token: 0x04004D43 RID: 19779
		private float startZ;

		// Token: 0x04004D44 RID: 19780
		private float interpolator;

		// Token: 0x04004D45 RID: 19781
		private int activeIndex;
	}
}
