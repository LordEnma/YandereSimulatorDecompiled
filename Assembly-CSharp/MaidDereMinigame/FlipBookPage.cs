using UnityEngine;

namespace MaidDereMinigame
{
	public class FlipBookPage : MonoBehaviour
	{
		[HideInInspector]
		public Animator animator;

		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		public GameObject objectToActivate;

		private void Awake()
		{
			animator = GetComponent<Animator>();
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		public void Transition(bool toOpen)
		{
			animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (objectToActivate != null)
			{
				objectToActivate.SetActive(false);
			}
		}

		public void SwitchSort()
		{
			spriteRenderer.sortingOrder = 10 - spriteRenderer.sortingOrder;
		}

		public void ObjectActive(bool toActive = true)
		{
			if (objectToActivate != null)
			{
				objectToActivate.SetActive(toActive);
			}
		}
	}
}
