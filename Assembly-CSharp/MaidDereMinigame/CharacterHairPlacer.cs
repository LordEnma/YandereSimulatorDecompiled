using System;
using System.Globalization;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058A RID: 1418
	public class CharacterHairPlacer : MonoBehaviour
	{
		// Token: 0x060023F8 RID: 9208 RVA: 0x001F808C File Offset: 0x001F628C
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

		// Token: 0x060023F9 RID: 9209 RVA: 0x001F8113 File Offset: 0x001F6313
		public void WalkPose(float height)
		{
			this.hairInstance.transform.localPosition = new Vector3(0f, height, this.hairInstance.transform.localPosition.z);
		}

		// Token: 0x060023FA RID: 9210 RVA: 0x001F8148 File Offset: 0x001F6348
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

		// Token: 0x04004BC3 RID: 19395
		public Sprite[] hairSprites;

		// Token: 0x04004BC4 RID: 19396
		[HideInInspector]
		public SpriteRenderer hairInstance;
	}
}
