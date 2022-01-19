using System;
using UnityEngine;

// Token: 0x0200042C RID: 1068
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001CAB RID: 7339 RVA: 0x001539B4 File Offset: 0x00151BB4
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

	// Token: 0x04003371 RID: 13169
	public Transform PhoneCrushingSpot;

	// Token: 0x04003372 RID: 13170
	public GameObject EmptyGameObject;

	// Token: 0x04003373 RID: 13171
	public Texture SmashedTexture;

	// Token: 0x04003374 RID: 13172
	public GameObject PhoneSmash;

	// Token: 0x04003375 RID: 13173
	public Renderer MyRenderer;

	// Token: 0x04003376 RID: 13174
	public PromptScript Prompt;

	// Token: 0x04003377 RID: 13175
	public MeshFilter MyMesh;

	// Token: 0x04003378 RID: 13176
	public Mesh SmashedMesh;
}
