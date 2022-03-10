using System;
using System.Globalization;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058D RID: 1421
	public class CharacterHairPlacer : MonoBehaviour
	{
		// Token: 0x06002413 RID: 9235 RVA: 0x001FA014 File Offset: 0x001F8214
		private void Awake()
		{
			int num = UnityEngine.Random.Range(0, this.hairSprites.Length);
			this.hairInstance = new GameObject("Hair", new Type[]
			{
				typeof(SpriteRenderer)
			}).GetComponent<SpriteRenderer>();
			Transform transform = this.hairInstance.transform;
			transform.parent = base.transform;
			transform.localPosition = new Vector3(0f, 0f, -0.1f);
			this.hairInstance.sprite = this.hairSprites[num];
		}

		// Token: 0x06002414 RID: 9236 RVA: 0x001FA09B File Offset: 0x001F829B
		public void WalkPose(float height)
		{
			this.hairInstance.transform.localPosition = new Vector3(0f, height, this.hairInstance.transform.localPosition.z);
		}

		// Token: 0x06002415 RID: 9237 RVA: 0x001FA0D0 File Offset: 0x001F82D0
		public void HairPose(string point)
		{
			string[] array = point.Split(new char[]
			{
				','
			});
			float num;
			bool flag = float.TryParse(array[0], NumberStyles.Float, NumberFormatInfo.InvariantInfo, out num);
			float y;
			bool flag2 = float.TryParse(array[1], NumberStyles.Float, NumberFormatInfo.InvariantInfo, out y);
			if (flag && flag2)
			{
				this.hairInstance.transform.localPosition = new Vector3(this.hairInstance.flipX ? (-num) : num, y, this.hairInstance.transform.localPosition.z);
				return;
			}
			Debug.Log("There was an error while parsing the hair position in CharacterHairPlacer");
		}

		// Token: 0x04004C02 RID: 19458
		public Sprite[] hairSprites;

		// Token: 0x04004C03 RID: 19459
		[HideInInspector]
		public SpriteRenderer hairInstance;
	}
}
