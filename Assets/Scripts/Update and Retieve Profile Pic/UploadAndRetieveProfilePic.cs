using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using GameSparks.Api.Requests;
using GameSparks.Api.Messages;

using Assets.SimpleAndroidNotifications;

public class UploadAndRetieveProfilePic : MonoBehaviour {


    public static string lastUploadId = "None";
    public  Texture2D downloadedImage;
    public Texture2D[] downloadImagePlayers;
    public static Texture2D imageToUplaod;
    public bool isOpponnetsImageDownloaded;
    public bool[] isOpponnetsImagesDownloaded;
    public string[] downloadImageURLS;
    public string downloadImageUrl;
    private int count;


    public void Start()
    {
        //We will be passing all our messages to a listener function
        DontDestroyOnLoad(this);
        UploadCompleteMessage.Listener += GetUploadMessage;
        isOpponnetsImageDownloaded = false;
        downloadImagePlayers = new Texture2D[3];
        downloadImageURLS = new string[3];
        isOpponnetsImagesDownloaded = new bool[3] { false, false, false };
        count = 0;


    }

    //This will get our upload url and on the response we will start our coroutine to take the screenshot
    public void UploadDisplayImage (byte[] bytes) {
        new GetUploadUrlRequest().Send((response) =>
        {
            //Start coroutine and pass in the upload url
            StartCoroutine(UploadImage(response.Url, bytes));  
        });
    }

    //Our coroutine takes a screenshot of the game
    public IEnumerator UploadImage(string uploadUrl, byte[] bytes)
    {
        yield return new WaitForEndOfFrame();
        var form = new WWWForm();
        form.AddField("somefield", "somedata");
        form.AddBinaryData("file", bytes, "displayImage.png", "image/png");

    //POST the displayImage to GameSparks
        WWW w = new WWW(uploadUrl, form);
        yield return w;

        if (w.error != null)
        {
            Debug.Log(w.error);
        }
        else
        {
            Debug.Log(w.text);
        }
    }

    //This will be our message listener, this will be triggered when we successfully upload a file
    public void GetUploadMessage(GSMessage message)
    {
        lastUploadId = message.BaseData.GetString("uploadId");
        Database.SetDsiplayImageUploadId(Register.userId, lastUploadId);

        MyNotification notification = new MyNotification();
        notification.MakeNotification("Picture Uploaded Successfully!");
    }

    //When we want to download our uploaded image
    public  void DownloadDisplayImage(string uploadId)
    {

        //Get the url associated with the uploadId
        new GetUploadedRequest().SetUploadId(uploadId).Send((response) =>
            {
                //pass the url to our coroutine that will accept the data

                StartCoroutine(DownloadImage(response.Url));
            });
    }


    public IEnumerator DownloadImage(string downloadUrl)
    {

   
        var www = new WWW(downloadUrl);

        yield return www;

        if (GameInitializer.NoOfPlayers == GameConstants.TWO_PLAYERS)
        {
            downloadImageUrl = downloadUrl;
            isOpponnetsImageDownloaded = true;
            downloadedImage = new Texture2D(100, 100, TextureFormat.Alpha8, false);
            www.LoadImageIntoTexture(downloadedImage);
        }
        else if(GameInitializer.NoOfPlayers == GameConstants.FOUR_PLAYERS){
            downloadImageURLS[count] = downloadUrl;
            isOpponnetsImagesDownloaded[count] = true;
            downloadImagePlayers[count] = new Texture2D(100, 100);
            www.LoadImageIntoTexture(downloadImagePlayers[count]);
            count++;
        }


    }

    public IEnumerator DownloadFBImage(string downloadUrl)
    {
        Debug.Log("FB URL: " + downloadUrl);
        Debug.Log("FB Image Downloding Started");
        Debug.Log(downloadUrl);
        var www = new WWW(downloadUrl);
        yield return www;
        downloadImageUrl = downloadUrl;
        downloadedImage = new Texture2D(100, 100, TextureFormat.Alpha8, false);
        www.LoadImageIntoTexture(downloadedImage);
        isOpponnetsImageDownloaded = true;
        Debug.Log("FB Image Downloded");
    }

}
