using System;
using UnityEngine;

// Token: 0x02000432 RID: 1074
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001CD7 RID: 7383 RVA: 0x00156E24 File Offset: 0x00155024
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

	// Token: 0x040033F8 RID: 13304
	public Transform PhoneCrushingSpot;

	// Token: 0x040033F9 RID: 13305
	public GameObject EmptyGameObject;

	// Token: 0x040033FA RID: 13306
	public Texture SmashedTexture;

	// Token: 0x040033FB RID: 13307
	public GameObject PhoneSmash;

	// Token: 0x040033FC RID: 13308
	public Renderer MyRenderer;

	// Token: 0x040033FD RID: 13309
	public PromptScript Prompt;

	// Token: 0x040033FE RID: 13310
	public MeshFilter MyMesh;

	// Token: 0x040033FF RID: 13311
	public Mesh SmashedMesh;
}
