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

    //ȭ�� �տ� ȭ�� ����
    public void PanelShow()
    {
        panel.SetActive(true);
    }

    //��� ȭ�� �����
    public void PanelHide()
    {
        panel.SetActive(false);
    }

    //����ũ ������ ������ ������Ʈ���� ������
    public void MicVolumeManagerShow()
    {
        MicVolumeSlider.SetActive(true);
        toggle.SetActive(true);
        MicVolumeText.SetActive(true);
    }

    //����ũ ������ ������ ������Ʈ���� ����
    public void MicVolumeManagerHide()
    {
        MicVolumeSlider.SetActive(false);
        toggle.SetActive(false);
        MicVolumeText.SetActive(false);
    }

    //����� ������ ������ ������Ʈ���� ������
    public void UsersVolumeManagerShow()
    {
        UsersVolumeSlider.SetActive(true);
        UsersVolumeText.SetActive(true);
    }

    //����� ������ ������ ������Ʈ���� ����
    public void UsersVolumeManagerHide()
    {
        UsersVolumeSlider.SetActive(false);
        UsersVolumeText.SetActive(false);
    }

    //����ũ,����� ���� ������ ������Ʈ�� �����ְ� ���� ��ư�� ����, ������ ��ư�� ������
    public void EnterRoom()
    {
        MicVolumeManagerShow();
        UsersVolumeManagerShow();
        quit.SetActive(true);
        enter.SetActive(false);

    }
    //����ũ,����� ���� ������Ʈ�� �����, ���� ��ư�� �����ְ�, ������ ��ư�� ����
    public void QuitTheRoom()
    {
        MicVolumeManagerHide();
        UsersVolumeManagerHide();
        quit.SetActive(false);
        enter.SetActive(true);
        joinBtn.interactable = true;//���� ��ư Ȱ��ȭ
    }
}
