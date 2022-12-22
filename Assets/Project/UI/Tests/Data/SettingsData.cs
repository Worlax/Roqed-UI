public class SettingsData : Data
{
	// System
	public string[] Languages;
	public string ActiveLanguage;
	public string SavePath;
	public string Email;

	public bool Interactive;
	public bool BetaFeatures;
	public bool OfflineMode;

	// Display
	public string[] Resolutions;
	public string ActiveResolution;
	public string[] GraphicQualitys;
	public string ActiveGraphicQuality;

	public bool ShowFps;

	// Volume
	public float GeneralVolume;
	public float EffectsVolume;
	public float MusicVolume;
	public float VoiceVolume;

	public bool EnableVoice;
}
