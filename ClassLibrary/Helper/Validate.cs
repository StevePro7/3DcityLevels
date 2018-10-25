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

            // 01. SpeedNotHundred
            Byte speed = (Byte)(data.EnemySpeedNone + data.EnemySpeedWave + data.EnemySpeedFast);
            if (100 != speed)
            {
                return String.Format("{0} Total:{1} None:{2} Wave:{3} Fast:{4}", ErrorType.SpeedNotHundred, speed, data.EnemySpeedNone, data.EnemySpeedWave, data.EnemySpeedFast);
            }

            //02. WrongNumberBullets
            const Byte bulletFrames = 6;
            UInt16 bulletSpace = (UInt16)(bulletFrames * data.BulletFrame);
            UInt16 bulletTimer = (UInt16)(data.BulletMaxim * data.BulletShoot);
            if (bulletTimer > bulletSpace)
            {
                Byte recommend = (Byte)(bulletSpace / data.BulletShoot);
                return String.Format("{0} Space:{1} [{2}*{3}] Timer:{4} [MAX:{5} * Shoot:{6}] RECOMMEND:{7}",
                    ErrorType.WrongNumberBullets,
                    bulletSpace,
                    bulletFrames,
                    data.BulletFrame,
                    bulletTimer,
                    data.BulletMaxim,
                    data.BulletShoot,
                    recommend);
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
