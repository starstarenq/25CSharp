using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunProject
{
    public record class Diamond
    {
        [JsonProperty("Speed")] public int Speed;

        [JsonProperty("Name")]public string Name;

        [JsonProperty("Score")] public int Score;
        int moveTick;//얼마 지나야 움직일 수 있?   Speed와 같아지면 움직여
                     //moveTick 1씩 더하다가 ++
        int x;
       public int y;
       
 
        // 오브젝트의 이동 로직
        public void Update()
        {
            moveTick++; // moveTick 1씩 증가시켜줘
            if (Speed <= moveTick)//Speed와 moveTick 같아지면 움직여라
            {
                x--;
                if (x<=0)
                {
                    x=50; 
                }
                moveTick=0; //한번돌면 0으로 초기화
            }




        }
        public void Draw(ConsoleRenderer renderer)
        {
            renderer.Print(x, y,Name);
        }
        public void GetScore(int px, int py, ref int currentscore)
        {
            if (x == px && y ==py)
            {
                currentscore += Score;
                x = 50;
            }
        }
    };





  



}
