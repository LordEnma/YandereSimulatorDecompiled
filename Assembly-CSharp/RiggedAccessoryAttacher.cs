using System;
using UnityEngine;

// Token: 0x0200001E RID: 30
public class RiggedAccessoryAttacher : MonoBehaviour
{
	// Token: 0x06000078 RID: 120 RVA: 0x0001099C File Offset: 0x0000EB9C
	public void Start()
	{
		this.Initialized = true;
		if (this.PantyID == 99)
		{
			this.PantyID = PlayerGlobals.PantiesEquipped;
		}
		if (this.CookingClub)
		{
			if (this.Student.Male)
			{
				this.accessory = GameObject.Find("MaleCookingApron");
			}
			else
			{
				this.accessory = GameObject.Find("FemaleCookingApron");
			}
		}
		else if (this.ArtClub)
		{
			if (this.Student.Male)
			{
				this.accessory = GameObject.Find("PainterApron");
				this.accessoryMaterials = this.painterMaterials;
			}
			else
			{
				this.accessory = GameObject.Find("PainterApronFemale");
				this.accessoryMaterials = this.painterMaterials;
			}
		}
		else if (this.Gentle)
		{
			this.accessory = GameObject.Find("GentleEyes");
			this.accessoryMaterials = this.defaultMaterials;
		}
		else if (this.ID == 1)
		{
			this.accessory = GameObject.Find("LabcoatFemale");
		}
		else if (this.ID == 2)
		{
			this.accessory = GameObject.Find("LabcoatMale");
		}
		else if (this.ID == 3)
		{
			this.accessory = GameObject.Find("BodyBag");
		}
		else if (this.ID == 4)
		{
			this.accessory = GameObject.Find("EightiesTeacher");
		}
		else if (this.ID == 5)
		{
			this.accessory = GameObject.Find("BowSwimsuit");
		}
		else if (this.ID == 26)
		{
			this.accessory = GameObject.Find("OkaBlazer");
			this.accessoryMaterials = this.okaMaterials;
		}
		else if (this.ID == 35)
		{
			this.accessory = GameObject.Find("CousinOutfit");
			this.accessoryMaterials = this.cousinMaterials;
		}
		else if (this.ID == 100)
		{
			this.accessory = this.Panties[this.PantyID];
			this.accessoryMaterials[0] = this.PantyMaterials[this.PantyID];
		}
		this.AttachAccessory();
	}

	// Token: 0x06000079 RID: 121 RVA: 0x00010BA2 File Offset: 0x0000EDA2
	public void AttachAccessory()
	{
		this.AddLimb(this.accessory, this.root, this.accessoryMaterials);
		if (this.ID == 100)
		{
			this.newRenderer.updateWhenOffscreen = true;
		}
	}

	// Token: 0x0600007A RID: 122 RVA: 0x00010BD2 File Offset: 0x0000EDD2
	public void RemoveAccessory()
	{
		UnityEngine.Object.Destroy(this.newRenderer);
	}

	// Token: 0x0600007B RID: 123 RVA: 0x00010BE0 File Offset: 0x0000EDE0
	private void AddLimb(GameObject bonedObj, GameObject rootObj, Material[] bonedObjMaterials)
	{
		foreach (SkinnedMeshRenderer thisRenderer in bonedObj.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
		{
			this.ProcessBonedObject(thisRenderer, rootObj, bonedObjMaterials);
		}
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00010C14 File Offset: 0x0000EE14
	private void ProcessBonedObject(SkinnedMeshRenderer thisRenderer, GameObject rootObj, Material[] thisRendererMaterials)
	{
		GameObject gameObject = new GameObject(thisRenderer.gameObject.name);
		gameObject.transform.parent = rootObj.transform;
		gameObject.layer = rootObj.layer;
		gameObject.AddComponent<SkinnedMeshRenderer>();
		this.newRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
		Transform[] array = new Transform[thisRenderer.bones.Length];
		for (int i = 0; i < thisRenderer.bones.Length; i++)
		{
			array[i] = this.FindChildByName(thisRenderer.bones[i].name, rootObj.transform);
		}
		this.newRenderer.bones = array;
		this.newRenderer.sharedMesh = thisRenderer.sharedMesh;
		if (thisRendererMaterials == null)
		{
			this.newRenderer.materials = thisRenderer.sharedMaterials;
		}
		else
		{
			this.newRenderer.materials = thisRendererMaterials;
		}
		if (this.UpdateBounds)
		{
			this.newRenderer.updateWhenOffscreen = true;
		}
	}

	// Token: 0x0600007D RID: 125 RVA: 0x00010CF4 File Offset: 0x0000EEF4
	private Transform FindChildByName(string thisName, Transform thisGameObj)
	{
		if (thisGameObj.name == thisName)
		{
			return thisGameObj.transform;
		}
		foreach (object obj in thisGameObj)
		{
			Transform thisGameObj2 = (Transform)obj;
			Transform transform = this.FindChildByName(thisName, thisGameObj2);
			if (transform)
			{
				return transform;
			}
		}
		return null;
	}

	// Token: 0x0400023D RID: 573
	public StudentScript Student;

	// Token: 0x0400023E RID: 574
	public GameObject root;

	// Token: 0x0400023F RID: 575
	public GameObject accessory;

	// Token: 0x04000240 RID: 576
	public Material[] accessoryMaterials;

	// Token: 0x04000241 RID: 577
	public Material[] okaMaterials;

	// Token: 0x04000242 RID: 578
	public Material[] cousinMaterials;

	// Token: 0x04000243 RID: 579
	public Material[] ribaruMaterials;

	// Token: 0x04000244 RID: 580
	public Material[] defaultMaterials;

	// Token: 0x04000245 RID: 581
	public Material[] painterMaterials;

	// Token: 0x04000246 RID: 582
	public Material[] painterMaterialsFlipped;

	// Token: 0x04000247 RID: 583
	public GameObject[] Panties;

	// Token: 0x04000248 RID: 584
	public Material[] PantyMaterials;

	// Token: 0x04000249 RID: 585
	public SkinnedMeshRenderer newRenderer;

	// Token: 0x0400024A RID: 586
	public bool UpdateBounds;

	// Token: 0x0400024B RID: 587
	public bool Initialized;

	// Token: 0x0400024C RID: 588
	public bool CookingClub;

	// Token: 0x0400024D RID: 589
	public bool ScienceClub;

	// Token: 0x0400024E RID: 590
	public bool ArtClub;

	// Token: 0x0400024F RID: 591
	public bool Gentle;

	// Token: 0x04000250 RID: 592
	public int PantyID;

	// Token: 0x04000251 RID: 593
	public int ID;
}
