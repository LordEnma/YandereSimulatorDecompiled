using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000527 RID: 1319
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x060021A0 RID: 8608 RVA: 0x001EE8CC File Offset: 0x001ECACC
		public void Awake()
		{
			if (this.MyProfile != null)
			{
				if (this.NameLabel != null)
				{
					this.NameLabel.text = this.MyProfile.FirstName + " " + this.MyProfile.LastName;
				}
				if (this.ProfilPictureTexture != null)
				{
					this.ProfilPictureTexture.mainTexture = this.MyProfile.ProfilePicture;
				}
				base.gameObject.name = this.MyProfile.FirstName + "_Message";
			}
		}

		// Token: 0x040049E4 RID: 18916
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x040049E5 RID: 18917
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x040049E6 RID: 18918
		public UILabel MessageLabel;

		// Token: 0x040049E7 RID: 18919
		public UITexture ProfilPictureTexture;
	}
}
