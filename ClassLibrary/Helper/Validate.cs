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

            // 03. WrongEnemySpeedWave
            if (0 != data.EnemySpeedWave)
            {
                String wave = EnemySpeed(data, 1);
                if (!String.IsNullOrEmpty(wave))
                {
                    return wave;
                }
            }

            // 03. WrongEnemySpeedFast
            if (0 != data.EnemySpeedFast)
            {
                String fast = EnemySpeed(data, 2);
                if (!String.IsNullOrEmpty(fast))
                {
                    return fast;
                }
            }
            
            // 04. WrongGridDelay
            const UInt16 minGridDelay = 100;
            const UInt16 maxGridDelay = 500;
            if (data.GridDelay < minGridDelay || data.GridDelay > maxGridDelay)
            {
                return String.Format("{0} Choose between {1} and {2}", ErrorType.WrongGridDelay, minGridDelay, maxGridDelay);
            }

            // 05. WrongEnemySpawn
            const Int16 minEnemySpawn = 1;
            const Int16 maxEnemySpawn = 8;
            if (data.EnemySpawn < minEnemySpawn || data.EnemySpawn > maxEnemySpawn)
            {
                return String.Format("{0} Choose between {1} and {2}", ErrorType.WrongEnemySpawn, minEnemySpawn, maxEnemySpawn);
            }

            // 06. WrongEnemyTotal
            const Int16 minEnemyTotal = 1;
            const Int16 maxEnemyTotal = 255;
            if (data.EnemyTotal < minEnemyTotal || data.EnemyTotal > maxEnemyTotal)
            {
                return String.Format("{0} Choose between {1} and {2}", ErrorType.WrongEnemyTotal, minEnemyTotal, maxEnemyTotal);
            }

            // 04. WrongExplodeDelay
            const UInt16 minExplodeDelay = 75;
            const UInt16 maxExplodeDelay = 125;
            if (data.ExplodeDelay < minExplodeDelay || data.ExplodeDelay > maxExplodeDelay)
            {
                return String.Format("{0} Choose between {1} and {2}", ErrorType.WrongExplodeDelay, minExplodeDelay, maxExplodeDelay);
            }

            return error;
        }

        private String EnemySpeed(LevelConfigData data, Byte mult)
        {
            Int16 maxEnemyFrameRange = (Int16)(mult * data.EnemyFrameRange);
            if (data.EnemyFrameDelay - maxEnemyFrameRange < data.EnemyFrameMinim)
            {
                Int16 recommend = (Int16)(data.EnemyFrameDelay - maxEnemyFrameRange);
                return String.Format("{0} Delay:{1} MAX:{2} Minim:{3} RECOMMEND:{4}",
                    ErrorType.EnemySpeedWave,
                    data.EnemyFrameDelay,
                    maxEnemyFrameRange,
                    data.EnemyFrameMinim,
                    recommend);
            }

            return String.Empty;
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
