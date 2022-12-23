//using UnityEngine;

//public class hehe { }
//public class hoho : hehe { }

//public class Lada : ICar<hoho> { }
//public class CoolerClass : BaseClass { }

//public interface ICar<out T> where T : hehe
//{
//	T GetData();
//}

//public class ActionClass
//{
//	void DoAction()
//	{
//		ICar<hoho> car = new Lada();
//		ICar<hehe> car2 = new Lada();



//		BaseClass<hoho> cast1 = coolerClass; // this is fine
//		BaseClass<lel> cast2 = coolerClass; // this is not?
//	}
//}