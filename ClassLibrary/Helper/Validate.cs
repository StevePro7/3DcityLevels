using System;
using System.Collections.Generic;
using System.Text;
using WindowsGame.Common.Data;

namespace ClassLibrary.Helper
{
    public class Validate
    {
        public String ValidLevelConfigData(LevelConfigData data)
        {
            String error = String.Empty;

            Byte speed = (Byte)(data.EnemySpeedNone + data.EnemySpeedWave + data.EnemySpeedFast);
            if (100 != speed)
            {
                return String.Format("{0} Total:{1} None:{2} Wave:{3} Fast:{4}", ErrorType.SpeedNotHundred, speed, data.EnemySpeedNone, data.EnemySpeedWave, data.EnemySpeedFast);
            }


            return error;
        }
        //public ErrorType ValidLevelConfigData(LevelConfigData data)
        //{
        //    Byte speed = (Byte)(data.EnemySpeedNone + data.EnemySpeedWave + data.EnemySpeedFast);
        //    if (100 != speed)
        //    {
        //        return ErrorType.SpeedNotHundred;
        //    }

        //    return ErrorType.None;
        //}
    }
}
