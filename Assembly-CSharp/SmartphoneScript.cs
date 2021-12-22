using System;
using UnityEngine;

// Token: 0x02000429 RID: 1065
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001CA0 RID: 7328 RVA: 0x00151B90 File Offset: 0x0014FD90
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

	// Token: 0x0400335F RID: 13151
	public Transform PhoneCrushingSpot;

	// Token: 0x04003360 RID: 13152
	public GameObject EmptyGameObject;

	// Token: 0x04003361 RID: 13153
	public Texture SmashedTexture;

	// Token: 0x04003362 RID: 13154
	public GameObject PhoneSmash;

	// Token: 0x04003363 RID: 13155
	public Renderer MyRenderer;

	// Token: 0x04003364 RID: 13156
	public PromptScript Prompt;

	// Token: 0x04003365 RID: 13157
	public MeshFilter MyMesh;

	// Token: 0x04003366 RID: 13158
	public Mesh SmashedMesh;
}
