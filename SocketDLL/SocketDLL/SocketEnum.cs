
namespace SocketDLL
{
    /// <summary>
    /// Socket相关消息头.
    /// </summary>
    public enum MessageHead
    {
        /// <summary>
        /// 登录.
        /// </summary>
        Login,
        /// <summary>
        /// 登录成功.
        /// </summary>
        LoginOK,
        /// <summary>
        /// 退出.
        /// </summary>
        Exit,
        /// <summary>
        /// 群消息.
        /// </summary>
        GroupMessage,
        /// <summary>
        /// 上线好友.
        /// </summary>
        GetOnLine,
        /// <summary>
        /// 新上线好友.
        /// </summary>
        NewOnLine,
        /// <summary>
        /// 测试A.
        /// </summary>
        TestA,
        /// <summary>
        /// 测试B.
        /// </summary>
        TestB
    }
}
