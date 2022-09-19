// Decompiled with JetBrains decompiler
// Type: MissingPosterManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MissingPosterManagerScript : MonoBehaviour
{
  public GameObject MissingPoster;
  public int RandomID;
  public int ID;

  private void Start()
  {
    for (; this.ID < 101; ++this.ID)
    {
      if (StudentGlobals.GetStudentMissing(this.ID))
      {
        GameObject gameObject = Object.Instantiate<GameObject>(this.MissingPoster, this.transform.position, Quaternion.identity);
        gameObject.transform.parent = this.transform;
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.Range(-15f, 15f));
        WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + this.ID.ToString() + ".png");
        gameObject.GetComponent<MissingPosterScript>().MyRenderer.material.mainTexture = (Texture) www.texture;
        this.RandomID = Random.Range(1, 3);
        gameObject.transform.localPosition = new Vector3((float) (this.ID * 500) - 16300f, Random.Range(1300f, 2000f), 0.0f);
        if ((double) gameObject.transform.localPosition.x > -3700.0)
          gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + 7300f, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        if ((double) gameObject.transform.localPosition.x > 15800.0)
          Object.Destroy((Object) gameObject);
      }
    }
  }
}
