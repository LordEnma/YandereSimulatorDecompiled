using System;
using UnityEngine;

// Token: 0x02000433 RID: 1075
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001CDE RID: 7390 RVA: 0x00157144 File Offset: 0x00155344
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

	// Token: 0x040033FB RID: 13307
	public Transform PhoneCrushingSpot;

	// Token: 0x040033FC RID: 13308
	public GameObject EmptyGameObject;

	// Token: 0x040033FD RID: 13309
	public Texture SmashedTexture;

	// Token: 0x040033FE RID: 13310
	public GameObject PhoneSmash;

	// Token: 0x040033FF RID: 13311
	public Renderer MyRenderer;

	// Token: 0x04003400 RID: 13312
	public PromptScript Prompt;

	// Token: 0x04003401 RID: 13313
	public MeshFilter MyMesh;

	// Token: 0x04003402 RID: 13314
	public Mesh SmashedMesh;
}
