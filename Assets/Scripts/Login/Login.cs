using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameSparks.Core;

using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

public class Login : MonoBehaviour
{

    private Button login_btn, createOne_btn, playAsGuest_btn, playAsGuestContinueBtn, playAsGuestCanvasBack_btn;
    private Text USERNAME, PASSWORD;
    public AudioSource audioSource;
    public AudioClip buttonSound;
    private GameObject passwordObject, passwordEye;
    private int passwordEye_spriteCheck;
    public Sprite[] passwordEye_sprites;
    private Button forgetPassword, forgetPasswordBack_btn, forgetPasswordContinue_btn;
    private Canvas forgetPassword_canvas, playAsGuest_canvas, defaultImages_canvas;
    private GameObject defaultPic01, defaultPic02, defaultPic03, defaultPic04, defaultPic05, defaultPic06, defaultPic07, defaultPic08, defaultPic09, defaultPic10,
    defaultPic11, defaultPic12;
    private GameObject guestImage_btn;
    public static Image guestImage;
    private Text guestName;
    public static string GuestName;
    private Text forgetPasswordUserName, forgetPasswordEmail;
    private Canvas resetPassword_canvas;
    private Text resetPasswordCanvas_token, resetPasswordCanvas_newPassword;
    private Button resetPasswordCanvasBack_btn, resetPasswordCanvasContinue_btn, defaultPicsCanvasBack_btn;

