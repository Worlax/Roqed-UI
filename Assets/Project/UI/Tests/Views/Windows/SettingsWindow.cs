using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class SettingsWindow : Window<SettingsData>
{
	// System
	[SerializeField] TMP_Dropdown language;
	[SerializeField] TMP_Text savePath;
	[SerializeField] TMP_InputField email;

	[SerializeField] Toggle interactive;
	[SerializeField] Toggle betaFeatures;
	[SerializeField] Toggle offlineMode;

	// Display
	[SerializeField] TMP_Dropdown resolution;
	[SerializeField] TMP_Dropdown graphicQuality;

	[SerializeField] Toggle showFps;

	// Volume
	[SerializeField] Slider generalVolume;
	[SerializeField] Slider effectsVolume;
	[SerializeField] Slider musicVolume;
	[SerializeField] Slider voiceVolume;

	[SerializeField] Toggle enableVoice;

	// Other
	[SerializeField] Transform licenseContent;
	[Inject] ViewFactory viewFactory;

	protected override void Init()
	{
		base.Init();

		// Licenst
		viewFactory.CreateLicense(licenseContent);

		// Settings
		language.AddOptions(Data.Languages.ToList());
		language.value = language.options.FindIndex(x => x.text == Data.ActiveLanguage);

		savePath.text = Data.SavePath;
		email.text = Data.Email;

		interactive.isOn = Data.Interactive;
		betaFeatures.isOn = Data.BetaFeatures;
		offlineMode.isOn = Data.OfflineMode;
	}
}
