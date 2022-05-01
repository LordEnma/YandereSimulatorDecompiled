using System;
using UnityEngine;

// Token: 0x02000434 RID: 1076
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001CE9 RID: 7401 RVA: 0x00157D90 File Offset: 0x00155F90
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

	// Token: 0x04003415 RID: 13333
	public Transform PhoneCrushingSpot;

	// Token: 0x04003416 RID: 13334
	public GameObject EmptyGameObject;

	// Token: 0x04003417 RID: 13335
	public Texture SmashedTexture;

	// Token: 0x04003418 RID: 13336
	public GameObject PhoneSmash;

	// Token: 0x04003419 RID: 13337
	public Renderer MyRenderer;

	// Token: 0x0400341A RID: 13338
	public PromptScript Prompt;

	// Token: 0x0400341B RID: 13339
	public MeshFilter MyMesh;

	// Token: 0x0400341C RID: 13340
	public Mesh SmashedMesh;
}
