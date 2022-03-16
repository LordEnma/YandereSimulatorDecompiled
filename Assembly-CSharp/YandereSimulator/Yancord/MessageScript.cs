using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000521 RID: 1313
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x06002188 RID: 8584 RVA: 0x001ECB2C File Offset: 0x001EAD2C
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

		// Token: 0x040049AE RID: 18862
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x040049AF RID: 18863
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x040049B0 RID: 18864
		public UILabel MessageLabel;

		// Token: 0x040049B1 RID: 18865
		public UITexture ProfilPictureTexture;
	}
}