    private void Awake()
    {
        defaultPicsCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_CANVAS_DEFAULTPICS_BACK_BUTTON).GetComponent<Button>();
        resetPassword_canvas = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_RESET_PASSWORD).GetComponent<Canvas>();
        resetPasswordCanvas_token = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_RESET_PASSWORD_TOKEN).GetComponent<Text>();
        resetPasswordCanvas_newPassword = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_RESET_PASSWORD_NEW_PASSWORD).GetComponent<Text>();
        resetPasswordCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_RESET_PASSWORD_BACK_BUTTON).GetComponent<Button>();
        resetPasswordCanvasContinue_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_RESET_PASSWORD_CONTINUE_BUTTON).GetComponent<Button>();
        forgetPasswordUserName = GameObject.FindGameObjectWithTag(GameConstants.FORGET_PASSWORD_USER_NAME).GetComponent<Text>();
        forgetPasswordEmail = GameObject.FindGameObjectWithTag(GameConstants.FORGET_PASSWORD_NEW_PASSWORD).GetComponent<Text>();
        defaultPic01 = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_DEFAULT_PIC01);
        defaultPic02 = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_DEFAULT_PIC02);
        defaultPic03 = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_DEFAULT_PIC03);
        defaultPic04 = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_DEFAULT_PIC04);
        defaultPic05 = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_DEFAULT_PIC05);
        defaultPic06 = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_DEFAULT_PIC06);
        defaultPic07 = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_DEFAULT_PIC07);
        defaultPic08 = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_DEFAULT_PIC08);
        defaultPic09 = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_DEFAULT_PIC09);
        defaultPic10 = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_DEFAULT_PIC10);
        defaultPic11 = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_DEFAULT_PIC11);
        defaultPic12 = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_DEFAULT_PIC12);
        passwordEye = GameObject.FindGameObjectWithTag(GameConstants.PASSWORD_EYE);
        passwordObject = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_PASSWORD_OBJECT);
        guestImage = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_CANVAS_PLAY_AS_GUEST_GUEST_IMAGE).GetComponent<Image>();
        guestImage_btn = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_CANVAS_PLAY_AS_GUEST_GUEST_FRAME_IMAGE);
        playAsGuestCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_CANVAS_PLAY_AS_GUEST_BACK_BUTTON).GetComponent<Button>();
        defaultImages_canvas = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_CANVAS_DEFAULT_IMAGES).GetComponent<Canvas>();
        playAsGuestContinueBtn = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_CANVAS_PLAY_AS_GUEST_CONTINUE_BUTTON).GetComponent<Button>();
        guestName = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_GUEST_NAME_TEXT).GetComponent<Text>();
        playAsGuest_canvas = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_CANVAS_PLAY_AS_GUEST).GetComponent<Canvas>();
        forgetPasswordBack_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_FORGET_PASSWORD_BACK_BUTTON).GetComponent<Button>();
        forgetPasswordContinue_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_FORGET_PASSWORD_CONTINUE_BUTTON).GetComponent<Button>();
        forgetPassword_canvas = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_FORGET_PASSWORD).GetComponent<Canvas>();
        forgetPassword = GameObject.FindGameObjectWithTag(GameConstants.FORGET_PASSWORD).GetComponent<Button>();
        passwordObject = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_PASSWORD_OBJECT);
        passwordEye = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_PASSWORD_EYE);
        playAsGuest_btn = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_PLAY_AS_GUEST_BUTTON).GetComponent<Button>();
        login_btn = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_BUTTON).GetComponent<Button>();
        createOne_btn = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_CREATEONE_BUTTON).GetComponent<Button>();
        USERNAME = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_USERNAME).GetComponent<Text>();
        PASSWORD = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_PASSWORD).GetComponent<Text>();
    }

    private void Start()
    {
        defaultPic01.GetComponent<Button>().onClick.AddListener(DefaultPic01);
        defaultPic02.GetComponent<Button>().onClick.AddListener(DefaultPic02);
        defaultPic03.GetComponent<Button>().onClick.AddListener(DefaultPic03);
        defaultPic04.GetComponent<Button>().onClick.AddListener(DefaultPic04);
        defaultPic05.GetComponent<Button>().onClick.AddListener(DefaultPic05);
        defaultPic06.GetComponent<Button>().onClick.AddListener(DefaultPic06);
        defaultPic07.GetComponent<Button>().onClick.AddListener(DefaultPic07);
        defaultPic08.GetComponent<Button>().onClick.AddListener(DefaultPic08);
        defaultPic09.GetComponent<Button>().onClick.AddListener(DefaultPic09);
        defaultPic10.GetComponent<Button>().onClick.AddListener(DefaultPic10);
        defaultPic11.GetComponent<Button>().onClick.AddListener(DefaultPic11);
        defaultPic12.GetComponent<Button>().onClick.AddListener(DefaultPic12);


        defaultPicsCanvasBack_btn.onClick.AddListener(DefaultPicsBakcBtn);
        playAsGuestContinueBtn.onClick.AddListener(PlayAsGuestContinueBtn);
        login_btn.onClick.AddListener(LoginUser);
        createOne_btn.onClick.AddListener(CreateOneBtn);
        playAsGuest_btn.onClick.AddListener(PlayAsGuestBtn);
        passwordEye.GetComponent<Button>().onClick.AddListener(PasswordEye);
        forgetPassword.onClick.AddListener(ForgetPassword);
        forgetPasswordBack_btn.onClick.AddListener(ForgetPasswordBackBtn);
        forgetPasswordContinue_btn.onClick.AddListener(ForgetPasswordContinueBtn);

        resetPasswordCanvasBack_btn.onClick.AddListener(ResetPasswordCanvasBackBtn);
        resetPasswordCanvasContinue_btn.onClick.AddListener(ResetPasswordCanvasContinueBtn);

        guestImage_btn.GetComponent<Button>().onClick.AddListener(GuestImageBtn);
        playAsGuestCanvasBack_btn.onClick.AddListener(PlayAsGuestCanvasBackBtn);
        audioSource.clip = buttonSound;
        passwordEye_spriteCheck = 0;
        GuestName = "Guest";
    }

    private void Update()
    {
        OnBackPress();
    }


    private void DefaultPicsBakcBtn(){
    
        playAsGuest_canvas.enabled = true;
        defaultImages_canvas.enabled = false;
    }

    private void ResetPasswordCanvasBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        resetPassword_canvas.enabled = false;
    }


    private void ResetPasswordCanvasContinueBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        string token = resetPasswordCanvas_token.text;
        string newPassword = resetPasswordCanvas_newPassword.text;

        if (token == "")
        {
            ShowToast.MyShowToastMethod("Please Enter Token!");
            return;
        }
        if (newPassword == "")
        {
            ShowToast.MyShowToastMethod("Please Enter New Password!");
            return;
        }
        GSRequestData gSRequestData = new GSRequestData();
        gSRequestData.AddString("action", "resetPassword");
        gSRequestData.AddString("token", token);
        gSRequestData.AddString("password", newPassword);
        new GameSparks.Api.Requests.AuthenticationRequest().SetUserName("").SetPassword("").SetScriptData(gSRequestData).Send((response) =>
        {
            Register.userId = response.UserId;

            if (response.Errors.GetString("action") == "complete")
            {
                ShowToast.MyShowToastMethod("Password Changed Successfully");
                Debug.Log("Password Changed Successfully");
                forgetPassword_canvas.enabled = false;
                resetPassword_canvas.enabled = false;
                createOne_btn.enabled = true;
                login_btn.interactable = true;
                playAsGuest_btn.interactable = true;

            }
            else
            {
                ShowToast.MyShowToastMethod("Error Resetting Password!");
                Debug.Log(response.Errors.GetString("action"));
                forgetPassword_canvas.enabled = false;
                login_btn.interactable = true;
                createOne_btn.interactable = true;
                playAsGuest_btn.interactable = true;
            }
        });
    }

    private void PlayAsGuestContinueBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        if (guestName.text != "")
        {
            GuestName = guestName.text;
        }

        //change scene
        SceneManager.LoadScene(GameConstants.STARTMENU_SCENE);
        Register.RegisterScreen = false;
    }

    private void ForgetPassword()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        forgetPassword_canvas.enabled = true;
        login_btn.interactable = false;
        createOne_btn.interactable = false;
        playAsGuest_btn.interactable = false;
    }

    private void ForgetPasswordBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        forgetPassword_canvas.enabled = false;
        login_btn.interactable = true;
        createOne_btn.interactable = true;
        playAsGuest_btn.interactable = true;
    }

    private void ForgetPasswordContinueBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        
        string userName = forgetPasswordUserName.text;
        string email = forgetPasswordEmail.text;

        if (userName == "")
        {
            ShowToast.MyShowToastMethod("Please Enter User Name!");
            return;
        }
        if (email == "")
        {
            ShowToast.MyShowToastMethod("Please Enter Email Address!");
            return;
        }
        GSRequestData gSRequestData = new GSRequestData();
        gSRequestData.AddString("action", "passwordRecoveryRequest");
        gSRequestData.AddString("email", email);
        new GameSparks.Api.Requests.AuthenticationRequest().SetUserName(userName).SetPassword("").SetScriptData(gSRequestData).Send((response) =>
        {
            Register.userId = response.UserId;

            if (response.Errors.GetString("action") == "complete")
            {
                ShowToast.MyShowToastMethod("Request Sent! Check You Email");
                Debug.Log("Request Sent! Check You Email");
                forgetPassword.enabled = false;
                resetPassword_canvas.enabled = true;

            }
            else
            {
                ShowToast.MyShowToastMethod("Error Sending Requset!");
                Debug.Log("Error Sending Requset! " + response.Errors.GetString("action"));
            }
        });
  
    }

    private void PlayAsGuestCanvasBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        playAsGuest_canvas.enabled = false;
        StartMenu.playAsGuest = false;
        login_btn.interactable = true;
        playAsGuest_btn.interactable = true;
        login_btn.interactable = true;
    }

    private void PasswordEye()
    {
        if(passwordEye_spriteCheck == 0){
            passwordEye_spriteCheck = 1;
            passwordEye.GetComponent<Image>().sprite = passwordEye_sprites[1];
            passwordObject.GetComponent<InputField>().contentType = InputField.ContentType.Standard;
            passwordObject.GetComponent<InputField>().enabled = false;
            passwordObject.GetComponent<InputField>().enabled = true;
        }
        else if (passwordEye_spriteCheck == 1)
        {
            passwordEye_spriteCheck = 0;
            passwordEye.GetComponent<Image>().sprite = passwordEye_sprites[0];
            passwordObject.GetComponent<InputField>().contentType = InputField.ContentType.Password;
            passwordObject.GetComponent<InputField>().enabled = false;
            passwordObject.GetComponent<InputField>().enabled = true;
        }
    }

    private void PlayAsGuestBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        StartMenu.playAsGuest = true;
        playAsGuest_canvas.enabled = true;
        login_btn.interactable = false;
        playAsGuest_btn.interactable = false;
        createOne_btn.interactable = false;
    }


    private void CreateOneBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        //Change Scene
        SceneManager.LoadScene(GameConstants.REGISTER_SCENE);
    }
    private void LoginUser()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        StartMenu.playAsGuest = false;
        string _username = USERNAME.text;
        string _password = PASSWORD.text;

        if (_username == "")
        {
            ShowToast.MyShowToastMethod("Enter you Username!");
            return;
        }
        if (_password == "")
        {
            ShowToast.MyShowToastMethod("Enter you Password!");
            return;
        }

        login_btn.interactable = false;
        Debug.Log("Authorizing Player.....");
        new GameSparks.Api.Requests.AuthenticationRequest().SetUserName(_username).SetPassword(_password).Send((response) =>
        {
            Register.userId = response.UserId;
            if (!response.HasErrors)
            {
                Debug.Log("Player Authenticated...");
                Database.LoadPlayerDataFromGameSpark();

                //change scene
                SceneManager.LoadScene(GameConstants.STARTMENU_SCENE);
                ShowToast.MyShowToastMethod("Player Logged In!");
                login_btn.interactable = true;
            }
            else
            {
                Debug.Log("Error Authenticating Player...");
                ShowToast.MyShowToastMethod("Error in Authentication!");
                login_btn.interactable = true;
            }
        });
    }




    private void DefaultPic01()
    {
        guestImage.sprite = defaultPic01.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic02()
    {
        guestImage.sprite = defaultPic02.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic03()
    {
        guestImage.sprite = defaultPic03.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic04()
    {
        guestImage.sprite = defaultPic04.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic05()
    {
        guestImage.sprite = defaultPic05.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic06()
    {
        guestImage.sprite = defaultPic06.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic07()
    {
        guestImage.sprite = defaultPic07.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic08()
    {
        guestImage.sprite = defaultPic08.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic09()
    {
        guestImage.sprite = defaultPic09.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic10()
    {
        guestImage.sprite = defaultPic10.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic11()
    {
        guestImage.sprite = defaultPic11.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic12()
    {
        guestImage.sprite = defaultPic12.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }



    private void GuestImageBtn()
    {
        playAsGuest_canvas.enabled = false;
        defaultImages_canvas.enabled = true;
    }

    public void OnBackPress()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(GameConstants.REGISTER_SCENE);
        }
    }

}
