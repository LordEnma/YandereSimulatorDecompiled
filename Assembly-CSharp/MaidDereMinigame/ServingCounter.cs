using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000594 RID: 1428
	public class ServingCounter : MonoBehaviour
	{
		// Token: 0x0600243E RID: 9278 RVA: 0x001FA7EC File Offset: 0x001F89EC
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

		// Token: 0x0600243F RID: 9279 RVA: 0x001FA8C2 File Offset: 0x001F8AC2
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002440 RID: 9280 RVA: 0x001FA8E4 File Offset: 0x001F8AE4
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002441 RID: 9281 RVA: 0x001FA908 File Offset: 0x001F8B08
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

		// Token: 0x06002442 RID: 9282 RVA: 0x001FAE94 File Offset: 0x001F9094
		public void SetMask(int position)
		{
			this.counterMask.gameObject.SetActive(position == 0);
			this.trashMask.gameObject.SetActive(position == 1);
			this.chefMask.gameObject.SetActive(position == 2);
			this.plateMask.gameObject.SetActive(position == 3);
		}

		// Token: 0x06002443 RID: 9283 RVA: 0x001FAEF4 File Offset: 0x001F90F4
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

		// Token: 0x06002444 RID: 9284 RVA: 0x001FAFC8 File Offset: 0x001F91C8
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

		// Token: 0x06002445 RID: 9285 RVA: 0x001FB03F File Offset: 0x001F923F
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002446 RID: 9286 RVA: 0x001FB048 File Offset: 0x001F9248
		private void OnTriggerEnter2D(Collider2D collision)
		{
			this.interactionIndicator.gameObject.SetActive(true);
			this.interactionIndicator.transform.position = this.interactionIndicatorStartingPos;
			this.interactionRange = true;
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.KitchenMenu);
		}

		// Token: 0x06002447 RID: 9287 RVA: 0x001FB07E File Offset: 0x001F927E
		private void OnTriggerExit2D(Collider2D collision)
		{
			this.interactionIndicator.gameObject.SetActive(false);
			this.interactionRange = false;
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
		}

		// Token: 0x04004C13 RID: 19475
		public FoodInstance platePrefab;

		// Token: 0x04004C14 RID: 19476
		public GameObject trash;

		// Token: 0x04004C15 RID: 19477
		public SpriteRenderer interactionIndicator;

		// Token: 0x04004C16 RID: 19478
		public SpriteRenderer kitchenModeHide;

		// Token: 0x04004C17 RID: 19479
		public SpriteMask chefMask;

		// Token: 0x04004C18 RID: 19480
		public SpriteMask trashMask;

		// Token: 0x04004C19 RID: 19481
		public SpriteMask counterMask;

		// Token: 0x04004C1A RID: 19482
		public SpriteMask plateMask;

		// Token: 0x04004C1B RID: 19483
		public int maxPlates = 7;

		// Token: 0x04004C1C RID: 19484
		public float plateSeparation = 0.214f;

		// Token: 0x04004C1D RID: 19485
		public float yPos = -1.328f;

		// Token: 0x04004C1E RID: 19486
		public float xPosStart = 2.812f;

		// Token: 0x04004C1F RID: 19487
		private ServingCounter.KitchenState state;

		// Token: 0x04004C20 RID: 19488
		private List<FoodInstance> plates;

		// Token: 0x04004C21 RID: 19489
		private List<Transform> platePositions;

		// Token: 0x04004C22 RID: 19490
		private Vector3 interactionIndicatorStartingPos;

		// Token: 0x04004C23 RID: 19491
		private int selectedIndex;

		// Token: 0x04004C24 RID: 19492
		private bool interactionRange;

		// Token: 0x04004C25 RID: 19493
		private bool interacting;

		// Token: 0x04004C26 RID: 19494
		private bool isPaused;

		// Token: 0x020006D9 RID: 1753
		public enum KitchenState
		{
			// Token: 0x040051AF RID: 20911
			None,
			// Token: 0x040051B0 RID: 20912
			SelectingInteraction,
			// Token: 0x040051B1 RID: 20913
			Plates,
			// Token: 0x040051B2 RID: 20914
			Chef,
			// Token: 0x040051B3 RID: 20915
			Trash
		}
	}
}
