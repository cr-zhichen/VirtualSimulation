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
using SimpleFileBrowser;
using UnityEngine;

public class UploadABPackage : MonoBehaviour
{

	public delegate void Complete(bool b,[CanBeNull] List<string> name,[CanBeNull] List<Byte[]> bytesList);
	
	public void Upload()
	{
		FileBrowser.AddQuickLink( "Users", "C:\\Users", null );
		StartCoroutine( ShowLoadDialogCoroutine(new Complete((b,name, bytesList) =>
		{
			Debug.Log(b);
			foreach (var byets in bytesList)
			{
				Debug.Log(byets);
			}

			for (int i = 0; i < bytesList.Count; i++)
			{
				Debug.Log(bytesList[i]);
				Debug.Log(name[i]);
			}
		} )) );
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
				namelist.Add(FileBrowser.Result[i]);
			}
			complete(FileBrowser.Success,namelist,bytesList);

		}
		else
		{
			complete(FileBrowser.Success,null,null);
		}
		
	}
}
