using UnityEngine;
using Zenject;

public class MainMenuInjector : MonoInstaller
{
	[SerializeField] ViewFactory viewFactory;
	[SerializeField] WindowFactory windowFactory;
	[SerializeField] CourseLoader courseLoader;

	public override void InstallBindings()
	{
		Container.Bind<CourseLoader>().FromComponentOn(courseLoader.gameObject).AsSingle();

		// Factorys
		Container.Bind<ViewFactory>().FromComponentOn(viewFactory.gameObject).AsSingle();
		Container.Bind<WindowFactory>().FromComponentOn(windowFactory.gameObject).AsSingle();

		// Data
		Container.Bind<DataBase>().FromNew().AsSingle();
		Container.Bind<SettingsData>().FromMethod(FakeDataLoader.GetSettingsData);
		Container.Bind<LicenseData>().FromMethod(FakeDataLoader.GetLicenseData);
		Container.Bind<BugReportData>().FromMethod(FakeDataLoader.GetBugReportData);
	}
}
