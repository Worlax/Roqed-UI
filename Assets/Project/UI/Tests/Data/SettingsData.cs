public class SettingsData : Data
{
	// System
	public string[] Languages { get; set; }
	public string ActiveLanguage { get; set; }
	public string SavePath { get; set; }
	public string Email { get; set; }

	public bool Interactive { get; set; }
	public bool BetaFeatures { get; set; }
	public bool OfflineMode { get; set; }

	// Display
	public string[] Resolutions { get; set; }
	public string ActiveResolution { get; set; }
	public string[] GraphicQualitys { get; set; }
	public string ActiveGraphicQuality { get; set; }

	public bool ShowFps { get; set; }

	// Volume
	public float GeneralVolume { get; set; }
	public float EffectsVolume { get; set; }
	public float MusicVolume { get; set; }
	public float VoiceVolume { get; set; }

	public bool EnableVoice { get; set; }
}
