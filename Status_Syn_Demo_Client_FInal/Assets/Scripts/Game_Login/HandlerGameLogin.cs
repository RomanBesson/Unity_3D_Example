using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketDLL;
using SocketDLL.Message;
using UnityEngine.SceneManagement;

public class HandlerGameLogin : MonoBehaviour {

    private MKAsyncClient clientSocket = null;
    private HandlerThread mainThread = null;

    private UserData tempUserData;

	void Start () {
        clientSocket = MKAsyncClient.Instance;
        mainThread = HandlerThread.Instance;

        clientSocket.MessageEvent += HandlerMessage;
	}

    /// <summary>
    /// 登录消息处理.
    /// </summary>
    private void HandlerMessage(SocketMessage message)
    {
        switch (message.Head)
        {
            case MessageHead.SC_Login:
                if(message.Body == null)
                {
                    Debug.Log("登录失败了...");
                    return;
                }
                UserData userData = (UserData)message.Body;
                tempUserData = userData;

                mainThread.AddDelegate(JumpScene);
                Debug.Log(userData.ToString());
                break;
        }
    }

    /// <summary>
    /// 场景跳转.
    /// </summary>
    private void JumpScene()
    {
        clientSocket.CurrentPlayerData = tempUserData;
        SceneManager.LoadScene("Game_City");
    }
}
