// Decompiled with JetBrains decompiler
// Type: RiggedAccessoryAttacher
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
  public bool UpdateBounds;
  public bool Initialized;
  public bool CookingClub;
  public bool ScienceClub;
  public bool ArtClub;
  public bool Gentle;
  public int PantyID;
  public int ID;

  public void Start()
  {
    this.Initialized = true;
    if (this.PantyID == 99)
      this.PantyID = PlayerGlobals.PantiesEquipped;
    if (this.CookingClub)
      this.accessory = !this.Student.Male ? GameObject.Find("FemaleCookingApron") : GameObject.Find("MaleCookingApron");
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
      this.accessory = GameObject.Find("LabcoatFemale");
    else if (this.ID == 2)
      this.accessory = GameObject.Find("LabcoatMale");
    else if (this.ID == 3)
      this.accessory = GameObject.Find("BodyBag");
    else if (this.ID == 4)
      this.accessory = GameObject.Find("EightiesTeacher");
    else if (this.ID == 5)
      this.accessory = GameObject.Find("BowSwimsuit");
    else if (this.ID == 6)
      this.accessory = GameObject.Find("SlaveAttire");
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

  public void AttachAccessory()
  {
    this.AddLimb(this.accessory, this.root, this.accessoryMaterials);
    if (this.ID != 100)
      return;
    this.newRenderer.updateWhenOffscreen = true;
  }

  public void RemoveAccessory() => Object.Destroy((Object) this.newRenderer);

  private void AddLimb(GameObject bonedObj, GameObject rootObj, Material[] bonedObjMaterials)
  {
    foreach (SkinnedMeshRenderer componentsInChild in bonedObj.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
      this.ProcessBonedObject(componentsInChild, rootObj, bonedObjMaterials);
  }

  private void ProcessBonedObject(
    SkinnedMeshRenderer thisRenderer,
    GameObject rootObj,
    Material[] thisRendererMaterials)
  {
    GameObject gameObject = new GameObject(thisRenderer.gameObject.name);
    gameObject.transform.parent = rootObj.transform;
    gameObject.layer = rootObj.layer;
    gameObject.AddComponent<SkinnedMeshRenderer>();
    this.newRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
    Transform[] transformArray = new Transform[thisRenderer.bones.Length];
    for (int index = 0; index < thisRenderer.bones.Length; ++index)
      transformArray[index] = this.FindChildByName(thisRenderer.bones[index].name, rootObj.transform);
    this.newRenderer.bones = transformArray;
    this.newRenderer.sharedMesh = thisRenderer.sharedMesh;
    if (thisRendererMaterials == null)
      this.newRenderer.materials = thisRenderer.sharedMaterials;
    else
      this.newRenderer.materials = thisRendererMaterials;
    if (this.UpdateBounds)
      this.newRenderer.updateWhenOffscreen = true;
    if (!((Object) this.Student != (Object) null))
      return;
    this.newRenderer.gameObject.AddComponent<OutlineScript>();
    this.Student.RiggedAccessoryOutlines[this.Student.RiggedAccessoryOutlineID] = this.newRenderer.gameObject.GetComponent<OutlineScript>();
    this.Student.RiggedAccessoryOutlines[this.Student.RiggedAccessoryOutlineID].color = this.Student.Outlines[0].color;
    this.Student.RiggedAccessoryOutlines[this.Student.RiggedAccessoryOutlineID].enabled = this.Student.Outlines[0].enabled;
    ++this.Student.RiggedAccessoryOutlineID;
  }

  private Transform FindChildByName(string thisName, Transform thisGameObj)
  {
    if (thisGameObj.name == thisName)
      return thisGameObj.transform;
    foreach (Transform thisGameObj1 in thisGameObj)
    {
      Transform childByName = this.FindChildByName(thisName, thisGameObj1);
      if ((bool) (Object) childByName)
        return childByName;
    }
    return (Transform) null;
  }
}
