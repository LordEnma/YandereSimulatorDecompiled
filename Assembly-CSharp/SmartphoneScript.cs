using System;
using UnityEngine;

// Token: 0x02000433 RID: 1075
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001CE2 RID: 7394 RVA: 0x00157554 File Offset: 0x00155754
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

	// Token: 0x04003406 RID: 13318
	public Transform PhoneCrushingSpot;

	// Token: 0x04003407 RID: 13319
	public GameObject EmptyGameObject;

	// Token: 0x04003408 RID: 13320
	public Texture SmashedTexture;

	// Token: 0x04003409 RID: 13321
	public GameObject PhoneSmash;

	// Token: 0x0400340A RID: 13322
	public Renderer MyRenderer;

	// Token: 0x0400340B RID: 13323
	public PromptScript Prompt;

	// Token: 0x0400340C RID: 13324
	public MeshFilter MyMesh;

	// Token: 0x0400340D RID: 13325
	public Mesh SmashedMesh;
}
