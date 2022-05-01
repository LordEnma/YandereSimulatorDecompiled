using System;
using System.Globalization;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000598 RID: 1432
	public class CharacterHairPlacer : MonoBehaviour
	{
		// Token: 0x06002453 RID: 9299 RVA: 0x001FFC04 File Offset: 0x001FDE04
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

		// Token: 0x06002454 RID: 9300 RVA: 0x001FFC8B File Offset: 0x001FDE8B
		public void WalkPose(float height)
		{
			this.hairInstance.transform.localPosition = new Vector3(0f, height, this.hairInstance.transform.localPosition.z);
		}

		// Token: 0x06002455 RID: 9301 RVA: 0x001FFCC0 File Offset: 0x001FDEC0
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

		// Token: 0x04004CBF RID: 19647
		public Sprite[] hairSprites;

		// Token: 0x04004CC0 RID: 19648
		[HideInInspector]
		public SpriteRenderer hairInstance;
	}
}
