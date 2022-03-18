/*****************************************

    文件：UploadABPackage.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/15 12:15:36
    功能：上传AB包

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using LitJson;
using SimpleFileBrowser;
using UnityEngine;
using UnityEngine.UI;

public class UploadABPackage : MonoBehaviour
{

	public delegate void Complete(bool b,[CanBeNull] List<string> name,[CanBeNull] List<Byte[]> bytesList,[CanBeNull] List<string> fill);
	public delegate void AbPackageDownloadIsComplete(AssetBundle AB);
	
	private string url = "https://virtualsimulationapi.ccrui.cn/api/Users/AddAB";

	public RenderTexture renderTexture;
	public Camera screenshotTheCamera;

	public byte[] ABbyte;
	public string ABname;

	public AssetBundle AB;
	public GameObject ABgameobject;

	public InputField inputField;//输入用户组

	private void Awake()
	{
		EventCenter.AddListener(ENventType.UpdateAB,UpdateAB);
	}

	private void UpdateAB()
	{
		if (AB!=null &&ABgameobject != null )
		{
			Destroy(ABgameobject);
			//卸载AB包
			AB.Unload(true);
			Destroy(AB);
		}
	}

	private void OnDestroy()
	{
		EventCenter.RemoveListener(ENventType.UpdateAB,UpdateAB);
		if (AB!=null)
		{
			AB.Unload(true);
		}
	}

	/// <summary>
	/// 打开本地AB包
	/// </summary>
	public void Open()
	{
		FileBrowser.AddQuickLink( "Users", "C:\\Users", null );
		StartCoroutine(ShowLoadDialogCoroutine(new Complete((b, name, bytesList,fill) =>
		{
			if (b)
			{
				EventCenter.Broadcast(ENventType.UpdateAB);

				if (bytesList.Count > 1)
				{
					Debug.LogWarning("只可选定一个AB包文件");
					return;
				}

				StartCoroutine(InstantiateObject(fill[0], new AbPackageDownloadIsComplete(ab =>
				{
					try
					{
						ABgameobject= Instantiate(ab.LoadAsset<GameObject>(name[0]));
						AB = ab;
						ABbyte = bytesList[0];
						ABname = name[0];
						
					}
					catch (Exception e)
					{
						Debug.Log("请加载正确AB包，并保证AB包内预制体与包名相同");
						ABbyte = null;
						ABname = null;
						Console.WriteLine(e);
						throw;
					}
				})));
			}


		})));
	}
	
	/// <summary>
	/// 上传AB包
	/// </summary>
	public void Upload()
	{
		
		if (ABbyte != null && ABname != null && ABgameobject != null)
		{

			string group;
			
			//判断用户组是否为空
			if (String.IsNullOrEmpty(inputField.text))
			{
				group = "1";
			}
			else
			{
				group = inputField.text;
			}
			
			var webRequest=GameManager.Instance.GetComponent<WebRequest>();
			JsonData jsonData = new JsonData();
			jsonData["adminOpenId"] = GameManager.Instance.userData.openId;
			jsonData["adminPassword"] =  Md5.ToCalculateMd5(GameManager.Instance.userData.password);
			jsonData["name"] = ABname;
			jsonData["image"] = Screenshots.StartScreenshots(screenshotTheCamera);
			jsonData["ab"] = Convert.ToBase64String(ABbyte);
			jsonData["group"] = group;
				
				
			webRequest.Post(url,new WebRequest.HttpHelperPostGetCallbacks((code, request, rsponse) =>
			{
				Debug.Log(rsponse.text);
				EventCenter.Broadcast(ENventType.UpdateData);
			}),jsonData,GameManager.Instance.userData.token);
		}
		else
		{
			Debug.Log("未选择AB包");
		}

	}

	
	
	/// <summary>
	/// Web加载AB包
	/// </summary>
	/// <returns></returns>
	IEnumerator InstantiateObject(string _url,AbPackageDownloadIsComplete abPackageDownloadIsComplete)
	{
		
		Debug.Log($"正在加载模型：{_url}");
		string url = _url;        
		var request 
			= UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle(url, 0);
		yield return request.Send();
		AssetBundle bundle = UnityEngine.Networking.DownloadHandlerAssetBundle.GetContent(request);

		abPackageDownloadIsComplete(bundle);

	}
	

	IEnumerator ShowLoadDialogCoroutine(Complete complete)
	{
		// Show a load file dialog and wait for a response from user
		// Load file/folder: both, Allow multiple selection: true
		// Initial path: default (Documents), Initial filename: empty
		// Title: "Load File", Submit button text: "Load"
		yield return FileBrowser.WaitForLoadDialog( FileBrowser.PickMode.FilesAndFolders, true, null, null, "Load Files and Folders", "Load" );

		// Dialog is closed
		// Print whether the user has selected some files/folders or cancelled the operation (FileBrowser.Success)
		// Debug.Log( FileBrowser.Success );

		if( FileBrowser.Success )
		{
			List<Byte[]> bytesList = new List<byte[]>();
			List<string> namelist = new List<string>();
			List<string> Fill = new List<string>();

			// Print paths of the selected files (FileBrowser.Result) (null, if FileBrowser.Success is false)
			for (int i = 0; i < FileBrowser.Result.Length; i++)
			{
				// Debug.Log( FileBrowser.Result[i] );
				// Read the bytes of the first file via FileBrowserHelpers
				// Contrary to File.ReadAllBytes, this function works on Android 10+, as well
				byte[] bytes = FileBrowserHelpers.ReadBytesFromFile( FileBrowser.Result[i] );

				// Or, copy the first file to persistentDataPath
				string destinationPath = Path.Combine( Application.persistentDataPath, FileBrowserHelpers.GetFilename( FileBrowser.Result[0] ) );
				FileBrowserHelpers.CopyFile( FileBrowser.Result[0], destinationPath );
				bytesList.Add(bytes);
				// namelist.Add(FileBrowser.Result[i]);
				namelist.Add(System.IO.Path.GetFileName(FileBrowser.Result[i]));
				Fill.Add(FileBrowser.Result[i]);
			}
			complete(FileBrowser.Success,namelist,bytesList,Fill);

		}
		else
		{
			complete(FileBrowser.Success,null,null,null);
		}
		
	}
}
