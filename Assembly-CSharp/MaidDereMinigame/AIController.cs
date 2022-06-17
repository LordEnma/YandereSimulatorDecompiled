// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.AIController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  [RequireComponent(typeof (Animator))]
  [RequireComponent(typeof (SpriteRenderer))]
  [RequireComponent(typeof (Collider2D))]
  public class AIController : AIMover
  {
    public GameObject throbObject;
    public Meter happinessMeter;
    public Bubble speechBubble;
    public float distanceThreshold = 0.5f;
    private Food desiredFood;
    private Collider2D collider2d;
    private Chair targetChair;
    [HideInInspector]
    public Transform leaveTarget;
    [HideInInspector]
    public AIController.AIState state;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float patienceDegradation = 2f;
    private float timeToOrder = 0.5f;
    private float timeToEat;
    private float happiness = 50f;
    private float orderTime;
    private float eatTime;
    private int normalSortingLayer;
    private bool isPaused;
    public bool Male;

    public void Init()
    {
      this.animator = this.GetComponent<Animator>();
      this.spriteRenderer = this.GetComponent<SpriteRenderer>();
      this.throbObject.SetActive(false);
      this.targetChair = Chair.RandomChair;
      this.collider2d = this.GetComponent<Collider2D>();
      this.collider2d.enabled = false;
      if ((Object) this.targetChair == (Object) null)
        Object.Destroy((Object) this.gameObject);
      this.happinessMeter.gameObject.SetActive(false);
      this.speechBubble.gameObject.SetActive(false);
    }

    private void Start()
    {
      this.leaveTarget.GetComponent<CustomerSpawner>().OpenDoor();
      this.moveSpeed = GameController.Instance.activeDifficultyVariables.customerMoveSpeed;
      this.timeToOrder = GameController.Instance.activeDifficultyVariables.timeSpentOrdering;
      this.eatTime = GameController.Instance.activeDifficultyVariables.timeSpentEatingFood;
      this.patienceDegradation = GameController.Instance.activeDifficultyVariables.customerPatienceDegradation;
      this.timeToEat = GameController.Instance.activeDifficultyVariables.timeSpentEatingFood;
      SFXController.PlaySound(SFXController.Sounds.DoorBell);
    }

    private void OnEnable() => GameController.PauseGame += new BoolParameterEvent(this.Pause);

    private void OnDisable() => GameController.PauseGame -= new BoolParameterEvent(this.Pause);

    public void Pause(bool toPause)
    {
      this.isPaused = toPause;
      this.GetComponent<Animator>().speed = this.isPaused ? 0.0f : 1f;
    }

    private void Update()
    {
      if (this.isPaused)
        return;
      switch (this.state)
      {
        case AIController.AIState.Entering:
          if ((double) Mathf.Abs(this.transform.position.x - this.targetChair.transform.position.x) > (double) this.distanceThreshold)
            break;
          this.SitDown();
          this.happiness = 100f;
          this.happinessMeter.SetFill(this.happiness / 100f);
          this.state = AIController.AIState.Menu;
          break;
        case AIController.AIState.Menu:
          if ((double) this.happiness <= 0.0)
          {
            this.StandUp();
            this.state = AIController.AIState.Leaving;
            GameController.AddAngryCustomer();
            break;
          }
          this.ReduceHappiness();
          break;
        case AIController.AIState.Ordering:
          if ((double) this.orderTime <= 0.0)
          {
            this.state = AIController.AIState.Waiting;
            this.speechBubble.GetComponent<Animator>().SetTrigger("BubbleDrop");
            this.animator.SetTrigger("DoneOrdering");
            break;
          }
          this.orderTime -= Time.deltaTime;
          break;
        case AIController.AIState.Waiting:
          if ((double) this.happiness <= 0.0)
          {
            this.StandUp();
            this.state = AIController.AIState.Leaving;
            GameController.AddAngryCustomer();
            break;
          }
          this.ReduceHappiness();
          break;
        case AIController.AIState.Eating:
          if ((double) this.eatTime <= 0.0)
          {
            this.StandUp();
            this.state = AIController.AIState.Leaving;
            break;
          }
          this.eatTime -= Time.deltaTime;
          break;
        case AIController.AIState.Leaving:
          if ((double) Mathf.Abs(this.transform.position.x - this.leaveTarget.position.x) > (double) this.distanceThreshold)
            break;
          Object.Destroy((Object) this.gameObject);
          this.leaveTarget.GetComponent<CustomerSpawner>().OpenDoor();
          break;
      }
    }

    public override ControlInput GetInput()
    {
      ControlInput input = new ControlInput();
      if (this.isPaused)
        return input;
      switch (this.state)
      {
        case AIController.AIState.Entering:
          if ((double) this.targetChair.transform.position.x > (double) this.transform.position.x)
          {
            input.horizontal = 1f;
            this.SetFlip(false);
            break;
          }
          input.horizontal = -1f;
          this.SetFlip(true);
          break;
        case AIController.AIState.Leaving:
          if ((double) this.leaveTarget.position.x > (double) this.transform.position.x)
          {
            input.horizontal = 1f;
            this.SetFlip(false);
            break;
          }
          input.horizontal = -1f;
          this.SetFlip(true);
          break;
      }
      return input;
    }

    public void TakeOrder()
    {
      this.state = AIController.AIState.Ordering;
      this.happiness = 100f;
      this.happinessMeter.SetFill(this.happiness / 100f);
      this.orderTime = this.timeToOrder;
      this.animator.SetTrigger("OrderTaken");
      this.animator.SetFloat("Happiness", this.happiness);
      this.desiredFood = FoodMenu.Instance.GetRandomFood();
      this.speechBubble.gameObject.SetActive(true);
      this.speechBubble.food = this.desiredFood;
      if (this.Male)
        SFXController.PlaySound(SFXController.Sounds.MaleCustomerGreet);
      else
        SFXController.PlaySound(SFXController.Sounds.FemaleCustomerGreet);
    }

    public void DeliverFood(Food deliveredFood)
    {
      if (deliveredFood.name == this.desiredFood.name)
      {
        this.state = AIController.AIState.Eating;
        this.animator.SetTrigger("ServedFood");
        this.eatTime = this.timeToEat;
        GameController.AddTip(GameController.Instance.activeDifficultyVariables.baseTip * this.happiness);
        if ((double) this.happiness <= 50.0)
        {
          this.happiness = 50f;
          this.animator.SetFloat("Happiness", this.happiness);
        }
        if (this.Male)
          SFXController.PlaySound(SFXController.Sounds.MaleCustomerThank);
        else
          SFXController.PlaySound(SFXController.Sounds.FemaleCustomerThank);
      }
      else
      {
        this.state = AIController.AIState.Leaving;
        this.happiness = 0.0f;
        this.animator.SetFloat("Happiness", this.happiness);
        GameController.AddAngryCustomer();
        this.StandUp();
        if (this.Male)
          SFXController.PlaySound(SFXController.Sounds.MaleCustomerLeave);
        else
          SFXController.PlaySound(SFXController.Sounds.FemaleCustomerLeave);
      }
      this.happinessMeter.gameObject.SetActive(false);
    }

    private void SitDown()
    {
      this.transform.position = new Vector3(this.targetChair.transform.position.x, this.transform.position.y, this.transform.position.z);
      this.animator.SetTrigger(nameof (SitDown));
      this.SetFlip((double) this.targetChair.transform.localScale.x <= 0.0);
      this.SetSortingLayer(true);
      this.collider2d.enabled = true;
      this.happinessMeter.gameObject.SetActive(true);
    }

    private void StandUp()
    {
      this.animator.SetTrigger(nameof (StandUp));
      this.SetSortingLayer(false);
      this.targetChair.available = true;
      this.collider2d.enabled = false;
      this.happinessMeter.gameObject.SetActive(false);
    }

    private void ReduceHappiness()
    {
      this.happiness -= Time.deltaTime * this.patienceDegradation;
      this.animator.SetFloat("Happiness", this.happiness);
      this.happinessMeter.SetFill(this.happiness / 100f);
    }

    private void SetFlip(bool flip)
    {
      this.spriteRenderer.flipX = flip;
      this.GetComponentInChildren<CharacterHairPlacer>().hairInstance.flipX = flip;
    }

    public void SetSortingLayer(bool back)
    {
      this.spriteRenderer.sortingLayerName = back ? "CustomerSitting" : "Default";
      this.GetComponent<CharacterHairPlacer>().hairInstance.sortingLayerName = back ? "CustomerSitting" : "Default";
      this.throbObject.GetComponent<SpriteRenderer>().sortingLayerName = back ? "CustomerSitting" : "Default";
    }

    public enum AIState
    {
      Entering,
      Menu,
      Ordering,
      Waiting,
      Eating,
      Leaving,
    }
  }
}
