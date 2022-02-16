using System;
using UnityEngine;

// Token: 0x0200042D RID: 1069
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001CB5 RID: 7349 RVA: 0x0015438C File Offset: 0x0015258C
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

	// Token: 0x04003381 RID: 13185
	public Transform PhoneCrushingSpot;

	// Token: 0x04003382 RID: 13186
	public GameObject EmptyGameObject;

	// Token: 0x04003383 RID: 13187
	public Texture SmashedTexture;

	// Token: 0x04003384 RID: 13188
	public GameObject PhoneSmash;

	// Token: 0x04003385 RID: 13189
	public Renderer MyRenderer;

	// Token: 0x04003386 RID: 13190
	public PromptScript Prompt;

	// Token: 0x04003387 RID: 13191
	public MeshFilter MyMesh;

	// Token: 0x04003388 RID: 13192
	public Mesh SmashedMesh;
}
