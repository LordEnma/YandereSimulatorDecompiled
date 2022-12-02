using UnityEngine;

namespace MaidDereMinigame
{
	public abstract class AIMover : MonoBehaviour
	{
		protected float moveSpeed = 3f;

		public abstract ControlInput GetInput();

		private void FixedUpdate()
		{
			ControlInput input = GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * moveSpeed);
		}
	}
}
