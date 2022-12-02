using System.Globalization;
using UnityEngine;

namespace MaidDereMinigame
{
	public class CharacterHairPlacer : MonoBehaviour
	{
		public Sprite[] hairSprites;

		[HideInInspector]
		public SpriteRenderer hairInstance;

		private void Awake()
		{
			int num = Random.Range(0, hairSprites.Length);
			hairInstance = new GameObject("Hair", typeof(SpriteRenderer)).GetComponent<SpriteRenderer>();
			Transform obj = hairInstance.transform;
			obj.parent = base.transform;
			obj.localPosition = new Vector3(0f, 0f, -0.1f);
			hairInstance.sprite = hairSprites[num];
		}

		public void WalkPose(float height)
		{
			hairInstance.transform.localPosition = new Vector3(0f, height, hairInstance.transform.localPosition.z);
		}

		public void HairPose(string point)
		{
			string[] array = point.Split(',');
			float result;
			bool flag = float.TryParse(array[0], NumberStyles.Float, NumberFormatInfo.InvariantInfo, out result);
			float result2;
			bool flag2 = float.TryParse(array[1], NumberStyles.Float, NumberFormatInfo.InvariantInfo, out result2);
			if (flag && flag2)
			{
				hairInstance.transform.localPosition = new Vector3(hairInstance.flipX ? (0f - result) : result, result2, hairInstance.transform.localPosition.z);
			}
			else
			{
				Debug.Log("There was an error while parsing the hair position in CharacterHairPlacer");
			}
		}
	}
}
