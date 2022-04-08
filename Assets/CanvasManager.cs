using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    public GameObject panel;
    public GameObject MicVolumeSlider;
    public GameObject toggle;
    public GameObject MicVolumeText;
    public GameObject enter;
    public GameObject quit;
    public GameObject UsersVolumeText;
    public GameObject UsersVolumeSlider;
    public Button joinBtn;

    //화면 앞에 화면 띄우기
    public void PanelShow()
    {
        panel.SetActive(true);
    }

    //띄운 화면 숨기기
    public void PanelHide()
    {
        panel.SetActive(false);
    }

    //마이크 볼륨과 관련한 컴포넌트들을 보여줌
    public void MicVolumeManagerShow()
    {
        MicVolumeSlider.SetActive(true);
        toggle.SetActive(true);
        MicVolumeText.SetActive(true);
    }

    //마이크 볼륨과 관련한 컴포넌트들을 숨김
    public void MicVolumeManagerHide()
    {
        MicVolumeSlider.SetActive(false);
        toggle.SetActive(false);
        MicVolumeText.SetActive(false);
    }

    //사용자 볼륨과 관련한 컴포넌트들을 보여줌
    public void UsersVolumeManagerShow()
    {
        UsersVolumeSlider.SetActive(true);
        UsersVolumeText.SetActive(true);
    }

    //사용자 볼륨과 관련한 컴포넌트들을 숨김
    public void UsersVolumeManagerHide()
    {
        UsersVolumeSlider.SetActive(false);
        UsersVolumeText.SetActive(false);
    }

    //마이크,사용자 볼륨 관련한 컴포넌트를 보여주고 입장 버튼은 숨김, 나가기 버튼은 보여줌
    public void EnterRoom()
    {
        MicVolumeManagerShow();
        UsersVolumeManagerShow();
        quit.SetActive(true);
        enter.SetActive(false);

    }
    //마이크,사용자 볼륨 컴포넌트를 숨기고, 입장 버튼은 보여주고, 나가기 버튼은 숨김
    public void QuitTheRoom()
    {
        MicVolumeManagerHide();
        UsersVolumeManagerHide();
        quit.SetActive(false);
        enter.SetActive(true);
        joinBtn.interactable = true;//입장 버튼 활성화
    }
}
