﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace BallApp {
    internal class SoccerBall : Obj {
        Random random = new Random();

        public static int Count { get; set; }

        public SoccerBall(double xp, double yp)
            : base(xp, yp, @"Picture\soccer_ball.png") {

            MoveX = random.Next(-25,25); //移動量設定
            MoveY = random.Next(-25, 25);

            Count++;
        }

        //移動メソッド（抽象メソッド）
        public override bool Move() {
            if (PosX > 750 || PosX < 0) {
                //移動量の符号を反転
                MoveX = -MoveX;
            }
            if (PosY > 500 || PosY < 0) {
                //移動量の符号を反転
                MoveY = -MoveY;
            }

            PosX += MoveX;
            PosY += MoveY;

            return true;
        }
    }
}
