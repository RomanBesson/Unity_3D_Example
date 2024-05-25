using System;


namespace SocketDLL.Message
{
    /// <summary>
    /// 玩家角色模型信息.
    /// </summary>
    [Serializable]
    public class PlayerModelInfo
    {
        public string ModelName;
        public float R;
        public float G;
        public float B;

        public PlayerModelInfo(string modelName, float r, float g, float b)
        {
            this.ModelName = modelName;
            this.R = r;
            this.G = g;
            this.B = b;
        }

    }
}
