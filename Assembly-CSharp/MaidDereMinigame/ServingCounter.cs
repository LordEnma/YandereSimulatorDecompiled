// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.ServingCounter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
  public class ServingCounter : MonoBehaviour
  {
    public FoodInstance platePrefab;
    public GameObject trash;
    public SpriteRenderer interactionIndicator;
    public SpriteRenderer kitchenModeHide;
    public SpriteMask chefMask;
    public SpriteMask trashMask;
    public SpriteMask counterMask;
    public SpriteMask plateMask;
    public int maxPlates = 7;
    public float plateSeparation = 0.214f;
    public float yPos = -1.328f;
    public float xPosStart = 2.812f;
    private ServingCounter.KitchenState state;
    private List<FoodInstance> plates;
    private List<Transform> platePositions;
    private Vector3 interactionIndicatorStartingPos;
    private int selectedIndex;
    private bool interactionRange;
    private bool interacting;
    private bool isPaused;

    private void Awake()
    {
      this.plates = new List<FoodInstance>();
      this.interactionIndicator.gameObject.SetActive(false);
      this.interactionIndicatorStartingPos = this.interactionIndicator.transform.position;
      this.platePositions = new List<Transform>();
      this.kitchenModeHide.gameObject.SetActive(false);
      FoodMenu.Instance.gameObject.SetActive(false);
      for (int index = 0; index < this.maxPlates; ++index)
      {
        Transform transform = new GameObject("Position " + index.ToString()).transform;
        transform.parent = this.transform;
        transform.position = new Vector3(this.xPosStart - this.plateSeparation * (float) index, this.yPos, 0.0f);
        this.platePositions.Add(transform);
      }
    }

    private void OnEnable() => GameController.PauseGame += new BoolParameterEvent(this.SetPause);

    private void OnDisable() => GameController.PauseGame -= new BoolParameterEvent(this.SetPause);

    private void Update()
    {
      switch (this.state)
      {
        case ServingCounter.KitchenState.None:
          if (this.isPaused || !this.interactionRange || !Input.GetButtonDown("A"))
            break;
          this.state = ServingCounter.KitchenState.SelectingInteraction;
          this.selectedIndex = this.plates.Count == 0 ? 2 : 0;
          this.kitchenModeHide.gameObject.SetActive(true);
          this.SetMask(this.selectedIndex);
          SFXController.PlaySound(SFXController.Sounds.MenuOpen);
          if (this.plates.Count == 0 && (Object) YandereController.Instance.heldItem == (Object) null)
          {
            this.interactionIndicator.transform.position = Chef.Instance.transform.position + Vector3.up * 0.8f;
            InteractionMenu.SetAButton(InteractionMenu.AButtonText.PlaceOrder);
            this.state = ServingCounter.KitchenState.Chef;
            FoodMenu.Instance.gameObject.SetActive(true);
          }
          GameController.SetPause(true);
          InteractionMenu.SetBButton(true);
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
                break;
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
                break;
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
                break;
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
              this.selectedIndex = (this.selectedIndex + 1) % 3;
            if (this.selectedIndex == 1 && (Object) YandereController.Instance.heldItem == (Object) null)
              this.selectedIndex = (this.selectedIndex + 1) % 3;
            SFXController.PlaySound(SFXController.Sounds.MenuSelect);
          }
          if (!YandereController.leftButton)
            break;
          if (this.selectedIndex == 0)
            this.selectedIndex = 2;
          else
            --this.selectedIndex;
          if (this.selectedIndex == 1 && (Object) YandereController.Instance.heldItem == (Object) null)
            --this.selectedIndex;
          if (this.selectedIndex == 0 && this.plates.Count == 0)
            this.selectedIndex = 2;
          SFXController.PlaySound(SFXController.Sounds.MenuSelect);
          break;
        case ServingCounter.KitchenState.Plates:
          this.interactionIndicator.gameObject.SetActive(true);
          this.interactionIndicator.transform.position = this.plates[this.selectedIndex].transform.position + Vector3.up * 0.25f;
          this.SetMask(3);
          this.plateMask.transform.position = this.plates[this.selectedIndex].transform.position + Vector3.up * 0.05f;
          if (YandereController.rightButton)
          {
            if (this.selectedIndex == 0)
              this.selectedIndex = this.plates.Count - 1;
            else
              --this.selectedIndex;
            SFXController.PlaySound(SFXController.Sounds.MenuSelect);
          }
          else if (YandereController.leftButton)
          {
            this.selectedIndex = (this.selectedIndex + 1) % this.plates.Count;
            SFXController.PlaySound(SFXController.Sounds.MenuSelect);
          }
          if (Input.GetButtonDown("A") && (Object) YandereController.Instance.heldItem == (Object) null)
          {
            YandereController.Instance.PickUpTray(this.plates[this.selectedIndex].food);
            this.RemovePlate(this.selectedIndex);
            this.selectedIndex = 2;
            this.state = ServingCounter.KitchenState.SelectingInteraction;
            SFXController.PlaySound(SFXController.Sounds.MenuOpen);
          }
          if (!Input.GetButtonDown("B"))
            break;
          this.state = ServingCounter.KitchenState.SelectingInteraction;
          SFXController.PlaySound(SFXController.Sounds.MenuBack);
          break;
        case ServingCounter.KitchenState.Chef:
          if (Input.GetButtonDown("B"))
          {
            this.state = ServingCounter.KitchenState.SelectingInteraction;
            FoodMenu.Instance.gameObject.SetActive(false);
            this.state = ServingCounter.KitchenState.SelectingInteraction;
            SFXController.PlaySound(SFXController.Sounds.MenuBack);
          }
          if (!Input.GetButtonDown("A"))
            break;
          this.state = ServingCounter.KitchenState.SelectingInteraction;
          Chef.AddToQueue(FoodMenu.Instance.GetActiveFood());
          FoodMenu.Instance.gameObject.SetActive(false);
          SFXController.PlaySound(SFXController.Sounds.MenuOpen);
          break;
        case ServingCounter.KitchenState.Trash:
          YandereController.Instance.DropTray();
          this.state = ServingCounter.KitchenState.SelectingInteraction;
          this.selectedIndex = 2;
          break;
      }
    }

    public void SetMask(int position)
    {
      this.counterMask.gameObject.SetActive(position == 0);
      this.trashMask.gameObject.SetActive(position == 1);
      this.chefMask.gameObject.SetActive(position == 2);
      this.plateMask.gameObject.SetActive(position == 3);
    }

    public void AddPlate(Food food)
    {
      if (this.plates.Count >= this.maxPlates)
      {
        this.RemovePlate(this.maxPlates - 1);
        --this.selectedIndex;
      }
      for (int index = 0; index < this.plates.Count; ++index)
      {
        FoodInstance plate = this.plates[index];
        plate.transform.parent = this.platePositions[index + 1];
        plate.transform.localPosition = Vector3.zero;
      }
      SFXController.PlaySound(SFXController.Sounds.Plate);
      FoodInstance foodInstance = Object.Instantiate<FoodInstance>(this.platePrefab);
      foodInstance.transform.parent = this.platePositions[0];
      foodInstance.transform.localPosition = Vector3.zero;
      foodInstance.food = food;
      this.plates.Insert(0, foodInstance);
    }

    public void RemovePlate(int index)
    {
      FoodInstance plate1 = this.plates[index];
      this.plates.RemoveAt(index);
      Object.Destroy((Object) plate1.gameObject);
      for (int index1 = index; index1 < this.plates.Count; ++index1)
      {
        FoodInstance plate2 = this.plates[index1];
        plate2.transform.parent = this.platePositions[index1];
        plate2.transform.localPosition = Vector3.zero;
      }
    }

    public void SetPause(bool toPause) => this.isPaused = toPause;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      this.interactionIndicator.gameObject.SetActive(true);
      this.interactionIndicator.transform.position = this.interactionIndicatorStartingPos;
      this.interactionRange = true;
      InteractionMenu.SetAButton(InteractionMenu.AButtonText.KitchenMenu);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      this.interactionIndicator.gameObject.SetActive(false);
      this.interactionRange = false;
      InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
    }

    public enum KitchenState
    {
      None,
      SelectingInteraction,
      Plates,
      Chef,
      Trash,
    }
  }
}
