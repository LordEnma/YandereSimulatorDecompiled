using System;
using UnityEngine;

// Token: 0x0200042E RID: 1070
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001CBE RID: 7358 RVA: 0x00154E38 File Offset: 0x00153038
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

	// Token: 0x04003391 RID: 13201
	public Transform PhoneCrushingSpot;

	// Token: 0x04003392 RID: 13202
	public GameObject EmptyGameObject;

	// Token: 0x04003393 RID: 13203
	public Texture SmashedTexture;

	// Token: 0x04003394 RID: 13204
	public GameObject PhoneSmash;

	// Token: 0x04003395 RID: 13205
	public Renderer MyRenderer;

	// Token: 0x04003396 RID: 13206
	public PromptScript Prompt;

	// Token: 0x04003397 RID: 13207
	public MeshFilter MyMesh;

	// Token: 0x04003398 RID: 13208
	public Mesh SmashedMesh;
}
