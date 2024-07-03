using UnityEngine;

public class RiggedAccessoryAttacher : MonoBehaviour
{
	public StudentScript Student;

	public GameObject root;

	public GameObject accessory;

	public Material[] accessoryMaterials;

	public Material[] okaMaterials;

	public Material[] cousinMaterials;

	public Material[] ribaruMaterials;

	public Material[] defaultMaterials;

	public Material[] painterMaterials;

	public Material[] painterMaterialsFlipped;

	public GameObject[] Panties;

	public Material[] PantyMaterials;

	public SkinnedMeshRenderer newRenderer;

	public SkinnedMeshRenderer[] newRenderers;

	public Material[] MaterialSet1;

	public Material[] MaterialSet2;

	public Material[] MaterialSet3;

	public Material[] EightiesMaterials;

	public bool UpdateBounds;

	public bool Initialized;

	public bool CookingClub;

	public bool ScienceClub;

	public bool CheckForAlt;

	public bool ArtClub;

	public bool Gentle;

	public int PantyID;

	public int ID;

	public void Start()
	{
		Initialized = true;
		if (PantyID == 99)
		{
			PantyID = PlayerGlobals.PantiesEquipped;
		}
		if (CookingClub)
		{
			if (Student.StudentID == 1)
			{
				accessory = GameObject.Find("TaroApron");
			}
			else if (Student.Male)
			{
				accessory = GameObject.Find("MaleCookingApron");
			}
			else
			{
				accessory = GameObject.Find("FemaleCookingApron");
			}
		}
		else if (ArtClub)
		{
			if (Student.Male)
			{
				accessory = GameObject.Find("PainterApron");
				accessoryMaterials = painterMaterials;
			}
			else
			{
				accessory = GameObject.Find("PainterApronFemale");
				accessoryMaterials = painterMaterials;
			}
		}
		else if (Gentle)
		{
			accessory = GameObject.Find("GentleEyes");
			accessoryMaterials = defaultMaterials;
		}
		else if (ID == 1)
		{
			accessory = GameObject.Find("LabcoatFemale");
		}
		else if (ID == 2)
		{
			accessory = GameObject.Find("LabcoatMale");
		}
		else if (ID == 3)
		{
			accessory = GameObject.Find("BodyBag");
		}
		else if (ID == 4)
		{
			accessory = GameObject.Find("EightiesTeacher");
		}
		else if (ID == 5)
		{
			accessory = GameObject.Find("BowSwimsuit");
		}
		else if (ID == 6)
		{
			accessory = GameObject.Find("SlaveAttire");
		}
		else if (ID == 26)
		{
			accessory = GameObject.Find("OkaBlazer");
			accessoryMaterials = okaMaterials;
		}
		else if (ID == 35)
		{
			accessory = GameObject.Find("CousinOutfit");
			accessoryMaterials = cousinMaterials;
		}
		else if (ID == 100)
		{
			accessory = Panties[PantyID];
			accessoryMaterials[0] = PantyMaterials[PantyID];
		}
		if (CheckForAlt && EightiesMaterials.Length != 0 && GameGlobals.Eighties)
		{
			accessoryMaterials = EightiesMaterials;
		}
		AttachAccessory();
	}

	public void AttachAccessory()
	{
		AddLimb(accessory, root, accessoryMaterials);
		if (ID == 100)
		{
			newRenderer.updateWhenOffscreen = true;
		}
	}

	public void UpdatePanties()
	{
		Object.Destroy(newRenderer);
		Start();
	}

	public void RemoveAccessory()
	{
		if (newRenderer != null)
		{
			newRenderer.enabled = false;
		}
	}

	private void AddLimb(GameObject bonedObj, GameObject rootObj, Material[] bonedObjMaterials)
	{
		SkinnedMeshRenderer[] componentsInChildren = bonedObj.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer thisRenderer in componentsInChildren)
		{
			ProcessBonedObject(thisRenderer, rootObj, bonedObjMaterials);
		}
	}

	private void ProcessBonedObject(SkinnedMeshRenderer thisRenderer, GameObject rootObj, Material[] thisRendererMaterials)
	{
		GameObject gameObject = new GameObject(thisRenderer.gameObject.name);
		gameObject.transform.parent = rootObj.transform;
		gameObject.layer = rootObj.layer;
		gameObject.AddComponent<SkinnedMeshRenderer>();
		newRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
		Transform[] array = new Transform[thisRenderer.bones.Length];
		for (int i = 0; i < thisRenderer.bones.Length; i++)
		{
			array[i] = FindChildByName(thisRenderer.bones[i].name, rootObj.transform);
		}
		newRenderer.bones = array;
		newRenderer.sharedMesh = thisRenderer.sharedMesh;
		if (thisRendererMaterials == null)
		{
			newRenderer.materials = thisRenderer.sharedMaterials;
		}
		else
		{
			newRenderer.materials = thisRendererMaterials;
		}
		if (UpdateBounds)
		{
			newRenderer.updateWhenOffscreen = true;
		}
		if (Student != null)
		{
			newRenderer.gameObject.AddComponent<OutlineScript>();
			if (Student.RiggedAccessoryOutlines.Length != 0)
			{
				Student.RiggedAccessoryOutlines[Student.RiggedAccessoryOutlineID] = newRenderer.gameObject.GetComponent<OutlineScript>();
				Student.RiggedAccessoryOutlines[Student.RiggedAccessoryOutlineID].color = Student.Outlines[0].color;
				Student.RiggedAccessoryOutlines[Student.RiggedAccessoryOutlineID].enabled = Student.Outlines[0].enabled;
			}
			Student.RiggedAccessoryOutlineID++;
			if (Student.Yandere != null && Student.Yandere.PauseScreen != null)
			{
				newRenderer.material.shader = Student.Yandere.PauseScreen.NewSettings.QualityManager.NewHairShader;
			}
		}
	}

	private Transform FindChildByName(string thisName, Transform thisGameObj)
	{
		if (thisGameObj.name == thisName)
		{
			return thisGameObj.transform;
		}
		foreach (Transform item in thisGameObj)
		{
			Transform transform = FindChildByName(thisName, item);
			if ((bool)transform)
			{
				return transform;
			}
		}
		return null;
	}
}
