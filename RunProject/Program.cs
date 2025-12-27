using Newtonsoft.Json;
using RunProject;

// See https://aka.ms/new-console-template for more information


string folderpath = "C:\\Users\\Administrator\\Desktop\\25CSharp\\RunProject";
string filename = "Diamond.json";
string fullpath = Path.Combine(folderpath, filename);


string folderpath2 = "C:\\Users\\Administrator\\Desktop\\25CSharp\\RunProject";
string filename2 = "Obstacle.json";
string fullpath2 = Path.Combine(folderpath2, filename2);





// 2. 파일 읽어오기
string text = File.ReadAllText(fullpath);
string text2 = File.ReadAllText(fullpath2);
//Console.WriteLine(text);
var diamonds = JsonConvert.DeserializeObject<List<Diamond>>(text);
var obstacles = JsonConvert.DeserializeObject<List<Obstacle>>(text2);
//foreach(var j in diamonds)
//{
//    Console.WriteLine(j);
//}
//string p_shape = "@";
//int p_x = 1;
//int p_y = 7;
Player player = new Player();
int score_x = 50;
int score_y = 2;
int currentScore = 0;

//1번 입력 게임 시작함
//그 이외면 종료함

int cusor = 5;

//게임 타이틀
Console.WriteLine("Press any key");
while (true)
{

    Console.CursorVisible=false;

    //플레이어 입력 화살표 위(-) 또는 아래(+)
    var key = Console.ReadKey(true).Key;
    if (key==ConsoleKey.DownArrow)
    {
        cusor++;
        if (cusor>=7)
        {
            cusor=5;
        }
    }
    else if (key==ConsoleKey.UpArrow)
    {
        cusor--;
        if (cusor<=4)
        {
            cusor=6;
        }
    }
    else if (key==ConsoleKey.Enter)
    {
        //cusor 값 5일때, 6 일때
        if (cusor==5)
        {
            currentScore=GamePlay(diamonds, obstacles, player, score_x, score_y, currentScore);
        }
        else if (cusor==6)
        {
            break;
        }


    }
    Console.Clear();
    Console.SetCursorPosition(0, 10);
    Console.WriteLine("  ____                  ____                              \r\n / ___|__ ___   _____  |  _ \\ _   _ _ __  _ __   ___ _ __ \r\n| |   / _` \\ \\ / / _ \\ | |_) | | | | '_ \\| '_ \\ / _ \\ '__|\r\n| |__| (_| |\\ V /  __/ |  _ <| |_| | | | | | | |  __/ |   \r\n \\____\\__,_| \\_/ \\___| |_| \\_\\\\__,_|_| |_|_| |_|\\___|_|   ");
    Console.SetCursorPosition(26, 5);
    Console.Write(" ");
    Console.SetCursorPosition(26, 6);
    Console.Write(" ");
    Console.SetCursorPosition(28, 5);
    Console.WriteLine("게임 시작");
    Console.SetCursorPosition(28, 6);
    Console.WriteLine("게임 종료");



    Console.SetCursorPosition(24, cusor);
    Console.WriteLine("▶");
    //  int input = int.Parse(Console.ReadLine());
    // if (input==1)
    //  {
    //      currentScore=GamePlay(diamonds, obstacles, player, score_x, score_y, currentScore);
    //  }
    //  else 
    // {
    //      break;
    //  }
}

//게임 플레이

static int GamePlay(List<Diamond>? diamonds, List<Obstacle>? obstacles, Player player, int score_x, int score_y, int currentScore)
{
    player.Start();
    foreach (var diamond in diamonds)
    {
        diamond.Start();
    }
    foreach (var obstacle in obstacles)
    {
        obstacle.Start();
    }
    currentScore = 0;
    using (var renderer = new ConsoleRenderer(80, 50))
    {
        int j0_x = 50;
        int j1_x = 50;
        int j2_x = 50;
        while (true)
        {
            // 1. 플레이어의 입력
            player.Update();
            // 2. 플레이어 이외의 오브젝트의 기능 구현
            diamonds[0].y=5;
            diamonds[1].y=6;
            diamonds[2].y=7;
            diamonds[0].Update();
            diamonds[1].Update();
            diamonds[2].Update();

            foreach (var obstacle in obstacles)
            {
                obstacle.Update();
            }

            diamonds[0].GetScore(player, ref currentScore);
            diamonds[1].GetScore(player, ref currentScore);
            diamonds[2].GetScore(player, ref currentScore);

            foreach (var obstacle in obstacles)
            {
                obstacle.LostScore(player, ref currentScore);
            }
            renderer.Clear(); // 화면 지워라

            // 3. 그림 그리기
            player.Draw(renderer);
            renderer.Print(score_x, score_y, $"score : {currentScore}");
            diamonds[0].Draw(renderer);
            diamonds[1].Draw(renderer);
            diamonds[2].Draw(renderer);
            foreach (var obstacle in obstacles)
            {
                obstacle.Draw(renderer);
            }

            // 4. Fliping 해결 -> Screen Double Buffer 더블 버퍼
            renderer.Flipping();
            if (currentScore<=-1000)
            {
                break;
            }
            Thread.Sleep(33); // frame per second 60FPS = 1초에 0.016
        }
    }

    return currentScore;
}
