using System;
using UnityEngine;

// Token: 0x02000435 RID: 1077
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001CF0 RID: 7408 RVA: 0x00158CCC File Offset: 0x00156ECC
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

	// Token: 0x04003432 RID: 13362
	public Transform PhoneCrushingSpot;

	// Token: 0x04003433 RID: 13363
	public GameObject EmptyGameObject;

	// Token: 0x04003434 RID: 13364
	public Texture SmashedTexture;

	// Token: 0x04003435 RID: 13365
	public GameObject PhoneSmash;

	// Token: 0x04003436 RID: 13366
	public Renderer MyRenderer;

	// Token: 0x04003437 RID: 13367
	public PromptScript Prompt;

	// Token: 0x04003438 RID: 13368
	public MeshFilter MyMesh;

	// Token: 0x04003439 RID: 13369
	public Mesh SmashedMesh;
}
