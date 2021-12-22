using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058F RID: 1423
	public class ServingCounter : MonoBehaviour
	{
		// Token: 0x06002415 RID: 9237 RVA: 0x001F6D3C File Offset: 0x001F4F3C
		private void Awake()
		{
			this.plates = new List<FoodInstance>();
			this.interactionIndicator.gameObject.SetActive(false);
			this.interactionIndicatorStartingPos = this.interactionIndicator.transform.position;
			this.platePositions = new List<Transform>();
			this.kitchenModeHide.gameObject.SetActive(false);
			FoodMenu.Instance.gameObject.SetActive(false);
			for (int i = 0; i < this.maxPlates; i++)
			{
				Transform transform = new GameObject("Position " + i.ToString()).transform;
				transform.parent = base.transform;
				transform.position = new Vector3(this.xPosStart - this.plateSeparation * (float)i, this.yPos, 0f);
				this.platePositions.Add(transform);
			}
		}

		// Token: 0x06002416 RID: 9238 RVA: 0x001F6E12 File Offset: 0x001F5012
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002417 RID: 9239 RVA: 0x001F6E34 File Offset: 0x001F5034
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002418 RID: 9240 RVA: 0x001F6E58 File Offset: 0x001F5058
		private void Update()
		{
			switch (this.state)
			{
			case ServingCounter.KitchenState.None:
				if (this.isPaused)
				{
					return;
				}
				if (this.interactionRange && Input.GetButtonDown("A"))
				{
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					this.selectedIndex = ((this.plates.Count == 0) ? 2 : 0);
					this.kitchenModeHide.gameObject.SetActive(true);
					this.SetMask(this.selectedIndex);
					SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					if (this.plates.Count == 0 && YandereController.Instance.heldItem == null)
					{
						this.interactionIndicator.transform.position = Chef.Instance.transform.position + Vector3.up * 0.8f;
						InteractionMenu.SetAButton(InteractionMenu.AButtonText.PlaceOrder);
						this.state = ServingCounter.KitchenState.Chef;
						FoodMenu.Instance.gameObject.SetActive(true);
					}
					GameController.SetPause(true);
					InteractionMenu.SetBButton(true);
					return;
				}
				break;
			case ServingCounter.KitchenState.SelectingInteraction:
				switch (this.selectedIndex)
				{
				case 0:
					this.interactionIndicator.transform.position = this.interactionIndicatorStartingPos;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.ChoosePlate);
					this.SetMask(this.selectedIndex);
					if (Input.GetButtonDown("A"))
					{
						this.state = ServingCounter.KitchenState.Plates;
						this.selectedIndex = 0;
						InteractionMenu.SetAButton(InteractionMenu.AButtonText.GrabPlate);
						SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					}
					break;
				case 1:
					this.interactionIndicator.transform.position = this.trash.transform.position + Vector3.up * 0.5f;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.TossPlate);
					this.SetMask(this.selectedIndex);
					if (Input.GetButtonDown("A"))
					{
						this.state = ServingCounter.KitchenState.Trash;
						SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					}
					break;
				case 2:
					this.interactionIndicator.transform.position = Chef.Instance.transform.position + Vector3.up * 0.8f;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.PlaceOrder);
					this.SetMask(this.selectedIndex);
					if (Input.GetButtonDown("A"))
					{
						this.state = ServingCounter.KitchenState.Chef;
						InteractionMenu.SetAButton(InteractionMenu.AButtonText.PlaceOrder);
						FoodMenu.Instance.gameObject.SetActive(true);
						SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					}
					break;
				}
				if (Input.GetButtonDown("B"))
				{
					InteractionMenu.SetBButton(false);
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.KitchenMenu);
					this.state = ServingCounter.KitchenState.None;
					GameController.SetPause(false);
					this.kitchenModeHide.gameObject.SetActive(false);
					this.interactionIndicator.transform.position = this.interactionIndicatorStartingPos;
					SFXController.PlaySound(SFXController.Sounds.MenuBack);
				}
				if (YandereController.rightButton)
				{
					this.selectedIndex = (this.selectedIndex + 1) % 3;
					if (this.selectedIndex == 0 && this.plates.Count == 0)
					{
						this.selectedIndex = (this.selectedIndex + 1) % 3;
					}
					if (this.selectedIndex == 1 && YandereController.Instance.heldItem == null)
					{
						this.selectedIndex = (this.selectedIndex + 1) % 3;
					}
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
				}
				if (YandereController.leftButton)
				{
					if (this.selectedIndex == 0)
					{
						this.selectedIndex = 2;
					}
					else
					{
						this.selectedIndex--;
					}
					if (this.selectedIndex == 1 && YandereController.Instance.heldItem == null)
					{
						this.selectedIndex--;
					}
					if (this.selectedIndex == 0 && this.plates.Count == 0)
					{
						this.selectedIndex = 2;
					}
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
					return;
				}
				break;
			case ServingCounter.KitchenState.Plates:
				this.interactionIndicator.gameObject.SetActive(true);
				this.interactionIndicator.transform.position = this.plates[this.selectedIndex].transform.position + Vector3.up * 0.25f;
				this.SetMask(3);
				this.plateMask.transform.position = this.plates[this.selectedIndex].transform.position + Vector3.up * 0.05f;
				if (YandereController.rightButton)
				{
					if (this.selectedIndex == 0)
					{
						this.selectedIndex = this.plates.Count - 1;
					}
					else
					{
						this.selectedIndex--;
					}
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
				}
				else if (YandereController.leftButton)
				{
					this.selectedIndex = (this.selectedIndex + 1) % this.plates.Count;
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
				}
				if (Input.GetButtonDown("A") && YandereController.Instance.heldItem == null)
				{
					YandereController.Instance.PickUpTray(this.plates[this.selectedIndex].food);
					this.RemovePlate(this.selectedIndex);
					this.selectedIndex = 2;
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					SFXController.PlaySound(SFXController.Sounds.MenuOpen);
				}
				if (Input.GetButtonDown("B"))
				{
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					SFXController.PlaySound(SFXController.Sounds.MenuBack);
					return;
				}
				break;
			case ServingCounter.KitchenState.Chef:
				if (Input.GetButtonDown("B"))
				{
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					FoodMenu.Instance.gameObject.SetActive(false);
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					SFXController.PlaySound(SFXController.Sounds.MenuBack);
				}
				if (Input.GetButtonDown("A"))
				{
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					Chef.AddToQueue(FoodMenu.Instance.GetActiveFood());
					FoodMenu.Instance.gameObject.SetActive(false);
					SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					return;
				}
				break;
			case ServingCounter.KitchenState.Trash:
				YandereController.Instance.DropTray();
				this.state = ServingCounter.KitchenState.SelectingInteraction;
				this.selectedIndex = 2;
				break;
			default:
				return;
			}
		}

		// Token: 0x06002419 RID: 9241 RVA: 0x001F73E4 File Offset: 0x001F55E4
		public void SetMask(int position)
		{
			this.counterMask.gameObject.SetActive(position == 0);
			this.trashMask.gameObject.SetActive(position == 1);
			this.chefMask.gameObject.SetActive(position == 2);
			this.plateMask.gameObject.SetActive(position == 3);
		}

		// Token: 0x0600241A RID: 9242 RVA: 0x001F7444 File Offset: 0x001F5644
		public void AddPlate(Food food)
		{
			if (this.plates.Count >= this.maxPlates)
			{
				this.RemovePlate(this.maxPlates - 1);
				this.selectedIndex--;
			}
			for (int i = 0; i < this.plates.Count; i++)
			{
				FoodInstance foodInstance = this.plates[i];
				foodInstance.transform.parent = this.platePositions[i + 1];
				foodInstance.transform.localPosition = Vector3.zero;
			}
			SFXController.PlaySound(SFXController.Sounds.Plate);
			FoodInstance foodInstance2 = UnityEngine.Object.Instantiate<FoodInstance>(this.platePrefab);
			foodInstance2.transform.parent = this.platePositions[0];
			foodInstance2.transform.localPosition = Vector3.zero;
			foodInstance2.food = food;
			this.plates.Insert(0, foodInstance2);
		}

		// Token: 0x0600241B RID: 9243 RVA: 0x001F7518 File Offset: 0x001F5718
		public void RemovePlate(int index)
		{
			Component component = this.plates[index];
			this.plates.RemoveAt(index);
			UnityEngine.Object.Destroy(component.gameObject);
			for (int i = index; i < this.plates.Count; i++)
			{
				FoodInstance foodInstance = this.plates[i];
				foodInstance.transform.parent = this.platePositions[i];
				foodInstance.transform.localPosition = Vector3.zero;
			}
		}

		// Token: 0x0600241C RID: 9244 RVA: 0x001F758F File Offset: 0x001F578F
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x0600241D RID: 9245 RVA: 0x001F7598 File Offset: 0x001F5798
		private void OnTriggerEnter2D(Collider2D collision)
		{
			this.interactionIndicator.gameObject.SetActive(true);
			this.interactionIndicator.transform.position = this.interactionIndicatorStartingPos;
			this.interactionRange = true;
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.KitchenMenu);
		}

		// Token: 0x0600241E RID: 9246 RVA: 0x001F75CE File Offset: 0x001F57CE
		private void OnTriggerExit2D(Collider2D collision)
		{
			this.interactionIndicator.gameObject.SetActive(false);
			this.interactionRange = false;
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
		}

		// Token: 0x04004BC2 RID: 19394
		public FoodInstance platePrefab;

		// Token: 0x04004BC3 RID: 19395
		public GameObject trash;

		// Token: 0x04004BC4 RID: 19396
		public SpriteRenderer interactionIndicator;

		// Token: 0x04004BC5 RID: 19397
		public SpriteRenderer kitchenModeHide;

		// Token: 0x04004BC6 RID: 19398
		public SpriteMask chefMask;

		// Token: 0x04004BC7 RID: 19399
		public SpriteMask trashMask;

		// Token: 0x04004BC8 RID: 19400
		public SpriteMask counterMask;

		// Token: 0x04004BC9 RID: 19401
		public SpriteMask plateMask;

		// Token: 0x04004BCA RID: 19402
		public int maxPlates = 7;

		// Token: 0x04004BCB RID: 19403
		public float plateSeparation = 0.214f;

		// Token: 0x04004BCC RID: 19404
		public float yPos = -1.328f;

		// Token: 0x04004BCD RID: 19405
		public float xPosStart = 2.812f;

		// Token: 0x04004BCE RID: 19406
		private ServingCounter.KitchenState state;

		// Token: 0x04004BCF RID: 19407
		private List<FoodInstance> plates;

		// Token: 0x04004BD0 RID: 19408
		private List<Transform> platePositions;

		// Token: 0x04004BD1 RID: 19409
		private Vector3 interactionIndicatorStartingPos;

		// Token: 0x04004BD2 RID: 19410
		private int selectedIndex;

		// Token: 0x04004BD3 RID: 19411
		private bool interactionRange;

		// Token: 0x04004BD4 RID: 19412
		private bool interacting;

		// Token: 0x04004BD5 RID: 19413
		private bool isPaused;

		// Token: 0x020006D8 RID: 1752
		public enum KitchenState
		{
			// Token: 0x04005187 RID: 20871
			None,
			// Token: 0x04005188 RID: 20872
			SelectingInteraction,
			// Token: 0x04005189 RID: 20873
			Plates,
			// Token: 0x0400518A RID: 20874
			Chef,
			// Token: 0x0400518B RID: 20875
			Trash
		}
	}
}
