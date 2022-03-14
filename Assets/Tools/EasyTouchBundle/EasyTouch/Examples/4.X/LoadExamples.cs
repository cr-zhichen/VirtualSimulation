using UnityEngine;
using System.Collections;

public class LoadExamples : MonoBehaviour {

	public void LoadExample(string level){
#if UNITY_5_3
#else
#pragma warning disable 618
		Application.LoadLevel( level );
#pragma warning restore 618
#endif
	}
}
