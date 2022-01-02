using System;
using System.Globalization;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000587 RID: 1415
	public class CharacterHairPlacer : MonoBehaviour
	{
		// Token: 0x060023E7 RID: 9191 RVA: 0x001F617C File Offset: 0x001F437C
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

		// Token: 0x060023E8 RID: 9192 RVA: 0x001F6203 File Offset: 0x001F4403
		public void WalkPose(float height)
		{
			this.hairInstance.transform.localPosition = new Vector3(0f, height, this.hairInstance.transform.localPosition.z);
		}

		// Token: 0x060023E9 RID: 9193 RVA: 0x001F6238 File Offset: 0x001F4438
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

		// Token: 0x04004B9D RID: 19357
		public Sprite[] hairSprites;

		// Token: 0x04004B9E RID: 19358
		[HideInInspector]
		public SpriteRenderer hairInstance;
	}
}
