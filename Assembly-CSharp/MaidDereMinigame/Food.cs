using UnityEngine;

namespace MaidDereMinigame
{
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		public Sprite largeSprite;

		public Sprite smallSprite;

		public float cookTimeMultiplier = 1f;
	}
}
