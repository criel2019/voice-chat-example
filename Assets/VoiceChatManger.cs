using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;
using System;
using UnityEngine.UI;
#if(UNITY_2018_3_OR_NEWER)
using UnityEngine.Android;
#endif
using Photon.Pun;

public class VoiceChatManger : MonoBehaviourPunCallbacks
{
    private readonly string appID = "2f7b4d8d3d824f018bb3ede7f3ad73f7"; //�ư�� ����Ʈ���� ���� App ID

    public static VoiceChatManger instance;
    private bool isMuted = true;

    IRtcEngine rtcEngine;
    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    void Start()
    {

#if (UNITY_2018_3_OR_NEWER)
        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {

        }
        else
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
        rtcEngine = IRtcEngine.GetEngine(appID);
        rtcEngine.OnJoinChannelSuccess += OnJoinChannelSuccess;
        rtcEngine.OnLeaveChannel += OnLeaveChannelSuccess;
        rtcEngine.OnError += OnError;
        rtcEngine.OnUserMutedAudio += (uint uid, bool muted) =>
        {
            string userMutedMessage = string.Format("onUserMuted callback uid {0} {1}", uid, muted);
            Debug.Log(userMutedMessage);
        };
    }

    public void MicVolumeManager(float vol)
    {
        int volume = (int)vol;
        Debug.Log(volume);
        if ((volume >= 0) && (volume <= 100))
        {
            //����ũ ���� ����
            rtcEngine.AdjustRecordingSignalVolume(volume) ;
            if (volume == 0)
            {
                rtcEngine.AdjustAudioMixingVolume(volume);
            }
        }
    }

    public void OtherUsersVolumeManager(float vol)
    {
        int volume = (int)vol;
        if ((volume >= 0) && (volume <= 100))
        {
            // �ٸ� ��� ��Ҹ� ����
            rtcEngine.AdjustPlaybackSignalVolume(volume);
            if (volume == 0) {
                rtcEngine.AdjustAudioMixingVolume(volume);
            }
        }
    }

    public void MuteBtnOnclick()
    {
        isMuted = !isMuted;
        rtcEngine.EnableLocalAudio(isMuted);
        Debug.Log("muted");
    }

    void OnError(int error, string msg)
    {
        Debug.LogError("Error: " + error +"/"+ msg);       
    }

    void OnLeaveChannelSuccess(RtcStats stats)
    {
        Debug.Log("Left channel with stats: " + stats);
    }

    void OnJoinChannelSuccess(string channelName, uint uid, int elapsed)
    {
        Debug.Log("Joined channel "+ channelName);
    }

    public override void OnJoinedRoom()
    {
        rtcEngine.JoinChannel(PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnLeftRoom()
    {
        rtcEngine.LeaveChannel();
    }
    void OnDestroy()
    {
        IRtcEngine.Destroy();
    }
    public void ApplicationQuit()
    {
       #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; //play��带 false��.
        #elif UNITY_WEBPLAYER
                Application.OpenURL("http://google.com"); //���������� ��ȯ
        #else
                Application.Quit(); //���ø����̼� ����
        #endif
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();//�涰���� ���� ��Ʈ��ũ ���
    }
}
