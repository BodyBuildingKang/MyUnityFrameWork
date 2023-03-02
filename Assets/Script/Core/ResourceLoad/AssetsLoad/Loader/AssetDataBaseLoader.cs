using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class AssetDataBaseLoader : LoaderBase
{
    public AssetDataBaseLoader(AssetsLoadController loadAssetsController) : base(loadAssetsController)
    {
    }

    public override IEnumerator LoadAssetsIEnumerator(string path, Type resType, CallBack<AssetsData> callBack)
    {
        throw new NotImplementedException();
    }

    public override AssetsData LoadAssets(string path)
    {
        string s = PathUtils.RemoveExtension(path);
        AssetsData rds = null;
        Object ass = AssetDatabase.LoadAssetAtPath<Object>(s);
        if (ass != null)
        {
            rds = new AssetsData(path);
            rds.Assets = new[] { ass };
        }
        else
        {
            Debug.LogError("加载失败,Path:" + path);
        }
        return rds;
    }

    public override AssetsData LoadAssets<T>(string path)
    {
        string s = PathUtils.RemoveExtension(path);
        AssetsData rds = null;
        T ass = AssetDatabase.LoadAssetAtPath<T>(s);
        if (ass != null)
        {
            rds = new AssetsData(path);
            rds.Assets = new[] { ass };
        }
        else
        {
            Debug.LogError("加载失败,Path:" + path);
        }
        return rds;
    }
}