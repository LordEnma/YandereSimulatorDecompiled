// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.YandereController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  [RequireComponent(typeof (SpriteRenderer))]
  [RequireComponent(typeof (Animator))]
  public class YandereController : AIMover
  {
    private static YandereController instance;
    public static bool leftButton;
    public static bool rightButton;
    public Transform leftBounds;
    public Transform rightBounds;
    public Transform interactionIndicator;
    public Transform plateTransform;
    public Food heldItem;
    public RuntimeAnimatorController EightiesAnimator;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private AIController aiTarget;
    public bool leftButtonPast;
    public bool rightButtonPast;
    private bool isPaused;
    private bool LastKnownFlip;
    public string LastKnownPoints;

    public static YandereController Instance
    {
      get
      {
        if ((Object) YandereController.instance == (Object) null)
          YandereController.instance = Object.FindObjectOfType<YandereController>();
        return YandereController.instance;
      }
    }

    private void Awake()
    {
      this.spriteRenderer = this.GetComponent<SpriteRenderer>();
      this.animator = this.GetComponent<Animator>();
      this.plateTransform.gameObject.SetActive(false);
      this.moveSpeed = GameController.Instance.activeDifficultyVariables.playerMoveSpeed;
      this.isPaused = true;
      if (!GameGlobals.Eighties)
        return;
      this.animator.runtimeAnimatorController = this.EightiesAnimator;
    }

    private void OnEnable() => GameController.PauseGame += new BoolParameterEvent(this.Pause);

    private void OnDisable() => GameController.PauseGame -= new BoolParameterEvent(this.Pause);

    public void Pause(bool toPause)
    {
      this.isPaused = toPause;
      if (this.isPaused)
        this.animator.SetBool("Moving", false);
      this.animator.speed = this.isPaused ? 0.0f : 1f;
    }

    private void Update()
    {
      YandereController.rightButton = false;
      YandereController.leftButton = false;
      if ((double) Input.GetAxisRaw("Horizontal") > 0.0 || Input.GetKey("right") || (double) Input.GetAxis("DpadX") > 0.5)
      {
        if (!this.rightButtonPast)
        {
          this.rightButtonPast = true;
          YandereController.rightButton = true;
        }
      }
      else if ((double) Input.GetAxisRaw("Horizontal") < 0.0 || Input.GetKey("left") || (double) Input.GetAxis("DpadX") < -0.5)
      {
        if (!this.leftButtonPast)
        {
          this.leftButtonPast = true;
          YandereController.leftButton = true;
        }
      }
      else
      {
        this.leftButtonPast = false;
        this.rightButtonPast = false;
      }
      if ((double) this.transform.position.x < (double) this.leftBounds.position.x)
        this.transform.position = new Vector3(this.leftBounds.position.x, this.transform.position.y, this.transform.position.z);
      if ((double) this.transform.position.x > (double) this.rightBounds.position.x)
        this.transform.position = new Vector3(this.rightBounds.position.x, this.transform.position.y, this.transform.position.z);
      if (Input.GetButtonDown("A") && (Object) this.aiTarget != (Object) null)
      {
        if (this.aiTarget.state == AIController.AIState.Menu)
        {
          this.aiTarget.TakeOrder();
          InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
        }
        else if (this.aiTarget.state == AIController.AIState.Waiting && (Object) this.heldItem != (Object) null)
        {
          this.aiTarget.DeliverFood(this.heldItem);
          SFXController.PlaySound(SFXController.Sounds.Plate);
          InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
          this.DropTray();
        }
      }
      if ((Object) this.aiTarget != (Object) null)
      {
        this.interactionIndicator.gameObject.SetActive(true);
        this.interactionIndicator.position = new Vector3(this.aiTarget.transform.position.x, this.aiTarget.transform.position.y + 0.6f, this.aiTarget.transform.position.z);
      }
      else
        this.interactionIndicator.gameObject.SetActive(false);
    }

    public override ControlInput GetInput()
    {
      if (this.isPaused)
      {
        this.animator.SetBool("Moving", false);
        return new ControlInput();
      }
      float num = 0.0f;
      if (this.rightButtonPast)
        num = 1f;
      else if (this.leftButtonPast)
        num = -1f;
      ControlInput input = new ControlInput();
      input.horizontal = num;
      if ((double) input.horizontal != 0.0)
      {
        if ((double) input.horizontal < 0.0)
          this.spriteRenderer.flipX = true;
        else if ((double) input.horizontal > 0.0)
          this.spriteRenderer.flipX = false;
        if (this.spriteRenderer.flipX != this.LastKnownFlip)
          this.PositionTray(this.LastKnownPoints);
        this.LastKnownFlip = this.spriteRenderer.flipX;
        this.animator.SetBool("Moving", true);
      }
      else
        this.animator.SetBool("Moving", false);
      return input;
    }

    public void PickUpTray(Food plate)
    {
      this.animator.SetTrigger("GetTray");
      this.heldItem = plate;
      this.plateTransform.gameObject.SetActive(false);
      this.plateTransform.GetComponent<SpriteRenderer>().sprite = this.heldItem.smallSprite;
      this.plateTransform.gameObject.SetActive(true);
    }

    public void DropTray()
    {
      this.plateTransform.gameObject.SetActive(false);
      this.animator.SetTrigger(nameof (DropTray));
      this.heldItem = (Food) null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      AIController component = collision.GetComponent<AIController>();
      if (!((Object) component != (Object) null))
        return;
      if (component.state == AIController.AIState.Menu)
      {
        this.aiTarget = component;
        InteractionMenu.SetAButton(InteractionMenu.AButtonText.TakeOrder);
      }
      if (component.state != AIController.AIState.Waiting || !((Object) this.heldItem != (Object) null))
        return;
      this.aiTarget = component;
      InteractionMenu.SetAButton(InteractionMenu.AButtonText.GiveFood);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      AIController component = collision.GetComponent<AIController>();
      if (!((Object) component != (Object) null) || !((Object) component == (Object) this.aiTarget))
        return;
      this.aiTarget = (AIController) null;
      InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
    }

    public void SetPause(bool toPause) => this.isPaused = toPause;

    public void PositionTray(string point)
    {
      string[] strArray = point.Split(',');
      this.LastKnownPoints = point;
      float result1;
      float.TryParse(strArray[0], out result1);
      float result2;
      float.TryParse(strArray[1], out result2);
      this.plateTransform.localPosition = new Vector3(this.spriteRenderer.flipX ? -result1 : result1, result2, 0.0f);
    }
  }
}
