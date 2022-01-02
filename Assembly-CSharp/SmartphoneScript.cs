using System;
using UnityEngine;

// Token: 0x02000429 RID: 1065
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001CA2 RID: 7330 RVA: 0x00151F9C File Offset: 0x0015019C
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

	// Token: 0x04003366 RID: 13158
	public Transform PhoneCrushingSpot;

	// Token: 0x04003367 RID: 13159
	public GameObject EmptyGameObject;

	// Token: 0x04003368 RID: 13160
	public Texture SmashedTexture;

	// Token: 0x04003369 RID: 13161
	public GameObject PhoneSmash;

	// Token: 0x0400336A RID: 13162
	public Renderer MyRenderer;

	// Token: 0x0400336B RID: 13163
	public PromptScript Prompt;

	// Token: 0x0400336C RID: 13164
	public MeshFilter MyMesh;

	// Token: 0x0400336D RID: 13165
	public Mesh SmashedMesh;
}
