<%@ WebHandler Language="C#" Class="UEditorHandler" %>

using System;
using System.Web;
using System.IO;
using System.Collections;
using Newtonsoft.Json;

public class UEditorHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        Handler action = null;
        switch (context.Request["action"])
        {
            case "config":
                action = new ConfigHandler(context);
                break;
            case "uploadimage":
                action = new UploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = BaseConfig.GetStringList("imageAllowFiles"),
                    PathFormat = BaseConfig.GetString("imagePathFormat"),
                    SizeLimit = BaseConfig.GetInt("imageMaxSize"),
                    UploadFieldName = BaseConfig.GetString("imageFieldName")
                });
                break;
            case "uploadscrawl":
                action = new UploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = new string[] { ".png" },
                    PathFormat = BaseConfig.GetString("scrawlPathFormat"),
                    SizeLimit = BaseConfig.GetInt("scrawlMaxSize"),
                    UploadFieldName = BaseConfig.GetString("scrawlFieldName"),
                    Base64 = true,
                    Base64Filename = "scrawl.png"
                });
                break;
            case "uploadvideo":
                action = new UploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = BaseConfig.GetStringList("videoAllowFiles"),
                    PathFormat = BaseConfig.GetString("videoPathFormat"),
                    SizeLimit = BaseConfig.GetInt("videoMaxSize"),
                    UploadFieldName = BaseConfig.GetString("videoFieldName")
                });
                break;
            case "uploadfile":
                action = new UploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = BaseConfig.GetStringList("fileAllowFiles"),
                    PathFormat = BaseConfig.GetString("filePathFormat"),
                    SizeLimit = BaseConfig.GetInt("fileMaxSize"),
                    UploadFieldName = BaseConfig.GetString("fileFieldName")
                });
                break;
            case "listimage":
                action = new ListFileManager(context, BaseConfig.GetString("imageManagerListPath"), BaseConfig.GetStringList("imageManagerAllowFiles"));
                break;
            case "listfile":
                action = new ListFileManager(context, BaseConfig.GetString("fileManagerListPath"), BaseConfig.GetStringList("fileManagerAllowFiles"));
                break;
            case "catchimage":
                action = new CrawlerHandler(context);
                break;
            default:
                action = new NotSupportedHandler(context);
                break;
        }
        action.Process();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}