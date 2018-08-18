using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
                
public class StartMenu : MonoBehaviour {

    private Button play_btn, settings_btn, exit_btn;
    private Button settingsCanvasBack_btn, settingsCanvasEditProfile_btn, editProfileCanvasBack_btn, editProfileCanvasContinue_btn, profileBox_btn, statsCanvasBack_btn,
    editProfileCanvasUserImage_btn, exitCanvasYes_btn, exitCanvasNo_btn;
    private Canvas settings_canvas, main_canvas, editProfile_canvas, stats_canvas, exit_canvas;
    private Text editProfileCanvas_displayName;
    public  Image editProfileCanvas_userImage;
    public static Texture2D texture;
    public static string displayImage_string;
    private Image displayImage,countryImage, statsCanvas_displayImage, statsCanvas_countryImage;
    private Text DisplayName, CountryName, NoOfCoins, statsCanvas_displayName, statsCanvas_countryName, statsCanvas_NoOfCoins;
    private Text vsComputerWins, vsComputerLoses, vsMultiplayerWins, vsMultiplayerLoses;

    private void Awake()
    {

        play_btn = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_PLAY_BUTTON).GetComponent<Button>();
        settings_btn = GameObject.FindGameObjectWithTag(GameConstants.SETTINGS_BUTTON).GetComponent<Button>();
        settings_canvas = GameObject.FindGameObjectWithTag(GameConstants.SETTINGS_CANVAS).GetComponent<Canvas>();
        main_canvas = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_MAIN_CANVAS).GetComponent<Canvas>();
        settingsCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.SETTINGS_CANVAS_BACK_BUTTON).GetComponent<Button>();
        settingsCanvasEditProfile_btn = GameObject.FindGameObjectWithTag(GameConstants.SETTINGS_CANVAS_EDITPROFILE_BUTTON).GetComponent<Button>();
        editProfileCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.EDITPROFILE_CANVAS_BACK_BUTTON).GetComponent<Button>();
        editProfileCanvasContinue_btn= GameObject.FindGameObjectWithTag(GameConstants.EDITPROFILE_CANVAS_CONTINUE_BUTTON).GetComponent<Button>();
        editProfile_canvas = GameObject.FindGameObjectWithTag(GameConstants.EDITPROFILE_CANVAS).GetComponent<Canvas>();
        editProfileCanvas_displayName = GameObject.FindGameObjectWithTag(GameConstants.EDITPROFILE_CANVAS_DISPLAY_NAME).GetComponent<Text>();
        editProfileCanvasUserImage_btn = GameObject.FindGameObjectWithTag(GameConstants.EDITPROFILE_CANVAS_USERIMAGE_BUTTON).GetComponent<Button>();
        editProfileCanvas_userImage = GameObject.FindGameObjectWithTag(GameConstants.EDITPROFILE_CANVAS_USERIMAGE_BUTTON).GetComponent<Image>();
        displayImage = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_DISPLAY_IMAGE).GetComponent<Image>();
        DisplayName = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_DISPLAY_NAME).GetComponent<Text>();
        CountryName = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_COUNTRY_NAME).GetComponent<Text>();
        NoOfCoins = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_NO_OF_COINS).GetComponent<Text>();
        countryImage = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_COUNTRY_IMAGE).GetComponent<Image>();
        statsCanvas_displayName = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_STATS_CANVAS_DISPLAY_NAME).GetComponent<Text>();
        statsCanvas_countryName = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_STATS_CANVAS_COUNTRY_NAME).GetComponent<Text>();
        statsCanvas_NoOfCoins = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_STATS_CANVAS_NOOFCOINS).GetComponent<Text>();
        statsCanvas_countryImage = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_STATS_CANVAS_COUNTRY_IMAGE).GetComponent<Image>();
        profileBox_btn = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_PROFILEBOX_BUTTON).GetComponent<Button>();
        stats_canvas = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_STATS_CANVAS).GetComponent<Canvas>();
        statsCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_STATS_CANVAS_BACK_BUTTON).GetComponent<Button>();
        statsCanvas_displayImage = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_STATS_CANVAS_DISPLAY_IMAGE).GetComponent<Image>();
        vsComputerWins = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_VSCOMPUTER_WINS).GetComponent<Text>();
        vsComputerLoses = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_VSCOMPUTER_LOSES).GetComponent<Text>();
        vsMultiplayerWins = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_VSMULTIPLAYER_WINS).GetComponent<Text>();
        vsMultiplayerLoses = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_VSMULTIPLAYER_LOSES).GetComponent<Text>();
        exit_btn = GameObject.FindGameObjectWithTag(GameConstants.EXIT_BUTTON).GetComponent<Button>();
        exitCanvasYes_btn = GameObject.FindGameObjectWithTag(GameConstants.EXIT_CANVAS_YES_BUTTON).GetComponent<Button>();
        exitCanvasNo_btn = GameObject.FindGameObjectWithTag(GameConstants.EXIT_CANVAS_NO_BUTTON).GetComponent<Button>();
        exit_canvas = GameObject.FindGameObjectWithTag(GameConstants.EXIT_CANVAS).GetComponent<Canvas>();


        LoadPlayerData();
        Set_Wins_Loses();

        GameObject manager = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_MANAGER);
    }

    private void Start()
    {
        displayImage_string = "None";

        play_btn.onClick.AddListener(PlayBtn);
        settings_btn.onClick.AddListener(SettingsBtn);
        settingsCanvasBack_btn.onClick.AddListener(SettingsBackBtn);
        settingsCanvasEditProfile_btn.onClick.AddListener(SettingsEditProfileBtn);
        editProfileCanvasBack_btn.onClick.AddListener(EditProfileBakcBtn);
        editProfileCanvasContinue_btn.onClick.AddListener(EditProfileContinueBtn);
        editProfileCanvasUserImage_btn.onClick.AddListener(EditProfileUserImageBtn);
        profileBox_btn.onClick.AddListener(ProfileBoxBtn);
        statsCanvasBack_btn.onClick.AddListener(StatsBackBtn);
        exit_btn.onClick.AddListener(ExitBtn);
        exitCanvasNo_btn.onClick.AddListener(ExitNoBtn);
        exitCanvasYes_btn.onClick.AddListener(ExitYesBtn);



    }

    private void ExitBtn(){
        main_canvas.GetComponent<CanvasGroup>().interactable = false;
        exit_canvas.enabled = true;
    }

    private void ExitNoBtn(){
        main_canvas.GetComponent<CanvasGroup>().interactable = true;
        exit_canvas.enabled = false;
    }

    private void ExitYesBtn()
    {
        main_canvas.GetComponent<CanvasGroup>().interactable = true;
        exit_canvas.enabled = false;
        Application.Quit();
    }

    private void PlayBtn(){
        //change scene
        SceneManager.LoadScene(GameConstants.MAINMENU_SCENE);
    }

    private void SettingsBtn(){
        main_canvas.GetComponent<CanvasGroup>().interactable = false;
        settings_canvas.enabled = true;
    }

    private void SettingsBackBtn(){
        main_canvas.GetComponent<CanvasGroup>().interactable = true;
        settings_canvas.enabled = false;
    }

    private void SettingsEditProfileBtn(){
        editProfileCanvas_displayName.text = DisplayName.text;
        settings_canvas.enabled = false;
        editProfile_canvas.enabled = true;
    }

    private void EditProfileBakcBtn(){
        editProfile_canvas.enabled = false;
        settings_canvas.enabled = true;
    }
    private void EditProfileContinueBtn(){
        int noOfCoins;
        string path = Database.GetPlayerDisplayImagePath(Register.userId);
        int.TryParse(NoOfCoins.text, out noOfCoins);
        string displayName = editProfileCanvas_displayName.text;
        Database.setPlayerDataInGameSpark(displayName, CountryName.text, path);
        Database.setPlayerDisplayImageinGameSpark(displayImage_string);
        Database.setPlayerDataInLocalDatabase(displayName, CountryName.text, noOfCoins ,Register.userId);
        LoadPlayerData();

        editProfile_canvas.enabled = false;
        main_canvas.GetComponent<CanvasGroup>().interactable = true;


        Texture2D tex = new Texture2D(texture.width, texture.height);
        tex = duplicateTexture(texture);
        tex.Compress(false);

        Database.UploadDisplayImageInGameSpark(tex.EncodeToPNG());


    }


    private void EditProfileUserImageBtn(){
        OpenGallery(10000);

        if(texture != null){
            Rect rec = new Rect(0, 0, texture.width, texture.height);
            editProfileCanvas_userImage.sprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);
        }
        displayImage_string = Texture2DToBase64(texture);

    }


    private void ProfileBoxBtn(){
        main_canvas.GetComponent<CanvasGroup>().interactable = false;
        stats_canvas.enabled = true;
    }


    private void StatsBackBtn()
    {
        main_canvas.GetComponent<CanvasGroup>().interactable = true;
        stats_canvas.enabled = false;
    }


    private void OpenGallery(int maxSize){
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            
            if (path != null)
            {
                Database.SetPlayerDisplayImagePath(Register.userId, path);
                texture = new Texture2D(NativeGallery.LoadImageAtPath(path, maxSize).width, NativeGallery.LoadImageAtPath(path, maxSize).height);
                texture = NativeGallery.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    ShowToast.MyShowToastMethod("Couldn't load Picture!");
                    return;
                }
            }
        }, "Select a PNG image", "image/png", maxSize);
    }




    public static string Texture2DToBase64(Texture2D texture)
    {
        byte[] imageData = texture.EncodeToPNG();
        return Convert.ToBase64String(imageData);
    }

    public static Texture2D Base64ToTexture2D(string encodedData)
    {
        byte[] imageData = Convert.FromBase64String(encodedData);

        int width, height;
        GetImageSize(imageData, out width, out height);

        Texture2D tex = new Texture2D(width, height, TextureFormat.ARGB32, false, true);
        tex.hideFlags = HideFlags.HideAndDontSave;
        tex.filterMode = FilterMode.Point;
        tex.LoadImage(imageData);

        return tex;
    }

    public static void GetImageSize(byte[] imageData, out int width, out int height)
    {
        width = ReadInt(imageData, 3 + 15);
        height = ReadInt(imageData, 3 + 15 + 2 + 2);
    }


    private static int ReadInt(byte[] imageData, int offset)
    {
        return (imageData[offset] << 8) | imageData[offset + 1];
    }

    private void Set_Wins_Loses()
    {
        vsComputerWins.text = "" + Database.getVsComputerWins(Register.userId);
        vsComputerLoses.text = "" + Database.getVsComputerLoses(Register.userId);
        vsMultiplayerWins.text = "" + Database.getVsMultiplayerWins(Register.userId);
        vsMultiplayerLoses.text = "" + Database.getVsMultiplayerLoses(Register.userId);
    }


    private void LoadPlayerData(){
        editProfileCanvas_displayName.text = Database.GetPlayerDisplayName(Register.userId);

        DisplayName.text = Database.GetPlayerDisplayName(Register.userId);
        CountryName.text = Database.GetPlayerCountryName(Register.userId);
        NoOfCoins.text = (Database.GetPlayerCoins(Register.userId)).ToString();
        countryImage.sprite = Database.LoadCountryImage(CountryName.text);

        statsCanvas_displayName.text = Database.GetPlayerDisplayName(Register.userId);
        statsCanvas_countryName.text = Database.GetPlayerCountryName(Register.userId);
        statsCanvas_NoOfCoins.text = (Database.GetPlayerCoins(Register.userId)).ToString();
        statsCanvas_countryImage.sprite = Database.LoadCountryImage(CountryName.text);

        if (PlayerPrefs.HasKey(Register.userId + "displayImage"))
        {
            editProfileCanvas_userImage.sprite = Database.GetPlayerDisplayImage(texture);
            displayImage.sprite = Database.GetPlayerDisplayImage(texture);
            statsCanvas_displayImage.sprite = Database.GetPlayerDisplayImage(texture);
        }

    }



    Texture2D duplicateTexture(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }
}
