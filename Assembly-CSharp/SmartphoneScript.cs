using System;
using UnityEngine;

// Token: 0x0200042F RID: 1071
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001CCD RID: 7373 RVA: 0x001562C8 File Offset: 0x001544C8
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

	// Token: 0x040033DC RID: 13276
	public Transform PhoneCrushingSpot;

	// Token: 0x040033DD RID: 13277
	public GameObject EmptyGameObject;

	// Token: 0x040033DE RID: 13278
	public Texture SmashedTexture;

	// Token: 0x040033DF RID: 13279
	public GameObject PhoneSmash;

	// Token: 0x040033E0 RID: 13280
	public Renderer MyRenderer;

	// Token: 0x040033E1 RID: 13281
	public PromptScript Prompt;

	// Token: 0x040033E2 RID: 13282
	public MeshFilter MyMesh;

	// Token: 0x040033E3 RID: 13283
	public Mesh SmashedMesh;
}
