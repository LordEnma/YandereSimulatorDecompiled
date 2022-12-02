using UnityEngine;

namespace MaidDereMinigame
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		public Food food;

		public Meter warmthMeter;

		public float timeToCool = 30f;

		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		private float heat;

		private void Start()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = food.smallSprite;
			heat = timeToCool;
		}

		private void Update()
		{
			heat -= Time.deltaTime;
			warmthMeter.SetFill(heat / timeToCool);
		}

		public void SetHeat(float newHeat)
		{
			heat = newHeat;
		}
	}
}
