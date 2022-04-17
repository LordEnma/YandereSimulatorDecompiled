using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000527 RID: 1319
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x060021A7 RID: 8615 RVA: 0x001EF328 File Offset: 0x001ED528
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

		// Token: 0x040049F6 RID: 18934
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x040049F7 RID: 18935
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x040049F8 RID: 18936
		public UILabel MessageLabel;

		// Token: 0x040049F9 RID: 18937
		public UITexture ProfilPictureTexture;
	}
}
