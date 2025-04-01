namespace TextRPG;

public static class Game
{
    // 게임에 필요한 정보들
    private static bool gameOver;

    private static Dictionary<string, Scene> sceneDic;
    private static Scene curScene;
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

        // 처음시작할 씬을 선정
        curScene = sceneDic["Title"];
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
            curScene.Render();
            curScene.Choice();
            curScene.Input();
            curScene.Result();
            curScene.Wait();
            curScene.Next();
            
        }
    }
}