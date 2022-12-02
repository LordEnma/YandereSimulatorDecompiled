using UnityEngine;

namespace MaidDereMinigame
{
	public class Chair : MonoBehaviour
	{
		private static Chairs chairs;

		public bool available = true;

		public static Chairs AllChairs
		{
			get
			{
				if (chairs == null || chairs.Count == 0)
				{
					chairs = new Chairs();
					Chair[] array = Object.FindObjectsOfType<Chair>();
					foreach (Chair item in array)
					{
						chairs.Add(item);
					}
				}
				return chairs;
			}
		}

		public static Chair RandomChair
		{
			get
			{
				Chairs chairs = new Chairs();
				foreach (Chair allChair in AllChairs)
				{
					if (allChair.available)
					{
						chairs.Add(allChair);
					}
				}
				if (chairs.Count > 0)
				{
					int index = Random.Range(0, chairs.Count);
					chairs[index].available = false;
					return chairs[index];
				}
				return null;
			}
		}

		private void OnDestroy()
		{
			chairs = null;
		}
	}
}
