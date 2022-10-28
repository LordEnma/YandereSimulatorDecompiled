// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.FoodMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using MaidDereMinigame.Malee;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
  public class FoodMenu : MonoBehaviour
  {
    private static FoodMenu instance;
    [Reorderable]
    public Foods foodItems;
    public Transform menuSelector;
    public Transform menuSlotParent;
    public float selectorMoveSpeed = 3f;
    private List<Transform> menuSlots;
    private float menuSelectorTarget;
    private float startY;
    private float startZ;
    private float interpolator;
    private int activeIndex;

    public static FoodMenu Instance
    {
      get
      {
        if ((Object) FoodMenu.instance == (Object) null)
          FoodMenu.instance = Object.FindObjectOfType<FoodMenu>();
        return FoodMenu.instance;
      }
    }

    private void Awake()
    {
      this.SetMenuIcons();
      this.menuSelectorTarget = this.menuSlots[0].position.x;
      this.startY = this.menuSelector.position.y;
      this.startZ = this.menuSelector.position.z;
    }

    public void SetMenuIcons()
    {
      this.menuSlots = new List<Transform>();
      for (int index = 0; index < this.menuSlotParent.childCount; ++index)
      {
        Transform child = this.menuSlotParent.GetChild(index);
        this.menuSlots.Add(child);
        if (this.foodItems.Count >= index)
          child.GetChild(0).GetComponent<SpriteRenderer>().sprite = this.foodItems[index].largeSprite;
      }
    }

    public void SetActive(int index)
    {
      this.menuSelectorTarget = this.menuSlots[index].position.x;
      this.interpolator = 0.0f;
      this.activeIndex = index;
    }

    public Food GetActiveFood()
    {
      Food activeFood = Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
      activeFood.name = this.foodItems[this.activeIndex].name;
      return activeFood;
    }

    public Food GetRandomFood()
    {
      int index = Random.Range(0, this.foodItems.Count);
      Food randomFood = Object.Instantiate<Food>(this.foodItems[index]);
      randomFood.name = this.foodItems[index].name;
      return randomFood;
    }

    private void Update()
    {
      if ((double) this.interpolator < 1.0)
      {
        this.menuSelector.position = new Vector3(Mathf.Lerp(this.menuSelector.position.x, this.menuSelectorTarget, this.interpolator), this.startY, this.startZ);
        this.interpolator += Time.deltaTime * this.selectorMoveSpeed;
      }
      else
        this.menuSelector.transform.position = new Vector3(this.menuSelectorTarget, this.startY, this.startZ);
      if (YandereController.rightButton)
      {
        this.IncrementSelection();
      }
      else
      {
        if (!YandereController.leftButton)
          return;
        this.DecrementSelection();
      }
    }

    private void IncrementSelection()
    {
      this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
      SFXController.PlaySound(SFXController.Sounds.MenuSelect);
    }

    private void DecrementSelection()
    {
      if (this.activeIndex == 0)
        this.SetActive(this.menuSlots.Count - 1);
      else
        this.SetActive(this.activeIndex - 1);
      SFXController.PlaySound(SFXController.Sounds.MenuSelect);
    }
  }
}
