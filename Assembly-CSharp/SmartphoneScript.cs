using System;
using UnityEngine;

// Token: 0x0200042B RID: 1067
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001CA9 RID: 7337 RVA: 0x001522A0 File Offset: 0x001504A0
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

	// Token: 0x0400336C RID: 13164
	public Transform PhoneCrushingSpot;

	// Token: 0x0400336D RID: 13165
	public GameObject EmptyGameObject;

	// Token: 0x0400336E RID: 13166
	public Texture SmashedTexture;

	// Token: 0x0400336F RID: 13167
	public GameObject PhoneSmash;

	// Token: 0x04003370 RID: 13168
	public Renderer MyRenderer;

	// Token: 0x04003371 RID: 13169
	public PromptScript Prompt;

	// Token: 0x04003372 RID: 13170
	public MeshFilter MyMesh;

	// Token: 0x04003373 RID: 13171
	public Mesh SmashedMesh;
}
