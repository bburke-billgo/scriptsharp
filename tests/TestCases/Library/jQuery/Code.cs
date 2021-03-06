using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using jQueryApi;

[assembly: ScriptAssembly("test")]

[Imported]
[IgnoreNamespace]
public class FooObject : jQueryObject {
    
    public FooObject Foo() {
        return this;
    }
}

public sealed class MyApp {

    static MyApp() {
        jQuery.Select("div").AddClass("foo");
        jQuery.Select("span").AddClass("bar").AddClass("baz");

        jQueryObject o = jQuery.Select(".special").Plugin<FooObject>().Foo();
        jQuery.Select(".special").Html("<span></span>").Plugin<FooObject>();
    }

    private static void AlertData(string url) {
        jQuery.Ajax(new jQueryAjaxOptions(
            "url", url,
            "type", "GET",
            "dataType", "html",
            "contentType", "application/json",
            "processData", false,
            "success", (AjaxRequestCallback)delegate(object result, string textData, jQueryXmlHttpRequest xhr) {
                string s = xhr.ResponseText;
                Script.Alert(s);
                Type.InvokeMethod(null, "xyz", s);
            },
            "error", (AjaxErrorCallback)delegate(jQueryXmlHttpRequest xhr, string textData, Exception e) {
                Debug.WriteLine(xhr.Status);
            }));
    }

    public static void PostData(string url, object data, AjaxRequestCallback succesCallback, AjaxErrorCallback errorCallback, string returnType, string requestType) {
        returnType = returnType ?? "text";
        requestType = requestType ?? "POST";

        jQuery.Ajax(new jQueryAjaxOptions(
            "cache", false,
            "data", data,
            "dataType", returnType,
            "error", (AjaxErrorCallback)delegate(jQueryXmlHttpRequest req, string textStatus, Exception error) {
                if (!Script.IsNullOrUndefined(errorCallback))
                    errorCallback(req, textStatus, error);
            },
            "success", (AjaxRequestCallback)delegate(object dataSuccess, string textStatus, jQueryXmlHttpRequest request) {
                if (Script.IsNullOrUndefined(succesCallback)) {
                    jQuery.Document.Append((string)dataSuccess);
                }
                else {
                    succesCallback(dataSuccess, textStatus, request);
                }
            },
            "type", requestType,
            "url", url));
    }
}
