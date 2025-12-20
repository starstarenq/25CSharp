using Newtonsoft.Json;
using RunProject;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string folderpath = "C:\\Users\\Administrator\\Desktop\\25CSharp\\RunProject";
string filename = "Diamond.json";
string fullpath = Path.Combine(folderpath, filename);
Console.WriteLine(fullpath);
// 2. 파일 읽어오기
string text = File.ReadAllText(fullpath);
Console.WriteLine(text);
var diamonds =  JsonConvert.DeserializeObject<List<Diamond>>(text);
//foreach(var j in diamonds)
//{
//    Console.WriteLine(j);
//}
string p_shape = "@";
int p_x = 1;
int p_y = 5;
int score_x = 50;
int score_y = 2;
int currentScore = 0;
using (var renderer = new ConsoleRenderer(80, 50)) 
{
    int j0_x = 50;
    int j1_x = 50;
int j2_x = 50;
    while (true)
    {
        // 1. 플레이어의 입력
        
        // 2. 플레이어 이외의 오브젝트의 기능 구현
        diamonds[0].y=5;
        diamonds[1].y=6;
        diamonds[2].y=7;
        diamonds[0].Update();
        diamonds[1].Update();
        diamonds[2].Update();
        diamonds[0].GetScore(p_x, p_y, ref currentScore);
        diamonds[1].GetScore(p_x, p_y, ref currentScore);
        diamonds[2].GetScore(p_x, p_y, ref currentScore);
        renderer.Clear(); // 화면 지워라

        // 3. 그림 그리기
        renderer.Print(p_x, p_y, p_shape);
        renderer.Print(score_x, score_y, $"score : {currentScore}");
        diamonds[0].Draw(renderer);
        diamonds[1].Draw(renderer);
        diamonds[2].Draw(renderer);

      
        // 4. Fliping 해결 -> Screen Double Buffer 더블 버퍼
        renderer.Flipping();
        Thread.Sleep(33); // frame per second 60FPS = 1초에 0.016
    }
}
    