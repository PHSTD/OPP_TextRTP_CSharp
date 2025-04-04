namespace TextRPG;

public static class Game
{
    // 게임에 필요한 정보들
    private static bool gameOver;

    private static Dictionary<string, Scene> sceneDic;
    private static Scene curScene;

    private static Player player;
    public static Player Player
    {
        get { return player;  }
    }
    
    // 1. 상황들
    // 2. 인벤토리
    // 3. 플레이어
    
    // 게임에 필요한 기능들
    // 1. 게임시작
    public static void Start()
    {
        // 게임에 있는 모든 씬들을 보관하고 빠르게 찾아줄 용도로 쓸 자료구조
        sceneDic = new Dictionary<string, Scene>();
        sceneDic.Add("Title", new TitleScene());
        sceneDic.Add("Town", new TownScene());
        sceneDic.Add("Shop", new ShopScene());

        // 처음시작할 씬을 선정
        curScene = sceneDic["Title"];

        player = new Player();
        player.Power = 10;
        player.speed = 8;
    }
    // 2. 게임종료
    public static void End()
    { // 게임 종료시에 필요한 작업들
    }
    // 3. 게임동작
    public static void Run()
    {
        // 게임 동작시에 필요한 작업들
        while (gameOver == false)
        {
            Console.Clear(); 
            curScene.Render();
            Console.WriteLine();
            curScene.Choice();
            curScene.Input();
            Console.WriteLine();
            curScene.Result();
            Console.WriteLine();
            curScene.Wait();
            curScene.Next();
            
        }
    }

    public static void ChangeScene(string sceneName)
    {
        curScene = sceneDic[sceneName];
    }

    public static void GameOver(string reason)
    {
        Console.Clear();
        Console.WriteLine("************************************");
        Console.WriteLine("           게임오버              ");
        Console.WriteLine("************************************");
        Console.WriteLine(reason);

        gameOver = true;
    }

    public static void PrintInfo()
    {
        Console.WriteLine("************************************");
        Console.WriteLine(" 플레이어");
        Console.WriteLine(" 힘: {0} 속도 :{1} ", player.Power, player.speed);
        Console.WriteLine("************************************");
    }
    
}