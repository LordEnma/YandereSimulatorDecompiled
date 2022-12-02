using System;
using UnityEngine;

namespace MaidDereMinigame
{
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(Animator))]
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
				if (instance == null)
				{
					instance = UnityEngine.Object.FindObjectOfType<YandereController>();
				}
				return instance;
			}
		}

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
			animator = GetComponent<Animator>();
			plateTransform.gameObject.SetActive(false);
			moveSpeed = GameController.Instance.activeDifficultyVariables.playerMoveSpeed;
			isPaused = true;
			if (GameGlobals.Eighties)
			{
				animator.runtimeAnimatorController = EightiesAnimator;
			}
		}

		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(Pause));
		}

		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(Pause));
		}

		public void Pause(bool toPause)
		{
			isPaused = toPause;
			if (isPaused)
			{
				animator.SetBool("Moving", false);
			}
			animator.speed = ((!isPaused) ? 1 : 0);
		}

		private void Update()
		{
			rightButton = false;
			leftButton = false;
			if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetKey("right") || Input.GetAxis("DpadX") > 0.5f)
			{
				if (!rightButtonPast)
				{
					rightButtonPast = true;
					rightButton = true;
				}
			}
			else if (Input.GetAxisRaw("Horizontal") < 0f || Input.GetKey("left") || Input.GetAxis("DpadX") < -0.5f)
			{
				if (!leftButtonPast)
				{
					leftButtonPast = true;
					leftButton = true;
				}
			}
			else
			{
				leftButtonPast = false;
				rightButtonPast = false;
			}
			if (base.transform.position.x < leftBounds.position.x)
			{
				base.transform.position = new Vector3(leftBounds.position.x, base.transform.position.y, base.transform.position.z);
			}
			if (base.transform.position.x > rightBounds.position.x)
			{
				base.transform.position = new Vector3(rightBounds.position.x, base.transform.position.y, base.transform.position.z);
			}
			if (Input.GetButtonDown("A") && aiTarget != null)
			{
				if (aiTarget.state == AIController.AIState.Menu)
				{
					aiTarget.TakeOrder();
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
				}
				else if (aiTarget.state == AIController.AIState.Waiting && heldItem != null)
				{
					aiTarget.DeliverFood(heldItem);
					SFXController.PlaySound(SFXController.Sounds.Plate);
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
					DropTray();
				}
			}
			if (aiTarget != null)
			{
				interactionIndicator.gameObject.SetActive(true);
				interactionIndicator.position = new Vector3(aiTarget.transform.position.x, aiTarget.transform.position.y + 0.6f, aiTarget.transform.position.z);
			}
			else
			{
				interactionIndicator.gameObject.SetActive(false);
			}
		}

		public override ControlInput GetInput()
		{
			if (isPaused)
			{
				animator.SetBool("Moving", false);
				return default(ControlInput);
			}
			float horizontal = 0f;
			if (rightButtonPast)
			{
				horizontal = 1f;
			}
			else if (leftButtonPast)
			{
				horizontal = -1f;
			}
			ControlInput result = default(ControlInput);
			result.horizontal = horizontal;
			if (result.horizontal != 0f)
			{
				if (result.horizontal < 0f)
				{
					spriteRenderer.flipX = true;
				}
				else if (result.horizontal > 0f)
				{
					spriteRenderer.flipX = false;
				}
				if (spriteRenderer.flipX != LastKnownFlip)
				{
					PositionTray(LastKnownPoints);
				}
				LastKnownFlip = spriteRenderer.flipX;
				animator.SetBool("Moving", true);
			}
			else
			{
				animator.SetBool("Moving", false);
			}
			return result;
		}

		public void PickUpTray(Food plate)
		{
			animator.SetTrigger("GetTray");
			heldItem = plate;
			plateTransform.gameObject.SetActive(false);
			plateTransform.GetComponent<SpriteRenderer>().sprite = heldItem.smallSprite;
			plateTransform.gameObject.SetActive(true);
		}

		public void DropTray()
		{
			plateTransform.gameObject.SetActive(false);
			animator.SetTrigger("DropTray");
			heldItem = null;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			AIController component = collision.GetComponent<AIController>();
			if (component != null)
			{
				if (component.state == AIController.AIState.Menu)
				{
					aiTarget = component;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.TakeOrder);
				}
				if (component.state == AIController.AIState.Waiting && heldItem != null)
				{
					aiTarget = component;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.GiveFood);
				}
			}
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			AIController component = collision.GetComponent<AIController>();
			if (component != null && component == aiTarget)
			{
				aiTarget = null;
				InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			}
		}

		public void SetPause(bool toPause)
		{
			isPaused = toPause;
		}

		public void PositionTray(string point)
		{
			string[] array = point.Split(',');
			LastKnownPoints = point;
			float result;
			float.TryParse(array[0], out result);
			float result2;
			float.TryParse(array[1], out result2);
			plateTransform.localPosition = new Vector3(spriteRenderer.flipX ? (0f - result) : result, result2, 0f);
		}
	}
}
