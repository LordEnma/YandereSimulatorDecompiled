using System;
using UnityEngine;

// Token: 0x0200042E RID: 1070
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001CC0 RID: 7360 RVA: 0x001553BC File Offset: 0x001535BC
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

	// Token: 0x040033A7 RID: 13223
	public Transform PhoneCrushingSpot;

	// Token: 0x040033A8 RID: 13224
	public GameObject EmptyGameObject;

	// Token: 0x040033A9 RID: 13225
	public Texture SmashedTexture;

	// Token: 0x040033AA RID: 13226
	public GameObject PhoneSmash;

	// Token: 0x040033AB RID: 13227
	public Renderer MyRenderer;

	// Token: 0x040033AC RID: 13228
	public PromptScript Prompt;

	// Token: 0x040033AD RID: 13229
	public MeshFilter MyMesh;

	// Token: 0x040033AE RID: 13230
	public Mesh SmashedMesh;
}
