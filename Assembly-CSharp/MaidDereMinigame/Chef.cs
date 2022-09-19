// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.Chef
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
  [RequireComponent(typeof (Animator))]
  public class Chef : MonoBehaviour
  {
    private static Chef instance;
    [Reorderable]
    public Foods cookQueue;
    public FoodMenu foodMenu;
    public Meter cookMeter;
    public float cookTime = 3f;
    private Chef.ChefState state;
    private Food currentPlate;
    private Animator animator;
    private float timeToFinishDish;
    private bool isPaused;

    public static Chef Instance
    {
      get
      {
        if ((Object) Chef.instance == (Object) null)
          Chef.instance = Object.FindObjectOfType<Chef>();
        return Chef.instance;
      }
    }

    private void Awake()
    {
      this.cookQueue = new Foods();
      this.animator = this.GetComponent<Animator>();
      this.cookMeter.gameObject.SetActive(false);
      this.isPaused = true;
    }

    private void OnEnable() => GameController.PauseGame += new BoolParameterEvent(this.Pause);

    private void OnDisable() => GameController.PauseGame -= new BoolParameterEvent(this.Pause);

    public void Pause(bool toPause)
    {
      this.isPaused = toPause;
      this.animator.speed = this.isPaused ? 0.0f : 1f;
    }

    public static void AddToQueue(Food foodItem) => Chef.Instance.cookQueue.Add(foodItem);

    public static Food GrabFromQueue()
    {
      Food cook = Chef.Instance.cookQueue[0];
      Chef.Instance.cookQueue.RemoveAt(0);
      return cook;
    }

    private void Update()
    {
      if (this.isPaused)
        return;
      switch (this.state)
      {
        case Chef.ChefState.Queueing:
          if (this.cookQueue.Count <= 0)
            break;
          this.currentPlate = Chef.GrabFromQueue();
          this.timeToFinishDish = this.currentPlate.cookTimeMultiplier * this.cookTime;
          this.state = Chef.ChefState.Cooking;
          this.cookMeter.gameObject.SetActive(true);
          break;
        case Chef.ChefState.Cooking:
          if ((double) this.timeToFinishDish <= 0.0)
          {
            this.state = Chef.ChefState.Delivering;
            this.animator.SetTrigger("PlateCooked");
            this.cookMeter.gameObject.SetActive(false);
            break;
          }
          this.timeToFinishDish -= Time.deltaTime;
          this.cookMeter.SetFill((float) (1.0 - (double) this.timeToFinishDish / ((double) this.currentPlate.cookTimeMultiplier * (double) this.cookTime)));
          break;
      }
    }

    public void Deliver() => Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);

    public void Queue() => this.state = Chef.ChefState.Queueing;

    public enum ChefState
    {
      Queueing,
      Cooking,
      Delivering,
    }
  }
}
