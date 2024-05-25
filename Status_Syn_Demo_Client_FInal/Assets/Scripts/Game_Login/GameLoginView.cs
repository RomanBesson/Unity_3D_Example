using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketDLL;
using SocketDLL.Message;

public class GameLoginView : MonoBehaviour {

    private MKAsyncClient clientSocket = null;

    private Transform m_Transform;
    private InputField nameInput;
    private Button loginButton;

	void Start () {
        InitUI();
        clientSocket = MKAsyncClient.Instance;
	}

    /// <summary>
    /// 初始化UI.
    /// </summary>
    private void InitUI()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        nameInput = m_Transform.Find("NameInput").GetComponent<InputField>();
        loginButton = m_Transform.Find("LoginButton").GetComponent<Button>();

        loginButton.onClick.AddListener(LoginButton);

    }


    /// <summary>
    /// 登录按钮点击事件.
    /// </summary>
    private void LoginButton()
    {
        if (nameInput.text.Trim() != "")
        {
            LoginMessage(nameInput.text.Trim());
            Debug.Log("登录:" + nameInput.text);
        }
        else
        {
            Debug.Log("请输入账号.");
        }
    }

    /// <summary>
    /// 账号登录消息.
    /// </summary>
    private void LoginMessage(string userName)
    {
        //消息体封装.
        SocketMessage message = new SocketMessage();
        Login login = new Login();
        login.UserName = userName;
        login.LoginInfo = null;
        message.Head = MessageHead.CS_Login;
        message.Body = login;

        //序列化.
        byte[] bytes = SocketTools.Serialize(message);

        //发送.
        clientSocket.Send(bytes);
    }



}
