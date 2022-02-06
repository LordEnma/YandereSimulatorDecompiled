using System;
using UnityEngine;

// Token: 0x0200042C RID: 1068
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001CAE RID: 7342 RVA: 0x00154084 File Offset: 0x00152284
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

	// Token: 0x0400337B RID: 13179
	public Transform PhoneCrushingSpot;

	// Token: 0x0400337C RID: 13180
	public GameObject EmptyGameObject;

	// Token: 0x0400337D RID: 13181
	public Texture SmashedTexture;

	// Token: 0x0400337E RID: 13182
	public GameObject PhoneSmash;

	// Token: 0x0400337F RID: 13183
	public Renderer MyRenderer;

	// Token: 0x04003380 RID: 13184
	public PromptScript Prompt;

	// Token: 0x04003381 RID: 13185
	public MeshFilter MyMesh;

	// Token: 0x04003382 RID: 13186
	public Mesh SmashedMesh;
}
