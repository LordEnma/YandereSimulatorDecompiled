// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Cameras.AbstractTargetFollower
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Cameras
{
  public abstract class AbstractTargetFollower : MonoBehaviour
  {
    [SerializeField]
    protected Transform m_Target;
    [SerializeField]
    private bool m_AutoTargetPlayer = true;
    [SerializeField]
    private AbstractTargetFollower.UpdateType m_UpdateType;
    protected Rigidbody targetRigidbody;

    protected virtual void Start()
    {
      if (this.m_AutoTargetPlayer)
        this.FindAndTargetPlayer();
      if ((Object) this.m_Target == (Object) null)
        return;
      this.targetRigidbody = this.m_Target.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
      if (this.m_AutoTargetPlayer && ((Object) this.m_Target == (Object) null || !this.m_Target.gameObject.activeSelf))
        this.FindAndTargetPlayer();
      if (this.m_UpdateType != AbstractTargetFollower.UpdateType.FixedUpdate)
        return;
      this.FollowTarget(Time.deltaTime);
    }

    private void LateUpdate()
    {
      if (this.m_AutoTargetPlayer && ((Object) this.m_Target == (Object) null || !this.m_Target.gameObject.activeSelf))
        this.FindAndTargetPlayer();
      if (this.m_UpdateType != AbstractTargetFollower.UpdateType.LateUpdate)
        return;
      this.FollowTarget(Time.deltaTime);
    }

    public void ManualUpdate()
    {
      if (this.m_AutoTargetPlayer && ((Object) this.m_Target == (Object) null || !this.m_Target.gameObject.activeSelf))
        this.FindAndTargetPlayer();
      if (this.m_UpdateType != AbstractTargetFollower.UpdateType.ManualUpdate)
        return;
      this.FollowTarget(Time.deltaTime);
    }

    protected abstract void FollowTarget(float deltaTime);

    public void FindAndTargetPlayer()
    {
      GameObject gameObjectWithTag = GameObject.FindGameObjectWithTag("Player");
      if (!(bool) (Object) gameObjectWithTag)
        return;
      this.SetTarget(gameObjectWithTag.transform);
    }

    public virtual void SetTarget(Transform newTransform) => this.m_Target = newTransform;

    public Transform Target => this.m_Target;

    public enum UpdateType
    {
      FixedUpdate,
      LateUpdate,
      ManualUpdate,
    }
  }
}
