using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowToast : MonoBehaviour {

    static string toastString;
    static AndroidJavaObject currentActivity;

    public static void MyShowToastMethod(string toastMessage)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            showToastOnUiThread(toastMessage);
        }
    }

    public static void showToastOnUiThread(string toastMessage)
    {
        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        toastString = toastMessage;

        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(showToast));
    }

    public static void showToast()
    {
        AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
        AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", toastString);
        AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
        toast.Call("show");
    }
}
