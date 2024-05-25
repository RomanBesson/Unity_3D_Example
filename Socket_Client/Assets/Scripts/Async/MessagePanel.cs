using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : MonoBehaviour {

    private MKAsyncClient clientSocket = null;

    private GameObject Top;
    private Transform m_Transform;
    private InputField nameInput;
    private InputField messageInput;
    private Button loginButton;
    private Button exitButton;
    private Button sendButton;
    private Transform contentListTransform;
    private Transform friendListTransform;
    private GameObject contentItemPrefab;
    private GameObject friendItemPrefab;

    private string tempInfo = null;                     //用于聊天内容的临时中转.
    private Dictionary<string, Text> friendDic = null;  //管理好友数据.

	void Start () {
        InitUI();
        friendDic = new Dictionary<string, Text>();
        clientSocket = MKAsyncClient.Instance;
        clientSocket.LoginEvent += LoginMessage;
        clientSocket.MessageEvent += MessageReceive;
    }
	
    /// <summary>
    /// 初始化UI.
    /// </summary>
    private void InitUI()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        Top = m_Transform.Find("Top").gameObject;
        nameInput = m_Transform.Find("Top/NameInput").GetComponent<InputField>();
        loginButton = m_Transform.Find("Top/LoginButton").GetComponent<Button>();

        messageInput = m_Transform.Find("Bottom/MessageInput").GetComponent<InputField>();
        exitButton = m_Transform.Find("ExitButton").GetComponent<Button>();
        sendButton = m_Transform.Find("Bottom/SendButton").GetComponent<Button>();
        contentListTransform = m_Transform.Find("Center/ContentList/Grid").GetComponent<Transform>();
        friendListTransform = m_Transform.Find("Center/FriendList/Grid").GetComponent<Transform>();
        contentItemPrefab = Resources.Load<GameObject>("ContentItem");
        friendItemPrefab = Resources.Load<GameObject>("FriendItem");

        loginButton.onClick.AddListener(LoginButton);
        exitButton.onClick.AddListener(ExitButton);
        sendButton.onClick.AddListener(SendButton);
    }



    private void LoginButton()
    {
        if(nameInput.text.Trim() != "")
        {
            clientSocket.StartClient();
            Debug.Log("登录:" + nameInput.text);
        }
        else
        {
            Debug.Log("请输入账号.");
        }

    }

    private void ExitButton()
    {
        clientSocket.Send("Exit|" + nameInput.text);
        Debug.Log("退出:" + nameInput.text);
    }

    private void SendButton()
    {
        if (messageInput.text.Trim() != "")
        {
            clientSocket.Send("GroupMessage|" + messageInput.text);
            Debug.Log("发送:" + messageInput.text);
        }
        else
        {
            Debug.Log("消息内容不能为空.");
        }
    }

    /// <summary>
    /// 登录消息.
    /// </summary>
    private void LoginMessage()
    {
        clientSocket.Send("Login|" + nameInput.text);
        Debug.Log("已经发送登陆数据");
    }

    /// <summary>
    /// 消息处理.
    /// </summary>
    private void MessageReceive(string str)
    {
        Debug.Log("收到传回来的消息信息:"+str);
        //第二版消息处理.
        if (str.Contains("|"))
        {
            string[] info = str.Split('|');
            if (info[0] == "GroupMessage")
            {

                tempInfo = info[1];
                HandlerThread.Instance.AddDelegate(SetMessageUI);
            }
            else if (info[0] == "LoginOK")
            {
                tempInfo = info[1];
                HandlerThread.Instance.AddDelegate(SetLoginUI);
                HandlerThread.Instance.AddDelegate(SetFriendUI);
                Debug.Log(nameInput.text + ":登录成功.");
            }
            else if (info[0] == "GetOnLine" || info[0] == "NewOnLine")
            {
                Debug.Log("正在更新好友列表");
                tempInfo = info[1];
                HandlerThread.Instance.AddDelegate(SetOnLineUI);
                Debug.Log("更新成功");
            }
        }

    }

    /// <summary>
    /// 设置登录后的UI效果.
    /// </summary>
    private void SetLoginUI()
    {
        Top.SetActive(false);
    }

    /// <summary>
    /// 设置聊天列表UI.
    /// </summary>
    private void SetMessageUI()
    {
        GameObject item = GameObject.Instantiate<GameObject>(contentItemPrefab, contentListTransform);
        item.GetComponent<Transform>().Find("Text").GetComponent<Text>().text = tempInfo;
        tempInfo = null;
    }

    /// <summary>
    /// 设置好友列表UI.
    /// </summary>
    private void SetFriendUI()
    {
        string[] body = tempInfo.Split('*');
        for (int i = 0; i < body.Length; i++)
        {
            GameObject item = GameObject.Instantiate<GameObject>(friendItemPrefab, friendListTransform);
            Text text = item.GetComponent<Transform>().Find("Text").GetComponent<Text>();
            text.text = body[i];
            text.color = Color.gray;
            friendDic.Add(body[i], text);
        }
        tempInfo = null;

        //获取已上线好友数据.
        clientSocket.Send("GetOnLine");
    }

    /// <summary>
    /// 设置好友列表已上线数据.
    /// </summary>
    private void SetOnLineUI()
    {
        string[] body = tempInfo.Split('*');
        for (int i = 0; i < body.Length; i++)
        {
            Text tempText = null;
            if (friendDic.TryGetValue(body[i], out tempText))
            {
                tempText.color = Color.black;
            }
        }
        tempInfo = null;
    }
}
