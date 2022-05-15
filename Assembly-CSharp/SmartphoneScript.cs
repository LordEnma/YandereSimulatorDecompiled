using System;
using UnityEngine;

// Token: 0x02000435 RID: 1077
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001CEF RID: 7407 RVA: 0x00158A10 File Offset: 0x00156C10
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.Prompt.Yandere.Dragging || this.Prompt.Yandere.Carrying)
			{
				this.Prompt.Yandere.EmptyHands();
			}
			this.Prompt.Yandere.CrushingPhone = true;
			this.Prompt.Yandere.PhoneToCrush = this;
			this.Prompt.Yandere.CanMove = false;
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, base.transform.position, Quaternion.identity);
			this.PhoneCrushingSpot = gameObject.transform;
			this.PhoneCrushingSpot.position = new Vector3(this.PhoneCrushingSpot.position.x, this.Prompt.Yandere.transform.position.y, this.PhoneCrushingSpot.position.z);
			this.PhoneCrushingSpot.LookAt(this.Prompt.Yandere.transform.position);
			this.PhoneCrushingSpot.Translate(Vector3.forward * 0.5f);
		}
	}

	// Token: 0x0400342A RID: 13354
	public Transform PhoneCrushingSpot;

	// Token: 0x0400342B RID: 13355
	public GameObject EmptyGameObject;

	// Token: 0x0400342C RID: 13356
	public Texture SmashedTexture;

	// Token: 0x0400342D RID: 13357
	public GameObject PhoneSmash;

	// Token: 0x0400342E RID: 13358
	public Renderer MyRenderer;

	// Token: 0x0400342F RID: 13359
	public PromptScript Prompt;

	// Token: 0x04003430 RID: 13360
	public MeshFilter MyMesh;

	// Token: 0x04003431 RID: 13361
	public Mesh SmashedMesh;
}
