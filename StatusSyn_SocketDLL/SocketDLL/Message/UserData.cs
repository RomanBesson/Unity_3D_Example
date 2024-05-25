using System;

namespace SocketDLL.Message
{
    [Serializable]
    public class UserData
    {
        public int ID;
        public string UserName;
        public string FaceName;
        public int Level;
        public int HP;
        public PlayerModelInfo ModelInfo;
        public PlayerPositionInfo PositionInfo;

        public UserData(int id, string userName, string faceName, int level, int hp, PlayerModelInfo modelInfo, PlayerPositionInfo positionInfo)
        {
            this.ID = id;
            this.UserName = userName;
            this.FaceName = faceName;
            this.Level = level;
            this.HP = hp;
            this.ModelInfo = modelInfo;
            this.PositionInfo = positionInfo;
        }

        public override string ToString()
        {
            return string.Format("ID:{0}, UserName:{1}, FaceName:{2}, Level:{3}, HP:{4}", ID, UserName, FaceName, Level, HP);
        }

    }
}
