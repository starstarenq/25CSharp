using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RunProject
{
    public class Player
    {

        string shape = "@";
        public int x = 1;
        public int y = 7;
        public bool isDamage;


        public void Start()
        {
            isDamage=false;
            y=7;
        }
        public void Update()
        {
            //땅의 좌표와 다르면(점프 하고있을때) 중력을 받으세요 
            //y의 좌표를 1씩 더하세요
            //지금 y좌표가 땅 위에 있? -> GroundCheck
            if (GroundCheck() == false)
            {
                y = y + 1;

            }



            // space 버튼 눌렀을때
            if (Console.KeyAvailable && GroundCheck())
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Spacebar)
                {
                    y = y-2;
                }
            }
            // jump 하겠다



        }
        public bool GroundCheck()
        {
            return y >= 7;
        }
        public void Draw(ConsoleRenderer renderer)
        {
            renderer.Print(x, y, shape);
        }

        public void Damage()
        {
            isDamage = true;
        }

    }
}
