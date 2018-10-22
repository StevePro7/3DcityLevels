using System;
using System.Collections.Generic;
using System.Text;
using WindowsGame.Common.Data;

namespace ClassLibrary.Helper
{
    public class Validate
    {
        public ErrorType ValidLevelConfigData(LevelConfigData data)
        {
            Byte speed = (Byte)(data.EnemySpeedNone + data.EnemySpeedWave + data.EnemySpeedFast);
            if (100 != speed)
            {
                return ErrorType.SpeedNotHundred;
            }

            return ErrorType.None;
        }
    }
}
