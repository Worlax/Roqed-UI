using UnityEngine;
using TMPro;

public class LicenseView : View<LicenseData>
{
	[SerializeField] TMP_Text key;
	[SerializeField] TMP_Text userName;
	[SerializeField] TMP_Text activationDate;
	[SerializeField] TMP_Text expireDate;

	protected override void Init()
	{
		string yearFormat = "d-MMM-yyyy";

		key.text = data.Key;
		userName.text = data.UserName;
		activationDate.text = data.ActivationDate.ToString(yearFormat);
		expireDate.text = data.ActivationDate.AddDays(data.ValidityDays).ToString(yearFormat);
	}
}